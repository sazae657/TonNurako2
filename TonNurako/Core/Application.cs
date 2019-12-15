//
// ﾄﾝﾇﾗｺ
//
//　ﾄﾝﾇﾗｹーｼｮﾝ
//
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TonNurako.Data;
using TonNurako.Native;
using TaskItem = System.Tuple<System.Threading.SendOrPostCallback, object>;

namespace TonNurako {
    /// <summary>
    /// ｱﾌﾟﾘｹーｼｮﾝｺﾝﾃｷｽﾄの実行諸々
    /// </summary>
    sealed public class Application
    {
        internal class SingleThreadSynchronizationContext : SynchronizationContext
        {
            ConcurrentQueue<TaskItem> continuations = new ConcurrentQueue<TaskItem>();

            public override void Post(SendOrPostCallback d, object state) {
                continuations.Enqueue(new TaskItem(d, state));
            }

            public void Update() {
                TaskItem cont;
                while(continuations.TryDequeue(out cont))
                {
                    cont.Item1(cont.Item2);
                }
            }
        }

		/// <summary>
        /// ｸﾞﾛーﾊﾞﾙｺﾝﾃｷｽﾄ(使わない)
        /// </summary>
		private static ApplicationContext GlobalContext {
            get;
            set;
        }

		//最終ﾘﾀーﾝｺーﾄﾞ
		private static int retVal = 0;

		//"名前"払い出し用ｶｳﾝﾀ
		private static int widgetCount = 0;


        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="_Ctx">ﾄﾝﾇﾗｺﾝﾃｷｽﾄ</param>
        /// <param name="_Shell">ｼｪﾙ</param>
        /// <returns></returns>
        public static int Run(ApplicationContext _Ctx, Widgets.IShell _Shell) {
            return Run(_Ctx, _Shell, new string[]{});
        }

        public delegate void Delegaty();

        /// <summary>
        /// ﾗｲﾌﾞﾗﾘーの登録
        /// </summary>
        public static void RegisterGlobals() {
            TonNurako.Xt.XtSports.Register("Xt");
            TonNurako.Motif.XmSports.Register("Xm");
            TonNurako.X11.Xi.Register("X11");
        }

        /// <summary>
        /// ﾗｲﾌﾞﾗﾘーの登録解除
        /// </summary>
        public static void UnregisterGlobals() {
            TonNurako.Motif.XmSports.Unregister();
            TonNurako.Xt.XtSports.Unregister();
            TonNurako.X11.Xi.Unregister();
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="_Ctx">ﾄﾝﾇﾗｺﾝﾃｷｽﾄ</param>
        /// <param name="_Shell">ｼｪﾙ</param>
        /// <param name="_Args">引数(Xtに渡されちゃうよ)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static int Run(ApplicationContext _Ctx, Widgets.IShell _Shell, string[] _Args) {
            _Ctx.SyncContext =  new SingleThreadSynchronizationContext();

            GlobalContext = _Ctx;

            RegisterGlobals();

            if (_Ctx.Name == "") {
                Assembly running = Assembly.GetEntryAssembly();
                // 名無しｺﾝﾃｷｽﾄは無理なのでﾌｧｲﾙ名から強制命名
                _Ctx.Name = System.IO.Path.GetFileNameWithoutExtension(running.Location);
            }

            var rs = new List<string>();
            foreach(var v in _Ctx.FallbackResource) {
                rs.Add($"{v.Key}: {v.Value}");
            }
            rs.Add(null);

            ExtremeSports.TnkCode code =
                (ExtremeSports.TnkCode)ExtremeSports.XtInitialize(_Ctx.Handle, _Ctx.Name, _Args, rs.ToArray());
            if (ExtremeSports.TnkCode.Ok != code) {
                throw new Exception(code.ToString());
            }

            _Ctx.Handle.Comm = () => {
                _Ctx.SyncContext.Update();
            };

            //名前ｶｳﾝﾀーの初期化
			widgetCount = 0;
            using(_Shell) {
                _Ctx.Shell = _Shell;
                _Shell.Create(_Ctx, _Args);
                _Shell.Realize();
                ExtremeSports.TriggerPrivateEvent(_Ctx.Handle, _Shell);
                ExtremeSports.AppMainLoop(_Ctx.Handle.Context.Handle, () => {
                    _Ctx.SyncContext.Update();
                });
            }

            UnregisterGlobals();

            return retVal;
        }

		/// <summary>
		/// それなりにﾕﾆーｸな"名前"を払い出す
		/// </summary>
		/// <returns>それなりにﾕﾆーｸな"名前"</returns>
		public static string CreateTempName( string key )
		{
            if (null != GlobalContext) {
                return GlobalContext.CreateTempName(key);
            }
            return $"TNK_{key}{widgetCount++:d4}";
		}

		/// <summary>
		/// ｱﾌﾟﾘｹーｼｮﾝの終了
		/// </summary>
		public static void Exit(ApplicationContext _Ctx)
		{
			//全ｳｲｼﾞｪｯﾄを優しく殺す
			ExtremeSports.AppSetExitFlag(_Ctx.Handle.Context.Handle);
		}

    }
}
