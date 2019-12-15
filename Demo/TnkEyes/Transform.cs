//
// transform.hから移植
//
// https://cgit.freedesktop.org/xorg/app/xeyes/tree/transform.h?id=XORG-7_1
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnkEyes {
    class Transform {
        public double Mx, Bx;
        public double My, By;
    }


    class TPoint {
        public double X, Y;
    }

    class TRectangle {
        public double X, Y, Width, Height;
        public TRectangle() {
            X = Y = Width = Height = 0;
        }

        public TRectangle(double x, double y, double width, double height) {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }

}
