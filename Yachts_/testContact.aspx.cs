using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using MimeKit;
using System.Net;
using System.Text;
using System.Configuration;

namespace Yachts_
{
    public partial class testContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

  

        public static void SendGmailMail(string fromAddress, string toAddress, string Subject, string MailBody, string password)
        {

            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = MailBody;
            // SMTP Server
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(fromAddress, password);
            mailSender.Credentials = basicAuthenticationInfo;
            mailSender.Port = 587;
            mailSender.EnableSsl = true;
            mailSender.Send(mailMessage);
            mailMessage.Dispose();
            //try
            //{

            //    mailSender.Send(mailMessage);
            //    mailMessage.Dispose();
            //}
            //catch
            //{
            //    return;
            //}
            mailSender = null;
        }





        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            string account = "foryachts@gmail.com";
            string password = "yabuhpxgwtwqudrl";

            //建立 html 郵件格式
            string body =
                "<h1>Thank you for contacting us!</h1>" +
                $"<h3>Name : {Name.Text.Trim()}</h3>" +
                $"<h3>Email : {Email.Text.Trim()}</h3>" +
                $"<h3>Phone : {Phone.Text.Trim()}</h3>" +
                $"<h3>Country : {Country.SelectedItem.Text}</h3>" +
                $"<h3>Type : {Type.SelectedItem.Text}</h3>" +
                $"<h3>Comments : </h3>" +
                $"<p>{Comments.Text.Trim()}</p>";

          


            SendGmailMail(account, "foryachts@gmail.com", "TayanaYacht Auto Email", body, password);

            //SmtpClient client = new SmtpClient();
            //client.Host = "smtp.gmail.com";
            //client.Port = 465;
            //client.Credentials = new NetworkCredential(Account, Password);
            //client.EnableSsl = true;

            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress(Account);
            //mail.To.Add("foryachts@gmail.com.com");
            //mail.Subject = "測試信";
            //mail.SubjectEncoding = Encoding.UTF8;
            //mail.IsBodyHtml = true;
            //mail.Body = "第一行<br> 第二行<br>第三行<br>";
            //mail.BodyEncoding = Encoding.UTF8;

            //////Attachment attachment = new Attachment(@"C:\fakepath\test.txt");
            //////mail.Attachments.Add(attachment);

            //try
            //{
            //    client.Send(mail);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    //attachment.Dispose();
            //    mail.Dispose();
            //    client.Dispose();
            //}

            Response.Write("<Script language='JavaScript'>alert('謝謝您的來信！');window.location.href='testContact.aspx';</Script>");
            Response.End();


        }


    }
}