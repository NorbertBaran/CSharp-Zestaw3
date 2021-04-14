using System;

namespace Cw3{

    class Zadanie3_6{
        public static void Main6(String[] args){
            Matrix<double> m1 = new Matrix<double>(2, 3);
            m1[0,0] = 1.2;
            m1[0,1] = 9.1;
            m1[0,2] = 3.4;

            m1[1,0] = 1.2;
            m1[1,1] = 9.1;
            m1[1,2] = 3.4;

            Console.WriteLine("m1: ");
            Console.WriteLine(m1);

            Matrix<int> m2 = new Matrix<int>( new [,] { {1, 8, 3, 12, 7}, {1, 8, 3, 12, 7} });

            Console.WriteLine("m2: ");
            Console.WriteLine(m2);

            Matrix<int> m3 = new Matrix<int>( new [,] { {3, 5, 2, 1, 8}, {3, 5, 2, 1, 8} });

            Console.WriteLine("m3: ");
            Console.WriteLine(m3);

            Matrix<int> m4 = m2 + m3;

            Console.WriteLine("m4: ");
            Console.WriteLine(m4);

            Matrix<int> m5 = new Matrix<int>(new [,] { {1, 2, 1}, {2, 3, 1} });

            Console.WriteLine("m5: ");
            Console.WriteLine(m5);

            Matrix<int> m6 = new Matrix<int>(new [,] { {2, 1, 3}, {1, 4, 1}, {3, 2, 1} });

            Console.WriteLine("m6: ");
            Console.WriteLine(m6);

            Matrix<int> m7 = m5 * m6;

            Console.WriteLine("m7: ");
            Console.WriteLine(m7);

            try{
                SquareMatrix<int> m8 = new SquareMatrix<int>(new [,] { {2, 1, 3}, {1, 4, 1} });
            }catch(InvalidMatrixException){
                Console.WriteLine("Argmument is not square table");
            }
            
            SquareMatrix<int> m9 = new SquareMatrix<int>(new [,] { {2, 1, 3}, {1, 4, 1}, {3, 2, 1} });

            Console.WriteLine("Is m9 diagonal:");
            Console.WriteLine(m9.isDiagonal());

            SquareMatrix<int> m10 = new SquareMatrix<int>(new [,] { {2, 0, 0}, {0, 4, 0}, {0, 0, 1} });

            Console.WriteLine("Is m10 diagonal:");
            Console.WriteLine(m10.isDiagonal());
            
        }
    }

    [Serializable]
    class InvalidMatrixException : Exception{
        public InvalidMatrixException(){}
        public InvalidMatrixException(string name) : base(String.Format("Invalid Matrix Exception Name: {0}", name)) {}
    }

    class Matrix<T> where T : IEquatable<T>{
        protected T[,] MatrixTable;

        public Matrix(int rowCount, int columnCount){
            MatrixTable = new T[rowCount, columnCount];
        }

        public Matrix(T[,] matrix){
            MatrixTable = (T[,]) matrix.Clone();
        }

        public int GetLength(int dimension){
            return MatrixTable.GetLength(dimension);
        }

        public T this[int i, int j]{
            get{ return MatrixTable[i, j]; }
            set{ MatrixTable[i, j] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> A, Matrix<T> B){
            if(A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
                throw new InvalidMatrixException("Different size of added matrix");
            Matrix<T> sum = new Matrix<T>(A.GetLength(0), A.GetLength(1));

            for(int i=0; i<A.GetLength(0); i++){
                for(int j=0; j<A.GetLength(1); j++){
                    dynamic a = A[i,j];
                    dynamic b = B[i,j];
                    sum[i, j] = a + b;
                }
            }

            return sum;
        }

        public static Matrix<T> operator *(Matrix<T> A, Matrix<T> B){
            if(A.GetLength(1) != B.GetLength(0))
                throw new InvalidMatrixException("Not maching sizes to multiply matrix");
            Matrix<T> mult = new Matrix<T>(A.GetLength(0), B.GetLength(1));
            
            for(int i=0; i<A.GetLength(0); i++){
                for(int j=0; j<B.GetLength(1); j++){
                    //Type type = typeof(T);
                    //dynamic score = Activator.CreateInstance(type);
                    dynamic a0 = A[i,0];
                    dynamic b0 = B[0,j];
                    dynamic score = a0 * b0;
                    for(int k=1; k<A.GetLength(1); k++){
                        dynamic a = A[i,k];
                        dynamic b = B[k,j];
                        dynamic c = a * b;
                        score = score + c;
                    }
                    mult[i,j] = score;
                }
            }
            
            return mult;
        }

        override
        public string ToString(){
            string s="";
            for(int i=0; i<this.GetLength(0); i++){
                for(int j=0; j<this.GetLength(1); j++)
                    s+=String.Format("{0} ", this[i,j]);
                s+="\n";
            }
            return s;
        }

    }

    class SquareMatrix<T> : Matrix<T> where T : IEquatable<T>{
        
        public SquareMatrix(int width) : base(width, width){}
        public SquareMatrix(T[,] matrix) : base(matrix){
            if(matrix.GetLength(0) != matrix.GetLength(1))
                throw new InvalidMatrixException("Argmument is not square table");
        }

        public bool isDiagonal(){
            for(int i=0; i<base.MatrixTable.GetLength(0); i++){
                for(int j=0; j<base.MatrixTable.GetLength(1); j++){
                    dynamic val = base.MatrixTable[i,j];
                    if(i!=j && val!=0)
                        return false;
                } 
            }
            return true;
        }

    }

}