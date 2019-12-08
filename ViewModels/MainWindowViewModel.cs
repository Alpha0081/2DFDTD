using _2DFDTD.ViewModels.Base;
using _2DFDTD.Models;

namespace _2DFDTD.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private static int _X = 500;
        private static int _Y = 450;

        public int X
        {
            get => _X;
            set { Set(ref _X, value); }
        }

        public int Y
        {
            get => _Y;
            set { Set(ref _Y, value); }
        }


        private Grid _G = new Grid(0, 0);

        public Grid G
        {
            get
            {
                _G.draw();
            }
            set { Set(ref _G, new Grid(_X, _Y))}
        }
        


    }
}
