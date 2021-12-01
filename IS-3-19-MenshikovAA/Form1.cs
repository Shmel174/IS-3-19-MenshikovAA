using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_3_19_MenshikovAA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        abstract class Components<A>
        {
            A Art;
            public int cena { get; set; }
            public string godV { get; set; }
            public Components(int cena, string godV, A Art)
            {
                this.cena = cena;
                this.godV = godV;
                this.Art = Art;
            }

            public string Display()
            {
                return $"Цена: {cena} руб., Год производства: {godV} год, Артикул: {Art} ";
            }
        }

        class CPU<A> : Components<A>
        {
            private double Hz { get; set; }
            private int vCores { get; set; }
            private int vPotoks { get; set; }
            public CPU(A Art , int cena, string godV, double Hz, int vCores,int vPotoks)
            :base(cena,godV,Art)
            {
                this.Hz = Hz;
                this.vCores = vCores;
                this.vPotoks = vPotoks;
            }
            public new string Display()
            {
                return base.Display() + $"| Данные о процессоре: Частота ЦП: {Hz} ГЦ, Количество ядер: {vCores}, Количество потоков: {vPotoks}" ;
            }
        }
        class GPU<A> : Components<A>
        {
            private double gHz { get; set; }
            private string Prod { get; set; }
            private int vMemory { get; set; }
            public GPU(A Art, int cena, string godV, double gHz, string Prod, int vMemory)
            : base(cena, godV, Art)
            {
                this.gHz = gHz;
                this.Prod = Prod;
                this.vMemory = vMemory;
            }
            public new string Display()
            {
                return base.Display() + $"| Данные о видеокарте: Частота ГП: {gHz} ГЦ, Производитель: {Prod}, Объём памяти: {vMemory} ГБ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && textBox4.TextLength != 0 && textBox5.TextLength != 0 && textBox6.TextLength != 0)
            {
                try
                {
                    CPU<string> cpu = new CPU<string>(Convert.ToString(textBox1.Text),
                        Convert.ToInt32(textBox2.Text),
                       Convert.ToString(textBox3.Text),
                        Convert.ToInt32(textBox4.Text),
                        Convert.ToInt32(textBox5.Text),
                        Convert.ToInt32(textBox6.Text));
                    listBox1.Items.Add(cpu.Display());
                }
                catch (Exception ex) { MessageBox.Show($"{ex}"); }
            }
            else
            {
                MessageBox.Show("Введите все данные.");
            }
        }
            private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && textBox7.TextLength != 0 && textBox8.TextLength != 0 && textBox9.TextLength != 0)
            {
                try
                {
                    GPU<string> gpu = new GPU<string>(Convert.ToString(textBox1.Text),
                        Convert.ToInt32(textBox2.Text),
                       Convert.ToString(textBox3.Text),
                        Convert.ToInt32(textBox7.Text),
                        Convert.ToString(textBox8.Text),
                        Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(gpu.Display());
                }
                catch (Exception ex) { MessageBox.Show($"{ex}"); }
            }
            else
            {
                MessageBox.Show("Введите все данные.");
            }
        }
    }
}
