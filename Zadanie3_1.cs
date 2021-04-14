using System;

namespace Cw3
{
    class Zadanie3_1
    {
        static void Main1(string[] args)
        {
            Zadanie3_1 zadanie3_1 = new Zadanie3_1();
            zadanie3_1.Method(new Rectangle(5, 10));
            zadanie3_1.Method(new Square(5));
            zadanie3_1.Method(new Square(10));
        }

        public void Method(Rectangle r){
            int width = r.Width;
            int height = r.Height;
            int area = r.GetArea();
            Console.WriteLine("Width: {0}, Height: {1}, Area: {2}", width, height, area);
        }
    }

    class Rectangle{
        public Rectangle(int width, int height){
            this.Width = width;
            this.Height = height;
        }

        public int Height{get;}
        public int Width{get;}

        public int GetArea(){
            return Width * Height;
        }
    }

    class Square: Rectangle{
        public Square(int width) : base(width, width) {}
    }

}
