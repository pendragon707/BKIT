using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6_2
{
    class ClassForInsp
    {
        public ClassForInsp() { }
        public ClassForInsp(string str, int x) { }
        public ClassForInsp(int x, int y) { }

        [Num(5)]
        public double SurfaceCircle(int r) { return Math.PI * r * r; }
        [Num(6)]
        public double SurfaceRectangle(int h, int w) { return h * w; }

        public double SurfaceSquare(int x) { return x * x; }

        public string SurfacePro1
        {
            get { return surfacepro1; }
            set { surfacepro1 = value; }
        }

        private string surfacepro1;

        public int SurfaceAll { get; set; }

        public int Heigh = 0;
        public float Width = 0;
    }
}
