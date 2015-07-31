using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Leanwork.CodePack.Mvc
{
    public class XmlResult : ActionResult
    {
        public string ContentType 
        { 
            get; 
            set; 
        }
        
        public Encoding ContentEncoding 
        { 
            get; 
            set; 
        }

        public object Data
        {
            get;
            set;
        }

        public XmlResult() { }
        public XmlResult(object data) { this.Data = data; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            { 
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            { 
                response.ContentType = "text/xml";
            }

            if (this.ContentEncoding != null)
            { 
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                if (this.Data is XmlNode)
                {
                    response.Write(((XmlNode)this.Data).OuterXml);
                }
                else if (this.Data is XNode)
                {
                    response.Write(((XNode)this.Data).ToString());
                }
                else
                {
                    var dataType = this.Data.GetType();
                    var xSer = new XmlSerializer(dataType);
                    xSer.Serialize(response.OutputStream, this.Data);
                }
            }
        }
    }
}
