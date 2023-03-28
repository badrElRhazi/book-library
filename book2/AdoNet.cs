using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace book2
{
    class AdoNet
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private SqlDataReader reader;
        private DataTable dtCat;
        private DataTable dtBooks;
        private DataSet ds;

        public SqlConnection Connection { get => connection; set => connection = value; }
        public SqlCommand Command { get => command; set => command = value; }
        public SqlDataAdapter Adapter { get => adapter; set => adapter = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }
        
        public DataSet Ds { get => ds; set => ds = value; }
        public DataTable DtCat { get => dtCat; set => dtCat = value; }
        public DataTable DtBooks { get => dtBooks; set => dtBooks = value; }

        public AdoNet()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=boook;Integrated Security=True");
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            ds = new DataSet();

        }
    }
}
