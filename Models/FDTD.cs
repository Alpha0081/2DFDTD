using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DFDTD.Models
{
    class FDTD
    {
        public FDTD(Grid G, int time)
        {
            for (int t = 0; t < time; ++t)
            {
                G.updateH();
                G.updateE();
            }
        }
    }
}
