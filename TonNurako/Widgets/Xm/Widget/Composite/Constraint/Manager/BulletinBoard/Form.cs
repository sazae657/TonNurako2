//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// Form
	/// </summary>
	public class Form : BulletinBoard
	{

		#region 生成

		public Form()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create( IWidget parent )
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateForm, parent, ToolkitResources);
			}

			return base.Create (parent);
		}


		#endregion

        #region XmForm Resource Set
        /// XmNfractionBase XmCMaxValue int 100 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int FractionBase {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNfractionBase, 100);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNfractionBase, value);
            }
        }


        /// XmNhorizontalSpacing XmCSpacing Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HorizontalSpacing {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNhorizontalSpacing, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNhorizontalSpacing, value);
            }
        }


        /// XmNrubberPositioning XmCRubberPositioning Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RubberPositioning {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNrubberPositioning, false);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNrubberPositioning, value);
            }
        }


        /// XmNverticalSpacing XmCSpacing Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VerticalSpacing {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNverticalSpacing, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNverticalSpacing, value);
            }
        }
        #endregion

	}
}
