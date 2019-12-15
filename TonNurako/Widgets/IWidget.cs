//
// ﾄﾝﾇﾗｺ
//
// Widget
//
using System;
using System.Collections;
using System.Collections.Generic;
using TonNurako.Data;

namespace TonNurako.Widgets {

    /// <summary>
    /// Widget
    /// </summary>
    public interface IWidget : System.IDisposable  {
        /// <summary>
        /// ﾁﾙﾄﾞﾚﾝをﾏﾈーｼﾞする
        /// </summary>
        void ManageChildren();

        /// <summary>
        /// ﾁﾙﾄﾞﾚﾝをﾃﾞｽﾄﾛｲする
        /// </summary>
        void DestroyChildren();

        /// <summary>
        /// XToolkitのWidgetを取得 (あぶない)
        /// </summary>
        Native.NativeWidget Handle {get; set;}

        /// <summary>
        /// このWidget、生きてますか？
        /// </summary>
        bool IsAvailable { get;}

        /// <summary>
        /// このWidget、ﾃﾞｽﾎﾟーｽﾞされましたか
        /// </summary>
        bool IsDisposed { get;}

        /// <summary>
        /// Widgetをﾃﾞｽﾄﾛｲする
        /// </summary>
        void Destroy();

        /// <summary>
        /// XToolkitでそのまま使われる名前
        /// 設定しなかったら実装ｸﾗｽで勝手に命名しちゃうよ
        /// </summary>
        string Name {get; set;}

        /// <summary>
        /// このWidgetにぶら下がっているWidget達
        /// </summary>
        WidgetCollection Children {get;}

        /// <summary>
        /// ﾂーﾙｷｯﾄﾘｿーｽｱｸｾｽ用危険ﾃﾞﾝｼﾞｬﾗｽI/F
        /// </summary>
        XResource ToolkitResources { get; }

        /// <summary>
        /// ｻーﾊﾞーｲﾍﾞﾝﾄ
        /// </summary>
        Events.ServerEvent XServerEvent {
            get;
        }

        /// <summary>
        /// ﾏﾈーｼﾞされてる？
        /// </summary>
        bool IsManaged { get; }

        /// <summary>
        /// 生成時に勝手にﾏﾈーｼﾞして良いですかね？
        /// </summary>
        bool AllowAutoManage { get; }

        /// <summary>
        /// ﾗｯﾌﾟされてる？
        /// </summary>
        bool WrappedWidget { get; }

        /// <summary>
        /// このWidgetが隷属するｱﾌﾟﾘｹーｼｮﾝｺﾝﾃｷｽﾄへの参照
        /// </summary>
        ApplicationContext AppContext{ get; set;}

        /// <summary>
        /// お好きなﾃﾞーﾀをどうぞ
        /// </summary>
        object UserData { get; set; }

        //
        // ｲﾍﾞﾝﾄ
        //

        /// <summary>
        /// 使えるようになったぞｲﾍﾞﾝﾄ
        /// </summary>
        event EventHandler<Events.TnkWidgetEventArgs> WidgetNowAvailableEvent;
    }

    /// <summary>
    /// ｼｪﾙ
    /// </summary>
    public interface IShell : IWidget {
        /// <summary>
        /// ｼｪﾙを生成する
        /// </summary>
        /// <param name="_Ctx">隷属先のｱﾌﾟﾘｹーｼｮﾝｺﾝﾃｷｽﾄ</param>
        /// <param name="args">引数</param>
        /// <returns></returns>
        int Create(ApplicationContext _Ctx, string[] args);

        /// <summary>
        /// 表示する
        /// </summary>
        void Realize();

        /// <summary>
        /// それなりにﾕﾆーｸなIDが欲しい
        /// </summary>
        Guid UniqueId { get; }
    }

    /// <summary>
    /// ｶーｿﾙの挙動
    /// </summary>
    public enum GrabOption {
        None = TonNurako.Motif.Constant.XtGrabNone,
        NonExclusive = TonNurako.Motif.Constant.XtGrabNonexclusive,
        Exclusive = TonNurako.Motif.Constant.XtGrabExclusive
    }

