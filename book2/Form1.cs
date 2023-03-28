using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace book2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bs1 = new BindingSource();
        DataTable dt = new DataTable();
        
        public void rechager()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from books", conn);
            var dr = cmd.ExecuteReader();
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
            
            conn.Open();
            string query = string.Format("insert into Books values({0},'{1}','{2}','{3}','{4}','{5}')",idText.Text,NameText.Text,
                AutorText.Text,PriceText.Text,PageText.Text,DateSortie.Value.ToString("yyyy-MM-dd"));
            SqlCommand cmd = new SqlCommand(query,conn);
            MessageBox.Show(query);
            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Add(idText.Text, NameText.Text, AutorText.Text, PriceText.Text, PageText.Text, DateSortie.Value.ToString("yyyy-MM-dd"));;
            conn.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Books set Name=@p1, Autor=@p2, Price=@p3,Pages=@p4,date_sortie=@p5 where ID=@p6",conn);
            cmd.Parameters.AddWithValue("p1", NameText.Text);
            cmd.Parameters.AddWithValue("p2", AutorText.Text);
            cmd.Parameters.AddWithValue("p3", PriceText.Text);
            cmd.Parameters.AddWithValue("p4", PageText.Text);
            cmd.Parameters.AddWithValue("p5", DateSortie.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("p6", idText.Text);
            cmd.ExecuteNonQuery();
            rechager();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            da.SelectCommand = new SqlCommand("select * from Books", conn);
            da.Fill(ds, "Books");
            /*
             cnx c = new cnx();
            SqlCommand cmd = new SqlCommand("select * from employer", c.cnx2);
            c.ouvircnx();
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt.Load(cmd.ExecuteReader());
            BS.DataSource = dt;
            dataGridView1.DataSource = dt;
            c.fermercnx();
             */
            /*SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from books",conn);
            var dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }*/
            /*idText.DataBindings.Add("text",bs1, "ID");
            NameText.DataBindings.Add("text",bs1, "Name");
            AutorText.DataBindings.Add("text",bs1, "Autor");
            PriceText.DataBindings.Add("text",bs1, "Price");
            PageText.DataBindings.Add("text",bs1, "Pages");
            DateSortie.DataBindings.Add("text",bs1, "date_sortie");
            dataGridView1.DataSource = bs1;*/
        }
        

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
            conn.Open();
            string Query = string.Format("select * from Books where ID={0}", idText.Text);
            SqlCommand cmd = new SqlCommand(Query, conn);
            if (idText.Text == "")
            {
                MessageBox.Show("veuillez entrer un id valid ");
                return;
            }
            var dr=cmd.ExecuteReader();
            dr.Read();
            NameText.Text = dr["Name"].ToString();
            AutorText.Text = dr["Autor"].ToString();
            PriceText.Text = dr["Price"].ToString();
            PageText.Text = dr["Pages"].ToString();
            DateSortie.Text = dr["date_sortie"].ToString();
            conn.Close();
        }
        int position = -1, id;

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs1.MoveLast();
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs1.MoveFirst();
           
        }
        int i,pos;

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bs1.MovePrevious();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs1.MoveNext();
            
            
            
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
          
                    position = dataGridView1.CurrentRow.Index;
                    id = int.Parse(dataGridView1.Rows[position].Cells[0].Value.ToString());
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Books where ID=@id ", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    DialogResult result = MessageBox.Show("voulez vous vraiment supprimmer ce livre?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        dataGridView1.Rows.RemoveAt(position);
                        MessageBox.Show("Le livre a été bien supprimer ! ", MessageBoxIcon.Hand.ToString());
                    }
                    conn.Close();
        }
    }
}
