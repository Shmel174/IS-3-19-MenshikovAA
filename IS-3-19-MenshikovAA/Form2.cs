using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_3_19_MenshikovAA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        class ConnectionDataBase
        {
            public MySqlConnection connDB()
            {
                string host = "caseum.ru";
                string port = "33333";
                string user = "test_user";
                string db = "db_test";
                string password = "test_pass";
                string connStr = $"server={host};port={port};user={user};database={db};password={password};";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }

    private void button1_Click(object sender, EventArgs e)
        {
        ConnectionDataBase connectionDB = new ConnectionDataBase();
        try
        {
            connectionDB.connDB().Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex}");
        }
        finally
        {
            MessageBox.Show("Я подключился к базе данных");
            connectionDB.connDB().Close();
        }
    }
    }
}
