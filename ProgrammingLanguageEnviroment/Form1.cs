using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ProgrammingLanguageEnviroment
{
    public partial class Form1 : Form
    {
        private Bitmap OutputBitmap = new Bitmap(500, 400); //sets the size of bitmap to 500,400
        private Canvass myCanvassInstance; //an instance of canvass class is declared
        private Command commandInstance; //an instance of command class is declared


        public Form1()
        {
            InitializeComponent();
            myCanvassInstance = new Canvass(Graphics.FromImage(OutputBitmap));
            commandInstance = new Command(myCanvassInstance, commandLine);
            myCanvassInstance.SetElementsSizes(OutputBitmap.Width, OutputBitmap.Height, OutputWindow.Width, OutputWindow.Height);
            OutputWindow.BackColor = Color.White;
            OutputWindow.Image = OutputBitmap;
        }

        //when text is changed this happens
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// once the program starts running - and an event occurs then this 
        /// method is used to pass commands to the object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            string[] InputStringArray = commandLine.Text.Trim().ToLower().Split(' ');
            String CommandString = InputStringArray[0];
            string[] ParamList = new string[0];
            if (InputStringArray.Length > 1) //check if there is greater than 1 string
            {
                ParamList = InputStringArray[1].Split(',');
            }
            //An if statement to check if the keyCode that is entered is equals to the enter button on keyboard
            if (e.KeyCode == Keys.Enter)
            {
                commandInstance.ProcessCommand(CommandString, ParamList);
                commandLine.Text = "";//clears command line
                OutputWindow.Refresh();
            }
        }

        /// <summary>
        /// all commands should be copied and printed onto this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InputWindow(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void movingObject_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //OutputWindow.Image = OutputBitmap;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunButton_Click(object sender, EventArgs e)
        {

        }






        /// <summary>
        /// When user clicks on save button ---
        /// --- a pop window appears which allows them to save their drawing ---
        /// --- in any folder they wish
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            saveFileDialog1.FileName = "Save Image";
            saveFileDialog1.Filter = "BMP|*.bmp";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                string savePath = saveFileDialog1.FileName;
                Bitmap OutputBitmap = new Bitmap(OutputWindow.Image);
                OutputBitmap.Save(savePath, ImageFormat.Bmp);
                MessageBox.Show("Image Saved");
            }
        }



        /// <summary>
        /// This method enables users to load up a file with ---
        /// --- bmp extension ontot the pictureTextBox screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (.bmp)|.Bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                OutputWindow.Image = Image.FromFile(dlg.FileName);
            }
            dlg.Dispose();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


    }
}