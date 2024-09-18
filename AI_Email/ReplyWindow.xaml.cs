using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AI_Email
{
    /// <summary>
    /// Interaction logic for ReplyWindow.xaml
    /// </summary>
    public partial class ReplyWindow : Window
    {
        private string _originalEmail;

        public ReplyWindow(string toEmail, string subject, string previousEmail)
        {
            InitializeComponent();
            txtReplyTo.Text = toEmail;
            txtReplySubject.Text = subject;
            txtReplyBody.Text = "\n\n----------------------------------------\n" + previousEmail;
        }

        private void btnSendReply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fromAddress = new MailAddress("your-email@example.com", "Your Name");
                var toAddress = new MailAddress(txtReplyTo.Text);
                const string fromPassword = "your-email-password";
                string subject = txtReplySubject.Text;
                string body = txtReplyBody.Text;

                var smtp = new SmtpClient
                {
                    Host = "smtp.example.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("Reply sent successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending reply: {ex.Message}");
            }
        }
    }
}
