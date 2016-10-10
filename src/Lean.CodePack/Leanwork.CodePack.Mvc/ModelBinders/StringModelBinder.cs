using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Leanwork.CodePack.Mvc
{
    public class StringModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var shouldPerformRequestValidation =
                controllerContext.Controller.ValidateRequest
                && bindingContext.ModelMetadata.RequestValidationEnabled;

            var valueResult = GetValueFromValueProvider(bindingContext, shouldPerformRequestValidation);
            if (valueResult == null || valueResult.AttemptedValue == null)
            {
                return null;
            }
            else if (valueResult.AttemptedValue == string.Empty)
            {
                return string.Empty;
            }

            return valueResult.AttemptedValue.Trim();
        }

        private ValueProviderResult GetValueFromValueProvider(ModelBindingContext bindingContext, bool performRequestValidation)
        {
            var unvalidatedValueProvider = bindingContext.ValueProvider as IUnvalidatedValueProvider;
            return (unvalidatedValueProvider != null)
                       ? unvalidatedValueProvider.GetValue(bindingContext.ModelName, !performRequestValidation)
                       : bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        }
    }
}
