using System;
namespace UnityUtilities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new WorldMatrix<int>(new int[,]{ { 1, 2, 3 }, { 4, 5, 6 } }));
            Console.WriteLine(new WorldMatrix<int>(new int[,] { }));
            Console.WriteLine(new WorldMatrix<int>(new int[,] { { 1, 2, 3 } }));

            WorldMatrix<float> worldMatrix = new WorldMatrix<float>(new float[,] { {1.1f, 2.2f, 3.3f}, {4.4f, 5.5f, 6.6f}, {7.7f, 8.9f, 9.9f}});
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


            WorldMatrix<char> colMatrix = new WorldMatrix<char>(new char[,] { { 'a' }, { 'b' }, { 'c' }, { 'd' } } );
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
