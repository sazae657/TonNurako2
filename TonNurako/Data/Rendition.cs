using System;
using System.Runtime.InteropServices;

namespace TonNurako.Data
{
    public enum StrikethruType {
        AS_IS = TonNurako.Motif.Constant.XmAS_IS,
        NO_LINE = TonNurako.Motif.Constant.XmNO_LINE,
        SINGLE_LINE = TonNurako.Motif.Constant.XmSINGLE_LINE,
        DOUBLE_LINE = TonNurako.Motif.Constant.XmDOUBLE_LINE,
        SINGLE_DASHED_LINE = TonNurako.Motif.Constant.XmSINGLE_DASHED_LINE,
        DOUBLE_DASHED_LINE = TonNurako.Motif.Constant.XmDOUBLE_DASHED_LINE,
    }

    public enum LoadModel {
        UNSPECIFIED = TonNurako.Motif.Constant.XmUNSPECIFIED_LOAD_MODEL,
        DEFERRED = TonNurako.Motif.Constant.XmLOAD_DEFERRED,
        IMMEDIATE = TonNurako.Motif.Constant.XmLOAD_IMMEDIATE,
    }
    public enum FontType {
        FONT = TonNurako.Motif.Constant.XmFONT_IS_FONT,
        FONTSET = TonNurako.Motif.Constant.XmFONT_IS_FONTSET,
        XFT = TonNurako.Motif.Constant.XmFONT_IS_XFT,
    }

    public class Rendition : System.IDisposable
    {
        internal static class NativeMethods {
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenditionCreate_TNK", CharSet=CharSet.Auto, BestFitMapping=false, ThrowOnUnmappableChar=true)]
            internal static extern IntPtr XmRenditionCreate(IntPtr widget,
                [MarshalAs(UnmanagedType.LPStr)] string tag, TonNurako.Xt.XtArgRec[] arglist, int argcount);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenditionFree_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmRenditionFree(IntPtr rendition);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenditionRetrieve_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmRenditionRetrieve(IntPtr rendition, IntPtr[] arglist, int argcount);

            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmRenditionUpdate_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmRenditionUpdate(IntPtr rendition, TonNurako.Xt.XtArgRec[] arglist, int argcount);
        }

        private XResource resource;
        internal XResource Resource {
            get {return resource;}
        }
        private IntPtr handle;
        public IntPtr Handle {
            get {return handle;}
        }

        private bool isReference = false;

        internal void ApplyResource() {
            if (IntPtr.Zero == handle || (0 != Resource.Count)) {
                return;
            }
            var args =  Resource.ToXtArg();
            TonNurako.Xt.XtArgRec[] au = new TonNurako.Xt.XtArgRec[args.Length];
            int argc = Native.ExtremeSports.TnkConvertResourceEx(args, au, true);

            NativeMethods.XmRenditionUpdate(handle, au, argc);

            Native.ExtremeSports.TnkFreeDeepCopyArg(au);

            Resource.Clear();
        }

        public Rendition() {
            resource = new XResource(null);
        }

        internal Rendition(IntPtr rendition) {
            resource = new XResource(null);
            isReference = true;
            handle = rendition;
        }

        public Rendition(Widgets.IWidget widget) {
            resource = new XResource(null);
            handle = NativeMethods.XmRenditionCreate(widget.Handle.Widget.Handle,
                        TonNurako.Motif.StringConstant.XmFONTLIST_DEFAULT_TAG, new TonNurako.Xt.XtArgRec[]{}, 0);
        }

        public Rendition(Widgets.IWidget widget, string tag) {
            resource = new XResource(null);
            handle = NativeMethods.XmRenditionCreate(widget.Handle.Widget.Handle, tag, new TonNurako.Xt.XtArgRec[]{}, 0);
        }


        public bool Create(Widgets.IWidget widget, string tag = TonNurako.Motif.StringConstant.XmFONTLIST_DEFAULT_TAG) {
            var args =  Resource.ToXtArg();
            TonNurako.Xt.XtArgRec[] au = new TonNurako.Xt.XtArgRec[args.Length];
            int argc = args.Length;
            if (argc != 0) {
                argc = Native.ExtremeSports.TnkConvertResourceEx(args, au, true);
            }
            handle = NativeMethods.XmRenditionCreate(widget.Handle.Widget.Handle, tag, au, argc);
            Native.ExtremeSports.TnkFreeDeepCopyArg(au);

            Resource.Clear();
            return true;
        }

