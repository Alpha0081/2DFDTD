using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DFDTD.Models
{
    class FT
    {
        public static Complex[] FFT_rec(Complex[] x)
        {
            Complex t;
            int N = x.Length;
            if (N <= 1)
            {
                return new Complex[1] { x[0] };
            }
            Complex[] odd = new Complex[N / 2];
            Complex[] even = new Complex[N / 2];
            for (int i = 0; i < N / 2; ++i)
            {
                even[i] = x[i * 2];
                odd[i] = x[i * 2 + 1];
            }

            even = FFT_rec(even);
            odd = FFT_rec(odd);
            for (int k = 0; k < N / 2; ++k)
            {
                t = Complex.Exp(-2 * Math.PI * k / N) * odd[k];
                x[k] = even[k] + t;
                x[N / 2 + k] = even[k] - t;
            }
            return x;
        }
        public static Complex[] FFT(double[] array)
        {
            int N = array.Length;
            Complex[] t_array = new Complex[N];
            for (int i = 0; i < N; ++i)
            {
                t_array[i] = (Complex)array[i];
            }
            return FFT_rec(t_array);
        }

    }
}
