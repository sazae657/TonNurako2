//
// ﾄﾝﾇﾗｺ
//
// ｴｸｽﾄﾘーﾑｽﾎﾟーﾂ
//
using System;
using System.Collections.Generic;
using TonNurako.X11;

namespace TonNurako.Native {

    /// <summary>
    /// ﾈーﾁﾌﾞなﾊﾝﾄﾞﾙへのｱｸｾｯｻー
    /// </summary>
    public class NativeWidget :
     TonNurako.X11.IDrawable, IEquatable<NativeWidget> {
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="ptr">Widget</param>
        public NativeWidget(System.IntPtr ptr) {
            if (IntPtr.Zero == ptr) {
                throw new NullReferenceException("Null Widget!!");
            }
            Widget = new TonNurako.Xt.Widget(ptr);

            Display = new X11.Display(()=> TonNurako.Xt.XtSports.XtDisplay(Widget.Handle));
            Window = new X11.Window(()=> TonNurako.Xt.XtSports.XtWindow(Widget.Handle), Display);
            Screen = new X11.Screen(()=>TonNurako.Xt.XtSports.XtScreen(Widget.Handle));

            Hash = ptr.ToInt64().ToString().GetHashCode();
        }

        /// <summary>
        /// Widget
        /// </summary>
        /// <returns>Widget</returns>
        public TonNurako.Xt.Widget Widget {
            get;
        }

        /// <summary>
        /// Display
        /// </summary>
        /// <returns>Display</returns>
        public X11.Display Display { get; }

        /// <summary>
        /// Window
        /// </summary>
        /// <returns>Window</returns>
        public X11.Window Window { get; }

        /// <summary>
        /// ﾄﾞﾛﾜﾎﾞー
        /// </summary>
        public IntPtr Drawable => Window.Handle;


        /// <summary>
        /// Screen
        /// </summary>
        /// <returns>Screen</returns>
        public X11.Screen Screen { get; }

        /// <summary>
        /// RootWindowOfScreen
        /// </summary>
        /// <returns>RootWindowOfScreen</returns>
        public X11.Window RootWindowOfScreen => Screen.RootWindowOfScreen;

        /// <summary>
        /// Name
        /// </summary>
        /// <returns>Name</returns>
        public string XtName =>
            TonNurako.Xt.XtSports.XtName(Widget.Handle);


        /// <summary>
        /// WidgetRecAccessor
        /// </summary>
        /// <returns>Name</returns>
        public Xt.Core.WidgetRecAccessor WidgetRecAccessor => new Xt.Core.WidgetRecAccessor(Widget.Handle);
        
        /// <summary>
        /// 比較
        /// </summary>
        /// <param name="with">比較元</param>
        /// <returns>比較結果</returns>
        public bool Equals(NativeWidget with) => (this.Widget.Handle == with.Widget.Handle);


        /// <summary>
        /// 比較
        /// </summary>
        /// <param name="with">比較元</param>
        /// <returns>比較結果</returns>
        public override bool Equals(Object with) {
            if (with == null)
                return base.Equals(with);
            if (with is NativeWidget)
                return Equals(with as NativeWidget);
            return false;
        }

        /// <summary>
        /// ﾊｯｼｭ
        /// </summary>
        /// <param name="obj">WidgetHandle</param>
        /// <returns>ﾊｯｼｭ</returns>
        public override int GetHashCode() => Hash;

        /// <summary>
        /// ﾊｯｼｭ
        /// </summary>
        /// <returns>ﾊｯｼｭ</returns>
        public int Hash {
            get;
        }
    }


    /// <summary>
    /// WidgetHandleの比較演算子
    /// </summary>
    public class NativeWidgetComparer : IEqualityComparer<NativeWidget>
    {
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns></returns>
        public bool Equals(NativeWidget x, NativeWidget y) => x.Equals(y);

        /// <summary>
        /// ﾊｯｼｭ
        /// </summary>
        /// <param name="obj">WidgetHandle</param>
        /// <returns>ﾊｯｼｭ</returns>
        public int GetHashCode(NativeWidget obj) => obj.Hash;
    }
}
