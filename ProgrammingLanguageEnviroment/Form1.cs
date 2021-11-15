using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnviroment
{
    public partial class Form1 : Form
    {
        private Bitmap OutputBitmap = new Bitmap(500, 400); //size of bitmap
        private Canvass myCanvassInstance; //an instance of Canvass class
        private Command commandInstance; //an instance of Command class


        public Form1()
        {
            InitializeComponent();
            myCanvassInstance = new Canvass(Graphics.FromImage(OutputBitmap)); 
            commandInstance = new Command(myCanvassInstance, commandLine);
            myCanvassInstance.SetElementsSizes(OutputBitmap.Width, OutputBitmap.Height, OutputWindow.Width, OutputWindow.Height);
            //Form1.Controls.Add(OutputWindow);
            OutputWindow.BackColor = Color.White;
            //OutputWindow.Location = new Point(mainCanvasInstance.xPos - OutputBitmap.Width / 2, mainCanvasInstance.yPos - OutputBitmap.Height / 2);
            OutputWindow.Image = OutputBitmap;
        }

        //when text is changed this happens
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sets up a process method where lines of commands is passed to the object
        /// The method is called when an event occurs after the program is ran
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            string[] InputStringArray = commandLine.Text.Trim().ToLower().Split(' ');
            String CommandString = InputStringArray[0];
            string[] ParamList = new string[0];
            if (InputStringArray.Length > 1) //check is there is greater than 1 string
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
            //OutputWindow.Location = new Point(mainCanvasInstance.xPos - OutputWindow.Width / 2, mainCanvasInstance.yPos - OutputWindow.Height/ 2);
        }

        /// <summary>
        /// After typing commands into commandLine, the command should be copied and ---
        /// --- be printed onto this inputWindow
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
    }
}