    /// <summary>
    /// ｼｪﾙ
    /// </summary>
    public interface IPopup : IWidget {
        /// <summary>
        /// 表示する
        /// </summary>
        void Popup(GrabOption option);

        /// <summary>
        /// 隠す
        /// </summary>
        void Popdown();
    }

    /// <summary>
    /// Shellでは無い親が無いとﾀﾞﾒな人たち
    /// </summary>
    public interface IChild : IWidget {

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="parent">親Widget</param>
        /// <returns>成功時はｾﾞﾛ</returns>
        int Create(IWidget parent );

        /// <summary>
        /// 親
        /// </summary>
        IWidget Parent {get;}

        /// <summary>
        /// 幅
        /// </summary>
        int Width {get; set;}

        /// <summary>
        /// 高さ
        /// </summary>
        int Height {get; set;}

        /// <summary>
        /// 位置(X)
        /// </summary>
        int X {get; set;}

        /// <summary>
        /// 位置(Y)
        /// </summary>
        int Y {get; set;}
    }

    /// <summary>
    /// ﾏﾈーｼﾞｬーな人達(結構偉い!!)
    /// </summary>
    public interface IManagerWidget : IChild {
    }

    /// <summary>
    /// 不完全実装
    /// </summary>
    public interface IDefectiveWidget {
    }

    /// <summary>
    /// 不完全ｺーﾙﾊﾞｯｸ
    /// </summary>
    public interface IDefectiveCallback {
    }


    #region ふぇいく

    /// <summary>
    /// 一時変数などでﾗｯﾌﾟする用のWidget
    /// </summary>
    public class ﾄﾝﾇﾗｼﾞｪｯﾄ : IWidget
    {
        private ﾄﾝﾇﾗｼﾞｪｯﾄ(IntPtr _WdgRef) {
            Handle = new Native.NativeWidget(_WdgRef);
            Children = new WidgetCollection(this);
            xresource = new XResource(this);
            XServerEvent = new Events.ServerEvent(null);
        }

        public ﾄﾝﾇﾗｼﾞｪｯﾄ(IntPtr _WdgRef, IWidget _Parent) {
            Handle = new Native.NativeWidget(_WdgRef);
            Children = new WidgetCollection(this);
            xresource = new XResource(this);
            XServerEvent = new Events.ServerEvent(null);

            if (null != _Parent) {
                AppContext = _Parent.AppContext;
            }
        }

        public ﾄﾝﾇﾗｼﾞｪｯﾄ(TonNurako.Xt.Widget _WdgRef, IWidget _Parent) {
            Handle = new Native.NativeWidget(_WdgRef.Handle);
            Children = new WidgetCollection(this);
            xresource = new XResource(this);
            XServerEvent = new Events.ServerEvent(null);

            if (null != _Parent) {
                AppContext = _Parent.AppContext;
            }
        }


        public ﾄﾝﾇﾗｼﾞｪｯﾄ(IWidget _WdgRef) {
            Handle = new Native.NativeWidget(_WdgRef.Handle.Widget.Handle);
            Children = new WidgetCollection(this);
            xresource = new XResource(this);
            XServerEvent = new Events.ServerEvent(null);

            AppContext = _WdgRef.AppContext;
        }

        public bool IsDisposed { get; internal set; } = false;

        public ApplicationContext AppContext {
            get; set;
        }

        public bool IsManaged {
            get { return false; }
        }
        public bool AllowAutoManage {
            get {return false;}
        }
        public bool WrappedWidget {
            get {return true;}
        }
        public WidgetCollection  Children {
            get;
        }

        public bool  IsAvailable {
            get { return true; }
        }

        public object UserData { get; set; }

        public Native.NativeWidget  Handle {
            get;
            set;
        }

        public  Events.ServerEvent XServerEvent {
            get;
        }

        XResource xresource;
        public XResource ToolkitResources {
            get { return xresource;}
        }

