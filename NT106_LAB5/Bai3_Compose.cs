using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Mail;
using System.Net;
namespace NT106_LAB5
{
    public partial class Bai3_Compose : Form
    {
        private string email;
        private string password;
        public Bai3_Compose(string _email, string _password)
        {
            InitializeComponent();
            this.email = _email;
            this.password = _password;
            textBox1.Text = this.email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient _smtpClient = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = this.email;
                string mailTo = textBox2.Text.ToString().Trim();
                string password = this.password;
                var basicCredential = new NetworkCredential(mailFrom, password);
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress(mailFrom);
                    _smtpClient.UseDefaultCredentials = false;
                    _smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = textBox4.Text.ToString().Trim();
                    //Set IsBodyHtml to true means you can send HTML email
                    message.IsBodyHtml = true;
                    message.Body = richTextBox1.Text.ToString();
                    message.To.Add(mailTo);

                    try
                    {
                        _smtpClient.Send(message);
                    }
                    catch (Exception _ex)
                    {
                        MessageBox.Show($"Error: {_ex}");
                    }
                }
            }
        }
    }
}
