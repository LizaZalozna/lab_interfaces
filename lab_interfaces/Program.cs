using System;
using System.Numerics;

namespace interfaces
{
    class Program
    {
        interface IMyNumber<T> where T : IMyNumber<T>
        {
            T Add(T b);
            T Subtract(T b);
            T Multiply(T b);
            T Divide(T b);
        }

        class MyFrac: IMyNumber<MyFrac>
        {
            private int nom, denom;
            public MyFrac(int nom, int denom)
            {
                this.nom = nom;
                this.denom = denom;
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

        class MyComplex : IMyNumber<MyComplex>
        {
            private int real, imaginary;
            public MyComplex(int real, int imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
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
    }
}