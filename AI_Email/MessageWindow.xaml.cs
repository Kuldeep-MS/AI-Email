using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        private Message _message;
        public MessageWindow(Message message)
        {
            InitializeComponent();
            txtSender.Text = "From: " + message.SenderEmail;
            txtTimeStamp.Text = "Sent: " + message.TimeStamp.ToString();
            txtSubject.Text = "Subject: " + message.Subject;
            txtBody.Text = message.Body;
            _message = message;
        }

        private void btnReply_Click(object sender, RoutedEventArgs e)
        {
            var replyWindow = new ReplyWindow(_message.SenderEmail, "Re: " + _message.Subject, _message.Body);
            replyWindow.Show();
        }
    }
}
