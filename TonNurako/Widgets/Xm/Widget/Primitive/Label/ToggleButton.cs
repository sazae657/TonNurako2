//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Runtime.InteropServices;
using TonNurako.Data;

namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// ToggleButton
	/// </summary>
	public class ToggleButton : LabelBase
	{

		public ToggleButton() : base() {
            ToggleButtonEventTable = new TnkXtEvents<Events.ToggleButtonEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }


		/// <summary>
		/// ToggleButton生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateToggleButton, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


        #region 固有
        internal static class NativeMethods {
            // Boolean: XmToggleButtonGetState [{'type': 'Widget', 'name': 'widget'}]
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmToggleButtonGetState_TNK", CharSet=CharSet.Auto)]
            internal static extern bool XmToggleButtonGetState(IntPtr widget);

            // void: XmToggleButtonSetState [{'type': 'Widget', 'name': 'widget'}, {'type': 'Boolean', 'name': 'state'}, {'type': 'Boolean', 'name': 'notify'}]
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmToggleButtonSetState_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmToggleButtonSetState(IntPtr widget, [MarshalAs(UnmanagedType.U1)] bool state, [MarshalAs(UnmanagedType.U1)] bool notify);

            // void: XmToggleButtonSetValue [{'type': 'Widget', 'name': 'widget'}, {'type': 'XmToggleButtonState', 'name': 'state'}, {'type': 'Boolean', 'name': 'notify'}]
            [DllImport(Native.ExtremeSports.Lib, EntryPoint="XmToggleButtonSetValue_TNK", CharSet=CharSet.Auto)]
            internal static extern void XmToggleButtonSetValue(IntPtr widget, ToggleButtonState state, [MarshalAs(UnmanagedType.U1)] bool notify);
        }

        /// <summary>
        /// ｽﾃーﾄ取得(Booleanのみ)
        /// </summary>
        /// <returns>ｽﾃーﾄ</returns>
        public bool GetState() {
            return NativeMethods.XmToggleButtonGetState(this.Handle.Widget.Handle);
        }

        /// <summary>
        /// ｽﾃーﾄ設定
        /// </summary>
        /// <param name="state">ｽﾃーﾄ</param>
        /// <param name="notify">通知有無</param>
        public void SetState(bool state, bool notify) {
            NativeMethods.XmToggleButtonSetState(this.Handle.Widget.Handle, state, notify);
        }

        /// <summary>
        /// ｽﾃーﾄ設定
        /// </summary>
        /// <param name="state">ｽﾃーﾄ</param>
        /// <param name="notify">通知有無</param>
        public void SetState(ToggleButtonState state, bool notify) {
            NativeMethods.XmToggleButtonSetValue(this.Handle.Widget.Handle, state, notify);
        }

        #endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNdetailShadowThickness XmCDetailShadowThickness Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int DetailShadowThickness {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNdetailShadowThickness, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNdetailShadowThickness, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNfillOnSelect XmCFillOnSelect Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool FillOnSelect {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNfillOnSelect, false, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNfillOnSelect, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNindeterminatePixmap XmCIndeterminatePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap IndeterminatePixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNindeterminatePixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNindeterminatePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNindicatorOn XmCIndicatorOn unsigned char XmINDICATOR_FILL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual Indicator IndicatorOn {
            get {
                return XSports.GetValue<Indicator>(
                TonNurako.Motif.ResourceId.XmNindicatorOn, Indicator.Fill, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<Indicator>(
                    TonNurako.Motif.ResourceId.XmNindicatorOn, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNindicatorSize XmCIndicatorSize Dimension dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int IndicatorSize {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNindicatorSize, 2, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNindicatorSize, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNindicatorType XmCIndicatorType unsigned char dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IndicatorType IndicatorType {
            get {
                return XSports.GetValue<IndicatorType>(
                    TonNurako.Motif.ResourceId.XmNindicatorType, IndicatorType.Diamond, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<IndicatorType>(
                    TonNurako.Motif.ResourceId.XmNindicatorType, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNselectColor XmCSelectColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color SelectColor {
            get {
                return XSports.GetColor(
                    TonNurako.Motif.ResourceId.XmNselectColor, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetColor(
                    TonNurako.Motif.ResourceId.XmNselectColor, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNselectInsensitivePixmap XmCSelectInsensitivePixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap SelectInsensitivePixmap {
            get {
                return XSports.GetPixmap(
                    TonNurako.Motif.ResourceId.XmNselectInsensitivePixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNselectInsensitivePixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNselectPixmap XmCSelectPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap SelectPixmap {
            get {
                return XSports.GetPixmap(
                    TonNurako.Motif.ResourceId.XmNselectPixmap, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetPixmap(
                    TonNurako.Motif.ResourceId.XmNselectPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNset XmCSet unsigned char XmUNSET CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ToggleButtonState Set {
            get {
                return XSports.GetValue<ToggleButtonState>(
                    TonNurako.Motif.ResourceId.XmNset, ToggleButtonState.Unset, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ToggleButtonState>(
                    TonNurako.Motif.ResourceId.XmNset, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNspacing XmCSpacing Dimension 4 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int Spacing {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNspacing, 4, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNspacing, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNtoggleMode XmCToggleMode unsigned char XmTOGGLE_BOOLEAN CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual ToggleMode ToggleMode {
            get {
                return XSports.GetValue<ToggleMode>(
                    TonNurako.Motif.ResourceId.XmNtoggleMode, ToggleMode.Boolean, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetValue<ToggleMode>(
                    TonNurako.Motif.ResourceId.XmNtoggleMode, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNunselectColor XmCUnselectColor Pixel dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual GC.Color UnselectColor {
            get {
                return XSports.GetColor(
                    TonNurako.Motif.ResourceId.XmNunselectColor, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetColor(
                    TonNurako.Motif.ResourceId.XmNunselectColor, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNvisibleWhenOff XmCVisibleWhenOff Boolean dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool VisibleWhenOff {
            get {
                return XSports.GetBool(
                    TonNurako.Motif.ResourceId.XmNvisibleWhenOff, false, Data.Resource.Access.CSG);
            }
            set {
                XSports.SetBool(
                    TonNurako.Motif.ResourceId.XmNvisibleWhenOff, value, Data.Resource.Access.CSG);
            }
        }

		#endregion

		#region ｲﾍﾞﾝﾄ
        TnkXtEvents<Events.ToggleButtonEventArgs> ToggleButtonEventTable {
            get;
        }

        /// XmNarmCallback XmCArmCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ToggleButtonEventArgs> ArmEvent
        {
            add {
                ToggleButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNarmCallback ,  value );
            }
            remove {
                ToggleButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNarmCallback ,  value );
            }
        }

        /// XmNdisarmCallback XmCDisarmCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ToggleButtonEventArgs> DisarmEvent
        {
            add {
                ToggleButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
            }
            remove {
                ToggleButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNdisarmCallback ,  value );
            }
        }

        /// XmNvalueChangedCallback XmCValueChangedCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.ToggleButtonEventArgs> ValueChangedEvent
        {
            add {
                ToggleButtonEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
            remove {
                ToggleButtonEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNvalueChangedCallback ,  value );
            }
        }

		#endregion

	}
}
