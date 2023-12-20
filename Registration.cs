using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToodedAB
{
    public partial class Registration : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToodeDB;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Registration()
        {
            InitializeComponent();
        }

        private void regitration_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label2.Visible = true;
            login_linkLabel.Visible = true;
            registration_button.Visible = true;
            label3.Visible = true;
            rollbox.Visible = true;

            label4.Visible = false;
            login_button.Visible = false;
            regitration_linkLabel.Visible = false;
            Text = "Registration";
        }

        private void login_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label4.Visible = true;
            login_button.Visible = true;
            regitration_linkLabel.Visible = true;

            label3.Visible = false;
            rollbox.Visible = false;
            label2.Visible = false;
            login_linkLabel.Visible = false;
            registration_button.Visible = false;
            Text = "Logi sisse";
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            label2.Visible = true;
            login_linkLabel.Visible = true;
            registration_button.Visible = true;
            label3.Visible = true;
            rollbox.Visible = true;

            label4.Visible = false;
            login_button.Visible = false;
            regitration_linkLabel.Visible = false;
        }

        private void login_button_Click(object sender, EventArgs e)
        {

        }

        private void registration_button_Click(object sender, EventArgs e)
        {
            if (namebox.Text.Trim() != string.Empty && rollbox.Text.Trim() != string.Empty)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("INSERT INTO Account (Nimi,Roll) VALUES (@nimi,@roll)", connect);
                    command.Parameters.AddWithValue("@nimi", namebox.Text);
                    command.Parameters.AddWithValue("@roll", rollbox.Text);

                    command.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
                if(rollbox.Text=="omanik" || rollbox.Text == "Omanik")
                {
                    var form1 = new Form1();
                    form1.ShowDialog();
                }
                else if (rollbox.Text == "müüja" || rollbox.Text == "Müüja")
                {
                    var kassa = new Kassa();
                    kassa.ShowDialog();
                }
            }
        }
    }
}
