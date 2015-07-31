using System;
using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;

namespace Leanwork.CodePack.Mvc
{
    public enum SubmitRequirement
    {
        Equal,
        StartsWith
    }

    public class SubmitAttribute : ActionMethodSelectorAttribute
    {
        private readonly string _submitButtonName;
        private readonly SubmitRequirement _requirement;

        public SubmitAttribute(string submitButtonName) :
            this(SubmitRequirement.Equal, submitButtonName)
        {
        }

        public SubmitAttribute(SubmitRequirement requirement, string _submitButtonName)
        {
            this._submitButtonName = _submitButtonName;
            this._requirement = requirement;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            string buttonName = _submitButtonName;

            try
            {
                string value = null;
                switch (this._requirement)
                {
                    case SubmitRequirement.Equal:
                        {
                            value = controllerContext.HttpContext.Request.Form[buttonName];
                        }
                        break;
                    case SubmitRequirement.StartsWith:
                        {
                            foreach (var formValue in controllerContext.HttpContext.Request.Form.AllKeys)
                            {
                                if (formValue.StartsWith(buttonName, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    value = controllerContext.HttpContext.Request.Form[formValue];
                                    break;
                                }
                            }
                        }
                        break;
                }
                if (!String.IsNullOrEmpty(value))
                    return true;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            return false;
        }
    }
}