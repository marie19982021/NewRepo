using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnviroment
{
    class Canvass
    {
        Graphics g; //declaring an instance g
        public Pen drawingPen; //declaring an instance drawingPen
        public int xPosition, yPosition; //declare a type integer for xPosition and yPosition
        public int myPenSizeX = 0, myPenSizeY = 0; //penSize is declared and initialised to 0
        int sizeOfCanvassX = 0, sizeOfCanvassY = 0; //sizeOfCanvass is declared and initialised to 0

        /// <summary>
        /// constructor
        /// param "g" is set to this.g
        /// xPosition and yPosition is initiliased to 0
        /// drawingPen is given the value of a new pen with black colour and thickness of 3 
        /// moveto method is co-ordinated to initial position
        /// </summary>
        /// <param name="g"></param>
        public Canvass(Graphics g)
        {
            this.g = g;
            xPosition = yPosition = 0;
            drawingPen = new Pen(Color.Black, 3);
            MoveTo(0, 0);
        }

        /// <summary>
        /// this method sets the element sizes for ---
        /// --- X/Y position of canvass and pen size
        /// </summary>
        /// <param name="myNewCanvasSizeX"></param>
        /// <param name="myNewCanvasSizeY"></param>
        /// <param name="myNewPenSizeX"></param>
        /// <param name="myNewPenSizeY"></param>
        public void SetElementsSizes(int myNewPenSizeX, int myNewPenSizeY, int myNewCanvasSizeX, int myNewCanvasSizeY)
        {
            myPenSizeX = myNewPenSizeX;
            myPenSizeY = myNewPenSizeY;
            sizeOfCanvassX = myNewCanvasSizeX;
            sizeOfCanvassY = myNewCanvasSizeY;
        }

        /// <summary>
        /// The x and y position is set to the new target position
        /// </summary>
        /// <param name="targetLocationX"></param>
        /// <param name="targetLocationY"></param>
        public void MoveTo(int targetLocationX, int targetLocationY)
        {
            xPosition = targetLocationX;
            yPosition = targetLocationY;
        }

        /// <summary>
        /// the new drawline position is set 
        /// </summary>
        /// <param name="targetLocationX"></param>
        /// <param name="targetLocationY"></param>
        public void DrawTo(int targetLocationX, int targetLocationY)
        {
            g.DrawLine(drawingPen, xPosition, yPosition, targetLocationX, targetLocationY);
            xPosition = targetLocationX;
            yPosition = targetLocationY;
        }

        /// <summary>
        /// sets the position of a square and draws
        /// </summary>
        /// <param name="width"></param>
        public void DrawSquare(int width)
        {
            g.DrawRectangle(drawingPen, xPosition, yPosition, xPosition + width, yPosition + width);
        }

        /// <summary>
        /// sets the position of a rectangle and draws
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(drawingPen, xPosition, yPosition, xPosition + width, yPosition + height);
        }

        /// <summary>
        /// sets the position of a triangle and draws
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            g.DrawPolygon(drawingPen, pointsToDraw);
        }

        /// <summary>
        /// sets the position of a circle and draws
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(float radius)
        {
            g.DrawEllipse(drawingPen, xPosition - radius, yPosition - radius, radius*2,radius*2);
        }

        /// <summary>
        /// clears drawing by cover it with a white colour
        /// </summary>
        public void ClearDrawing()
        {
            g.Clear(Color.White);
        }

        /// <summary>
        /// resets the postion of x and y and moves it to (50,50) co-ordination
        /// </summary>
        public void ResetPenPosition()
        {
            MoveTo(50, 50);
        }

    }
}
