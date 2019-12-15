//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// MessageDialog
	/// </summary>
	public class MessageDialog : MessageBox
	{

		#region 生成

		public MessageDialog()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        // Separator
        // Symbol

		public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateMessageDialog, parent, ToolkitResources);
			}

			return base.Create (parent);
		}

		#endregion
	}

	/// <summary>
	/// ErrorDialog
	/// </summary>
    public class ErrorDialog : MessageDialog {

		public ErrorDialog()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateErrorDialog, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
    }

	/// <summary>
	/// InformationDialog
	/// </summary>
    public class InformationDialog : MessageDialog {


		public InformationDialog()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateInformationDialog, parent, ToolkitResources);
			}

			return base.Create (parent);
		}
    }

	/// <summary>
	/// QuestionDialog
	/// </summary>
    public class QuestionDialog : MessageDialog {
		public QuestionDialog()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateQuestionDialog, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
    }

	/// <summary>
	/// TemplateDialog
	/// </summary>
    public class TemplateDialog : MessageDialog {

		public TemplateDialog()  : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateTemplateDialog, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
    }

    /// <summary>
    /// WarningDialog
    /// </summary>
    public class WarningDialog : MessageDialog {


		public WarningDialog()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

         public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateWarningDialog, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
    }

    /// <summary>
    /// WorkingDialog
    /// </summary>
    public class WorkingDialog : MessageDialog {

		public WorkingDialog()  : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        public override int Create( IWidget parent )
		{
			if( !IsAvailable ) {
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateWorkingDialog, parent, ToolkitResources);
			}
			return base.Create (parent);
		}
    }
}
