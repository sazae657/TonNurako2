using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TonNurako.Native;

using TonNurako.Widgets;
namespace TonNurako.Data
{
    /// <summary>
    /// ﾘｿーｽ
    /// TODO: このｸﾗｽは仕事し過ぎなので分割を考える
    /// </summary>
    public sealed class XResource : IDisposable
	{
		/// <summary>
		/// 完成待ちのｳｲｼﾞｪｯﾄ参照
		/// </summary>
		private struct WaitWidget {
			public IWidget widget;
			public Enum arg;

			public WaitWidget(Enum  a, IWidget w) {
				widget = w;
				arg = a;
			}
		}

		/// <summary>
		/// 配列のﾎﾟﾝﾀーを参照するﾌﾞﾂ
		/// </summary>
        private class ArrayPtrResource :IDisposable {
            private IntPtr addrOfArray = IntPtr.Zero;
            internal IntPtr Array {
                get {return addrOfArray;}
            }
            internal int Count {
                get; private set;
            }

            public ArrayPtrResource() {
            }

            public void SetValue(byte[] arr) {
                Count = arr.Length;
                addrOfArray = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(byte)) * arr.Length);
                Marshal.Copy(arr, 0, addrOfArray, arr.Length);
            }

            #region IDisposable Support
            private bool disposedValue = false;
            protected virtual void Dispose(bool disposing)
            {
                if (disposedValue) {
                    return;
                }
                if (IntPtr.Zero != addrOfArray) {
                    Marshal.FreeCoTaskMem(addrOfArray);
                    addrOfArray = IntPtr.Zero;
                }
                disposedValue = true;
            }
            public void Dispose() {
                Dispose(true);
                System.GC.SuppressFinalize(this);
            }

