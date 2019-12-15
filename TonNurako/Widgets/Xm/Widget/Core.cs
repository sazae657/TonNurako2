//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    ///　Core
    /// </summary>
    public abstract class Core : Widget
    {
        public Core() : base() {

        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
            InitProperties();
        }

        internal void CreateMotifWidget(
            TonNurako.Motif.CreateSymbol sym, IWidget parent, XResource res)
        {
            if (0 == this.Name.Length) {
                // 名無しは作れないので強制命名
                this.Name = AppContext.CreateTempName(this.GetType().Name);
            }

            IntPtr w = TonNurako.Motif.XmSports.CallCreate2P(sym,
                                    parent,
                                    this.Name,
                                    (null != res) ? res.ToXtArg() : null);

            if (IntPtr.Zero == w) {
                throw new Exception($"{sym.ToString()} failed");
            }
            Handle = new Native.NativeWidget(w);
            if (null != res) {
                res.Clear();
            }     
            
        }

        /*
        Core Resource Set
        Name	Class	Type	Default	Access
        XmNscreen	XmCScreen	Screen *	dynamic	CG

        // --- Widgetで定義 ---
        /// XmNborderWidth	XmCBorderWidth	Dimension	1	CSG
        /// XmNdestroyCallback	XmCCallback	XtCallbackList	NULL	C
        /// XmNdepth	XmCDepth	int	dynamic	CG
        // (Widget.Size)  XmNheight	XmCHeight	Dimension	dynamic	CSG
        // (Widget.Size)  XmNwidth	XmCWidth	Dimension	dynamic	CSG
        /// XmNsensitive	XmCSensitive	Boolean	True	CSG
        */
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Data.Accelerators Accelerators {
            get {
                return XSports.GetAccelerators(TonNurako.Motif.ResourceId.XmNaccelerators);
            }
            set {
                XSports.SetAccelerators(TonNurako.Motif.ResourceId.XmNaccelerators, value);
            }
        }


        /// XmNtranslations
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Xt.Translations Translations {
            get {
                return XSports.GetTranslations(TonNurako.Motif.ResourceId.XmNtranslations);
            }
            set {
                XSports.SetTranslations(TonNurako.Motif.ResourceId.XmNtranslations, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AncestorSensitive {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNancestorSensitive, false);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNancestorSensitive, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Colormap {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNcolormap, -1);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNcolormap, value);
            }
        }

        /// XmNbackgroundPixmap
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BackgroundPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNbackgroundPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNbackgroundPixmap, value);
            }
        }


        /// XmNborderPixmap
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BorderPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNborderPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNborderPixmap, value);
            }
        }


        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BackgroundColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNbackground);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNbackground, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BorderColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNborderColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNborderColor, value);
            }
        }


        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool InitialResourcesPersistent {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNinitialResourcesPersistent, true);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNinitialResourcesPersistent, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool MappedWhenManaged {
            get {

                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNmappedWhenManaged, false);

            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNmappedWhenManaged, value);
            }
        }

    }
}
