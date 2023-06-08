using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;

namespace NT106_LAB5
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();


            using (var client = new ImapClient())
            {
                client.Connect("127.0.0.1", 143, false);

                client.Authenticate(email, password);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                label5.Text = inbox.Count.ToString();   // Total mail count
                label6.Text = inbox.Recent.ToString();  // Recent mail count
                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    ListViewItem name = new ListViewItem(message.Subject);

                    ListViewItem.ListViewSubItem from = new ListViewItem.ListViewSubItem(name, message.From.ToString());
                    name.SubItems.Add(from);

                    ListViewItem.ListViewSubItem date = new ListViewItem.ListViewSubItem(name, message.Date.Date.ToString());
                    name.SubItems.Add(date);

                    listView1.Items.Add(name);
                }

                client.Disconnect(true);
            }

        }

        private void Bai2_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Email", 200);
            listView1.Columns.Add("From", 100);
            listView1.Columns.Add("Date time", 100);
            listView1.View = View.Details;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
