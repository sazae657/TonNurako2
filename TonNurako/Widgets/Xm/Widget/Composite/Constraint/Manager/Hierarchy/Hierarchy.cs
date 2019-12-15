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
	/// Hierarchy (XmHierarchy.txt)
	/// </summary>
	public abstract class Hierarchy : Manager
	{
        public enum NodeState : byte {
            AlwaysOpen = TonNurako.Motif.Constant.XmAlwaysOpen,
            Open   = TonNurako.Motif.Constant.XmOpen,
            Closed  = TonNurako.Motif.Constant.XmClosed,
            Hidden = TonNurako.Motif.Constant.XmHidden,
        }

		public Hierarchy() : base() {
            HierarchyEventTable = new TnkXtEvents<Events.HierarchyEventArgs>();
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent) {
			return base.Create (parent);
		}

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNautoClose XmCAutoClose Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool AutoClose {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNautoClose, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNautoClose, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNcloseFolderPixmap XmCPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap CloseFolderPixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNcloseFolderPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNcloseFolderPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNhorizontalMargin XmCDimension Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int HorizontalMargin {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNhorizontalMargin, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNhorizontalMargin, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNopenFolderPixmap XmCPixmap Pixmap XmUNSPECIFIED_PIXMAP CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual X11.Pixmap OpenFolderPixmap {
            get {
                return XSports.GetPixmap(
                TonNurako.Motif.ResourceId.XmNopenFolderPixmap, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetPixmap(
                TonNurako.Motif.ResourceId.XmNopenFolderPixmap, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNrefigureMode XmCBoolean Boolean True CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual bool RefigureMode {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNrefigureMode, true, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNrefigureMode, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNverticalMargin XmCDimension Dimension 2 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual int VerticalMargin {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNverticalMargin, 2, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetInt(
                TonNurako.Motif.ResourceId.XmNverticalMargin, value, Data.Resource.Access.CSG);
            }
        }


		#endregion

		#region ｲﾍﾞﾝﾄ

        internal TnkXtEvents<Events.HierarchyEventArgs> HierarchyEventTable {
            get;
        }

        /// XmNnodeStateCallback XmCNodeStateCallback XtCallbackList NULL C
        public virtual event EventHandler<Events.HierarchyEventArgs> NodeStateEvent
        {
            add {
                HierarchyEventTable.AddHandler(this, TonNurako.Motif.EventId.XmNnodeStateCallback ,  value );
            }
            remove {
                HierarchyEventTable.RemoveHandler(TonNurako.Motif.EventId.XmNnodeStateCallback ,  value );
            }
        }

		#endregion

	}
}