        //  XmNfont
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SportyFontList Font {
            get {
                IntPtr tab = Resource.GetPointerValue(TonNurako.Motif.ResourceId.XmNfont);
                return SportyFontList.FromFont(tab);
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNfont, value.Font);
                ApplyResource();
            }
        }

        /// XmNtabList
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual TabList TabList {
            get {
                IntPtr tab = Resource.GetPointerValue(TonNurako.Motif.ResourceId.XmNtabList);
                return new TabList(tab);
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNtabList, value.Handle);
                ApplyResource();
            }
        }

        /// XmNrenditionBackground
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color RenditionBackground {
            get {
                TonNurako.GC.Color color;
                Resource.GetValue(
                    TonNurako.Motif.ResourceId.XmNrenditionBackground, out color);
                return color;
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNrenditionBackground, value);
                ApplyResource();
            }
        }

        /// XmNfontName
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string FontName {
            get {
                return Resource.GetAnsiStringValue(TonNurako.Motif.ResourceId.XmNfontName, true);
            }
            set {
                Resource.Add(
                    TonNurako.Motif.ResourceId.XmNfontName, value);
                ApplyResource();
            }
        }

        // OM2.3+Xft専用
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FontSize {
            get {
                int v;
                Resource.GetValue(TonNurako.Motif.ResourceId.XmNfontSize, out v);
                return v;
            }
            set {
                Resource.Add(
                    TonNurako.Motif.ResourceId.XmNfontSize, value);
                ApplyResource();
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string FontStyle {
            get {
                return Resource.GetAnsiStringValue(TonNurako.Motif.ResourceId.XmNfontStyle, true);
            }
            set {
                Resource.Add(
                    TonNurako.Motif.ResourceId.XmNfontStyle, value);
                ApplyResource();
            }
        }


        /// XmNfontType
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual FontType FontType {
           get {
                byte w;
                Resource.GetValue(TonNurako.Motif.ResourceId.XmNfontType, out w);
                return (FontType)w;
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNfontType, (byte)value);
                ApplyResource();
            }
        }

        /// XmNrenditionForeground
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color RenditionForeground {
            get {
                TonNurako.GC.Color color;
                Resource.GetValue(
                    TonNurako.Motif.ResourceId.XmNrenditionForeground, out color);
                return color;
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNrenditionForeground, value);
                ApplyResource();
            }
        }

        /// XmNloadModel
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual LoadModel LoadModel {
           get {
                byte w;
                Resource.GetValue(TonNurako.Motif.ResourceId.XmNloadModel, out w);
                return (LoadModel)w;
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNloadModel, (byte)value);
                ApplyResource();
            }
        }

        /// XmNstrikethruType
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual StrikethruType StrikethruType {
            get {
                byte w;
                Resource.GetValue(TonNurako.Motif.ResourceId.XmNstrikethruType, out w);
                return (StrikethruType)w;
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNstrikethruType, (byte)value);
                ApplyResource();
            }
        }

        /// XmNtag
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Tag {
            get {
                return Resource.GetAnsiStringValue(TonNurako.Motif.ResourceId.XmNtag, true);
            }
        }

        /// XmNunderlineType
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual StrikethruType UnderlineType {
            get {
                byte w;
                Resource.GetValue(TonNurako.Motif.ResourceId.XmNunderlineType, out w);
                return (StrikethruType)w;
            }
            set {
                Resource.Add(TonNurako.Motif.ResourceId.XmNunderlineType, (byte)value);
                ApplyResource();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)  {
            if (!disposedValue)
            {
                if (IntPtr.Zero != handle) {
                    if(! isReference) {
                        NativeMethods.XmRenditionFree(handle);
                    }
                    handle = IntPtr.Zero;
                }
                resource.Dispose();
                disposedValue = true;
            }
        }

        ~Rendition() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }

}
