using System;
using System.Collections.Generic;

namespace TonNurako.Data
{


    /// <summary>
    /// ｴｸｽﾄﾘーﾑﾘｿーｽｽﾎﾟーﾂ
    /// </summary>
    public sealed class ExtremeResourceSports : IDisposable
    {
        internal Widgets.IWidget widget;
        struct WidgetHolder {
            public Widgets.IWidget widget;
            public Enum key;

            public WidgetHolder(Enum k, Widgets.IWidget w) {
                key = k;
                widget = w;
            }
        }

        Dictionary<Widgets.IWidget, List<WidgetHolder>> widgetResList;

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀー
        /// </summary>
        /// <param name="widget"></param>
        public ExtremeResourceSports(Widgets.IWidget widget) {
            this.widget = widget;
            this.widgetResList = new Dictionary<Widgets.IWidget, List<WidgetHolder>>();
        }

        //
        // byte
        //

        internal byte GetByte(Enum key, byte def, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return def;
            }
            byte dat = def;
            widget.ToolkitResources.GetValue(key, out dat );
            return dat;
        }


        internal void SetByte(Enum key, byte val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
            widget.ToolkitResources.SetWidget(true);
        }

        //
        // bool
        //

        internal bool GetBool(Enum key, bool def, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return def;
            }
            bool dat = def;
            widget.ToolkitResources.GetValue(key, out dat );
            return dat;
        }

        internal void SetBool(Enum key, bool val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
            widget.ToolkitResources.SetWidget(true);
        }

        //
        // UInt16
        //

        internal ushort GetUInt16(Enum key, ushort def, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return def;
            }
            ushort dat = def;
            widget.ToolkitResources.GetValue(key, out dat );
            return dat;
        }

        internal void SetUInt16(Enum key, ushort val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
            widget.ToolkitResources.SetWidget(true);
        }

        //
        // int32
        //

        internal int GetInt(Enum key, Int32 def, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return def;
            }
            Int32 dat = def;
            widget.ToolkitResources.GetValue(key, out dat );
            return dat;
        }

        internal void SetInt(Enum key, Int32 val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
            widget.ToolkitResources.SetWidget(true);
        }
        //
        // uint32
        //
        internal UInt32 GetUInt(Enum key, UInt32 def, Resource.Access access = Resource.Access.CSG) {
            return (UInt32)GetInt(key, (int)def, access);
        }

        internal void SetUInt(Enum key, UInt32 val, Resource.Access access = Resource.Access.CSG) {
            SetInt(key, (Int32)val, access);
        }

        //
        // Color
        //
        internal GC.Color GetColor(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }
            GC.Color ret;
            widget.ToolkitResources.GetValue(key, out ret);
            return ret;
        }

        internal void SetColor(Enum key, GC.Color color, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, color);
            widget.ToolkitResources.SetWidget(true);
        }

        internal void SetPixmap(Enum key, X11.Pixmap pixmap, Resource.Access accessa = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, (ulong)pixmap.Drawable);
            widget.ToolkitResources.SetWidget(true);
        }

        //
        // pixmap
        //

        internal X11.Pixmap GetPixmap(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }
            return widget.ToolkitResources.GetPixmapValue(key);
        }

        //
        // Widget
        //

        internal void SetWidget<T>(Enum key, T widg, Resource.Access access = Resource.Access.CSG) where T : class,Widgets.IWidget
        {
            if (!widg.IsAvailable) {
                throw new InvalidOperationException($"{widg.GetType()} Not Avalible!!");
            }
            widget.ToolkitResources.Add(key, widg.Handle);
            widget.ToolkitResources.SetWidget(true);
        }

        internal void SetChildWidget<T>(Enum key, T widg, Resource.Access access = Resource.Access.CSG) where T : class,Widgets.IChild
        {
            if(! widg.IsAvailable) {
                if (! this.widgetResList.ContainsKey(widg)) {
                    widg.WidgetNowAvailableEvent += this.OnWidgetNowAvailable;
                    this.widgetResList.Add(widg, new List<WidgetHolder>());
                }
                this.widgetResList[widg].Add(new WidgetHolder(key, widg));
                if (null == widg.Parent) {
                    widget.Children.Add(widg);
                }
            }
            else {
                SetWidget<T>(key, widg, access);
            }
        }

        private void OnWidgetNowAvailable(object sender, Events.TnkWidgetEventArgs a) {
            if (! this.widgetResList.ContainsKey(a.Sender)) {
                return;
            }
            foreach (WidgetHolder e in this.widgetResList[a.Sender]) {
                widget.ToolkitResources.Add(e.key, e.widget.Handle);
            }
            widget.ToolkitResources.SetWidget(true);
            this.widgetResList.Remove((Widgets.IWidget)a.Sender);
            a.Sender.WidgetNowAvailableEvent -= this.OnWidgetNowAvailable;
        }

        internal T GetWidget<T>(Enum key, Resource.Access access = Resource.Access.CSG) where T : class,Widgets.IWidget
        {
            if (! widget.IsAvailable) {
                return null;
            }
            IntPtr ptr = widget.ToolkitResources.GetPointerValue(key);
            if (ptr == IntPtr.Zero) {
                return null;
            }
            Widgets.IWidget wgt;
            if (null != (wgt = widget.AppContext.FindWidgetByHandle(ptr))) {
                return (T)wgt;
            }
            return null;
        }

        //
        // KeySym
        //
        internal void SetKeySym(Enum key, Data.KeySym sym, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, sym.NativeKeySym);
            widget.ToolkitResources.SetWidget(true);
        }

        internal Data.KeySym GetKeySym(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }

            var ks = this.GetInt(key, (int)0, access);
            return Data.KeySym.FromKeySym(ks);
        }

        //
        // Translations
        //
        internal void SetTranslations(Enum key, Xt.Translations sym, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, sym.Handle);
            widget.ToolkitResources.SetWidget(true);
        }

        internal Xt.Translations GetTranslations(Enum key, Resource.Access access = Resource.Access.CSG) {
            throw new System.NotImplementedException("GET XtTranslations");
        }

        //
        // Accelerators
        //
        internal void SetAccelerators(Enum key, Data.Accelerators sym, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, sym.Binary);
            widget.ToolkitResources.SetWidget(true);
        }

        internal Data.Accelerators GetAccelerators(Enum key, Resource.Access access = Resource.Access.CSG) {
            throw new System.NotImplementedException("GET XtAccelerators");
        }


        //
        // AnsiString
        //
        internal string GetAnsiString(Enum key, string def, Resource.Access access = Resource.Access.CSG) {
            return GetAnsiString(key, def, true, access);
        }

        internal string GetAnsiString(Enum key, string def, bool callFree, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return def;
            }

            string s = widget.ToolkitResources.GetAnsiStringValue(key, callFree);
            if (null == s) {
                return def;
            }
            return s;
        }

        internal void SetAnsiString(Enum key, string val, Resource.Access access = Resource.Access.CSG) {
			widget.ToolkitResources.Add(key, val);
   			widget.ToolkitResources.SetWidget(true);
        }

        //
        // String
        //
        internal string GetString(Enum key, string def, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return def;
            }

            string s = widget.ToolkitResources.GetStringValue(key);
            if (null == s) {
                return def;
            }
            return s;
        }

        internal void SetString(Enum key, string val, Resource.Access access = Resource.Access.CSG) {
			widget.ToolkitResources.Add(key, new CompoundString(val));
   			widget.ToolkitResources.SetWidget(true);
        }

        //
        // XmString
        //

        internal CompoundString GetCompoundString(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }
            return widget.ToolkitResources.GetCompoundStringValue(key);
        }

        internal void SetCompoundString(Enum key, CompoundString val, Resource.Access access = Resource.Access.CSG) {
			widget.ToolkitResources.Add(key, val);
   			widget.ToolkitResources.SetWidget(true);
        }

        //
        // StringTable
        //
        internal CompoundStringTable GetStringTable(Enum key, int count, bool isRef, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }
            IntPtr ptr = widget.ToolkitResources.GetPointerValue(TonNurako.Motif.ResourceId.XmNitems);
            if (IntPtr.Zero == ptr) {
                return null;
            }
            return (new CompoundStringTable(ptr, count, isRef));
        }

        internal void SetStringTable(Enum key, CompoundStringTable val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
   			widget.ToolkitResources.SetWidget(true);
        }


        //
        // FontList
        //
        internal SportyFontList GetFontList(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }
            throw new NotImplementedException();
        }

        internal void SetFontList(Enum key, SportyFontList val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
   			widget.ToolkitResources.SetWidget(true);
        }

        //
        // RenderTable
        //
        internal Data.RenderTable GetRenderTable(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return null;
            }
            var r = widget.ToolkitResources.GetPointerValue(key);
            if (IntPtr.Zero == r) {
                return null;
            }
            return (new Data.RenderTable(r));

        }

        internal void SetRenderTable(Enum key, Data.RenderTable val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val.Handle);
   			widget.ToolkitResources.SetWidget(true);
        }


        //
        // pointer
        //
        internal IntPtr GetPtr(Enum key, Resource.Access access = Resource.Access.CSG) {
            if (! widget.IsAvailable) {
                return IntPtr.Zero;
            }
            return widget.ToolkitResources.GetPointerValue(key);
        }

        internal void SetPtr(Enum key, IntPtr val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
   			widget.ToolkitResources.SetWidget(true);
        }

        //
        // Callback
        //
        internal void SetCallback(Enum key, TonNurako.Xt.XtCallbackProc val, Resource.Access access = Resource.Access.CSG) {
            widget.ToolkitResources.Add(key, val);
   			widget.ToolkitResources.SetWidget(true);
        }
        //
        // 定数っぽいやつ
        //
        internal T GetValue<T>(Enum key, T def, Resource.Access access = Resource.Access.CSG) where T : struct {
            if (! widget.IsAvailable) {
                return def;
            }

            int v = Convert.ToInt32(def);
            widget.ToolkitResources.GetValue(key, out v);
            return (T)System.Enum.ToObject(typeof(T), v);
        }

        internal void SetValue<T>(Enum key, T val, Resource.Access access = Resource.Access.CSG) where T : struct {
            int v = Convert.ToInt32(val);
            widget.ToolkitResources.Add(key, v);
            widget.ToolkitResources.SetWidget(true);
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (disposedValue) {
                return;
            }

        }
        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
