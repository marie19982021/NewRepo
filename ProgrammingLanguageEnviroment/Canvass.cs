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

        /// <summary>
        /// creating an object g of Graphics
        /// declaring xPosition and yPosition as an int
        /// declaring and initializing penSizeX, sizeOfCanvassX and penSizeY,sizeOfCanvassY to 0
        /// 
        /// </summary>
        Graphics g;
        public Pen drawingPen;
        public int xPosition, yPosition;
        public int myPenSizeX = 0, myPenSizeY = 0;
        int sizeOfCanvassX = 0, sizeOfCanvassY = 0;

        /// <summary>
        /// constructor
        /// this.g is set g
        /// drawingPen is set to new pen with color black and level of pen thickness is set to 3
        /// MoveTo method is set to (0,0) position
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
        /// the initial sizes for the canvas and pensize within the X and Y coordinates
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
        /// The initial X and Y drawing position is set to a new target co-ordinates
        /// </summary>
        /// <param name="targetLocationX"></param>
        /// <param name="targetLocationY"></param>
        public void MoveTo(int targetLocationX, int targetLocationY)
        {
            xPosition = targetLocationX;
            yPosition = targetLocationY;
        }

        /// <summary>
        /// The DrawTo method moves the pen's drawing location to a new target location
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
        /// draws a square shape
        /// </summary>
        /// <param name="width"></param>
        public void DrawSquare(int width)
        {
            g.DrawRectangle(drawingPen, xPosition, yPosition, xPosition + width, yPosition + width);
        }

        /// <summary>
        /// draws a rectangle shape
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(drawingPen, xPosition, yPosition, xPosition + width, yPosition + height);
        }

        /// <summary>
        /// draws a trangle shape
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            g.DrawPolygon(drawingPen, pointsToDraw);
        }

        /// <summary>
        /// draws a circle shape
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(float radius)
        {
            g.DrawEllipse(drawingPen, xPosition - radius, yPosition - radius, radius*2,radius*2);
        }

        /// <summary>
        /// ClearDrawing() nethod clears any drawing in the picture box by coloring it white
        /// </summary>
        public void ClearDrawing()
        {
            g.Clear(Color.White);
        }

        /// <summary>
        /// Resets the position of the pen by moving the pen to (50,50) location
        /// </summary>
        public void ResetPenPosition()
        {
            MoveTo(50, 50);
        }



    }
}
