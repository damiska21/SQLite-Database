using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQLite_databáze_1
{
    public partial class Form1 : Form
    {
        DataTable dt;
        SQLiteDataAdapter adapter;
        DataSQLite tridaSQL;
        public Form1()
        {
            InitializeComponent();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            dt = new DataTable();
            tridaSQL = new DataSQLite();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            tridaSQL.VytvorTabulku();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSQLite.Pripoj();
            adapter = new SQLiteDataAdapter("SELECT * FROM cars orde by nazev", DataSQLite.Connection);
            dt = new DataTable();
        }
    }
}
