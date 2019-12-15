//
// ﾄﾝﾇﾗｺ
//
// Widget
//
namespace TonNurako.Widgets.Xm
{
    /// <summary>
    /// Composite
    /// </summary>
    public abstract class Composite : Core
    {
		internal Composite() : base()
		{

		}

        internal override void InitalizeLocals()
        {
            base.InitalizeLocals();
        }

        /// <summary>
        /// 子ｳｲｼﾞｪｯﾄの作成
        /// </summary>
        /// <param name="parent">親ｳｲｼﾞｪｯﾄ</param>
        /// <returns></returns>
        public override int Create( IWidget parent )
		{
			return base.Create( parent );
		}

		#region Compositeﾌﾟﾛﾊﾟﾃｨ

        /*
        XmNchildren	XmCReadOnly	WidgetList	NULL	G
        XmNinsertPosition	XmCInsertPosition	XtOrderProc	NULL	CSG

        */

        /// XmNnumChildren	XmCReadOnly	Cardinal	0	G
        [Data.Resource.SportyResource(Data.Resource.Access.G)]
        public virtual int NumChildren {
            get {
                return XSports.GetInt(TonNurako.Motif.ResourceId.XmNnumChildren, 0, Data.Resource.Access.G);
            }
        }
		#endregion


    }
}
