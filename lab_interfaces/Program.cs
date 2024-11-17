using System;
using System.Numerics;

namespace lab_interfaces
{
    public class Program
    {
        public interface IMyNumber<T> where T : IMyNumber<T>
        {
            T Add(T b);
            T Subtract(T b);
            T Multiply(T b);
            T Divide(T b);
        }

        public class MyFrac: IMyNumber<MyFrac>
        {
            public int nom, denom;
            public MyFrac(int nom, int denom)
            {
                if (denom < 0)
                {
                    nom *= -1;
                    denom *= -1;
                }
                int k = Evklid(nom, denom);
                if (k < 0) k *= -1;
                this.nom = nom / k;
                this.denom = denom / k;
            }
            private static int Evklid(int f, int s)
            {
                while (s != 0)
                {
                    int temp = s;
                    s = f % s;
                    f = temp;
                }
                return f;
            }
            public override string ToString()
            {
                return $"{nom}/{denom}";
            }

            MyFrac IMyNumber<MyFrac>.Add(MyFrac that)
            {
                return new MyFrac(this.nom * that.denom + that.nom * this.denom, this.denom * that.denom);
            }

            MyFrac IMyNumber<MyFrac>.Subtract(MyFrac that)
            {
                return new MyFrac(this.nom * that.denom - that.nom * this.denom, this.denom * that.denom);
            }

            MyFrac IMyNumber<MyFrac>.Multiply(MyFrac that)
            {
                return new MyFrac(this.nom * that.nom, this.denom * that.denom);
            }

            MyFrac IMyNumber<MyFrac>.Divide(MyFrac that)
            {
                return new MyFrac(this.nom * that.denom, this.denom * that.nom);
            }
        }

        public class MyComplex : IMyNumber<MyComplex>
        {
            public double real, imaginary;
            public MyComplex(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public override string ToString()
            {
                return $"{real}+{imaginary}i";
            }

            MyComplex IMyNumber<MyComplex>.Add(MyComplex that)
            {
                return new MyComplex(this.real + that.real, this.imaginary + that.imaginary);
            }

            MyComplex IMyNumber<MyComplex>.Subtract(MyComplex that)
            {
                return new MyComplex(this.real - that.real, this.imaginary - that.imaginary);
            }

            MyComplex IMyNumber<MyComplex>.Multiply(MyComplex that)
            {
                return new MyComplex(this.real * that.real - this.imaginary * that.imaginary, this.real * that.imaginary + this.imaginary * that.real);
            }

            MyComplex IMyNumber<MyComplex>.Divide(MyComplex that)
            {
                return new MyComplex((this.real * that.real + this.imaginary * that.imaginary)/(that.real*that.real+that.imaginary*that.imaginary),
                    (this.imaginary * that.real - this.real * that.imaginary)/ (that.real * that.real + that.imaginary * that.imaginary));
            }
        }
        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            // I'm not sure how to create constant factor "2" in more elegant way,
            // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            Console.ReadKey();
        }
    }
}