using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leanwork.CodePack.Mvc
{
    public class Column
    {
        public string PropertyName { get; set; }
        public string HeaderName { get; set; }
        public TableItemStyle HeaderStyle { get; set; }
        public TableItemStyle ContentStyle { get; set; }

        public Column(string propertyName, string headerName, TableItemStyle headerStyle = null, TableItemStyle contentStyle = null)
        {
            PropertyName = propertyName;
            HeaderName = headerName;
            HeaderStyle = headerStyle;
            ContentStyle = contentStyle;
        }
    }

    public class ExcelResult<T> : ActionResult
    {
        private string _fileName;
        private IEnumerable<T> _rows;
        private IEnumerable<Column> _headers;

        private TableStyle _tableStyle;
        private TableItemStyle _headerStyle;

        public ExcelResult(IEnumerable<Column> headers, IEnumerable<T> rows, string fileName)
        {
            _rows = rows;
            _fileName = fileName;
            _headers = headers;

            // provide defaults
            if (_tableStyle == null)
            {
                _tableStyle = new TableStyle();
                _tableStyle.BorderStyle = BorderStyle.Solid;
                _tableStyle.BorderColor = Color.Black;
                _tableStyle.BorderWidth = Unit.Parse("2px");
            }

            _headerStyle = new TableItemStyle();
            _headerStyle.BackColor = Color.Black;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // Create HtmlTextWriter
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            // Build HTML Table from Items
            if (_tableStyle != null)
                _tableStyle.AddAttributesToRender(tw);
            tw.RenderBeginTag(HtmlTextWriterTag.Table);

            // Create Header Row
            tw.RenderBeginTag(HtmlTextWriterTag.Thead);
            foreach (Column header in _headers)
            {
                if (header.HeaderStyle != null)
                    header.HeaderStyle.AddAttributesToRender(tw);
                tw.RenderBeginTag(HtmlTextWriterTag.Th);
                tw.Write(HttpUtility.HtmlEncode(header.HeaderName));
                //tw.Write(header.Value);
                tw.RenderEndTag();
            }
            tw.RenderEndTag();

            // Create Data Rows
            tw.RenderBeginTag(HtmlTextWriterTag.Tbody);
            foreach (T row in _rows)
            {
                tw.RenderBeginTag(HtmlTextWriterTag.Tr);
                foreach (Column header in _headers)
                {
                    string strValue = String.Empty;

                    var property = row.GetType().GetProperty(header.PropertyName);
                    if (property != null)
                    {
                        var value = property.GetValue(row, null);
                        if (value != null)
                        {
                            strValue = value.ToString();
                            strValue = ReplaceSpecialCharacters(strValue);
                        }
                    }

                    if (header.ContentStyle != null)
                        header.ContentStyle.AddAttributesToRender(tw);
                    tw.RenderBeginTag(HtmlTextWriterTag.Td);
                    tw.Write(HttpUtility.HtmlEncode(strValue));
                    //tw.Write(strValue);
                    tw.RenderEndTag();
                }
                tw.RenderEndTag();
            }
            tw.RenderEndTag(); // tbody

            tw.RenderEndTag(); // table
            WriteFile(_fileName, "application/ms-excel", sw.ToString());
        }

        private static string ReplaceSpecialCharacters(string value)
        {
            value = value.Replace("’", "'");
            value = value.Replace("“", "\"");
            value = value.Replace("”", "\"");
            value = value.Replace("–", "-");
            value = value.Replace("…", "...");
            return value;
        }

        private static void WriteFile(string fileName, string contentType, string content)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            context.Response.Charset = "";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = contentType;
            context.Response.Write(content);
            context.Response.End();
        }
    }

    public static class Styles
    {
        private static TableItemStyle _styleDefault;
        public static TableItemStyle StyleDefault
        {
            get
            {
                if (_styleDefault == null)
                {
                    _styleDefault = new TableItemStyle();
                    _styleDefault.Width = new Unit(300, UnitType.Point);
                    _styleDefault.BorderColor = Color.White;
                    _styleDefault.VerticalAlign = VerticalAlign.Top;
                    _styleDefault.HorizontalAlign = HorizontalAlign.Left;
                    _styleDefault.Font.Name = "Calibri";
                    _styleDefault.Font.Size = new FontUnit(12, UnitType.Point);
                    _styleDefault.Wrap = true;
                    _styleDefault.BorderWidth = new Unit(0.5, UnitType.Point);
                }

                return _styleDefault;
            }
        }

        private static TableItemStyle _headerBlue;
        public static TableItemStyle HeaderBlue
        {
            get
            {
                if (_headerBlue == null)
                {
                    _headerBlue = new TableItemStyle();
                    _headerBlue.CopyFrom(StyleDefault);
                    _headerBlue.BackColor = Color.FromArgb(31, 78, 120);
                    _headerBlue.ForeColor = Color.White;
                    _headerBlue.Font.Bold = true;
                }
                return _headerBlue;
            }
        }

        private static TableItemStyle _headerGreen;
        public static TableItemStyle HeaderGreen
        {
            get
            {
                if (_headerGreen == null)
                {
                    _headerGreen = new TableItemStyle();
                    _headerGreen.CopyFrom(StyleDefault);
                    _headerGreen.BackColor = Color.FromArgb(155, 187, 89);
                    _headerGreen.ForeColor = Color.White;
                    _headerGreen.Font.Bold = true;
                }
                return _headerGreen;
            }
        }

        private static TableItemStyle _headerRed;
        public static TableItemStyle HeaderRed
        {
            get
            {
                if (_headerRed == null)
                {
                    _headerRed = new TableItemStyle();
                    _headerRed.CopyFrom(StyleDefault);
                    _headerRed.Width = new Unit(150, UnitType.Point);
                    _headerRed.BackColor = Color.FromArgb(192, 0, 0);
                    _headerRed.ForeColor = Color.White;
                    _headerRed.Font.Bold = true;
                }
                return _headerRed;
            }
        }

        private static TableItemStyle _contentGreen;
        public static TableItemStyle ContentGreen
        {
            get
            {
                if (_contentGreen == null)
                {
                    _contentGreen = new TableItemStyle();
                    _contentGreen.CopyFrom(StyleDefault);
                    _contentGreen.Font.Size = new FontUnit(11, UnitType.Point);
                    _contentGreen.BackColor = Color.FromArgb(216, 228, 188);
                }
                return _contentGreen;
            }
        }

        private static TableItemStyle _contentRed;
        public static TableItemStyle ContentRed
        {
            get
            {
                if (_contentRed == null)
                {
                    _contentRed = new TableItemStyle();
                    _contentRed.CopyFrom(StyleDefault);
                    _contentRed.Width = new Unit(150, UnitType.Point);
                    _contentRed.HorizontalAlign = HorizontalAlign.Right;
                    _contentRed.Font.Size = new FontUnit(11, UnitType.Point);
                    _contentRed.BackColor = Color.FromArgb(230, 184, 183);
                }
                return _contentRed;
            }
        }
    }
}
