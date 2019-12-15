//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Data;
using TonNurako.Events;
using TonNurako.Native;
using TonNurako.Motif;

namespace TonNurako.Widgets.Xm
{

	/// <summary>
	/// Shell
	/// </summary>
	public abstract class Shell : Composite, IPopup, IDefectiveWidget
	{

		public Shell() : base() {
            PopupChildEventTable = new TnkEvents<TonNurako.Motif.ResourceId, TnkEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

		public override int Create(IWidget parent) {
			return base.Create (parent);
		}

        #region 固有
        internal static class NativeMethods {
            [DllImport(ExtremeSports.Lib, EntryPoint="XtPopup_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtPopup(IntPtr popup_shell, int grab_kind);

            [DllImport(ExtremeSports.Lib, EntryPoint="XtPopdown_TNK", CharSet=CharSet.Auto)]
            internal static extern void XtPopdown(IntPtr popup_shell);
        }
        public override bool AllowAutoManage {
            get {return false;}
        }

        public void Popup(GrabOption option)
        {
            NativeMethods.XtPopup(this.Handle.Widget.Handle, (int)option);
        }

        public void Popdown()
        {
            NativeMethods.XtPopdown(this.Handle.Widget.Handle);
        }

        #endregion

        #region ﾌﾟﾛﾊﾟﾁー


        /// XmNallowShellResize XmCAllowShellResize Boolean False CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool AllowShellResize {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNallowShellResize, false, Data.Resource.Access.CG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNallowShellResize, value, Data.Resource.Access.CG);
            }
        }

        /// XmNgeometry XmCGeometry String NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Geometry {
            get {
                return XSports.GetAnsiString(
                    TonNurako.Motif.ResourceId.XmNgeometry, "", false, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetAnsiString(
                    TonNurako.Motif.ResourceId.XmNgeometry, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNoverrideRedirect XmCOverrideRedirect Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool OverrideRedirect {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNoverrideRedirect, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNoverrideRedirect, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNsaveUnder XmCSaveUnder Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool SaveUnder {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNsaveUnder, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNsaveUnder, value, Data.Resource.Access.CSG);
            }
        }

        // ### UNKOWN TYPE
        // ### XmNvisual XmCVisual Visual * CopyFromParent CSG

        #endregion

        #region ｲﾍﾞﾝﾄ

        /// XmNpopdownCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> PopdownEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpopdownCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpopdownCallback ,  value );
            }
        }

        /// XmNpopupCallback XmCCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.AnyEventArgs> PopupEvent
        {
            add {
                MotifAnyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNpopupCallback ,  value );
            }
            remove {
                MotifAnyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNpopupCallback ,  value );
            }
        }

        internal TnkEvents<TonNurako.Motif.ResourceId, TnkEventArgs> PopupChildEventTable;
        /// <summary>
        /// Popupが作られたら呼ばれる
        /// </summary> <summary>
        public event EventHandler<TnkEventArgs> CreatePopupChildEvent {
            add{
                if (! PopupChildEventTable.HasHandler(TonNurako.Motif.ResourceId.XmNcreatePopupChildProc)) {
                    XSports.SetCallback(ResourceId.XmNcreatePopupChildProc,
                        (w, client, call ) =>{
                            PopupChildEventTable.CallHandler(ResourceId.XmNcreatePopupChildProc, this);
                        });
                }
                PopupChildEventTable.AddHandler(ResourceId.XmNcreatePopupChildProc, value);
            }
            remove{
                PopupChildEventTable.RemoveHandler(ResourceId.XmNcreatePopupChildProc, value);
            }
        }
		#endregion

	}
}
