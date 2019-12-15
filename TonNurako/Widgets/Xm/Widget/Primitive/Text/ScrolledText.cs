//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
	/// <summary>
	/// ScrolledText
	/// </summary>
	public class ScrolledText : Text
	{

		public ScrolledText() : base()
		{
		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

		public override int Create(IWidget parent)
		{
			if( !IsAvailable )
			{
				this.CreateMotifWidget(TonNurako.Motif.CreateSymbol.XmCreateScrolledText, parent, ToolkitResources);
			}
			return base.Create (parent);
		}


	}
}
