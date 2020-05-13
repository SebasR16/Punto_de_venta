using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta
{
    public partial class Form1 : Form
    {
        Conexion c = null;
        //variable de clase 
        private String[,] productos =
        {
            {"128468579216","Burro percheron","100"},
            {"127813549721","Taco de asada","25"},
            {"178149325487","Caramelo","35"},
            {"151873204809","Dogo","20"},
            {"094156349284","Pizza","50"},
            {"594684123498","Refresco","20"},
            {"846124863084","Elote","10"},
            {"248765108846","Sopa de Macaco","17"},
            {"948175230843","Tochos","32"},
            {"348147895032","Cloro","5"},
        };
        private void buscarProductos()
        {
            if (textBox1.Text.IndexOf('*') != -1)
            {
                String[] arre = textBox1.Text.Split('*');
                for (int i = 0; i < productos.GetUpperBound(0); i++)
                {
                    if (arre[1] == productos[i, 0])
                    {
                        dataGridView1.Rows.Add(productos[i, 2], productos[i, 1], arre[0], float.Parse(productos[i, 2])*float.Parse(arre[0]));
                        
                    }
                }
            }
            else
            {
                for (int i = 0; i < productos.GetUpperBound(0); i++)
                {
                    if (textBox1.Text == productos[i, 0])
                    {
                        dataGridView1.Rows.Add(productos[i, 2], productos[i, 1], "1", productos[i, 2]);
                        
                    }
                }
            }
                    total();
        }
        private void total()
        {
            float total = 0.0f;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += float.Parse(dataGridView1[3, i].Value.ToString());

            }
            label3.Text = "Total = " + total;
            textBox1.Clear();
            textBox1.Focus();
        }
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Before Connection");
            c = new Conexion();
            Console.WriteLine("After connection");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((this.Width/2)-(label1.Width/2),0);
            label2.Text = DateTime.Now.ToLongDateString()+" "+ DateTime.Now.ToLongTimeString();
            
            label2.Location = new Point((this.Width / 2) - (label2.Width / 2), label1.Height + 1);
            dataGridView1.Width = this.Width-10;
            dataGridView1.Height = this.Height * 3/4;
            dataGridView1.Location = new Point(5, label1.Height+label2.Height + 1);
            textBox1.Width = this.Width;
            textBox1.Location = new Point(0, this.Height - (textBox1.Height-3));
            label3.Location = new Point(this.Width - dataGridView1.Columns[3].Width, label1.Height + dataGridView1.Height + 30);
            button1.Location = new Point(this.Width - dataGridView1.Columns[3].Width - label3.Width -10, label1.Height + dataGridView1.Height + 30);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Form1_Load(sender, e); //Hace la ventana responsiva
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                buscarProductos();
            }
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                total();
            }
            if (e.KeyCode == Keys.P)
            {
                MessageBox.Show("¿Vas a pagar?");
            }
        }
    }
}
