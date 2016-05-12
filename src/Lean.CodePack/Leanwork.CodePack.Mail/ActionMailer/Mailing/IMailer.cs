using ActionMailer.Net.Standalone;
using System;
using System.Threading.Tasks;

namespace Leanwork.CodePack.Mail
{
    public interface IMailer
    {
        void SendEmail(MailDTO model);
    }

    public class MailerSend : RazorMailerBase, IMailer
    {
        object _model;
        string _template;

        public override string ViewPath
        {
            get { return "Templates\\Mailing"; }
        }

        public MailerSend(string template, object model)
        {
            _template = template;
            _model = model;
        }

        public void SendEmail(MailDTO model)
        {
            Task.Factory.StartNew(() =>
            {
                Subject = model.Subject;

                this.SetEmailValues(model);                

                RazorEmailResult result = Email(_template, _model);

                if (null == result)
                {
                    return;
                }

                result.DeliverAsync();
            });            
        }

        private void SetEmailValues(MailDTO mail)
        {
            if (null == mail)
            {
                return;
            }

            //email from
            From = String.Format("{0} <{1}>", mail.SenderName, mail.SenderEmail);

            // email to
            foreach (var receiver in mail.Receivers)
            {
                To.Add(receiver);
            }
        }        
    }
}
