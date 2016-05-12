using System.Collections.Generic;

namespace Leanwork.CodePack.Mail
{
    public class MailDTO
    {
        public string SenderName { get; set; }

        public string SenderEmail { get; set; }                

        public string Subject { get; set; }                

        public IList<string> Receivers
        {
            get { return _receivers ?? (_receivers = new List<string>()); }
            set { _receivers = value; }
        }
        IList<string> _receivers;        
    }    
}
