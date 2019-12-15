//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// MainWindow
	/// </summary>
	public class MainWindow : ScrolledWindow
	{

		public MainWindow()  : base()
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
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateMainWindow, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

        /// XmNcommandWindow XmCCommandWindow Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CSG)]
        public virtual IWidget CommandWindow {
            get {
                return XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNcommandWindow);
            }
            set {
            XSports.SetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNcommandWindow, value);
            }
        }


        /// XmNcommandWindowLocation XmCCommandWindowLocation unsigned char ABOVE (SeeDesc.) CG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual CommandWindowLocation CommandWindowLocation {
            get {
                return XSports.GetValue<CommandWindowLocation>(
                    TonNurako.Motif.ResourceId.XmNcommandWindowLocation, CommandWindowLocation.AboveWorkspace, Data.Resource.Access.CG);
            }
            set {
                XSports.SetValue<CommandWindowLocation>(TonNurako.Motif.ResourceId.XmNcommandWindowLocation, value, Data.Resource.Access.CG);
            }
        }


        /// XmNmainWindowMarginHeight XmCMainWindowMarginHeight Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int MainWindowMarginHeight {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmainWindowMarginHeight, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmainWindowMarginHeight, value);
            }
        }


        /// XmNmainWindowMarginWidth XmCMainWindowMarginWidth Dimension 0 CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual int MainWindowMarginWidth {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNmainWindowMarginWidth, 0);
            }
            set {
            XSports.SetInt(TonNurako.Motif.ResourceId.XmNmainWindowMarginWidth, value);
            }
        }


        /// XmNmenuBar XmCMenuBar Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual IWidget MenuBar {
            get {
                return XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNmenuBar);
            }
            set {
                XSports.SetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNmenuBar, value);
            }
        }


        /// XmNmessageWindow XmCMessageWindow Widget NULL CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual IWidget MessageWindow {
            get {
                return XSports.GetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNmessageWindow);
            }
            set {
            XSports.SetWidget<IWidget>(TonNurako.Motif.ResourceId.XmNmessageWindow, value);
            }
        }


        /// XmNshowSeparator XmCShowSeparator Boolean False CSG
        [Data.Resource.SportyResource(Data.Resource.Access.CG)]
        public virtual bool ShowSeparator {
            get {
                return XSports.GetBool(TonNurako.Motif.ResourceId.XmNshowSeparator, false);
            }
            set {
                XSports.SetBool(TonNurako.Motif.ResourceId.XmNshowSeparator, value);
            }
        }

	}
}
