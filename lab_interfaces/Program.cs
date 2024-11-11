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

    }
}