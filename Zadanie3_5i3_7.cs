using System;

namespace Cw3{

    class Zadanie3_5{
        public static void Main5(String[] args){
            Complex<int, int> c1 = new Complex<int, int>(5, 3);
            Complex<double, double> c2 = new Complex<double, double>(1.2, 3.4);

            Console.WriteLine(c1.Real);
            Console.WriteLine(c1.Imaginary);
            Console.WriteLine(c1);

            Console.WriteLine(c2.Real);
            Console.WriteLine(c2.Imaginary);
            Console.WriteLine(c2);
        }
    }

    class Zadanie3_7{
        public static void Main7(String[] args){

            Complex<int, int> c1 = new Complex<int, int>(2, 0);
            Complex<int, int> c2 = new Complex<int, int>(1, 0);
            Complex<int, int> c3 = new Complex<int, int>(1, 0);
            Complex<int, int> c4 = new Complex<int, int>(3, 0);
            Complex<int, int> c5 = new Complex<int, int>(1, 0);
            Complex<int, int> c6 = new Complex<int, int>(2, 0);

            Matrix<Complex<int, int>> m1 = new Matrix<Complex<int, int>>(new [,]{
                {c1, c2},
                {c3, c4}
            });

            Matrix<Complex<int, int>> m2 = new Matrix<Complex<int, int>>(new [,]{
                {c5},
                {c6}
            });

            Matrix<Complex<int, int>> m3 = m1 * m2;

            Console.WriteLine(m3.ToString());
        }
    }

    class Complex<Re, Im> : IEquatable<Complex<Re, Im>>{
        public Re Real{get;}
        public Im Imaginary{get;}

        public Complex(){
            Real = default(Re);
            Imaginary = default(Im);
        }

        public Complex(Re real, Im imaginary){
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex<Re, Im> operator +(Complex<Re, Im> A, Complex<Re, Im> B){
            dynamic aRe = A.Real;
            dynamic aIm = A.Imaginary;
            dynamic bRe = B.Real;
            dynamic bIm = B.Imaginary;
            return new Complex<Re, Im>(aRe+bRe, aIm+bIm);
        }

        public static Complex<Re, Im> operator *(Complex<Re, Im> A, Complex<Re, Im> B){
            dynamic aRe = A.Real;
            dynamic aIm = A.Imaginary;
            dynamic bRe = B.Real;
            dynamic bIm = B.Imaginary;
            return new Complex<Re, Im>(aRe*bRe - aIm*bIm, aIm*bRe + aRe*bIm);
        }

        override
        public String ToString(){
            return String.Format("({0}; {1})", Real, Imaginary);
        }

        public bool Equals(Complex<Re, Im> o){
            if(this.ToString() == o.ToString())
                return true;
            return false;
        }

    }
}