//
// ﾄﾝﾇﾗｺ
//
// GC
//
using System;
using TonNurako.Xt;

namespace TonNurako.GC
{
    //
    // たぶん廃止する
    //

    /// <summary>
    /// GC
    /// </summary>
    public class GraphicsContext : IDisposable {
        #region ｲﾝｽﾀﾝｽ変数

        //作成したGCが入る
        private TonNurako.X11.GC gc = null;
        public TonNurako.X11.GC Handle => gc;

        //Displayが入る
        public TonNurako.X11.Display Display { get; private set; }

        //Windowが入る
        public IntPtr Target { get; private set; }

        private bool disposed;

		#endregion

		#region ｺﾝｽﾄﾗｸﾀー

        private GraphicsContext() {
            disposed = false;
        }

		/// <summary>
		/// 共有GC取得
		/// </summary>
		/// <param name="w">Widget</param>
		public static GraphicsContext FromSharedGC(Widgets.IWidget w)
		{
            var gc = new GraphicsContext();

            gc.gc = new TonNurako.X11.GC(TonNurako.Xt.XtSports.XtGetGC(w), w.Handle.Display, w.Handle, false);
            gc.Display = w.Handle.Display;
			gc.Target = w.Handle.Drawable;
            gc.gc.DispseGCDelegate = (g) => {
                //GC解放
                if (null != gc.gc) {
                    TonNurako.Xt.XtSports.XtReleaseGC(w, gc.Handle.Handle);
                    gc = null;
                }
            };
            return gc;
		}


		/// <summary>
		/// GCの作成
		/// </summary>
		/// <param name="w">ﾄﾞﾛﾜﾎﾞー</param>
		public GraphicsContext(TonNurako.X11.IDrawable w)
		{
            disposed = false;
            Display = w.Display;
            Target = w.Drawable;
            //
            // 単純なGCを生成
            // 属性は後でｾｯﾄさせる
            //
            gc = new TonNurako.X11.GC(TonNurako.X11.Xi.XCreateGC(Display, Target), w.Display, w, false);

            gc.DispseGCDelegate = (g)  => {
                //GC解放
                if (gc != null) {
                    TonNurako.X11.Xi.XFreeGC(Display, gc.Handle);
                    gc = null;
                    System.Diagnostics.Debug.WriteLine("GC : Dispose");
                }
            };
		}

		#endregion

		#region IDisposable ﾒﾝﾊﾞ

        /// <summary>
        /// GCの後始末
        /// </summary>
		public void Dispose()
		{
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        ~GraphicsContext() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed) {
                return;
            }
            if (null != gc) {
                gc.Dispose();
            }
            
            disposed = true;
        }

        #endregion

        #region ｸﾘｱ

