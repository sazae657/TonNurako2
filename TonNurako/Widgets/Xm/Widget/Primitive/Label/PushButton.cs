//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{

	/// <summary>
	/// PushButton の作成
	/// </summary>
	public class PushButton : LabelBase
	{

		public PushButton()  : base()
		{
            PushButtonEventTable = new TnkXtEvents<Events.PushButtonEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
            InitProperties();
        }


		/// <summary>
		/// PushButtonの作成
		/// </summary>
		/// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
		/// <returns></returns>
		public override int Create(IWidget parent)
		{
			if (! this.IsAvailable)
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreatePushButton, parent, ToolkitResources);
			}
			return base.Create(parent);
		}


		#region PushButtonﾌﾟﾛﾊﾟﾃｨ

		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool FillOnArm
		{
			get {
				return XSports.GetBool(TonNurako.Motif.ResourceId.XmNfillOnArm, true);
			}
			set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNfillOnArm, value);
			}
		}

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color ArmColor {
            get {
                return XSports.GetColor(TonNurako.Motif.ResourceId.XmNarmColor);
            }
            set {
                XSports.SetColor(TonNurako.Motif.ResourceId.XmNarmColor, value);
            }
        }

        /// XmNarmPixmap
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap ArmPixmap {
            get {
                return XSports.GetPixmap(TonNurako.Motif.ResourceId.XmNarmPixmap);
            }
            set {
                XSports.SetPixmap(TonNurako.Motif.ResourceId.XmNarmPixmap, value);
            }
        }

		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DefaultButtonShadowThickness
		{
			get {
				return XSports.GetInt(TonNurako.Motif.ResourceId.XmNdefaultButtonShadowThickness, 2);
			}
			set {
                XSports.SetInt(TonNurako.Motif.ResourceId.XmNdefaultButtonShadowThickness, value);
			}
		}

        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual MultiClick MultiClick {
			get {
                return XSports.GetValue<MultiClick>(TonNurako.Motif.ResourceId.XmNmultiClick, MultiClick.Discard);
			}
			set {
				XSports.SetValue<MultiClick>( TonNurako.Motif.ResourceId.XmNmultiClick, value);
			}
        }

		/// <summary>
		/// ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝに指定
		/// </summary>
		[Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool ShowAsDefault
		{
			get {
				bool dat;
				ToolkitResources.GetValue(TonNurako.Motif.ResourceId.XmNshowAsDefault, out dat );

				return dat;
			}
			set {
                ToolkitResources.Add( TonNurako.Motif.ResourceId.XmNshowAsDefault, value );
    			ToolkitResources.SetWidget(true );
			}
		}

		#endregion

		#region PushButtonｲﾍﾞﾝﾄ

        internal TnkXtEvents<Events.PushButtonEventArgs> PushButtonEventTable {
            get;
        }

		/// <summary>
		/// ﾏｳｽﾎﾞﾀﾝｸﾘｯｸ時
		/// </summary>
		public event EventHandler<Events.PushButtonEventArgs> ActivateEvent
		{
			add
			{
				PushButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNactivateCallback ,  value );
			}
			remove
			{
				PushButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNactivateCallback ,  value );
			}
		}

		/// <summary>
		/// ﾏｳｽﾎﾞﾀﾝ押下時
		/// </summary>
		public event EventHandler<Events.PushButtonEventArgs> ArmEvent
		{
			add
			{
				PushButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNarmCallback ,  value );
			}
			remove
			{
				PushButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNarmCallback ,  value );
			}
		}

		/// <summary>
		/// ﾏｳｽﾎﾞﾀﾝ解放時
		/// </summary>
		public event EventHandler<Events.PushButtonEventArgs> DisarmEvent
		{
			add
			{
				PushButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
			}
			remove
			{
				PushButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
			}
		}

		#endregion


	}
}
