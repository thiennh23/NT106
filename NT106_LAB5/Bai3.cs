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
    public partial class Bai3 : Form
    {
        private bool isLoggedIn = false;
        private ImapClient client;
        private string email;
        private string password;
        public Bai3()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            email = textBox1.Text.Trim();
            password = textBox2.Text.Trim();

            try
            {
                client = new ImapClient();
                client.Connect("127.0.0.1", 143, false);
                client.Authenticate(email, password);
                isLoggedIn = true;
            }
            catch (Exception _ex)
            {
                isLoggedIn = false;
                button1.Enabled = true;
                MessageBox.Show($"Error {_ex}");
            }
            if (isLoggedIn == true)
            {
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
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
            
        }

        private void Bai3_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Email", 200);
            listView1.Columns.Add("From", 100);
            listView1.Columns.Add("Thời gian", 100);
            listView1.View = View.Details;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                textBox1.Clear();
                textBox2.Clear();
                label5.Text = "";
                label6.Text = "";
                listView1.Items.Clear();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                client.Disconnect(true);
                client = null;
                MessageBox.Show("LOG OUT");
            }
        }

        private void Bai3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Disconnect(true);
                client = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai3_Compose frmCompose = new Bai3_Compose(email,password);
            frmCompose.Show();
        }
    }
}
