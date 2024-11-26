using System;
using System.Numerics;
using System.Text.RegularExpressions;
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

        public class MyFrac: IMyNumber<MyFrac>, IComparable<MyFrac>
        {
            public BigInteger nom, denom;

            public MyFrac(BigInteger nom, BigInteger denom)
            {
                if (denom == 0) throw new DivideByZeroException("Denominator cannot be zero");
                if (denom < 0)
                {
                    nom *= -1;
                    denom *= -1;
                }
                BigInteger k = BigInteger.GreatestCommonDivisor(nom, denom);
                if (k < 0) k *= -1;
                this.nom = nom / k;
                this.denom = denom / k;
            }

            public MyFrac(string data)
            {
                Regex r = new Regex(@"-?\d+\/-?\d+");
                if (r.IsMatch(data))
                {
                    string[] data1 = data.Trim().Split("/", StringSplitOptions.RemoveEmptyEntries);
                    MyFrac l = new MyFrac(BigInteger.Parse(data1[0]), BigInteger.Parse(data1[1]));
                    this.nom = l.nom;
                    this.denom = l.denom;
                }
                else throw new ArgumentException("Input string is not in the correct format");
            }

            public override string ToString()
            {
                return $"{nom}/{denom}";
            }

            public MyFrac Add(MyFrac that)
            {
                return new MyFrac(this.nom * that.denom + that.nom * this.denom, this.denom * that.denom);
            }

            public MyFrac Subtract(MyFrac that)
            {
                return new MyFrac(this.nom * that.denom - that.nom * this.denom, this.denom * that.denom);
            }

            public MyFrac Multiply(MyFrac that)
            {
                return new MyFrac(this.nom * that.nom, this.denom * that.denom);
            }

            public MyFrac Divide(MyFrac that)
            {
                return new MyFrac(this.nom * that.denom, this.denom * that.nom);
            }

            public int CompareTo(MyFrac other)
            {
                return (this.nom /this.denom).CompareTo(other.nom / other.denom);
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

            public MyComplex(string data)
            {
                Regex r = new Regex(@"^(-?\d+(\.\d+)?)([+-]\d+(\.\d+)?)i$");
                if (r.IsMatch(data))
                {
                    Match match = r.Match(data);
                    this.real = double.Parse(match.Groups[1].Value);
                    this.imaginary = double.Parse(match.Groups[3].Value);
                }
                else throw new ArgumentException("Input string is not in the correct format");
            }

            public override string ToString()
            {
                return $"{real}+{imaginary}i";
            }

            public MyComplex Add(MyComplex that)
            {
                return new MyComplex(this.real + that.real, this.imaginary + that.imaginary);
            }

            public MyComplex Subtract(MyComplex that)
            {
                return new MyComplex(this.real - that.real, this.imaginary - that.imaginary);
            }

            public MyComplex Multiply(MyComplex that)
            {
                return new MyComplex(this.real * that.real - this.imaginary * that.imaginary, this.real * that.imaginary + this.imaginary * that.real);
            }

            public MyComplex Divide(MyComplex that)
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

        static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("a - b = " + aMinusB);
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Subtract(curr);
            curr = a.Add(b);
            Console.WriteLine("a+b = " + curr);
            wholeRightPart = wholeRightPart.Divide(curr);
            Console.WriteLine("(a^2-b^2)/(a+b) = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing a-b=(a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");
        }

        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
            TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

            MyFrac[] array = new MyFrac[] { new MyFrac(2, 6), new MyFrac(2, 1), new MyFrac(83, -2) };
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
}