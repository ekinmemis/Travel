using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="CustomSearchModelBinding" />.
    /// </summary>
    public class CustomSearchModelBinding : IModelBinder
    {
        /// <summary>
        /// The BindModel.
        /// </summary>
        /// <param name="controllerContext">The controllerContext<see cref="ControllerContext"/>.</param>
        /// <param name="bindingContext">The bindingContext<see cref="ModelBindingContext"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                Type listModelType = Type.GetType(bindingContext.ModelType.FullName);

                var model = Activator.CreateInstance(listModelType);

                var searchValue = HttpContext.Current.Request.Form.GetValues("search[value]");

                var draw = HttpContext.Current.Request.Form.GetValues("draw").FirstOrDefault();
                var start = HttpContext.Current.Request.Form.GetValues("start").FirstOrDefault();
                var length = HttpContext.Current.Request.Form.GetValues("length").FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int pageIndex = start != null ? Convert.ToInt32(start) : 0;

                model.GetType().GetProperty("Draw").SetValue(model, draw);
                model.GetType().GetProperty("PageSize").SetValue(model, pageSize);
                model.GetType().GetProperty("PageIndex").SetValue(model, pageIndex);

                if (!string.IsNullOrEmpty(searchValue[0]))
                {
                    foreach (var searchItem in searchValue)
                    {
                        var searchValueItem = searchItem.Split(':');
                        model.GetType().GetProperty(searchValueItem[0]).SetValue(model, searchValueItem[1]);
                    }
                }

                return model;
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Error", "Received Model cannot be serialized");

                return null;
            }
        }

        /// <summary>
        /// Defines the <see cref="DataTablesToObjectModelBinderProvider" />.
        /// </summary>
        public class DataTablesToObjectModelBinderProvider : IModelBinderProvider
        {
            /// <summary>
            /// The GetBinder.
            /// </summary>
            /// <param name="modelType">The modelType<see cref="Type"/>.</param>
            /// <returns>The <see cref="IModelBinder"/>.</returns>
            public IModelBinder GetBinder(Type modelType)
            {
                if (HttpContext.Current.Request.RequestType == "POST" && modelType.Name.Contains("ListModel"))
                    return new CustomSearchModelBinding();

                return null;
            }
        }
    }
}
