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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Mail;
using System.Net;

namespace Lesson_WPF_20200205
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("gersen@mail.ru");
            msg.Body = tbxBody.Text;
            msg.Subject = tbxSubject.Text;
            msg.To.Add(new MailAddress(tbxTo.Text));

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            //smtp.EnableSsl = true;
            smtp.DeliveryMethod
                = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(
                "gersen.e.a@gmail.com",
                "");

            try
            {
                smtp.Send(msg);
                lblMessage.Content = "Письмо успешно отправлено";
                lblMessage.Foreground = new SolidColorBrush(Colors.Green);
            }
            catch(Exception ex)
            {
                lblMessage.Content = "Письмо не отправлено по причине" + ex.Message;
                lblMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
