//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using TonNurako.Data;
using TonNurako.Events;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// SimpleMenuBase
	/// </summary>
	public abstract class SimpleMenuBase : RowColumnBase, IMenuWidget
	{

		#region 生成

		public SimpleMenuBase() : base()
		{
            SimpleEventTable = new TnkXtEvents<SimpleEventArgs>();
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

		public override int Create(IWidget parent)
		{
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー
        /// <summary>
        /// IMenuWidget用
        /// </summary>
        public IChild ExtremeMenuSports {
            get {
                return this;
            }
        }

        internal void delegaty( IntPtr w, IntPtr client, IntPtr call ){
            if(! MotifAnyEventTable.HasHandler(TonNurako.Motif.EventId.XmNsimpleCallback)) {
                return;
            }
            MotifAnyEventTable.CallHandler(TonNurako.Motif.EventId.XmNsimpleCallback, this,
                ((Func<AnyEventArgs>)(() => {
                    var t = new AnyEventArgs();
                    t.Sender = this;
                    t.ParseXEvent(call, client);
                    return t;
                }))());
        }

        internal void AddInternalEventHandler() {
            //ToolkitResources.Add(TonNurako.Motif.EventId.XmNsimpleCallback, delegaty);
        }


        // ### UNKOWN TYPE
        // ### XmNbuttonAccelerators XmCButtonAccelerators StringTable NULL C

        /// XmNbuttonAcceleratorText XmCButtonAcceleratorText XmStringTable NULL C
        public virtual string[] ButtonAcceleratorText {
            set {
                XSports.SetStringTable(
                    TonNurako.Motif.ResourceId.XmNbuttonAcceleratorText, new CompoundStringTable(value), Data.Resource.Access.C);
            }
        }

        /// XmNbuttonCount XmCButtonCount int 0 C
        public virtual int ButtonCount {
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNbuttonCount, value, Data.Resource.Access.C);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNbuttonMnemonicCharSets XmCButtonMnemonicCharSets XmStringCharSetTable NULL C

        // ### UNKOWN TYPE
        // ### XmNbuttonMnemonics XmCButtonMnemonics XmKeySymTable NULL C

        /// XmNbuttons XmCButtons XmStringTable NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual string[] Buttons {
            set {
                XSports.SetStringTable(
                    TonNurako.Motif.ResourceId.XmNbuttons, new CompoundStringTable(value), Data.Resource.Access.C);
            }
        }

        /// XmNbuttonSet XmCButtonSet int -1 C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual int ButtonSet {
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNbuttonSet, value, Data.Resource.Access.C);
            }
        }

        /// XmNbuttonType XmCButtonType XmButtonTypeTable NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual MenuButtonType[] ButtonType {

            set {
                byte[] w = new byte[value.Length];
                for(int i = 0; i < value.Length; i++) {
                    w[i] = (byte)value[i];
                }
                ToolkitResources.Add(TonNurako.Motif.ResourceId.XmNbuttonType, w);
                ToolkitResources.SetWidget(true);
                //XSports.SetIntArray(
                //    TonNurako.Motif.ResourceId.XmNbuttonType, value, Data.Resource.Access.C);
            }
        }

        /// XmNoptionLabel XmCOptionLabel XmString NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual string OptionLabel {
            set {
                XSports.SetString(
                    TonNurako.Motif.ResourceId.XmNoptionLabel, value, Data.Resource.Access.C);
            }
        }

        /// XmNoptionMnemonic XmCOptionMnemonic KeySym NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual KeySym OptionMnemonic {

            set {
                XSports.SetKeySym(
                    TonNurako.Motif.ResourceId.XmNoptionMnemonic, value, Data.Resource.Access.C);
            }
        }

        /// XmNpostFromButton XmCPostFromButton int -1 C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual int PostFromButton {

            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNpostFromButton, value, Data.Resource.Access.C);
            }
        }
		#endregion

		#region ｲﾍﾞﾝﾄ
        internal TnkXtEvents<SimpleEventArgs> SimpleEventTable {
            get;
        }

        /// XmNsimpleCallback XmCCallback XtCallbackProc NULL C
        public virtual event EventHandler<Events.SimpleEventArgs> SimpleEvent
        {
            add {
                SimpleEventTable.AddHandlerToRes(this, TonNurako.Motif.EventId.XmNsimpleCallback ,  value );
            }
            remove {
                SimpleEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNsimpleCallback ,  value );
            }
        }


		#endregion

	}
}
