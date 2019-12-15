using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.Widgets.Shell {

    /// <summary>
    /// Motif関与しないShell
    /// </summary>
    public class TopLevel : ShellBase {

        public TopLevel() : base() {
        }

        #region 作成

        /// <summary>
        /// 最下層ｳｲｼﾞｪｯﾄの作成
        /// </summary>
        /// <param name="context">ｺﾏﾝﾄﾞﾗｲﾝ引数</param>
        /// <param name="args">ｺﾏﾝﾄﾞﾗｲﾝ引数</param>
        /// <returns></returns>
        public override int Create(ApplicationContext context, string[] args) {

            //名称が何も指定されていない場合
            if (this.Name == "") {
                this.Name = this.GetType().Name;
            }

            //ShellWidget作成
            CreateShell(context, args);

            return base.Create(context, args);
        }

        #endregion


        #region 作成/破棄
        internal override void InitalizeLocals() {
            base.InitalizeLocals();
        }

        internal override void InitialzieShell(ApplicationContext _Ctx) {
            base.InitialzieShell(_Ctx);
        }


        /// <summary>
        /// ｳｲｼﾞｪｯﾄの破壊
        /// </summary>
		public override void Destroy() {
            //親ｸﾗｽに任せる
            base.Destroy();

            //Applicationの管理ﾘｽﾄから削除
            AppContext.RemoveShellWidget(this);
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }

        #endregion

    }
}
