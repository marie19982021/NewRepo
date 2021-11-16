using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnviroment
{
    class Command
    {
        private Canvass myCanvassInstance; //declaring an instance of canvass class
        private RichTextBox commandLine; //declaring an instance of RichTextBox

        /// <summary>
        /// constructor for the command class
        /// </summary>
        /// <param name="myCanvasInstance"></param>
        /// <param name="CommandLine"></param>
        public Command(Canvass myCanvasInstance, RichTextBox CommandLine)
        {
            myCanvassInstance = myCanvasInstance;
            commandLine = CommandLine;
        }

        /// <summary>
        /// A switch statement within the processCommand method to
        /// process what the user will type
        /// </summary>
        /// <param name="CommandString"></param>
        /// <param name="ParamList"></param>
        public void ProcessCommand(string CommandString, string[] ParamList)
        {
            switch (CommandString)
            {
                case "drawto": //lets the user to draw using the digital pen
                    DrawTo(ParamList);
                    break;
                case "moveto": //allows the user to move the pen to a target co-ordinate
                    MoveTo(ParamList);
                    break;
                case "square": //allows user to draw a square onto pictureBox
                    myCanvassInstance.DrawSquare(25);
                    break;
                case "rect": //allows user to draw a retangle onto pictureBox
                    DrawRect(ParamList);
                    break;
                case "circle": //allows user to draw a circle onto pictureBox
                    DrawCircle(ParamList);
                    break;
                case "triangle": //allows user to draw a triangle onto pictureBox
                    DrawTriangle();
                    break;
                case "clear": //allows user clear whatever is on the pictureBox window
                    myCanvassInstance.ClearDrawing();
                    break;
                case "pencolour": //allows user to choose a pen colour of their choice
                    ChangePenColour(ParamList);
                    break;
                case "reset": //allows user to reset the output window and resets the pen position
                    ResetPenPosition();
                    break;
                default: //if command is invalid then show this error message!
                    MessageBox.Show(CommandString + "invalid command. Try again.");
                    break;
            }
        }

        /// <summary>
        /// The drawTo method
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawTo(string[] ParamList)
        {
            if (ParamList.Length == 2)
            {
                int x, y = 0;
                try
                {
                    x = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }
                try
                {
                    y = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }
                myCanvassInstance.DrawTo(x, y);
            }
            else
            {
                MessageBox.Show("The right format for drawto is: 100,200");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// moveTo method
        /// </summary>
        /// <param name="ParamList"></param>
        private void MoveTo(string[] ParamList)
        {
            if (ParamList.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                myCanvassInstance.MoveTo(x, y);
            }
            else
            {
                MessageBox.Show("The right format for moveTo is: 100,200");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// Draw rectangle method
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawRect(string[] ParamList)
        {
            if (ParamList.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                myCanvassInstance.DrawRectangle(x, y);
            }
            else
            {
                MessageBox.Show("The right format for the rectangle shape is: 100,200");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawCircle(string[] ParamList)
        {
            // Check we have been given the x and y
            if (ParamList.Length == 1)
            {
                int r = 0;

                try
                {
                    r = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Not able to parse parameter " + ParamList[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                myCanvassInstance.DrawCircle(r);
            }
            else
            {
                MessageBox.Show("The right format for shape circle is: 10");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// instance point1, point2, point3 for all three sides of triangle 
        /// </summary>
        private void DrawTriangle()
        {
            PointF point1 = new PointF(25.0f+ myCanvassInstance.xPosition-25, 0.0f + myCanvassInstance.yPosition - 25);
            PointF point2 = new PointF(50.0F + myCanvassInstance.xPosition-25, 50.0F + myCanvassInstance.yPosition- 25);
            PointF point3 = new PointF(0 + myCanvassInstance.xPosition- 25, 50.0f + myCanvassInstance.yPosition- 25);

            PointF[] trianglePoints =
            {
                    point1,
                    point2,
                    point3,
                     };
            myCanvassInstance.DrawTriangle(trianglePoints);
        }

        /// <summary>
        /// a switch statement used to let user choose one of 4 colours 
        /// mentioned in the statement and allows the user to draw in that colour
        /// </summary>
        /// <param name="ParamList"></param>
        private void ChangePenColour(string[] ParamList)
        {
            if (ParamList.Length == 1)
            {
                string c = ParamList[0];
                switch (c)
                {
                    case "black":
                        myCanvassInstance.drawingPen.Color = Color.Black;
                        break;
                    case "green":
                        myCanvassInstance.drawingPen.Color = Color.Green;
                        break;
                    case "pink":
                        myCanvassInstance.drawingPen.Color = Color.Pink;
                        break;
                    case "purple":
                        myCanvassInstance.drawingPen.Color = Color.Purple;
                        break;
                }
            }
            else
            {
                MessageBox.Show("use right format for cicle such as: 10, 15, 50");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// resets the position of the pen to (0,0)
        /// </summary>
        private void ResetPenPosition()
        {
            myCanvassInstance.MoveTo(0, 0);
        }
    }
}
