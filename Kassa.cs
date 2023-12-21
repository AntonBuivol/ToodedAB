using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Pdf;

namespace ToodedAB
{
    public partial class Kassa : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToodeDB;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Kassa()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        private void lisa_korvi_button_Click(object sender, EventArgs e)
        {

        }

        private void osta_button_Click(object sender, EventArgs e)
        {

        }

        private void eemalda_button_Click(object sender, EventArgs e)
        {

        }

        private void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetable.Id, Toodetable.Toodenimetus, Toodetable.Kogus, Toodetable.Hind, Kategooria.Kategooria_nimetus FROM Toodetable INNER JOIN Kategooria on Toodetable.Kategooriad=Kategooria.Id", connect);
            adapter_toode.Fill(dt_toode);
            dgv.Columns.Clear();
            dgv.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.HeaderText = "Kategooria";
            combo_kat.Name = "KategooriaColumn";
            combo_kat.DataPropertyName = "Kategooria";
            HashSet<string> uniqueCategories = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
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
//покупать видит только цену, картинку и название
//отправлять чек с кассы