            ~ArrayPtrResource() {
                Dispose(false);
            }
            #endregion
        }

		/// <summary>
		/// stringのﾎﾟﾝﾀーを参照するﾌﾞﾂ
		/// </summary>
        private class StringPtrResource :IDisposable {
            private IntPtr addrOfString = IntPtr.Zero;
            internal IntPtr String {
                get {return addrOfString;}
            }
            public StringPtrResource(string src) {
                addrOfString = Marshal.StringToCoTaskMemAnsi(src);
            }

            #region IDisposable Support
            private bool disposedValue = false;
            protected virtual void Dispose(bool disposing)
            {
                if (disposedValue) {
                    return;
                }
                if (IntPtr.Zero != addrOfString) {
                    Marshal.FreeCoTaskMem(addrOfString);
                    addrOfString = IntPtr.Zero;
                }
                disposedValue = true;
            }
            public void Dispose() {
                Dispose(true);
                System.GC.SuppressFinalize(this);
            }

            ~StringPtrResource() {
                Dispose(false);
            }
            #endregion
        }

		//#region ｲﾝｽﾀﾝｽ変数

		//保持するﾘｿーｽ
		private List<TonNurako.Xt.Arg> resources;

		//完成待ちのｳｲｼﾞｪｯﾄ参照
		private List<WaitWidget> waitWidget;

		//参照保持
		private List<IDisposable> retainObjects;

        private List<TonNurako.Xt.XtCallbackProc> callbacks;


        // ﾍﾟﾝﾃﾞｨﾝｸﾞ？
        bool isPending = false;

        bool isDisposed = false;


        public IWidget Widget {
            get;
            set;
        }

        public void Begin() {
            isPending = true;
        }
        public void Commit(bool clear) {
            isPending = false;
            SetWidget(clear);
        }


		#region ﾌﾟﾛﾊﾟﾃｨ

		/// <summary>
		/// 現在ｾｯﾄされているﾘｿーｽの数を返す
		/// </summary>
		public int Count
		{
			get
			{
				return resources.Count;
			}
		}
		#endregion


		/// <summary>
		/// ｺﾝｽﾄﾗｸﾀー
		/// </summary>
		/// <param name="widget">管理対象のｳｲｼﾞｪｯﾄ</param>
		public XResource(IWidget widget)
		{
			//保持用ﾘｿーｽの確保
			resources = new List<TonNurako.Xt.Arg>();

			waitWidget = new List<WaitWidget>();

			retainObjects = new List<IDisposable>();

            callbacks = new List<TonNurako.Xt.XtCallbackProc>();

            isPending = false;


            Widget = widget;
		}

		//#region ﾘｿーｽの追加

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, int val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg), val);

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}


		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, uint val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg), val);

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, long val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg), val);

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, ulong val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg), val);

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, IntPtr val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , val);

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}


		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, Native.NativeWidget val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , val.Widget.Handle);

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}


		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, Enum val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , Convert.ToInt32(val));

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, bool val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , val ? 1 : 0 );

			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, ushort val )
		{
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , (int)val);
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, TonNurako.GC.Color val)
		{
            ulong pixel = val.Pixel;
            if (null != Widget) {
                pixel = val.ToXColor(Widget).Pixel;
            }
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , pixel);
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, IWidget val )
		{
			if( val != null )
			{
				waitWidget.Add( new WaitWidget(arg, val));
			}
			else
			{
				Add(arg, 0);
			}
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, CompoundString val )
		{
			//保持
			retainObjects.Add(val);
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , val);
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, CompoundStringTable val )
		{
			//保持
			retainObjects.Add(val);
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , val.ToPointer());
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, SportyFontList val )
		{
			//保持
			retainObjects.Add(val);
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , val.FontList);
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, byte[] val) {
            var arr = new ArrayPtrResource();
            arr.SetValue(val);

			//保持
			retainObjects.Add(arr);
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(ToolkitOptionAttribute.GetToolkitName(arg) , arr.Array);
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}


		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, string val )
		{
            var str = new StringPtrResource(val);
            retainObjects.Add(str);
			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(
                ToolkitOptionAttribute.GetToolkitName(arg) , str.String
            );
			//ﾃーﾌﾞﾙに追加
			resources.Add( args );
		}

		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void Add(Enum arg, TonNurako.Xt.XtCallbackProc val )
		{
            callbacks.Add(new TonNurako.Xt.XtCallbackProc(val));

			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(
                ToolkitOptionAttribute.GetToolkitName(arg) , val
            );
			//ﾃーﾌﾞﾙに追加
			resources.Add( args );
		}



		/// <summary>
		/// ﾘｿーｽの追加
		/// </summary>
		/// <param name="arg">ｾｯﾄするﾘｿーｽ</param>
		/// <param name="val">値</param>
		public void AddRAW(string arg, string val )
		{
            //var str = new StringPtrResource(val);
            //retainObjects.Add(str);

			//ﾘｿーｽの保持用
			TonNurako.Xt.Arg args = new TonNurako.Xt.Arg(arg , val);
			//ﾃーﾌﾞﾙに追加
			resources.Add(args);
		}

		/// <summary>
		/// 保持している作成待ちｳｲｼﾞｪｯﾄのﾁｪｯｸ
		/// </summary>
		private void ResWidget()
		{
			//空の場合は無視
			if( waitWidget.Count == 0 )
			{
				return;
			}

			List<WaitWidget> dl = new List<WaitWidget>();

			foreach( WaitWidget c in waitWidget )
			{
				if( c.widget.IsAvailable )
				{
					this.Add( c.arg, c.widget.Handle );

                    dl.Add( c );
              	}
			}

			foreach(WaitWidget o in dl )
			{
                waitWidget.Remove( o );
			}

			dl.Clear();
		}

		/// <summary>
		/// ﾘｿーｽのｸﾘｱ
		/// </summary>
		public void Clear()
		{
            resources.Clear();
			CrearRetainObjects();
		}

        /// <summary>
        /// IntPtr系のﾌﾞﾂを保持させる
        /// </summary>
        /// <param name="obzekt">ｵﾌﾞｾﾞｸﾄ</param>
        public void RetainCustomObject(IDisposable obzekt)
        {
            retainObjects.Add(obzekt);
        }

		/// <summary>
		/// 保持ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
		/// </summary>
		public void CrearRetainObjects()
		{
            foreach (IDisposable d in retainObjects) {
                d.Dispose();
            }
            retainObjects.Clear();
		}

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (isDisposed) {
                return;
            }
            callbacks.Clear();
            isDisposed = true;
            Clear();
        }


		//#region ﾘｿーｽの取得
		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(BOOL)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		/// <param name="val">取得した値を格納する領域</param>
		public void GetValue(Enum arg, out byte val )
		{
			ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out val );
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(BOOL)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		/// <param name="val">取得した値を格納する領域</param>
		public void GetValue(Enum arg, out bool val )
		{
			ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out val );
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(int)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		/// <param name="val">取得した値を格納する領域</param>
		public void GetValue(Enum arg, out int val )
		{
			ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out val );
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(ushort)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		/// <param name="val">取得した値を格納する領域</param>
		public void GetValue(Enum arg, out ushort val )
		{
			ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out val );
		}

		public void GetValue(Enum arg, out long val )
		{
			ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out val );
		}

		public void GetValue(Enum arg, out TonNurako.GC.Color val )
		{
            long pixel = 0;
			ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out pixel);

            val = new TonNurako.GC.Color((uint)pixel);
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(ushort)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		public string GetStringValue(Enum arg)
		{
            string ret = "";
            using(CompoundString s =
                ExtremeSports.XtGetValuesCS(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg))) {
                ret = s.String;
            }
            return ret;
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(ushort)
		/// </summary>
		public string GetAnsiStringValue(Enum arg, bool callFree)
		{
            return ExtremeSports.XtGetValuesAS(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), callFree);
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(ushort)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		public CompoundString GetCompoundStringValue(Enum arg)
		{
            return ExtremeSports.XtGetValuesCS(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg));
		}


		/// <summary>
		/// Pixmap
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		public X11.Pixmap GetPixmapValue(Enum arg)
		{
            throw new NotImplementedException();
		}

		/// <summary>
		/// Widgetに関連づけられているﾘｿーｽを取得(IntPtr)
		/// </summary>
		/// <param name="arg">取得するﾘｿーｽ</param>
		public IntPtr GetPointerValue(Enum arg)
		{
            long ret;
            ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out ret);
            return (IntPtr)ret;
		}

        /// <summary>
        /// Widgetに関連づけられているﾘｿーｽを取得(int)
        /// </summary>
        /// <param name="arg">取得するﾘｿーｽ</param>
        public long GetIntValue(Enum arg) {
            int ret;
            ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out ret);
            return ret;
        }

        /// <summary>
        /// Widgetに関連づけられているﾘｿーｽを取得(long)
        /// </summary>
        /// <param name="arg">取得するﾘｿーｽ</param>
        public long GetLongValue(Enum arg) {
            long ret;
            ExtremeSports.XtGetValues(Widget.Handle, ToolkitOptionAttribute.GetToolkitName(arg), out ret);
            return ret;
        }

        /// <summary>
        /// Argに変換
        /// </summary>
        public TonNurako.Xt.Arg[] ToXtArg() {
			TonNurako.Xt.Arg [] res = new TonNurako.Xt.Arg[ resources.Count ];
			for(int i = 0 ; i < resources.Count ; i++) {
				res[i] = resources[i];
			}
            return res;
        }


		/// <summary>
		/// ﾘｿーｽをWidgetにｾｯﾄする
		/// </summary>
		/// <param name="clear">trueを指示するとｾｯﾄ後に保持しているﾘｿーｽを消去</param>
		public void SetWidget(bool clear )
		{
			//待ちｳｲｼﾞｪｯﾄのﾁｪｯｸ
			ResWidget();

			//空の場合は無視する
			if ((0 == resources.Count) || (true != Widget.IsAvailable) || (true == isPending)) {
				return;
			}
			//ﾘｿーｽの設定
			ExtremeSports.SetValues(Widget, ToXtArg());

			//保持ﾘｿーｽの破棄
			if( clear == true ) {
                Clear();
			}
		}


	}
}
