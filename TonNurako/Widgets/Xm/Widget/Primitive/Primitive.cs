//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{
    /// <summary>
    ///　Primitive
    /// </summary>
    abstract public class Primitive : Core
    {
        public Primitive() : base() {
        }

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
            InitProperties();
        }

        private PrimitiveProperties prop = null;

		#region Primitiveﾌﾟﾛﾊﾟﾃｨ

		/// <summary>
		/// ﾌﾟﾛﾊﾟﾃｨー
		/// </summary>
		internal class PrimitiveProperties
		{
            public int hilightThickness = 2;
			public int shadowThickness = 2;
			public bool highlightOnEnter = false;
			public NavigationType navigationType = NavigationType.TabGroup;
			public bool traversalOn = true;
		}

		/// <summary>
		/// ﾌﾟﾛﾊﾟﾃｨ初期化
		/// </summary>
		protected override void InitProperties()
		{
            prop = new PrimitiveProperties();
			base.InitProperties();
		}

        /*
        ** XmPrimitive Resource Set
        Name	Class	Type	Default	Access

        XmNuserData	XmCUserData	XtPointer	NULL	CSG
        */

        /// XmNbottomShadowPixmap XmCBottomShadowPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap BottomShadowPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNbottomShadowPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNbottomShadowPixmap, value);
            }
        }


        /// XmNhighlightPixmap XmCHighlightPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap HighlightPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNhighlightPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNhighlightPixmap, value);
            }
        }


        /// XmNtopShadowPixmap XmCTopShadowPixmap Pixmap dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap TopShadowPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNtopShadowPixmap);
            }
            set {
            XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNtopShadowPixmap, value);
            }
        }


        /// XmNunitType XmCUnitType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual UnitType UnitType {
            get {
                return XSports.GetValue<UnitType>(TonNurako.Motif.ResourceId.XmNunitType, UnitType.Pixels);
            }
            set {
                XSports.SetValue<UnitType>(TonNurako.Motif.ResourceId.XmNunitType, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color BottomShadowColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNbottomShadowColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNbottomShadowColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color ForegroundColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNforeground);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNforeground, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color HighlightColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNhighlightColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNhighlightColor, value);
            }
        }

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color TopShadowColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNtopShadowColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNtopShadowColor, value);
            }
        }

		/// <summary>
		/// ﾊｲﾗｲﾄを表す枠の厚みを設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public int HighlightThickness
		{
			get
			{

				prop.hilightThickness =
                    XSports.GetInt(TonNurako.Motif.ResourceId.XmNhighlightThickness, (ushort)prop.hilightThickness);
                return prop.hilightThickness;
			}
			set
			{
				XSports.SetInt( TonNurako.Motif.ResourceId.XmNhighlightThickness, (ushort)value );
				//値を保持
				prop.hilightThickness = value;
			}
		}

		/// <summary>
		/// ﾊｲﾗｲﾄを表す枠の厚みを設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public int ShadowThickness
		{
			get
			{
				prop.shadowThickness =
                    XSports.GetInt(TonNurako.Motif.ResourceId.XmNshadowThickness, (ushort)prop.shadowThickness);
				return prop.shadowThickness;
			}
			set
			{
				XSports.SetInt(TonNurako.Motif.ResourceId.XmNshadowThickness, (ushort)value );
				//値を保持
				prop.shadowThickness = value;
			}
		}

		/// <summary>
		/// ﾏｳｽﾎﾟｲﾝﾀ通過時に強調表示するか否かを設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public bool HighlightOnEnter
		{
			get
			{
                prop.highlightOnEnter =
                    XSports.GetBool(TonNurako.Motif.ResourceId.XmNhighlightOnEnter, prop.highlightOnEnter);
                return prop.highlightOnEnter;
			}
			set
			{
				XSports.SetBool( TonNurako.Motif.ResourceId.XmNhighlightOnEnter, value );
				//値を保持
				prop.highlightOnEnter = value;

			}
		}


		/// <summary>
		/// ﾀﾌﾞｸﾞﾙーﾌﾟ構成の設定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public NavigationType NavigationType
		{
			get {
				prop.navigationType =
                    XSports.GetValue<NavigationType>(TonNurako.Motif.ResourceId.XmNnavigationType, NavigationType.TabGroup);
                return prop.navigationType;
			}
			set {
				prop.navigationType = value;

                XSports.SetValue<NavigationType>(TonNurako.Motif.ResourceId.XmNnavigationType, value );
			}
		}

		/// <summary>
		/// ﾏｳｽ入力中のｷー入力を許可
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public bool TraversalOn
		{
			get {
				prop.traversalOn =
			         XSports.GetBool( TonNurako.Motif.ResourceId.XmNtraversalOn, prop.traversalOn);
                return prop.traversalOn;
			}
			set {
				XSports.SetBool(TonNurako.Motif.ResourceId.XmNtraversalOn, value );
				prop.traversalOn = value;
			}
		}

        /// XmNhelpCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> HelpEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNhelpCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNhelpCallback ,  value );
            }
        }

		#endregion
    }
}
