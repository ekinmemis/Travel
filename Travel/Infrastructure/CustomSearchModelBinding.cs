using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Infrastructure
{
    public class CustomSearchModelBinding : IModelBinder
    {
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

        public class DataTablesToObjectModelBinderProvider : IModelBinderProvider
        {
            public IModelBinder GetBinder(Type modelType)
            {
                if (HttpContext.Current.Request.RequestType == "POST" && modelType.Name.Contains("ListModel"))
                    return new CustomSearchModelBinding();

                return null;
            }
        }
    }
}
