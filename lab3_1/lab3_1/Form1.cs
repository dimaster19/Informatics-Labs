using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_1
{
    public partial class CopywriterMainform : Form
    {
        public CopywriterMainform()
        {
            InitializeComponent();
            dataGridView1.RowCount = 20;
        }

        private string PathToFile;
        private string PathToOpenFolder;
        private string PathToSaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private Bitmap panelBitmap;

        public static string TextC = "(C)programmer";
        public static Font FontC = new Font("Times New Roman", 25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        public static Color Color = Color.FromArgb(255, 0, 0);


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog()
            {
                DefaultExt = "jpg",
                AddExtension = true,
                Filter = "Bitmap files (*.bmp)|*.bmp|Image files (*.jpg)|*.jpg|Image files (*.jpeg)|*.jpeg|Gif files (*.gif)|*.gif|PNG files (*.png)|*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                PathToOpenFolder = null;
                ImageFiles.Clear();
                PathToFile = openFile.FileName;
            }
            try
            {
                panelBitmap = new Bitmap(panel1.Width - 15, panel1.Height);
                panel1.AutoScrollMinSize = new Size(0, 900);
                var img = new Bitmap(PathToFile);
                var drawImg = Graphics.FromImage(panelBitmap);
                var imgSize = new Rectangle(0, 0, panel1.Width - 15, (int)(img.Height / (img.Width / (double)(panel1.Width - 15))));
                drawImg.DrawImage(img, imgSize);
                pictureBox1.Image = null;
                pictureBox1.Tag = null;
                panel1.Refresh();
            }
            catch
            {
            }
        }
        Dictionary<int, string> ImageFiles = new Dictionary<int, string>();
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                PathToFile = null;
                ImageFiles.Clear();
                PathToOpenFolder = browserDialog.SelectedPath;
                int i = 0;
                foreach (string imageFile in Directory.EnumerateFiles(PathToOpenFolder))
                {
                    try
                    {
                        var img = new Bitmap(imageFile);
                        ImageFiles.Add(i++, imageFile);
                    }
                    catch { }
                }
                panelBitmap = new Bitmap(panel1.Width, 200 * i + 15);
                panel1.AutoScrollMinSize = new Size(0, 200 * i + 15);
                pictureBox1.Image = null;
                pictureBox1.Tag = null;
                i = 0;

                foreach (string imageFile in Directory.EnumerateFiles(PathToOpenFolder))
                {
                    try
                    {
                        var img = new Bitmap(imageFile);
                        var graphics = Graphics.FromImage(panelBitmap);
                        graphics.DrawImage(img, 0, 200 * i + 15, 200, 200);
                        i++;
                    }
                    catch { }
                }
                panel1.Refresh();
            }

        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Transform = new Matrix(1, 0, 0, 1, panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
            if (panelBitmap != null)
            {
                e.Graphics.DrawImage(panelBitmap, 0, 0);
            }
        }
      
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (PathToOpenFolder != null)
            {
                var realY = e.Y - panel1.AutoScrollPosition.Y;
                var numberPic = (realY - 15) / 200;
                var img = new Bitmap(ImageFiles[numberPic]);
                pictureBox1.Image = img;
                pictureBox1.Tag = numberPic;
            }
            else if (PathToFile != null)
            {
                var img = new Bitmap(PathToFile);
                if (e.Y < (int)(img.Height / (img.Width / (double)(panel1.Width - 15))))
                {
                    pictureBox1.Image = img;
                }
            }
        }
        List<int> FilesNotForSave = new List<int>();
        private void CopywriterMainform_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                if (pictureBox1.Tag != null)
                {
                    FilesNotForSave.Add((int)pictureBox1.Tag);
                    var drawCross = Graphics.FromImage(panelBitmap);
                    var dy = 200 * (int)pictureBox1.Tag + 15;
                    var points = new Point[] { new Point(20, 20 + dy), new Point(40, 40 + dy), new Point(60, 20 + dy), new Point(20, 60 + dy), new Point(40, 40 + dy), new Point(60, 60 + dy) };
                    drawCross.DrawLines(new Pen(Color.Red, 5), points);
                    panel1.Refresh();
                }
                else if (PathToFile != null)
                {
                    var drawCross = Graphics.FromImage(panelBitmap);
                    var points = new Point[] { new Point(20, 20), new Point(40, 40), new Point(60, 20), new Point(20, 60), new Point(40, 40), new Point(60, 60) };
                    drawCross.DrawLines(new Pen(Color.Red, 5), points);
                    panel1.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PathToFile != null && pictureBox1.Image != null)
            {
                var img = new Bitmap(PathToFile);
                pictureBox1.Image = img;
                var graphics = Graphics.FromImage(img);
                graphics.DrawString(TextC, FontC, new Pen(Color).Brush, 50, 50);
                var drawChecked = Graphics.FromImage(panelBitmap);
                var points = new Point[] { new Point(10, 20), new Point(30, 40), new Point(60, 10) };
                drawChecked.DrawLines(new Pen(Color.Green, 5), points);
                panel1.Refresh();
                DataGridAddRow(PathToFile, img);
            }
            else if (PathToOpenFolder != null)
            {
                var img = new Bitmap(ImageFiles[(int)pictureBox1.Tag]);
                pictureBox1.Image = img;
                var graphics = Graphics.FromImage(img);
                graphics.DrawString(TextC, FontC, new Pen(Color).Brush, 50, 50);
                var drawChecked = Graphics.FromImage(panelBitmap);
                var dy = 200 * (int)pictureBox1.Tag + 15;
                var points = new Point[] { new Point(10, 20 + dy), new Point(30, 40 + dy), new Point(60, 10 + dy) };
                drawChecked.DrawLines(new Pen(Color.Green, 5), points);
                panel1.Refresh();
                DataGridAddRow(ImageFiles[(int)pictureBox1.Tag], img);
            }
        }
        int counter = 0;
        private int CounterAdd(ref int lastValue)
        {
            return lastValue++;
        }
        private void DataGridAddRow(string pathToFile, Bitmap img)
        {
            int currentRow = CounterAdd(ref counter);
            if (currentRow == dataGridView1.RowCount - 1)
            {
                currentRow--;
                dataGridView1.RowCount++;
            }
            dataGridView1.Rows[currentRow].Cells[0].Value = Path.GetFileName(pathToFile);
            dataGridView1.Rows[currentRow].Cells[1].Value = img.Width;
            dataGridView1.Rows[currentRow].Cells[2].Value = img.Height;
            dataGridView1.Rows[currentRow].Cells[3].Value = $"{TextC} [{DateTime.Now.ToShortTimeString()}]";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (PathToOpenFolder != null)
            {
                int cnt = 0;
                foreach (var key in ImageFiles.Keys)
                {
                    if (FilesNotForSave.BinarySearch(key) < 0)
                    {
                        var img = new Bitmap(ImageFiles[key]);
                        var graphics = Graphics.FromImage(img);
                        graphics.DrawString(TextC, FontC, new Pen(Color).Brush, 50, 50);
                        var path = PathToSaveFolder + @"\" + $"{cnt++}__" + Path.GetFileName(ImageFiles[key]);
                        img.Save(path);
                    }
                }
                MessageBox.Show("All files saved successfully!");
            }
            else
            {
                MessageBox.Show("This mode is for multiple images!");
            }
        }
        
        private void copyrightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var copyrightTextForm = new CopyrightTextForm();
            copyrightTextForm.ShowDialog();
        }
        private void copyrightDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                PathToSaveFolder = browserDialog.SelectedPath;
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog()
            {
                FileName = "CopyrightImage",
                DefaultExt = "jpg",
                AddExtension = true,
                OverwritePrompt = true,
                Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                ShowHelp = true
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Откройте директорию или определенный файл\n2. Далее выберите файл и в верхнем левом углу выберите влкадку меню 'Operations' или воспользуетесь кнопки внизу программы\n3.Выберите действие и нажмите на него ПКМ\n4.Также есть возможность измененеия текста надписис (вкладка Settings)");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      


    }

}
