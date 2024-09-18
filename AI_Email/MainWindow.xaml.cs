using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AI_Email
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Dummy data for received emails
            var emails = new List<Message>
            {
                new Message { SenderEmail = "sender1@example.com", Subject = "Hello", Body = "Hello, how are you?", TimeStamp = DateTime.Now },
                new Message { SenderEmail = "sender2@example.com", Subject = "Meeting", Body = "Let's schedule a meeting.", TimeStamp = DateTime.Now },
                new Message { SenderEmail = "sender3@example.com", Subject = "Project Update", Body = "Here is the latest update on the project.", TimeStamp = DateTime.Now }
            };
            lstEmails.ItemsSource = emails;
        }

        private void lstEmails_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //if (lstEmails.SelectedItem != null)
            //{
            //    var replyWindow = new ReplyWindow(lstEmails.SelectedItem.ToString());
            //    replyWindow.Show();
            //}
        }

        private void lstEmails_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstEmails.SelectedItem != null)
            {
                var selectedMessage = (Message)lstEmails.SelectedItem;
                var messageWindow = new MessageWindow(selectedMessage);
                messageWindow.Show();
            }
        }

        private void Reply_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmails.SelectedItem != null)
            {
                var selectedMessage = (Message) lstEmails.SelectedItem;
                var replyWindow = new ReplyWindow(selectedMessage.SenderEmail, "Re: " + selectedMessage.Subject, selectedMessage.Body);
                replyWindow.Show();
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Forward action clicked for: " + lstEmails.SelectedItem);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete action clicked for: " + lstEmails.SelectedItem);
        }

    }
}