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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToodedAB
{
    public partial class Form1 : Form
    {
        
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToodeDB;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        Label lb1, lb2, lb3, lb4;
        Button btn1, btn2, btn3, btn4, btn5, btn6;

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
            if (Toode.Text.Trim() != string.Empty && Kogus.Text.Trim() != string.Empty && Hind.Text.Trim() != string.Empty && Kat.SelectedItem != null)
            {
                try
                {
                    connect.Open();

                    command = new SqlCommand("SELECT Id FROM Kategooriatabel WHERE Kategooria_nimetus = @kat", connect);
                    command.Parameters.AddWithValue("@kat", Kat.Text);
                    int Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilte, Kategooriat) VALUES (@toode, @kogus, @hind, @pilt, @kat)", connect);
                    command.Parameters.AddWithValue("@toode", Toode.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(Kogus.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(Hind.Text));
                    command.Parameters.AddWithValue("@pilt", Toode.Text + ".jpg");
                    command.Parameters.AddWithValue("@kat", Id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasid viga: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                        NaitaAndmed();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sisestage andmeid!");
            }
        }

        private void Otsi_Pilt_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\Users\\opilane\\Pictures";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpg;*.png;*.bmp;*.jpeg)|*.jpg;*.png;*.bmp;*.jpeg";

            FileInfo open_info = new FileInfo(@"C:\\Users\\opilane\\Pictures" + open.FileName);
            if(open.ShowDialog()==DialogResult.OK && Toode.Text!=null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\..\Images");
                save.FileName = Toode.Text+Path.GetExtension(open.FileName);
                save.Filter = "Images" + Path.GetExtension(open.FileName)+"|"+Path.GetExtension(open.FileName);
                if (save.ShowDialog()==DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName);
                    Toode_pb.Image=Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus");
            }
        }

        
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

                    command = new SqlCommand("INSERT INTO Toodetable (Toodenimetus,Kogus,Hind,Pilt,Kategooriad) VALUES (@toode,@kogus,@hind,@pilt,@kat)", connect);
                    command.Parameters.AddWithValue("@toode", Toode.Text);
                    command.Parameters.AddWithValue("@kogus", Kogus.Text);
                    command.Parameters.AddWithValue("@hind", Hind.Text);
                    command.Parameters.AddWithValue("@pilt", Toode.Text+".jpg");
                    command.Parameters.AddWithValue("@kat", Toode.Text);

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

        

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = (int)dgv.Rows[e.RowIndex].Cells["id"].Value;
            Toode.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            Kogus.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            Hind.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            try
            {
                Toode_pb.Image = Image.FromFile(@"..\..\..\Images" + dgv.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Pilt puudub");
            }
            Kat.SelectedItem = dgv.Rows[e.RowIndex].Cells[5].Value;
        }

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
            adapter_toode = new SqlDataAdapter("SELECT Toodetable.Id, Toodetable.Toodenimetus, Toodetable.Kogus, Toodetable.Hind, Toodetable.Pilt, Kategooria.Kategooria_nimetus FROM Toodetable INNER JOIN Kategooria on Toodetable.Kategooriad=Kategooria.Id", connect);
            adapter_toode.Fill(dt_toode);
            dgv.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            foreach(DataRow item in dt_toode.Rows)
            {
                if (!combo_kat.Items.Contains(item["Kategooria_nimetus"]))
                {
                    combo_kat.Items.Add(item["Kategooria_nimetus"]);
                }
            }
            dgv.Columns.Add(combo_kat);
            connect.Close();
        }
    }
}
