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
            NaitaRoll();
        }

        int Id = 0;
        private void registration_button_Click(object sender, EventArgs e)
        {
            if (namebox.Text.Trim() != string.Empty && rollbox.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("SELECT Id FROM Account WHERE Roll = @roll", connect);
                    command.Parameters.AddWithValue("@roll", rollbox.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Account (Nimi,Roll) VALUES (@nimi,@roll)", connect);
                    command.Parameters.AddWithValue("@nimi", namebox.Text);
                    command.Parameters.AddWithValue("@roll", Id);

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

        private void login_button_Click(object sender, EventArgs e)
        {

        }

        private void NaitaRoll()
        {
            rollbox.Items.Clear();
            rollbox.Text = "";
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Id, Roll FROM Account", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!rollbox.Items.Contains(item["Roll"]))
                {
                    rollbox.Items.Add(item["Roll"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM Account WHERE Id=@Id", connect);
                    command.Parameters.AddWithValue("@Id", item["id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }
    }
}
