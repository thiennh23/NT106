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
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient _smtpClient = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = textBox1.Text.ToString().Trim();
                string mailTo = textBox2.Text.ToString().Trim();
                string password = textBox3.Text.ToString().Trim();
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
                        MessageBox.Show("SENT");
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
