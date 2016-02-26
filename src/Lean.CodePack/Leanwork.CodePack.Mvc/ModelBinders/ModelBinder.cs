using System;
using System.Web.Mvc;

namespace Leanwork.CodePack.Mvc
{
    public abstract class ModelBinder : IModelBinder
    {
        public abstract object ConvertTo(string value);

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult =
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            var modelState = new ModelState { Value = valueResult };

            object actualValue = null;

            try
            {
                actualValue = ConvertTo(valueResult.AttemptedValue);

                return ConvertTo(valueResult.AttemptedValue);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            if (!bindingContext.ModelState.ContainsKey(bindingContext.ModelName))
            {
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            }   

            return actualValue;            
        }        
    }
}