﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;

namespace LB1
{
    public partial class Organizer_window : Form
    {
        public Organizer_window()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        string writePath = "file.txt";
        int[] Position = new int[2];
        private void Add_Click(object sender, EventArgs e)
        {
            Add_event_window window = new Add_event_window();
            window.ShowDialog();
            if (Temp.temp == true)
            {
                DataEvents.Rows.Add();
                if (Temp.type == "Памятка") { DataEvents[0, DataEvents.Rows.Count - 1].Value = new Bitmap("ok.png"); }
                if (Temp.type == "Встреча") { DataEvents[0, DataEvents.Rows.Count - 1].Value = new Bitmap("clea.png"); }
                if (Temp.type == "Задание") { DataEvents[0, DataEvents.Rows.Count - 1].Value = new Bitmap("voskl.png"); }
                DataEvents[1, DataEvents.Rows.Count - 1].Value = Temp.data;
                DataEvents[2, DataEvents.Rows.Count - 1].Value = Temp.time;
                DataEvents[3, DataEvents.Rows.Count - 1].Value = Temp.text;
                DataEvents[4, DataEvents.Rows.Count - 1].Value = Temp.type;
                TypeMode.Text = Temp.type;
                Temp.temp = false;
            }
        }

        private void DataEvents_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var h = DataEvents.HitTest(e.X, e.Y);
                Point a = new Point( e.X, e.Y );
                if (h.Type == DataGridViewHitTestType.Cell)
                {
                    contextMenu.Show(DataEvents, a);
                    Position[0] = h.RowIndex;
                    Position[1] = h.ColumnIndex;
                }
            }
        }

        private void Addrevresh_Click(object sender, EventArgs e)
        {
            Temp.data = DataEvents[0, Position[0]].Value.ToString();
            Temp.time = DataEvents[1, Position[0]].Value.ToString();
            Temp.text = DataEvents[2, Position[0]].Value.ToString();
            Temp.type = DataEvents[3, Position[0]].Value.ToString();
            Add_event_window window = new Add_event_window("Change");
            window.ShowDialog();
            if (Temp.temp == true)
            {
                DataEvents.Rows.RemoveAt(Position[0]);
                DataEvents.Rows.Add();
                if (Temp.type == "Памятка") { DataEvents[0, DataEvents.Rows.Count - 1].Value = new Bitmap("ok.png"); }
                if (Temp.type == "Встреча") { DataEvents[0, DataEvents.Rows.Count - 1].Value = new Bitmap("clea.png"); }
                if (Temp.type == "Задание") { DataEvents[0, DataEvents.Rows.Count - 1].Value = new Bitmap("voskl.png"); }
                DataEvents[1, DataEvents.Rows.Count - 1].Value = Temp.data;
                DataEvents[2, DataEvents.Rows.Count - 1].Value = Temp.time;
                DataEvents[3, DataEvents.Rows.Count - 1].Value = Temp.text;
                DataEvents[4, DataEvents.Rows.Count - 1].Value = Temp.type;
                TypeMode.Text = Temp.type;
                Temp.temp = false;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить запись " + DataEvents.Rows[Position[0]].Cells[3].Value.ToString(), "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataEvents.Rows.RemoveAt(Position[0]);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        int flag1 = 1;
        private void DataEvents_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DataEvents.Rows.Count != 1 && flag1 == 0)
            {
                TypeMode.Text = DataEvents.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void events_CheckedChanged(object sender, EventArgs e)
        {
            if(category.Checked == false)
            {
                for(int i = 0; i< DataEvents.Rows.Count;i++)
                {
                    DataEvents.Rows[i].Visible = true;
                }
            }
        }

        private void category_CheckedChanged(object sender, EventArgs e)
        {
            if (events.Checked == false)
            {
                int i = 0;
                while (DataEvents.Rows.Count != i)
                {
                    if (DataEvents.Rows[i].Cells[4].Value.ToString() != TypeMode.Text)
                    { DataEvents.Rows[i].Visible = false; }
                    i++;
                }
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
        metca1:
            string stroka = Interaction.InputBox("Поиск", "Ведите событие", "Текст");
            if (stroka == "") 
            {
                return; 
            } 
           
            for (int i = 0; i < DataEvents.Rows.Count; i++)
            {
                if (DataEvents.Rows[i].Cells[3].Value.ToString() != stroka)
                { 
                    DataEvents.Rows[i].Visible = false; 
                }
            }
        }
        bool flag = true;
        private void Filter_Click(object sender, EventArgs e)
        {
            if (flag == true) { DataEvents.Sort(DataEvents.Columns[1], ListSortDirection.Ascending); }
            if (flag == false) { DataEvents.Sort(DataEvents.Columns[1], ListSortDirection.Descending); }
            flag = !flag;

        }
        private void Organizer_window_Load(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            if (open.FileName != "")
            { writePath = open.FileName; }
            else
            { writePath = "file.txt"; }
            openfile();
            Button Add_button = new Button();
            
            //flowLayoutPanel1.Controls.Add(Add_button);
            Button add_Button = new Button();
            add_Button.BackColor = Color.White;
            add_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            add_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            add_Button.Font = new System.Drawing.Font("Open Sans ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            add_Button.ForeColor = System.Drawing.Color.MediumPurple;
            add_Button.Location = new System.Drawing.Point(324, 28);
            add_Button.Name = "add_Button";
            add_Button.Size = new System.Drawing.Size(142, 54);
            add_Button.Text = "Add";
            add_Button.UseVisualStyleBackColor = false;
            add_Button.Click += new System.EventHandler(this.Add_Click);
            tableLayoutPanel1.Controls.Add(add_Button, 0, 0);
            
           



        }
        private void openfile()
        {
            if (System.IO.File.Exists(writePath))
            {
                using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
                {

                    string line = sr.ReadLine();
                    DataEvents.Rows.Add(Convert.ToInt32(line));
                    for (int i = 1; i < DataEvents.Columns.Count; i++)
                    {
                        for (int j = 0; j < DataEvents.Rows.Count; j++)
                        {
                            line = sr.ReadLine();
                            DataEvents.Rows[j].Cells[i].Value = line;
                        }
                    }
                    for (int i = 0; i < DataEvents.Rows.Count; i++)
                    {
                        if (DataEvents.Rows[i].Cells[4].Value.ToString() == "Памятка") { DataEvents.Rows[i].Cells[0].Value = new Bitmap("ok.png"); }
                        if (DataEvents.Rows[i].Cells[4].Value.ToString() == "Встреча") { DataEvents.Rows[i].Cells[0].Value = new Bitmap("clea.png"); }
                        if (DataEvents.Rows[i].Cells[4].Value.ToString() == "Задание") { DataEvents.Rows[i].Cells[0].Value = new Bitmap("voskl.png"); }
                    }
                }
            }
            flag1 = 0;
        }
        private void Organizer_window_FormClosed(object sender, FormClosedEventArgs e)
        {
            save();
            Application.Exit();

        }
        private void save ()
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(DataEvents.Rows.Count);
                for (int i = 1; i < DataEvents.Columns.Count; i++)
                {
                    for (int j = 0; j < DataEvents.Rows.Count; j++)
                    {
                        sw.WriteLine(DataEvents.Rows[j].Cells[i].Value);
                    }
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.S && e.Control)
            {
                save();
                MessageBox.Show("Файл сохранен");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.O && e.Control)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                writePath = open.FileName;
                DataEvents.Rows.Clear();
                flag1 = 1;
                openfile();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                DataEvents.Rows.RemoveAt(DataEvents.CurrentCell.RowIndex);
                e.Handled = true;
            }
        }
    }
}
