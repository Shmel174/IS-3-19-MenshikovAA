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
using ConnectDB;

namespace IS_3_19_MenshikovAA
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection conn = ConnDB_Lib.connDB_lib();
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();

        private void Form4_Load(object sender, EventArgs e)
        {
            {
                try
                {
                    conn.Open();
                    string commandStr = "SELECT idStud AS 'Код', fioStud AS 'ФИО', drStud AS 'Дата рождения' FROM t_datetime";
                    MyDA.SelectCommand = new MySqlCommand(commandStr, ConnDB_Lib.connDB_lib());
                    MyDA.Fill(table);
                    bSource.DataSource = table;
                    dataGridView1.DataSource = bSource;
                }
                catch
                {
                    MessageBox.Show("Исправьте ошибку!!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
                // Нужно чтобы было выравнивание строк
                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[2].Visible = true;

                dataGridView1.Columns[0].FillWeight = 20;
                dataGridView1.Columns[1].FillWeight = 40;
                dataGridView1.Columns[2].FillWeight = 40;

                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.RowHeadersVisible = false;

                dataGridView1.ColumnHeadersVisible = true;

                dataGridView1.AllowUserToResizeColumns = false;

                dataGridView1.AllowUserToResizeRows = false;

                dataGridView1.MultiSelect = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                    dataGridView1.CurrentRow.Selected = true;
                }
                catch
                {

                }

                DateTime dateTime = new DateTime();
                try
                {
                    dateTime = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    MessageBox.Show($"{DateTime.Today.Subtract(dateTime.Date).Days.ToString()} дней прошло с вашего дня рождения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                }
            }
        }
    }
}
