using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ToodedAB
{
    public partial class Form1 : Form
    {
        
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToodeDB;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        ComboBox cb1, cb2, cb3, cb4;
        Label lb1, lb2, lb3, lb4;

        private void button3_Click(object sender, EventArgs e)
        {
            if(Kat.SelectedItem!=null)
            {
                string val_kat=Kat.SelectedItem.ToString();

                connect.Open();
                SqlCommand command = new SqlCommand("Delete FROM Kategooria WHERE Kategooria_nimetus = @kat", connect);
                command.Parameters.AddWithValue("@kat", val_kat);
                command.ExecuteNonQuery();
                connect.Close();
                Kat.Items.Clear();
                NaitaKategooriad();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        int Id = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(Toode.Text.Trim()!=string.Empty && Kogus.Text.Trim()!=string.Empty && Hind.Text.Trim()!=string.Empty && Kat.SelectedItem!=null)
            {
                try
                {
                    connect.Open();

                    command = new SqlCommand("SELECT Id FROM Kategooria WHERE Katergooria_nimetus = @kat", connect);
                    command.Parameters.AddWithValue("@kat", Kat.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Toodetable (Toodenimetus,Kogus,Hind,Pilt,Kategooriad) VALUES (@toode,@kogus,@hind,@pilt,@kat)", connect);
                    command.Parameters.AddWithValue("@toode", Toode.Text);
                    command.Parameters.AddWithValue("@kogus", Kogus.Text);
                    command.Parameters.AddWithValue("@hind", Hind.Text);
                    command.Parameters.AddWithValue("@pilt", Toode.Text+".jpg");
                    command.Parameters.AddWithValue("@kat", Id);

                    command.ExecuteNonQuery();
                    connect.Close();
                    NaitaAndmed();
                }
                catch(Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
        }

        Button btn1, btn2, btn3, btn4, btn5, btn6;

        //private void Lisa_Kategooriad(object sender, EventArgs e)
        //{
        //    command = new SqlCommand("INSERT INTO kategooriatabel (Kategooria_nimetus) VALUES ()");
        //}
        public Form1()
        {
            InitializeComponent();
            lb1 = new Label() { Text = "Toode nimetus", Location = new Point(20, 20), Font = new Font("Arial", 16), ForeColor = Color.Black, Size=new Size(150, 30) };
            lb2 = new Label() { Text = "Kogus", Location = new Point(20, lb1.Location.Y+60), Font = new Font("Arial", 16), ForeColor = Color.Black, Size=new Size(150, 30) };
            lb3 = new Label() { Text = "Hind", Location = new Point(20, lb2.Location.Y+60), Font = new Font("Arial", 16), ForeColor = Color.Black, Size=new Size(150, 30) };
            lb4 = new Label() { Text = "Kategooria", Location = new Point(20,lb3.Location.Y+60), Font = new Font("Arial", 16), ForeColor = Color.Black, Size=new Size(150,30)};
            btn1 = new Button() { Text = "Lisa kategooria", Location = new Point(lb4.Left, lb4.Bottom+15), Size = new Size(100,20), FlatStyle = FlatStyle.Popup };
            btn1.Click +=Btn1_Click;
            this.Controls.AddRange(new Control[] {lb1,lb2,lb3,lb4,btn1});
            NaitaAndmed();
            NaitaKategooriad();

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach(var item in Kat.Items)
            {
                if(item.ToString()== Kat.Text)
                {
                    on = true;
                }
            }
            if(on==false)
            {
                command = new SqlCommand("INSERT INTO Kategooria (Kategooria_nimetus) VALUES (@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", Kat.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Kat.Items.Clear();
                NaitaKategooriad();
            }
            else
            {
                MessageBox.Show("Andmebaasiga viga!");
            }
            
        }

        private void NaitaKategooriad()
        {
            Kat.Items.Clear();
            Kat.Text = "";
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooria", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!Kat.Items.Contains(item["Kategooria_nimetus"]))
                {
                    Kat.Items.Add(item["Kategooria_nimetus"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM Kategooria WHERE Id=@Id", connect);
                    command.Parameters.AddWithValue("@Id", item["Id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }

        private void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            DataTable table = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetable.Id, Toodetable.Toodenimetus, Toodetable.Kogus, Toodetable.Hind, Toodetable.Pilt, Kategooria.Kategooria_nimetus FROM Toodetable INNER JOIN Kategooria on Toodetable.Id=Kategooria.Id", connect);
            adapter_toode.Fill(dt_toode);
            table.Columns.Add("Nimetus");
            table.Columns.Add("Kogus");
            table.Columns.Add("Hind");
            table.Columns.Add("Pilt");
            DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            foreach(DataRow item in dt_toode.Rows)
            {
                if (!dgvcb.Items.Contains(item["Kategooria_nimetus"]))
                {
                    dgvcb.Items.Add(item["Kategooria_nimetus"]);
                }
            }
            foreach(DataRow item in dt_toode.Rows)
            {
                table.Rows.Add(item["Toodenimetus"], item["Kogus"], item["Hind"], item["Pilt"]);
            }
            dgv.DataSource = table;
            dgv.Columns.Add(dgvcb);
            connect.Close();
        }
    }
}
