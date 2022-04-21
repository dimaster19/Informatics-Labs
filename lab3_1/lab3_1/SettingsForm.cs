using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_1
{
    public partial class CopyrightTextForm : Form
    {
        public CopyrightTextForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            if (fontDialog.ShowDialog()==DialogResult.OK)
            {
                CopywriterMainform.FontC = fontDialog.Font;
                textBox1.Font = fontDialog.Font;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                CopywriterMainform.Color = colorDialog.Color;
                textBox1.ForeColor = colorDialog.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopywriterMainform.TextC = textBox1.Text;
            this.Close();
        }

        private void CopyrightTextForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = CopywriterMainform.TextC;
            textBox1.Font = CopywriterMainform.FontC;
            textBox1.ForeColor = CopywriterMainform.Color;
        }
    }
}
