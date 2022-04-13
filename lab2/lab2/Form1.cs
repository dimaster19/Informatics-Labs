using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace _3_лаба
{
    public partial class DirectoryBrowser : Form
    {
        public DirectoryBrowser() {  InitializeComponent(); }
        private void Tree_BeforeExpand(object sender, TreeViewCancelEventArgs e) { Build(e.Node); }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e) //после нажатия по папке (ветке дерева) 
        {                                                                    //происходит заполнение таблицы
            TreeNode selectedNode = e.Node;
            string fullPath = selectedNode.FullPath;
            DirectoryInfo di = new DirectoryInfo(fullPath);
            FileInfo[] fiArray;
            DirectoryInfo[] diArray;
            try
            {
                fiArray = di.GetFiles();
                diArray = di.GetDirectories();
            }
            catch { return; }
            DataTable.Items.Clear(); //очищаем таблицу перед каждым "обновлением"
            foreach (DirectoryInfo dirInfo in diArray) //папки
            {
                ListViewItem list = new ListViewItem(dirInfo.Name);
                list.Checked = true;
                list.SubItems.Add(" ");
                list.SubItems.Add("Folder with files");
                DataTable.Items.Add(list);
            }
            long shortName = 0, midName = 0, longName = 0;
            long count = 0;
            int shortCount = 0;
            int midCount = 0;
            int longCount = 0;
            foreach (FileInfo fileInfo in fiArray) //файлы
            {
                count += fileInfo.Length;
                string name = fileInfo.Name; 
                ListViewItem list = new ListViewItem(name);
                list.Checked = true;
                list.Tag = fileInfo.FullName; 
                list.SubItems.Add(fileInfo.Length.ToString() ); //размер файла
                string type;
                //fileInfo.Name.ToString;
                Regex reg = new Regex(@"(\.\w{1,4}$)"); //ищет в конце строки от 1 до 4 символом, перед которыми стоит "."
                foreach (Match wrd in reg.Matches(name)) 
                {
                    type = wrd.ToString(); //тип файла 
                    list.SubItems.Add(type);
                    DataTable.Items.Add(list);
                    //окрашивание строк таблицы
                    if (type == ".png" || type == ".jpg" || type == ".bmp" || type == ".gif" || type == ".JPG")
                        list.BackColor = Color.YellowGreen; //светло-фиолетовый
                    else if (type == ".docx" || type == ".xlsx" || type == ".pdf" || type == ".txt")
                        list.BackColor = Color.DodgerBlue;
                    else if (type == ".zip" || type == ".rar" || type == ".7z")
                        list.BackColor = Color.Firebrick;
                    else if (type == ".exe" || type == ".dll" || type == ".ini")
                        list.BackColor = Color.Violet;
                }
                //график (6 вариант)
                Chart.Series.Clear();
                Chart.Series.Add("Average file size");
                string temp = fileInfo.Name;
            

                if (temp.Length <= 5)
                {
                    if (temp.Length > shortName)
                    {
                        shortName += fileInfo.Length;
                        shortCount++;
                    }
                }
                if (temp.Length > 5 && temp.Length < 8)
                {
                    if (temp.Length > midName)
                    {
                        midName += fileInfo.Length;
                        midCount++;
                    }
                        
                }
                if (temp.Length >= 8)
                {
                    if (temp.Length > longName)
                    {
                        longName += fileInfo.Length;
                        longCount++;

                    }
                }
          
                
            }
            Chart.Series[0].Points.AddXY("ShortName", shortName/shortCount);
            Chart.Series[0].Points.AddXY("MidName", midName/midCount);
            Chart.Series[0].Points.AddXY("LongName", longName/longCount);

            statusStrip1.Items[0].Text = "Total bytes: " + count; 
            statusStrip1.Items[1].Text = DataTable.CheckedItems.Count + " of " + DataTable.CheckedItems.Count + " items selected"; //эта строка изначально
        }
        private void Build(TreeNode parent) //формирование дерева
        {
            var path = parent.Tag as string;
            parent.Nodes.Clear();
            foreach (var dir in Directory.GetDirectories(path))
                parent.Nodes.Add(new TreeNode(Path.GetFileName(dir), new[] { new TreeNode("...") }) { Tag = dir });
            foreach (var file in Directory.GetFiles(path))
                parent.Nodes.Add(new TreeNode(Path.GetFileName(file), 1, 1) { Tag = file });
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e) //пункт меню "Оpen"                
        {                                                                    
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TreeNode node = new TreeNode() { Text = fbd.SelectedPath.ToString(), Tag = fbd.SelectedPath };
                Tree.Nodes.Add(node);
                Build(node);
                node.Expand();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //пункт меню "Save"
        {                   
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TreeNode TNode = Tree.SelectedNode;
                string DI_path = TNode.FullPath;
                string path = fbd.SelectedPath + @"\file.txt";
                FileStream FS = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter file = new StreamWriter(FS);
                DirectoryInfo DI = new DirectoryInfo(DI_path);
                DirectoryInfo[] dir = DI.GetDirectories();
                foreach (DirectoryInfo s in dir)
                    file.Write(s.Name + "\n");
                file.Close();
                FS.Close();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e) //возможность выбрать цвет текста в таблице
        {
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                DataTable.ForeColor = color.Color;
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e) //возможность выбрать шрифт текста в таблице
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                DataTable.Font = font.Font;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // exit
        {
            
                this.Close();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) // help

        {  
            MessageBox.Show("Я не знаю, что тут пишут, поэтому напишу следующие...\nУ меня есть такса (мальчик), его зовут Ральф, он прикольный. \nГав-Гав-Гав "); 
        }



        private void DataTable_SelectedIndexChanged(object sender, EventArgs e) //эта строка, когда изменяется количество выделенных элементов
        {
            if (DataTable.SelectedIndices.Count > 0)
            {
                int total = DataTable.Items.Count;
                int elem = DataTable.CheckedItems.Count;
                statusStrip1.Items[1].Text = elem + " of " + total + " items selected";
            }
        }
        private void DirectoryBrowser_Load(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "";
            statusStrip1.Items[1].Text = "";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
