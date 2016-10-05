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
        public object BindModel(ControllerContext controllerContext,
        ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null || valueResult.AttemptedValue == null)
                return null;
            else if (valueResult.AttemptedValue == string.Empty)
                return string.Empty;
            return valueResult.AttemptedValue.Trim();
        }
    }
}
