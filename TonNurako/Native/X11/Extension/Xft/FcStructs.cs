using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TonNurako.Native;

namespace TonNurako.X11.Extension.Xft {

    [StructLayout(LayoutKind.Sequential)]
    internal struct FcMatrixRec {
        public double XX;
        public double XY;
        public double YX;
        public double YY;
    }
    public class FcMatrix {
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixInit_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcMatrixInit(ref FcMatrixRec mat);

            // FcMatrix*: FcMatrixCopy const FcMatrix*:mat  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixCopy_TNK", CharSet = CharSet.Auto)]
            internal static extern IntPtr FcMatrixCopy(ref FcMatrixRec mat);

            // FcBool: FcMatrixEqual const FcMatrix*:mat1  const FcMatrix*:mat2  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixEqual_TNK", CharSet = CharSet.Auto)]
            internal static extern bool FcMatrixEqual(ref FcMatrixRec mat1, ref FcMatrixRec mat2);

            // void: FcMatrixMultiply FcMatrix*:result  const FcMatrix*:a  const FcMatrix*:b  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixMultiply_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcMatrixMultiply(out IntPtr result, ref FcMatrixRec a, ref FcMatrixRec b);

            // void: FcMatrixRotate FcMatrix*:m  double:c  double:s  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixRotate_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcMatrixRotate(ref FcMatrixRec m, double c, double s);

            // void: FcMatrixScale FcMatrix*:m  double:sx  double:sy  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixScale_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcMatrixScale(ref FcMatrixRec m, double sx, double sy);

            // void: FcMatrixShear FcMatrix*:m  double:sh  double:sv  
            [DllImport(ExtremeSports.Lib, EntryPoint = "FcMatrixShear_TNK", CharSet = CharSet.Auto)]
            internal static extern void FcMatrixShear(ref FcMatrixRec m, double sh, double sv);
        }
        internal FcMatrixRec Record;
        public FcMatrix() {
            Record = new FcMatrixRec();
        }

        public double Xx {
            get => Record.XX;
            set => Record.XX = value;
        }
        public double Xy {
            get => Record.XY;
            set => Record.XY = value;
        }
        public double Yx {
            get => Record.YX;
            set => Record.YX = value;
        }
        public double Yy {
            get => Record.YY;
            set => Record.YY = value;
        }

        internal FcMatrix(IntPtr v, bool dealloc) {
            Record = Marshal.PtrToStructure<FcMatrixRec>(v);
            if (dealloc) {
                //TODO: ぁゃιぃ
                TonNurako.Xt.XtSports.XtFree(v);
            }
        }

        public void Init() =>
            NativeMethods.FcMatrixInit(ref Record);

        public FcMatrix Copy() =>
            new FcMatrix(NativeMethods.FcMatrixCopy(ref Record), true);

        public bool Equal(FcMatrix mat2) =>
            NativeMethods.FcMatrixEqual(ref Record, ref mat2.Record);


        public FcMatrix Multiply(FcMatrix b) {
            IntPtr res = IntPtr.Zero;
            NativeMethods.FcMatrixMultiply(out res, ref Record, ref b.Record);
            if (IntPtr.Zero == res) {
                throw new NullReferenceException("FcMatrixMultiply == NULL");
            }
            return (new FcMatrix(res, true));
        }


        public void Rotate(double c, double s) =>
            NativeMethods.FcMatrixRotate(ref Record, c, s);


        public void Scale(double sx, double sy) =>
            NativeMethods.FcMatrixScale(ref Record, sx, sy);


        public void Shear(double sh, double sv) =>
            NativeMethods.FcMatrixShear(ref Record, sh, sv);


    }
}
