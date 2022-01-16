using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProgrammingLanguageEnviroment
{
    class Canvass
    {   //
        Graphics g; //declaring an instance g
        public Pen drawingPen; //declaring an instance drawingPen
        public int xPosition, yPosition; //declare a type integer for xPosition and yPosition
        public int myPenSizeX = 0, myPenSizeY = 0; //penSize is declared and initialised to 0
        int sizeOfCanvassX = 0, sizeOfCanvassY = 0; //sizeOfCanvass is declared and initialised to 0
        public SolidBrush brush; //brush instance declared - part 1
        public bool fill = false; // fill instance set to false - part 1
        PictureBox pictureBox; //pictureBox instance declared - part 2
        public bool flashing, flashingSetBW, flashingSetBY, flashingSetRG; //declared instances for flash method - part 2

        /// <summary>
        /// constructor
        /// param "g" is set to this.g
        /// xPosition and yPosition is initiliased to 0
        /// drawingPen is given the value of a new pen with black colour and thickness of 3 
        /// moveto method is co-ordinated to initial position
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public Canvass(Graphics g, PictureBox pictureBox)
        {
            this.g = g;
            xPosition = yPosition = 0;
            drawingPen = new Pen(Color.Black, 3);
            this.pictureBox = pictureBox; //pictureBox set to pictureBox - part 2
            brush = new SolidBrush(Color.Transparent); //brush instance set to transparent color - part 1
            flashing = true; //flashing set to true - part 2
            MoveTo(0, 0);
        }

        /// <summary>
        /// non-arg constructor
        /// flashing instance set to false - part 2
        /// </summary>
        Canvass()
        {
            flashing = false;
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
        /// methods to flash colour dippending on the combination of the colors - part 2
        /// </summary>
        /// <param name="targetLocationX"></param>
        /// <param name="targetLocationY"></param>
        public void DrawTo(int targetLocationX, int targetLocationY)
        {
            void callFlashRG()
            {
                flashingLine(targetLocationX, targetLocationY, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            void callFlashBY()
            {
                flashingLine(targetLocationX, targetLocationY, Color.Blue, Color.Yellow);
            }
            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }

            void callFlashBW()
            {
                flashingLine(targetLocationX, targetLocationY, Color.Black, Color.White);
            }
            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }

            //else draw line in outputwindow
            else
            {
                g.DrawLine(drawingPen, xPosition, yPosition, targetLocationX, targetLocationY);
                xPosition = targetLocationX;
                yPosition = targetLocationY;
            }
        }

        /// <summary>
        /// this thread flashes the line - part 2
        /// </summary>
        /// <param name="targetLocationX"></param>
        /// <param name="targetLocationY"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingLine(int targetLocationX, int targetLocationY, Color color1, Color color2)
        {
            Pen drawingPen = new Pen(color2);

            while (flashing)
            {
                g.DrawLine(drawingPen, xPosition, yPosition, targetLocationX, targetLocationY);
                xPosition = targetLocationX;
                yPosition = targetLocationY;
                refreshSafe();
                Thread.Sleep(500);
                drawingPen.Color = color1;

                g.DrawLine(drawingPen, xPosition, yPosition, targetLocationX, targetLocationY);
                xPosition = targetLocationX;
                yPosition = targetLocationY;
                refreshSafe();
                Thread.Sleep(500);
                drawingPen.Color = color2;

            }
        }




        /// <summary>
        /// methods to flash colour dippending on the combination of the colors - part 2
        /// </summary>
        /// <param name="width"></param>
        public void DrawSquare(int width)
        {
            void callFlashRG() 
            {
                flashingSquare(width, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            void callFlashBY() 
            {
                flashingSquare(width, Color.Blue, Color.Yellow);
            }
            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }

            void callFlashBW()
            {
                flashingSquare(width, Color.Black, Color.White);
            }
            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }

            //else draw square in ouputwindow
            else
            {
                g.DrawRectangle(drawingPen, xPosition, yPosition, xPosition + width, yPosition + width);
                g.FillRectangle(brush, xPosition, yPosition, xPosition + width, yPosition + width); //fill rectangle with brush - part 1
            }
        }

        /// <summary>
        /// this thread flashes the line - part 2
        /// </summary>
        /// <param name="width"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingSquare(int width, Color color1, Color color2)
        {
            SolidBrush solidBrush = new SolidBrush(color2);

            while (flashing)
            {
                g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + width);
                refreshSafe();
                Thread.Sleep(500);
                solidBrush.Color = color1;

                g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + width);
                refreshSafe();
                Thread.Sleep(500);
                solidBrush.Color = color2;

            }
        }



        /// <summary>
        /// methods to flash colour dippending on the combination of the colors - part 2
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            void callFlashRG() 
            {
                flashingRectangle(width, height, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            void callFlashBY() 
            {
                flashingRectangle(width, height, Color.Blue, Color.Yellow);
            }
            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }

            void callFlashBW()
            {
                flashingRectangle(width, height, Color.Black, Color.White);
            }
            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }

            //else draw rectangle on the outputwindow
            else
            {
                g.DrawRectangle(drawingPen, xPosition, yPosition, xPosition + width, yPosition + height);
                g.FillRectangle(brush, xPosition, yPosition, xPosition + width, yPosition + height); //fill rectangle with brush - part 1
            }

        }

        /// <summary>
        /// this thread flashes the line - part 2
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingRectangle(int width, int height, Color color1, Color color2)
        {
            SolidBrush solidbrush = new SolidBrush(color2);

            while (flashing)
            {
                g.FillRectangle(solidbrush, xPosition, yPosition, xPosition + width, yPosition + height);
                refreshSafe();
                Thread.Sleep(500);
                solidbrush.Color = color1;

                g.FillRectangle(solidbrush, xPosition, yPosition, xPosition + width, yPosition + height);
                refreshSafe();
                Thread.Sleep(500);
                solidbrush.Color = color2;

            }
        }




        /// <summary>
        /// methods to flash colour dippending on the combination of the colors - part 2
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            void callFlashRG()
            {
                flashingTriangle(pointsToDraw, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            void callFlashBY()
            {
                flashingTriangle(pointsToDraw, Color.Blue, Color.Yellow);
            }
            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }

            void callFlashBW()
            {
                flashingTriangle(pointsToDraw, Color.Black, Color.White);
            }
            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }

            //else draw triangle on the outputwindow
            else
            {
                g.DrawPolygon(drawingPen, pointsToDraw);
                g.FillPolygon(brush, pointsToDraw); //fill Polygon with brush - part 1
            }

        }




        /// <summary>
        /// this thread flashes the line - part 2
        /// </summary>
        /// <param name="pointsToDraw"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingTriangle(PointF[] pointsToDraw, Color color1, Color color2)
        {
            SolidBrush solidbrush = new SolidBrush(color2);

            while (flashing)
            {
                g.FillPolygon(solidbrush, pointsToDraw);
                refreshSafe();
                Thread.Sleep(500);
                solidbrush.Color = color1;

                g.FillPolygon(solidbrush, pointsToDraw);
                refreshSafe();
                Thread.Sleep(500);
                solidbrush.Color = color2;
            }
        }




        /// <summary>
        /// methods to flash colour dippending on the combination of the colors - part 2
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(float radius)
        {
            void callFlashRG()
            {
                flashingCircle(radius, xPosition, yPosition, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            void callFlashBY()
            {
                flashingCircle(radius, xPosition, yPosition, Color.Blue, Color.Yellow);
            }
            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }

            void callFlashBW()
            {
                flashingCircle(radius, xPosition, yPosition, Color.Black, Color.White);
            }
            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }

            //else draw circle on the output window
            else
            {
                g.DrawEllipse(drawingPen, xPosition - radius, yPosition - radius, radius * 2, radius * 2);
                g.FillEllipse(brush, xPosition - radius, yPosition - radius, radius * 2, radius * 2); //fill Polygon with brush - part 1
            }

        }


        /// <summary>
        /// this thread flashes the line - part 2
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingCircle(float radius, int xPos, int yPos, Color color1, Color color2)
        {
            SolidBrush solidBrush = new SolidBrush(color2);

            while (flashing)
            {
                g.FillEllipse(solidBrush, xPos - radius, yPos - radius, radius * 2, radius * 2);
                refreshSafe();
                Thread.Sleep(500);
                solidBrush.Color = color1;

                g.FillEllipse(solidBrush, xPos - radius, yPos - radius, radius * 2, radius * 2);
                refreshSafe();
                Thread.Sleep(500);
                solidBrush.Color = color2;
            }
        }



        /// <summary>
        /// when refreshSafe method is invoked - the flashing color method is executed - part 2
        /// </summary>
        public void refreshSafe()
        {
            if (pictureBox.InvokeRequired)
            {
                Action safeRefresh = delegate { refreshSafe(); };
                pictureBox.Invoke(safeRefresh);
            }
            else
            {
                pictureBox.Refresh();
            }
        }

        /// <summary>
        /// fill shape with color when fillShape is invoked - part 1
        /// </summary>
        public void FillShape()
        {
            fill = !fill;
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
