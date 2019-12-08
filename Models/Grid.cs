using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DFDTD.Models
{
    class Grid
    {
        double[,] Ex;
        double[,] Ey;
        double[,] Hz;
        private double[,] Ceye;
        private double[,] Ceyh;
        private double[,] Cexe;
        private double[,] Cexh;
        private double[,] Chzh;
        private double[,] Chze;
        int x, y;

        public Grid(int x, int y)
        {
            this.x = x;
            this.y = y;
            Ex = new double[x - 1, y];
            Ey = new double[x, y - 1];
            Hz = new double[x - 1, y - 1];
            Chzh = new double[x - 1, y - 1];
            Chze = new double[x - 1, y - 1];
            Cexe = new double[x - 1, y];
            Cexh = new double[x - 1, y];
            Ceye = new double[x, y - 1];
            Ceyh = new double[x, y - 1];

            double cn = 1.0 / Math.Sqrt(3);
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    Cexe[i, j] = 1;
                    Cexh[i, j] = cn * 377;
                }
            }
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    Ceye[i, j] = 1;
                    Ceyh[i, j] = cn * 377;
                }
            }

            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    Chzh[i, j] = 1;
                    Chze[i, j] = cn / 377;
                }
            }
        }

        public void updateE()
        {
            // Update Ex
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 1; j < y - 1; ++j)
                {
                    Ex[i, j] = Cexe[i, j] * Ex[i, j] + Cexh[i, j] * (Hz[i, j] - Hz[i, j - 1]);
                }
            }
            for (int i = 1; i < x - 1; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    Ey[i, j] = Ceye[i, j] * Ey[i, j] + Ceyh[i, j] * (Hz[i - 1, j] - Hz[i, j]);
                }
            }
        }

        public void updateH()
        {
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    Hz[i, j] = Chzh[i, j] * Hz[i, j] + Chze[i, j] * ((Ex[i, j + 1] - Ex[i, j]) - (Ey[i + 1, j] - Ey[i, j]));
                }
            }
        }
    }
}
