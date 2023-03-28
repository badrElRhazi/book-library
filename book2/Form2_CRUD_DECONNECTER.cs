using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace book2
{
    public partial class Form2_CRUD_DECONNECTER : Form
    {
        public Form2_CRUD_DECONNECTER()
        {
            InitializeComponent();
        }
        AdoNet Ado = new AdoNet();
        private void Form2_CRUD_DECONNECTER_Load(object sender, EventArgs e)
        {
            //GetBooksCat
            Ado = new AdoNet();
            string Query = string.Empty + "GetBooksCat";
            Ado.Command.CommandText = Query;
            Ado.Command.CommandType = CommandType.StoredProcedure;
            Ado.Command.Connection = Ado.Connection;
            Ado.Adapter.SelectCommand = Ado.Command;
            Ado.Adapter.Fill(Ado.Ds);
            MessageBox.Show(Ado.Ds.Tables.Count + "");
            Ado.DtBooks = Ado.Ds.Tables[1];
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {

        }
    }
}
