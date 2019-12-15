//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// Separator
    /// </summary>
    public class Separator : Primitive
    {
		public Separator() : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }


		/// <summary>
		/// Separator
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateSeparator, parent, ToolkitResources);
			}

			return base.Create (parent);
		}


        #region ﾌﾟﾛﾊﾟﾁー
        /// XmNmargin XmCMargin Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Margin {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmargin, 0);
            }
            set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNmargin, value);
            }
        }


        /// XmNorientation XmCOrientation unsigned char XmHORIZONTAL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Orientation Orientation {
            get {
                return XSports.GetValue<Orientation>(TonNurako.Motif.ResourceId.XmNorientation, Orientation.Horizontal);
            }
            set {
                XSports.GetValue<Orientation>(TonNurako.Motif.ResourceId.XmNorientation, value);
            }
        }


        /// XmNseparatorType XmCSeparatorType unsigned char XmSHADOW_ETCHED_IN CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual SeparatorType SeparatorType {
            get {
                return XSports.GetValue<SeparatorType>(TonNurako.Motif.ResourceId.XmNseparatorType, SeparatorType.ShadowEtchedIn);
            }
            set {
                XSports.GetValue<SeparatorType>(TonNurako.Motif.ResourceId.XmNseparatorType, value);
            }
        }

        #endregion
    }

}
