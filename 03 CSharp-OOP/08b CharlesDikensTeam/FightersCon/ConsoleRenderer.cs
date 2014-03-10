using System;
using System.Linq;
using System.Text;

namespace FightersCon
{
    public class ConsoleRenderer : IRenderer 
    {
        readonly int renderContextMatrixRows; // the size of the console:
        readonly int renderContextMatrixCols;
        readonly char[,] renderContextMatrix;
        readonly int menuOffset; // defines the current info board throughout the game process

        public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols, int rowsOffset) // constructor - we create a new object of the ConsoleRenderer class
        {
            renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

            this.renderContextMatrixRows = renderContextMatrix.GetLength(0);
            this.renderContextMatrixCols = renderContextMatrix.GetLength(1);
            this.menuOffset = rowsOffset;
            this.ClearQueue();
        }

        public void EnqueueForRendering(IRenderable obj) // this method adds an object for visualization.
        {
            char[,] objImage = obj.GetImage();

            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);

            MatrixCoords objTopLeft = obj.GetTopLeft(); // we extract the top left point from the object itself.

            int lastRow = Math.Min(objTopLeft.Row + imageRows, this.renderContextMatrixRows); // prevents us from getting out of the console.
            int lastCol = Math.Min(objTopLeft.Col + imageCols, this.renderContextMatrixCols); // prevents us from getting out of the console.

            for (int row = obj.GetTopLeft().Row; row < lastRow; row++)
            {
                for (int col = obj.GetTopLeft().Col; col < lastCol; col++)
                {
                    if (row >= 0 && row < renderContextMatrixRows &&
                            col >= 0 && col < renderContextMatrixCols)
                    {
                        renderContextMatrix[row, col] = objImage[row - obj.GetTopLeft().Row, col - obj.GetTopLeft().Col];
                    }
                }
            }
        }

        public void RenderAll() // this method visualizes all objects currently on the console by converting all their symbols into a StringBuilder which is printed on the console.
        {
            var scene = new StringBuilder();

            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    scene.Append(this.renderContextMatrix[row, col]);
                }
                if (row != renderContextMatrixRows - 1)
                    scene.Append(Environment.NewLine);
            }

            //scene.Append(Ship.GetDetail()); // the addition of the information board.

            Console.SetCursorPosition(0, 0); // placing the cursor at the top left position of the console for printing the next scene.
            Console.Write(scene); // the final printing on the console.
        }

        public void ClearQueue() // clearing the matrix which includes all the symbols of all objects.
        {
            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    this.renderContextMatrix[row, col] = ' ';
                }
            }
        }
    }
}
