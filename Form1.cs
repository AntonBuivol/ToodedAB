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


        private void Lisa_kategooria_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in Kat.Items)
            {
                if (item.ToString() == Kat.Text)
                {
                    on = true;
                }
            }
            if (on == false)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (Toode.Text.Trim() != string.Empty && Kogus.Text.Trim() != string.Empty && Hind.Text.Trim() != string.Empty && Kat.SelectedItem != null)
            {
                try
                {

                    command = new SqlCommand("UPDATE Toodetable SET Toodenimetus=@toode, Kogus=@kogus, Hind=@hind,Pilt=@pilt,Kategooriad=@kat WHERE Id=@id", connect);
                    connect.Open();
                    int Id = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@toode", Toode.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(Kogus.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(Hind.Text));
                    command.Parameters.AddWithValue("@pilt", Toode.Text + ".jpg");
                    command.Parameters.AddWithValue("@kat", Kat.Text);

                    command.ExecuteNonQuery();
                    connect.Close();
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasid viga: " + ex.Message);
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
                save.InitialDirectory = Path.GetFullPath(@"..\..\Images");
                save.FileName = Toode.Text+Path.GetExtension(open.FileName);
                save.Filter = "Images" + Path.GetExtension(open.FileName)+"|"+Path.GetExtension(open.FileName);
                if (save.ShowDialog()==DialogResult.OK && Toode.Text!=null)
                {
                    File.Copy(open.FileName, save.FileName);
                    Toode_pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    Toode_pb.Image=Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus");
            }
        }

        int Id = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Toode.Text.Trim() != string.Empty && Kogus.Text.Trim() != string.Empty && Hind.Text.Trim() != string.Empty && Kat.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("SELECT Id FROM Kategooria WHERE Kategooria_nimetus = @kat", connect);
                    command.Parameters.AddWithValue("@kat", Kat.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Toodetable (Toodenimetus,Kogus,Hind,Pilt,Kategooriad) VALUES (@toode,@kogus,@hind,@pilt,@kat)", connect);
                    command.Parameters.AddWithValue("@toode", Toode.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(Kogus.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(Hind.Text));
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
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }


        

        private void Kustuta_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count>0)
            {
                DataGridViewRow selectedRow = dgv.SelectedRows[0];
                int selectedRowID = Convert.ToInt32(selectedRow.Cells["id"].Value);

                try
                {
                    if (connect.State==ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    string deleteQuery = "DELETE FROM Toodetable WHERE Id=@id";
                    command = new SqlCommand(deleteQuery,connect);
                    command.Parameters.AddWithValue("@id", selectedRowID);
                    command.ExecuteNonQuery();
                    connect.Close();

                    dgv.Rows.Remove(selectedRow);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Probleem tekkis kustutamisel: " + ex.Message);
                }
                finally
                {
                    if(connect.State==ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dgv.Rows[e.RowIndex].Cells["id"].Value;
            Toode.Text = dgv.Rows[e.RowIndex].Cells["Toodenimetus"].Value.ToString();
            Kogus.Text = dgv.Rows[e.RowIndex].Cells["Kogus"].Value.ToString();
            Hind.Text = dgv.Rows[e.RowIndex].Cells["Hind"].Value.ToString();
            try
            {
                Toode_pb.SizeMode = PictureBoxSizeMode.StretchImage;
                Toode_pb.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Images"), dgv.Rows[e.RowIndex].Cells["Pilt"].Value.ToString()));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Pilt puudub"+ex.Message);
            }
            Kat.SelectedItem = dgv.Rows[e.RowIndex].Cells[5].Value;
        }

        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            NaitaKategooriad();

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
                    command.Parameters.AddWithValue("@Id", item["id"]);
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
            dgv.Columns.Clear();
            dgv.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.HeaderText = "Kategooria";
            combo_kat.Name = "KategooriaColumn";
            combo_kat.DataPropertyName = "Kategooria";
            HashSet<string> uniqueCategories = new HashSet<string>();
            foreach(DataRow item in dt_toode.Rows)
            {
                string category = item["Kategooria_nimetus"].ToString();
                if (!uniqueCategories.Contains(category))
                {
                    uniqueCategories.Add(category);
                    combo_kat.Items.Add(category);
                }
            }
            dgv.Columns.Add(combo_kat);
            dgv.Columns["Kategooria_nimetus"].Visible = false;
            connect.Close();
        }
    }
}