        /// <summary>
        /// 表示内容のｸﾘｱ
        /// </summary>
        public void Clear()
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XClearWindow(Display, Target );
			}
		}

        public void SetForeground(TonNurako.X11.XColor color) {
            if (gc == null) {
                return;
            }
            TonNurako.X11.Xi.XSetForeground(Display, gc.Handle, color.Pixel);
        }

        public void SetForeground(TonNurako.GC.Color color) {
            if (gc == null) {
                return;
            }
            TonNurako.X11.Xi.XSetForeground(Display, gc.Handle, color.Pixel);
        }

        public void CopyArea(TonNurako.X11.IDrawable dest, int x, int y, int w, int h, int dx, int dy) {
            if (gc == null) {
                return;
            }
            TonNurako.X11.Xi.XCopyArea(Display,
                Target, dest.Drawable,
                this.gc.Handle,
                x, y, (uint)w, (uint)h,
                dx, dy);
        }

		#endregion

		#region 図形描画

		/// <summary>
		/// 点を描画する
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		public void DrawPoint( int x, int y )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawPoint(Display, Target, gc.Handle, x, y );
			}
		}
		/// <summary>
		/// 複数の点を描画する
		/// </summary>
		/// <param name="points">点の座標定義</param>
		/// <param name="mode">点の座標指定ﾓーﾄﾞ</param>
		public void DrawPoints( TonNurako.X11.XPoint [] points, TonNurako.X11.CoordMode mode )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawPoints(Display, Target, gc.Handle, points, points.Length, (int)mode );
			}

		}

		/// <summary>
		/// 直線の描画
		/// </summary>
		/// <param name="ax">始点X座標</param>
		/// <param name="ay">始点Y座標</param>
		/// <param name="fx">終点X座標</param>
		/// <param name="fy">終点Y座標</param>
		public void DrawLine( int ax, int ay, int fx, int fy )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawLine( Display, Target, gc.Handle, ax, ay, fx, fy );
			}
		}

		/// <summary>
		/// 折れ線の描画
		/// </summary>
		/// <param name="points">折れ線の座標定義</param>
		/// <param name="mode">折れ線の座標指定ﾓーﾄﾞ</param>
		public void DrawLines( TonNurako.X11.XPoint [] points, TonNurako.X11.CoordMode mode )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawLines( Display, Target, gc.Handle, points, points.Length, (int)mode );
			}

		}

		/// <summary>
		/// 矩形の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		public void DrawRectangle( int x, int y, int w, int h )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawRectangle( Display, Target, gc.Handle, x, y, (uint)w, (uint)h );
			}
		}

		/// <summary>
		/// 複数矩形の描画
		/// </summary>
		/// <param name="rects">矩形の定義</param>
		public void DrawRectangle( TonNurako.X11.XRectangle [] rects )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawRectangles( Display, Target, gc.Handle, rects, rects.Length );
			}

		}

		/// <summary>
		/// 塗りつぶし矩形の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		public void FillRectangle( int x, int y, int w, int h )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XFillRectangle( Display, Target, gc.Handle, x, y, (uint)w, (uint)h );
			}
		}

		/// <summary>
		/// 複数の塗りつぶし矩形の描画
		/// </summary>
		/// <param name="rects">矩形の定義</param>
		public void FillRectangles( TonNurako.X11.XRectangle [] rects )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XFillRectangles( Display, Target, gc.Handle, rects, rects.Length );
			}

		}

		/// <summary>
		/// 円弧の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		/// <param name="startAngle">開始角(度数*64)</param>
		/// <param name="sweepAngle">角度(度数*64)</param>
		public void DrawArc( int x, int y, int w, int h, int startAngle, int sweepAngle )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawArc( Display, Target, gc.Handle,
					x, y, (uint)w, (uint)h, startAngle, sweepAngle );
			}
		}

		/// <summary>
		/// 複数の円弧の描画
		/// </summary>
		/// <param name="arcs">円弧の定義</param>
		public void DrawArcs( TonNurako.X11.XArc [] arcs )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XDrawArcs( Display, Target, gc.Handle,
					arcs, arcs.Length );
			}
		}

		/// <summary>
		/// 塗りつぶし円弧の描画
		/// </summary>
		/// <param name="x">左上角X座標</param>
		/// <param name="y">左上角Y座標</param>
		/// <param name="w">幅</param>
		/// <param name="h">高さ</param>
		/// <param name="startAngle">開始角(度数*64)</param>
		/// <param name="sweepAngle">角度(度数*64)</param>
		public void FillArc( int x, int y, int w, int h, int startAngle, int sweepAngle )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XFillArc( Display, Target, gc.Handle,
					x, y, (uint)w, (uint)h, startAngle, sweepAngle );
			}
		}

		/// <summary>
		/// 複数の塗りつぶし円弧の描画
		/// </summary>
		/// <param name="arcs">円弧の定義</param>
		public void FillArcs( TonNurako.X11.XArc [] arcs )
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XFillArcs( Display, Target, gc.Handle,
					arcs, arcs.Length );
			}
		}

		#endregion

		#region 線の属性
		/// <summary>
		/// 線の属性の設定
		/// </summary>
		/// <param name="w">幅</param>
		/// <param name="line">線の形状</param>
		/// <param name="cap">端の形状</param>
		/// <param name="join">接合方法</param>
		public void SetLineAttributes( uint w, TonNurako.X11.LineStyle line,
                TonNurako.X11.CapStyle cap,
                TonNurako.X11.JoinStyle join)
		{
			if( gc != null)
			{
				TonNurako.X11.Xi.XSetLineAttributes( Display, gc.Handle,
					w, (int)line, (int)cap, (int)join );
			}
		}
        #endregion

        #region XImage
		public void PutImage(XImage image) {
			if( gc != null) {
				image.PutImage(Display, Target, gc.Handle, 0, 0, 0, 0, image.Width, image.Height);
			}
		}
		public void PutImage(XImage image, int x, int y) {
			if( gc != null) {
				image.PutImage(Display, Target, gc.Handle, x, y, 0, 0, image.Width, image.Height);
			}
		}
		public void PutImage(XImage image, int x, int y, int dx, int dy) {
			if( gc != null) {
				image.PutImage(Display, Target, gc.Handle, x, y, dx, dy, image.Width, image.Height);
			}
		}

		public void PutImage(XImage image, int x, int y, int dx, int dy, int w, int h) {
			if( gc != null) {
				image.PutImage(Display, Target, gc.Handle, x, y, dx, dy, w, h);
			}
		}
        #endregion
        
    }
}
