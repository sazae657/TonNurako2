//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;

namespace TonNurako.Widgets.Xm
{

	/// <summary>
	/// FileSelectionBox
	/// </summary>
	public class FileSelectionBox : SelectionBox, IDefectiveWidget
	{

		#region 生成

		public FileSelectionBox() : base() {
		}

        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

		/// <summary>
		/// FileSelectionBox生成
		/// </summary>
		/// <param name="parent">親</param>
		/// <returns></returns>
		public override int Create(IWidget parent) {
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateFileSelectionBox, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
		#endregion

		#region ﾌﾟﾛﾊﾟﾁー

        /// XmNdirectory XmCDirectory XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Directory {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNdirectory, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNdirectory, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdirectoryValid XmCDirectoryValid Boolean dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual bool DirectoryValid {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNdirectoryValid, false, Data.Resource.Access.SG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNdirectoryValid, value, Data.Resource.Access.SG);
            }
        }

        /// XmNdirListItems XmCDirListItems XmStringTable dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual string[] DirListItems {
            get {
                return XSports.GetStringTable(
                    TonNurako.Motif.ResourceId.XmNdirListItems, DirListItemCount, true, Data.Resource.Access.SG).ToStringArray();
            }
            set {
                XSports.SetStringTable(
                    TonNurako.Motif.ResourceId.XmNdirListItems, new Data.CompoundStringTable(value), Data.Resource.Access.SG);
            }
        }

        /// XmNdirListItemCount XmCDirListItemCount int dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual int DirListItemCount {
            get {
                return XSports.GetInt(
                    TonNurako.Motif.ResourceId.XmNdirListItemCount, 0, Data.Resource.Access.SG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNdirListItemCount, value, Data.Resource.Access.SG);
            }
        }

        /// XmNdirListLabelString XmCDirListLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string DirListLabelString {
            get {
                return XSports.GetString(
                    TonNurako.Motif.ResourceId.XmNdirListLabelString, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetString(
                    TonNurako.Motif.ResourceId.XmNdirListLabelString, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdirMask XmCDirMask XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string DirMask {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNdirMask, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNdirMask, value, Data.Resource.Access.CSG);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNdirSearchProc XmCDirSearchProc XmSearchProc default procedure CSG

        /// XmNdirSpec XmCDirSpec XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string DirSpec {
            get {
                return XSports.GetString(
                    TonNurako.Motif.ResourceId.XmNdirSpec, "", Data.Resource.Access.CSG);
            }
            set {
                XSports.SetString(
                    TonNurako.Motif.ResourceId.XmNdirSpec, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNdirTextLabelString XmCDirTextLabelString XmString NULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual string DirTextLabelString {
            set {
                XSports.SetString(
                    TonNurako.Motif.ResourceId.XmNdirTextLabelString, value, Data.Resource.Access.C);
            }
        }

        /// XmNfileFilterStyle XmCFileFilterStyle XtEnum XmFILTER_NONE C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual FileFilterStyle FileFilterStyle {
            get {
                return XSports.GetValue<FileFilterStyle>(
                    TonNurako.Motif.ResourceId.XmNfileFilterStyle, FileFilterStyle.None, Data.Resource.Access.C);
            }
            set {
                XSports.SetValue<FileFilterStyle>(
                    TonNurako.Motif.ResourceId.XmNfileFilterStyle, value, Data.Resource.Access.C);
            }
        }

        /// XmNfileListItems XmCItems XmStringTable dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual string[] FileListItems {
            get {
                return XSports.GetStringTable(
                    TonNurako.Motif.ResourceId.XmNfileListItems, FileListItemCount, true, Data.Resource.Access.SG).ToStringArray();
            }
            set {
                XSports.SetStringTable(
                    TonNurako.Motif.ResourceId.XmNfileListItems, new Data.CompoundStringTable(value), Data.Resource.Access.SG);
            }
        }

        /// XmNfileListItemCount XmCItemCount int dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual int FileListItemCount {
            get {
                return XSports.GetInt(
                TonNurako.Motif.ResourceId.XmNfileListItemCount, 0, Data.Resource.Access.SG);
            }
            set {
                XSports.SetInt(
                    TonNurako.Motif.ResourceId.XmNfileListItemCount, value, Data.Resource.Access.SG);
            }
        }

        /// XmNfileListLabelString XmCFileListLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string FileListLabelString {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNfileListLabelString, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNfileListLabelString, value, Data.Resource.Access.CSG);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNfileSearchProc XmCFileSearchProc XmSearchProc default procedure CSG

        /// XmNfileTypeMask XmCFileTypeMask unsigned char XmFILE_REGULAR CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual FileTypeMask FileTypeMask {
            get {
                return XSports.GetValue<FileTypeMask>(
                    TonNurako.Motif.ResourceId.XmNfileTypeMask, FileTypeMask.Regular, Data.Resource.Access.CSG);
            }
            set {
            XSports.SetValue<FileTypeMask>(
                TonNurako.Motif.ResourceId.XmNfileTypeMask, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNfilterLabelString XmCFilterLabelString XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string FilterLabelString {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNfilterLabelString, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNfilterLabelString, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNlistUpdated XmCListUpdated Boolean dynamic SG
        [Data.Resource.SportyResource(Data.Resource.Access.SG)]
        public virtual bool ListUpdated {
            get {
                return XSports.GetBool(
                TonNurako.Motif.ResourceId.XmNlistUpdated, false, Data.Resource.Access.SG);
            }
            set {
            XSports.SetBool(
                TonNurako.Motif.ResourceId.XmNlistUpdated, value, Data.Resource.Access.SG);
            }
        }

        /// XmNnoMatchString XmCNoMatchString XmString " [    ] " CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string NoMatchString {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNnoMatchString, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNnoMatchString, value, Data.Resource.Access.CSG);
            }
        }

        /// XmNpathMode XmCPathMode XtEnum XmPATH_MODE_FULL C
        [Data.Resource.SportyResource(Data.Resource.Access.C)]
        public virtual PathMode PathMode {

            set {
            XSports.SetValue<PathMode>(
                TonNurako.Motif.ResourceId.XmNpathMode, value, Data.Resource.Access.C);
            }
        }

        /// XmNpattern XmCPattern XmString dynamic CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual string Pattern {
            get {
                return XSports.GetString(
                TonNurako.Motif.ResourceId.XmNpattern, "", Data.Resource.Access.CSG);
            }
            set {
            XSports.SetString(
                TonNurako.Motif.ResourceId.XmNpattern, value, Data.Resource.Access.CSG);
            }
        }
        // ### UNKOWN TYPE
        // ### XmNqualifySearchDataProc XmCQualifySearchDataProc XmQualifyProc default procedure CSG
		#endregion

		#region ｲﾍﾞﾝﾄ

		#endregion

	}
}
