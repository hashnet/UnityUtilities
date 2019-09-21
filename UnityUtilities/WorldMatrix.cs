using System;
using System.Collections.Generic;
using System.Text;

namespace UnityUtilities
{
    class WorldMatrix<T>
    {
        private T[,] matrix;
        private int nRow;
        private int nCol;
        private int left;
        private int right;
        private int top;
        private int bottom;

        public WorldMatrix(T[,] matrix)
        {
            this.matrix = matrix;

            nRow = matrix.GetLength(0);
            nCol = matrix.GetLength(1);

            left = top = 0;
            right = nCol - 1;
            bottom = nRow - 1;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");

            bool firstRow = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (firstRow)
                {
                    firstRow = false;
                } else
                {
                    sb.Append(Environment.NewLine + " ");
                }

                bool firstCol = true;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (firstCol)
                    {
                        sb.Append("[");
                        firstCol = false;
                    } else
                    {
                        sb.Append(", ");
                    }

                    sb.Append(matrix[i, j]);
                }
                sb.Append("]");
            }
            sb.Append("]");

            sb.Append(Environment.NewLine);
            if (nRow == 0)
            {
                sb.Append("L=n/a, R=n/a, T=n/a, B=n/a");
            } else { 
                sb.Append(String.Format("L={0}, R={1}, T={2}, B={3}", left, right, top, bottom));
            }

            return sb.ToString();
        }

         public delegate void Action(ref T obj);

        public void ApplyOnLeftColumn(Action action)
        {
            for (int i = 0; i < nRow; i++)
            {
                action(ref matrix[i, left]);
            }
        }

        public void ApplyOnRightColumn(Action action)
        {
            for (int i = 0; i < nRow; i++)
            {
                action(ref matrix[i, right]);
            }
        }

        public void ApplyOnTopRow(Action action)
        {
            for (int j = 0; j < nCol; j++)
            {
                action(ref matrix[top, j]);
            }
        }

        public void ApplyOnBottomRow(Action action)
        {
            for (int j = 0; j < nCol; j++)
            {
                action(ref matrix[bottom, j]);
            }
        }

        public IEnumerable<T> GetLeftColumn()
        {
            for(int i=0; i<nRow; i++)
            {
                yield return matrix[i, left];
            }
        }

        public IEnumerable<T> GetRightColumn()
        {
            for (int i = 0; i < nRow; i++)
            {
                yield return matrix[i, right];
            }
        }

        public IEnumerable<T> GetTopRow()
        {
            for(int j = 0; j < nCol; j++)
            {
                yield return matrix[top, j];
            }
        }

        public IEnumerable<T> GetBottomRow()
        {
            for (int j = 0; j < nCol; j++)
            {
                yield return matrix[bottom, j];
            }
        }

        public String GetBorderAsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("L:[");
            sb.Append(String.Join((", "), GetLeftColumn()));
            sb.Append("], R:[");
            sb.Append(String.Join((", "), GetRightColumn()));
            sb.Append("], T:[");
            sb.Append(String.Join((", "), GetTopRow()));
            sb.Append("], B:[");
            sb.Append(String.Join((", "), GetBottomRow()));
            sb.Append("]");

            return sb.ToString();
        }

        public void TransferLeftToRight()
        {
            right = left;
            left = (left + 1) % nCol;
        }

        public void TransferRightToLeft()
        {
            left = right;
            right = (right - 1 + nCol) % nCol;
        }

        public void TransferTopToBottom()
        {
            bottom = top;
            top = (top + 1) % nRow;
        }

        public void TransferBottomToTop()
        {
            top = bottom;
            bottom = (bottom - 1 + nRow) % nRow;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine(new WorldMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }));
            Console.WriteLine(new WorldMatrix<int>(new int[,] { }));
            Console.WriteLine(new WorldMatrix<int>(new int[,] { { 1, 2, 3 } }));

            WorldMatrix<float> worldMatrix = new WorldMatrix<float>(new float[,] { { 1.1f, 2.2f, 3.3f }, { 4.4f, 5.5f, 6.6f }, { 7.7f, 8.9f, 9.9f } });
            Console.WriteLine(worldMatrix);
            worldMatrix.ApplyOnRightColumn((ref float item) => { ++item; });
            Console.WriteLine(worldMatrix);
            worldMatrix.ApplyOnBottomRow((ref float item) => { --item; });
            Console.WriteLine(worldMatrix);

            Console.WriteLine("Left Column: " + String.Join(", ", worldMatrix.GetLeftColumn()));
            Console.Write("Top Row: ");
            foreach (float f in worldMatrix.GetTopRow())
            {
                Console.Write(f + ", ");
            }
            Console.WriteLine();

            WorldMatrix<char> charMatrix = new WorldMatrix<char>(new char[,] { { 'a', 'b', 'c', 'd' } });
            Console.WriteLine("Original:");
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            Console.WriteLine("Left to right shifts:");
            charMatrix.TransferLeftToRight();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferLeftToRight();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferLeftToRight();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferLeftToRight();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferLeftToRight();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            Console.WriteLine("Right to left shifts:");
            charMatrix.TransferRightToLeft();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferRightToLeft();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferRightToLeft();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferRightToLeft();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferRightToLeft();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());
            charMatrix.TransferRightToLeft();
            Console.WriteLine(charMatrix);
            Console.WriteLine(charMatrix.GetBorderAsString());


            WorldMatrix<char> colMatrix = new WorldMatrix<char>(new char[,] { { 'a' }, { 'b' }, { 'c' }, { 'd' } });
            Console.WriteLine("Original:");
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            Console.WriteLine("Top to bottok shifts:");
            colMatrix.TransferTopToBottom();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferTopToBottom();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferTopToBottom();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferTopToBottom();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferTopToBottom();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            Console.WriteLine("Right to left shifts:");
            colMatrix.TransferBottomToTop();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferBottomToTop();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferBottomToTop();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferBottomToTop();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferBottomToTop();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
            colMatrix.TransferBottomToTop();
            Console.WriteLine(colMatrix);
            Console.WriteLine(colMatrix.GetBorderAsString());
        }
    }
}
