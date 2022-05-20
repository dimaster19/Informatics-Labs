using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace zachet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Возможен ввод только цифр. Дрообные числа вводить через запятую.");


        }

        void calculateArea() 
        {
            double r; 
          
            r = double.Parse(textBox1.Text);
            StaticClass.Area = 3.14 * Math.Pow(r, 2);

            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateArea();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!double.TryParse(textBox1.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }
    }
}