        public string Name {
            get { return "ﾄﾝﾇﾗｺ"; }
            set {}
        }

        public void ManageChildren()
        {
        }

        public void DestroyChildren()
        {
        }

        public void Destroy()
        {
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) {
                return;
            }
            xresource.Dispose();
            xresource = null;
        }

        public event EventHandler<Events.TnkWidgetEventArgs> WidgetNowAvailableEvent {
            add { }
            remove { }
        }

        #endregion
    }
    #endregion

    #region WidgetCollection ｸﾗｽ
    /// <summary>
    /// Widgetをﾘｽﾄ管理する
    /// </summary>
    public sealed class WidgetCollection : IEnumerable<IChild>
    {
        //ｳｲｼﾞｪｯﾄ格納用
        private List<IChild> widgetList = null;

        //親ｳｲｼﾞｪｯﾄ
        private IWidget self;


        //  #region ｺﾝｽﾄﾗｸﾀー
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="owner">このﾘｽﾄを所持するｳｲｼﾞｪｯﾄ</param>
        public WidgetCollection(IWidget owner)
        {
            self = owner;
            widgetList = new List<IChild>();
        }

        /// <summary>
        /// 子ｳｲｼﾞｪｯﾄの追加
        /// </summary>
        /// <param name="w">子ｳｲｼﾞｪｯﾄ</param>
        public void Add(IChild w )
        {
            if (self.Equals(w)) {
                throw new InvalidOperationException("再起Addやめれ");
            }

            widgetList.Add(w);

            //ｳｲｼﾞｪｯﾄの作成
            if( self.IsAvailable ) {
                if(! w.WrappedWidget) {
                    w.Create(self);
                    System.Diagnostics.Debug.WriteLine($"Create<IMM>: {w.ToString()}:{self.GetHashCode()}");
                }
                self.ManageChildren();
            }
            else {
                System.Diagnostics.Debug.WriteLine($"WidgetCollection<Queue>: {w.ToString()} Parent:{self.ToString()}:{self.GetHashCode()}");
            }
        }

        /// <summary>
        /// 子ｳｲｼﾞｪｯﾄの追加
        /// </summary>
        /// <param name="cs">子ｳｲｼﾞｪｯﾄ</param>
        public void Add(IEnumerable<IChild> cs)
        {
            foreach(IChild w in cs) {
                if (self.Equals(w)) {
                    throw new InvalidOperationException("再起Addやめれ");
                }

                widgetList.Add(w);
                //ｳｲｼﾞｪｯﾄの作成
                if( self.IsAvailable ) {
                    if(! w.WrappedWidget) {
                        w.Create(self);
                        System.Diagnostics.Debug.WriteLine($"CreateL<IMM>: {w.ToString()}:{self.GetHashCode()}");
                    }
                    self.ManageChildren();
                }
                else {
                    System.Diagnostics.Debug.WriteLine($"WidgetCollection<Queue>: {w.ToString()} Parent:{self.ToString()}:{self.GetHashCode()}");
                }
            }
        }

        /// <summary>
        /// 子ｳｲｼﾞｪｯﾄの削除
        /// </summary>
        public void Remove(IChild w)
        {
            if( widgetList.Contains( w ) )
            {
                widgetList.Remove( w );
            }
            w.Dispose();
        }

        /// <summary>
        /// 子ｳｲｼﾞｪｯﾄの削除
        /// </summary>
        public void RemoveAll()
        {
            foreach(var w in widgetList)
            {
                w.Dispose();
            }
            widgetList.Clear();
        }

        /// <summary>
        /// Manage()用逆順ﾘｽﾄ
        /// </summary>
        public List<IChild> GetCreationList() {
            return widgetList;
        }

        #region IEnumerable ﾒﾝﾊﾞ

        IEnumerator<IChild> IEnumerable<IChild>.GetEnumerator() {
            return widgetList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return widgetList.GetEnumerator();
        }
        #endregion

    }
    #endregion
}
