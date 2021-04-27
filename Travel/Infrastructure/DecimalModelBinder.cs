using System;
using System.Globalization;
using System.Web.Mvc;

namespace Travel.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="DecimalModelBinder" />.
    /// </summary>
    public class DecimalModelBinder : IModelBinder
    {
        /// <summary>
        /// The BindModel.
        /// </summary>
        /// <param name="controllerContext">The controllerContext<see cref="ControllerContext"/>.</param>
        /// <param name="bindingContext">The bindingContext<see cref="ModelBindingContext"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            ModelState modelState = new ModelState
            {
                Value = valueResult
            };

            object actualValue = null;

            try
            {
                //Check if this is a nullable decimal and a null or empty string has been passed
                var isNullableAndNull = (bindingContext.ModelMetadata.IsNullableValueType && string.IsNullOrEmpty(valueResult.AttemptedValue));

                //If not nullable and null then we should try and parse the decimal
                if (!isNullableAndNull)
                {
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
                }
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Error", "Received Model cannot be serialized");

                return null;
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}
