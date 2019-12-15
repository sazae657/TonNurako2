using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using TonNurako.Data;
using TonNurako.Widgets;
using TonNurako.Widgets.Xm;

namespace Widgets {
    class Widgets : TonNurako.Widgets.LayoutWindow<TonNurako.Widgets.Xm.MainWindow> {

        RowColumn rightPane;
        Form leftPane;
        Label widgetty;
        Widget currentWidget;
        CascadeButtonGadget childMenuButton;
        Dictionary<string, Type> widgetMap;

        Widgets() {
        }

        /// <summary>
        /// Shellができた
        /// </summary>
        public override void ShellCreated()
        {
            this.Layout.MenuBar = CreateMenu();
            this.Title = Properties.Resources.Title;
            this.IconName = Properties.Resources.IconTitle;


            var pw = new Paned();
            pw.Name = "pw";
            pw.Orientation = Orientation.Horizontal;
            this.Layout.Children.Add(pw);

            var frame = new Frame();
            frame.MarginWidth = 5;
            frame.MarginHeight = 5;
            frame.PanedConstraint.PaneMinimum = 200;
            pw.Children.Add(frame);

            leftPane = new Form();
            leftPane.Name = "leftPane";
            //rc.Width = 320;
            leftPane.Height = 640;
            leftPane.MarginWidth =
            leftPane.MarginHeight = 10;

            frame.Children.Add(leftPane);

            var sb = new ScrolledWindow();
            sb.ScrollingPolicy = ScrollingPolicy.Automatic;
            sb.Name = "sb";
            sb.TopAttachment =
            sb.RightAttachment =
            sb.LeftAttachment =
            sb.BottomAttachment = AttachmentType.Form;
            sb.PanedConstraint.AllowResize = true;
            sb.PanedConstraint.PaneMaximum = 1920;
            sb.PanedConstraint.PaneMinimum = 640;
            pw.Children.Add(sb);

            rightPane = new RowColumn();
            rightPane.Name = "rightPane";
            rightPane.Height = 200;

            rightPane.TopAttachment =
            rightPane.RightAttachment =
            rightPane.LeftAttachment =
            rightPane.BottomAttachment = AttachmentType.Form;

            sb.Children.Add(rightPane);

            SetWidget(new PushButton(), false);

            this.RealizedEvent += (sender,ev) => {
                this.IconPixmap = TonNurako.GC.PixmapFactory.FromXpm(this, Properties.Resources.icon_xpm);
            };
        }

        #region Reflection

        class TypeMap {
            public string Key;
            public Type Type;
            public Dictionary<string, TypeMap> Children;

            public TypeMap(string k, Type t)
            {
                Key = k;
                Type = t;
                Children = new Dictionary<string, TypeMap>();
            }
        }

        /// <summary>
        /// ウイジェットクラスのマップ作る
        /// </summary>
        /// <param name="root"></param>
        /// <param name="type"></param>
        void CreateWigetClassMap(TypeMap root, Type type)
        {
            List<Type> tl = new List<Type>();
            for (var g = type; null != g && g != typeof(TonNurako.Widgets.WidgetBase); g = g.BaseType) {
                tl.Insert(0, g);
            }
            TypeMap mop = root;
            for (int i = 0; i < tl.Count; ++i) {
                string key = tl[i].Name.Replace("TonNurako.Widgets.Xm.", "");
                if (tl[i].GetInterfaces().Contains(typeof(TonNurako.Widgets.IDefectiveWidget))) {
                    key = $"<{key}>";
                }

                if (!mop.Children.ContainsKey(key)) {
                    mop.Children.Add(key, new TypeMap(tl[i].ToString(), tl[i]));
                }
                mop = mop.Children[key];
            }
        }

        /// <summary>
        /// TypeMapをダンプする
        /// </summary>
        /// <param name="root"></param>
        /// <param name="level"></param>
        void DumpMap(TypeMap root, int level)
        {
            string indent = "";
            for (int i = 0; i <= level; ++i) {
                indent += "  ";
            }
            Console.WriteLine($"{indent} N:{root.Key} ({root.Children.Count})");
            foreach (var c in root.Children) {
                Console.WriteLine($"{indent}   C:{c.Key}");
            }
            foreach (var w in root.Children) {
                DumpMap(w.Value, level++);
            }
        }

        /// <summary>
        /// TypeMapからメニューを作る
        /// </summary>
        /// <param name="root"></param>
        /// <param name="pdm"></param>
        /// <param name="delegaty"></param>
        void CreateMenuFromMap(TypeMap root, TonNurako.Widgets.Xm.PulldownMenu pdm,
                             EventHandler<TonNurako.Events.PushButtonEventArgs> delegaty)
        {
            string indent = "";
            Console.WriteLine($"{indent} N:{root.Key} ({root.Children.Count})");
            foreach (var w in root.Children) {
                if (0 == w.Value.Children.Count) {
                    var xb = new PushButtonGadget();
                    xb.LabelString = w.Key;
                    xb.ActivateEvent += delegaty;
                    pdm.Children.Add(xb);
                    continue;
                }

                if (!w.Value.Type.IsAbstract) {
                    var xb = new PushButtonGadget();
                    xb.LabelString = w.Key;
                    xb.ActivateEvent += delegaty;
                    pdm.Children.Add(xb);
                }

                var cb = new CascadeButton();
                cb.LabelString = w.Key;
                pdm.Children.Add(cb);

                var pm = new PulldownMenu();
                cb.Children.Add(pm);
                cb.SubMenuId = pm;
                CreateMenuFromMap(w.Value, pm, delegaty);
            }
        }
        #endregion


        #region メニュー


        /// <summary>
        /// メニュー生成
        /// </summary>
        /// <returns></returns>
        IWidget CreateMenu()
        {
            TonNurako.Widgets.Xm.MenuBar smbar;
            smbar = new TonNurako.Widgets.Xm.MenuBar();
            this.Layout.Children.Add(smbar);

            // PDM
            var pdm = new TonNurako.Widgets.Xm.PulldownMenu();
            pdm.Name = "PDM";
            smbar.Children.Add(pdm);

            var cb1 = new TonNurako.Widgets.Xm.CascadeButton();
            cb1.Name = "CB";
            cb1.LabelString = "メニュー(M)";
            cb1.Mnemonic = TonNurako.Data.KeySym.FromName("M");
            cb1.SubMenuId = pdm;
            smbar.Children.Add(cb1);

            pdm.Children.Add(
             ((Func<PushButtonGadget>)(() => {
                 var t = new PushButtonGadget();
                 t.LabelString = "クリアー";
                 t.ActivateEvent += (X, Y) => {
                     Console.WriteLine($"push {X.GetType()} -> {Y.GetType()}");
                     Console.WriteLine($"{Y.DumpStruct()}");
                     this.Clear(true);
                 };
                 return t;
             }))());
            pdm.Children.Add(
             ((Func<PushButtonGadget>)(() => {
                 var t = new PushButtonGadget();
                 t.LabelString = "追加(button)";
                 t.ActivateEvent += (X, Y) => {
                     this.SetWidget(new PushButton(), true);
                 };
                 return t;
             }))());

            pdm.Children.Add(
             ((Func<PushButtonGadget>)(() => {
                 var t = new PushButtonGadget();
                 t.LabelString = "終了";
                 t.ActivateEvent += (X, Y) => {
                     this.Destroy();
                 };
                 return t;
             }))());

            // help
            var helpm = new TonNurako.Widgets.Xm.PulldownMenu();
            helpm.Name = "HELP";
            smbar.Children.Add(helpm);

            var helpb = new TonNurako.Widgets.Xm.CascadeButtonGadget();
            helpb.LabelString = "ヘルプ(H)";
            helpb.Mnemonic = TonNurako.Data.KeySym.FromName("H");
            helpb.SubMenuId = helpm;
            smbar.Children.Add(helpb);

            helpm.Children.Add(
             ((Func<PushButtonGadget>)(() => {
                 var t = new PushButtonGadget();
                 t.LabelString = "これについて";
                 t.ActivateEvent += (X, Y) => {
                     var d = new InformationDialog();
                     d.WidgetCreatedEvent += (x, y) => {
                         d.Items.Cancel.Visible = false;
                         d.Items.Help.Visible = false;
                     };
                     d.WidgetManagedEvent += (x, y) => {
                        d.SymbolPixmap = TonNurako.GC.PixmapFactory.FromXpm(this, Properties.Resources.icon_xpm);
                     };
                     StringBuilder str = new StringBuilder();
                     foreach (var asp in AppDomain.CurrentDomain.GetAssemblies()) {
                         if (asp.FullName.StartsWith("TonNurako")) {
                             str.Append($"{asp.GetName().Name} Version: {asp.GetName().Version}(ExtremeSports:{TonNurako.Native.ExtremeSports.GetVersion()})\n");

                             var mv = TonNurako.Native.ExtremeSports.GetMotifVersion();
                             var mvx = mv % 1000;
                             var mvy = (mv - mvx) / 1000;
                             str.Append($"Motif {mvy}.{mvx} ({TonNurako.Native.ExtremeSports.GetMotifVersionString()})\n");
                             str.Append($"\nRuntime: {Environment.Version}").Append("\n");
                             using (var und = TonNurako.Native.Uname.Get()) {
                                 str.Append($"Platform: {und.SysName} Release:{und.Release}({und.Machine})").Append("\n");
                             }
                             break;
                         }
                     }
                     d.DialogTitle = "トンヌラコ";
                     d.DialogStyle = DialogStyle.ApplicationModal;
                     d.MessageString = str.ToString();
                     d.OkLabelString = "わかった";

                     this.Layout.Children.Add(d);
                     d.Visible = true;

                 };
                 return t;
             }))());

            smbar.MenuHelpWidget = helpb;


            // widget
            var wdm = new TonNurako.Widgets.Xm.PulldownMenu();
            wdm.Name = "WDM";
            wdm.TearOffModel = TearOffModel.Enabled;
            smbar.Children.Add(wdm);

            var wdb = new TonNurako.Widgets.Xm.CascadeButtonGadget();
            wdb.Name = "wdb";
            wdb.LabelString = "ウイジェット(W)";
            wdb.SubMenuId = wdm;
            wdb.Mnemonic = TonNurako.Data.KeySym.FromName("W");
            smbar.Children.Add(wdb);

            // widget
            var cwm = new TonNurako.Widgets.Xm.PulldownMenu();
            cwm.Name = "cwm";
            cwm.TearOffModel = TearOffModel.Enabled;
            smbar.Children.Add(cwm);

            childMenuButton = new TonNurako.Widgets.Xm.CascadeButtonGadget();
            childMenuButton.Name = "childMenuButton";
            childMenuButton.LabelString = "子ウイジェット(C)";
            childMenuButton.SubMenuId = cwm;
            childMenuButton.Mnemonic = TonNurako.Data.KeySym.FromName("C");
            smbar.Children.Add(childMenuButton);
            // デフォ無効
            childMenuButton.Sensitive = false;

            Assembly asm = null;
            foreach (var t in AppDomain.CurrentDomain.GetAssemblies()) {
                //Console.WriteLine($"W:{t.FullName}");
                if (t.FullName.StartsWith("TonNurako")) {
                    asm = t;
                }
            }
            widgetMap = new Dictionary<string, Type>();

            TypeMap map = new TypeMap("ROOT", typeof(object));
            Console.WriteLine($"W:{asm.ToString()}");
            foreach (var t in (from x in asm.GetTypes() where x.IsClass && !x.IsAbstract orderby x.Name select x)) {
                var r = from c in t.GetInterfaces()
                        where c == typeof(TonNurako.Widgets.IChild) &&
                              c.IsPublic
                        select c;

                if (0 != r.Count()) {
                    string key = t.Name.Replace("TonNurako.Widgets.Xm.", "");
                    if (t.GetInterfaces().Contains(typeof(TonNurako.Widgets.IDefectiveWidget))) {
                        Console.WriteLine($"IGNORE W:{t.ToString()} C:{r.Count()}");
                        key = $"<{key}>";
                    }
                    Console.WriteLine($"found W:{t.ToString()} C:{r.Count()}");
                    CreateWigetClassMap(map, t);
                    widgetMap.Add(key, t);
                }
            }

            foreach (var m in map.Children) {
                // 普通のやつ
                CreateMenuFromMap(m.Value, wdm, OnWidgetMenuSelect);
                // 子
                CreateMenuFromMap(m.Value, cwm, OnChildMenuSelect);
            }
            DumpMap(map, 0);
            return smbar;
        }

        /// <summary>
        /// ウイジェットメニューハンドラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnWidgetMenuSelect(object sender, TonNurako.Events.PushButtonEventArgs args)
        {
            var wc = ((PushButtonGadget)sender).LabelString;
            Console.WriteLine($"Menu {widgetMap[wc]}");
            if (widgetMap[wc].IsAbstract) {
                return;
            }
            SetWidget((Widget)Activator.CreateInstance(widgetMap[wc]), true);
        }

        /// <summary>
        /// 子ウイジェットメニューハンドラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnChildMenuSelect(object sender, TonNurako.Events.PushButtonEventArgs args)
        {
            var wc = ((PushButtonGadget)sender).LabelString;
            Console.WriteLine($"Menu {widgetMap[wc]}");
            if (widgetMap[wc].IsAbstract) {
                return;
            }

            IChild cw = (Widget)Activator.CreateInstance(widgetMap[wc]);
            cw.Name = $"Child_{currentWidget.Children.Count()}";
            currentWidget.Children.Add(cw);

        }
        public void activate(object sender, TonNurako.Events.PushButtonEventArgs args)
        {
            Console.WriteLine("Activate");
        }

        #endregion

        #region 左ペイン操作
        /// <summary>
        /// ウイジェットを左ペインにセット
        /// </summary>
        /// <param name="widget"></param>
        /// <param name="showDlg"></param>
        void SetWidget(Widget widget, bool showDlg)
        {
            WorkingDialog wd = null;
            if (showDlg) {
                wd = new WorkingDialog();
                wd.LabelString = "wait";
                wd.DialogStyle = DialogStyle.ApplicationModal;
                this.Children.Add(wd);
                wd.Visible = true;
            }

            rightPane.Visible =
            leftPane.Visible = false;
            Clear(false);

            currentWidget = widget;
            widget.Name = "TEST";

            leftPane.Children.Add(widget);
            ((Widget)widget).DestroyEvent += (x, y) => {
                rightPane.DestroyChildren();
            };

            CreatePropertyPane(rightPane, widget);
            if (!widget.AllowAutoManage) {
                ((Widget)widget).Visible = true;
            }
            childMenuButton.Sensitive = true;

            rightPane.Visible =
            leftPane.Visible = true;

            if (null != wd) {
                wd.Destroy();
                wd = null;
            }

        }

        /// <summary>
        /// クリア
        /// </summary>
        /// <param name="hide"></param>
        void Clear(bool hide)
        {
            if (hide) {
                rightPane.Visible =
                leftPane.Visible = false;
            }
            currentWidget = null;
            childMenuButton.Sensitive = false;
            leftPane.DestroyChildren();
            if (hide) {
                leftPane.Visible =
                rightPane.Visible = true;
            }

        }

        #endregion

        #region 右ペイン

        /// <summary>
        /// プロパチーペインを作る
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="instance"></param>
        void CreatePropertyPane(Manager parent, IWidget instance)
        {
            widgetty = new Label();
            widgetty.LabelString = instance.ToString();
            parent.Children.Add(widgetty);
            var rendition = new Rendition();
            //rendition.FontName = "Misc Fixed";
            rendition.FontName = "Misc";
            rendition.FontStyle = "Regular";
            rendition.FontSize = 14;
            rendition.UnderlineType = StrikethruType.SINGLE_LINE;
            rendition.FontType = FontType.FONT;
            rendition.Create(this);
            var render = new RenderTable(new Rendition[] { rendition });
            widgetty.RenderTable = render;

            rendition.Dispose();
            render.Dispose();

            Type target = instance.GetType();
            while (null != target && !target.Equals(typeof(System.Object))) {
                Console.WriteLine($"{target}");
                var f = CreateFormFromClass(parent, target, instance);
                target = target.BaseType;
            }
        }


        /// <summary>
        /// クラスからフォーム生成
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="type"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        IChild CreateFormFromClass(Manager parent, Type type, IWidget instance)
        {
            var frame = new Frame();
            frame.EntryAlignment = Alignment.Beginning;
            frame.MarginHeight = frame.MarginWidth = 2;
            parent.Children.Add(frame);

            var label = new Label();
            label.FrameConstraint.ChildType = FrameChildType.TitleChild;
            label.LabelString = type.Name;
            frame.Children.Add(label);

            var form = new WorkArea();
            form.TopAttachment = AttachmentType.Widget;
            form.TopWidget = widgetty;
            form.RightAttachment =
            form.LeftAttachment = AttachmentType.Form;
            form.NumColumns = 3;
            form.Packing = Packing.Column;
            frame.Children.Add(form);

            PropertyInfo[] infoArray = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo info in infoArray) {
                if (!Attribute.IsDefined(info, typeof(TonNurako.Data.Resource.SportyResourceAttribute))) {
                    continue;
                }
                var attr = (TonNurako.Data.Resource.SportyResourceAttribute)Attribute.GetCustomAttribute(
                                            info, typeof(TonNurako.Data.Resource.SportyResourceAttribute));
                if (!attr.Access.HasFlag(TonNurako.Data.Resource.Access.G)) {
                    continue;
                }

                if (info.PropertyType.Equals(typeof(IWidget)) ||
                    info.PropertyType.GetInterfaces().Contains(typeof(IWidget)) ||
                    info.PropertyType.IsSubclassOf(typeof(EventHandler))) {
                    continue;
                }

                bool result = true;
                var ifr = new Frame();
                ifr.EntryAlignment = Alignment.Beginning;
                ifr.MarginHeight = ifr.MarginWidth = 2;
                var ttl = new Label();
                ttl.FrameConstraint.ChildType = FrameChildType.TitleChild;
                ttl.LabelString = info.Name;
                ifr.Children.Add(ttl);

                var prop = new PropHolder(instance, info, attr.Access);

                if (info.PropertyType.IsSubclassOf(typeof(Enum))) {
                    result = CreateEnumForm(ifr, prop);
                }
                else if (info.PropertyType.Equals(typeof(bool))) {
                    result = CreateBooleanForm(ifr, prop);
                }
                else if (info.PropertyType.Equals(typeof(string))) {
                    result = CreateStringRWForm(ifr, prop);
                }
                else if (info.PropertyType.Equals(typeof(int))) {
                    result = CreateIntForm(ifr, prop);
                }
                else if (info.PropertyType.Equals(typeof(TonNurako.GC.Color))) {
                    result = CreateColorRWForm(ifr, prop);
                }
                else if (info.PropertyType.Equals(typeof(TonNurako.Data.KeySym))) {
                    result = CreateKeySymForm(ifr, prop);
                }
                else if (info.PropertyType.Equals(typeof(TonNurako.X11.Pixmap))) {
                    result = CreatePixmapSelectorForm(ifr, prop);
                }
                else {
                    result = CreateLabelForm(ifr, prop);
                }
                if (!result) {
                    ifr.Destroy();
                }
                else {
                    form.Children.Add(ifr);
                }
            }
            return frame;
        }

        class PropHolder {
            public PropertyInfo info;
            public object instance;
            public TonNurako.Data.Resource.Access access;
            public List<string> list;

            public PropHolder(object ins, PropertyInfo ifo, TonNurako.Data.Resource.Access acc)
            {
                info = ifo;
                instance = ins;
                access = acc;
                list = null;
            }

        }

        /// <summary>
        /// 列挙定数のフォーム生成
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateEnumForm(Frame frame, PropHolder prop)
        {
            var cb = new SimpleOptionMenu();
            cb.FrameConstraint.ChildHorizontalAlignment = Alignment.Beginning;
            List<string> el = new List<string>();
            int i = 0;
            foreach (var v in Enum.GetValues(prop.info.PropertyType)) {
                el.Add(v.ToString());
                if (Enum.Equals(v, prop.info.GetValue(prop.instance, null))) {
                    cb.ButtonSet = i;
                }
                i++;
            }

            cb.ButtonCount = el.Count;
            cb.Buttons = el.ToArray();
            prop.list = el;
            cb.UserData = prop;

            cb.SimpleEvent += (x, y) => {
                PropHolder ph = (PropHolder)y.Sender.UserData;
                Console.WriteLine($"index={y.SelectedIndex} E={Enum.Parse(ph.info.PropertyType, ph.list[y.SelectedIndex])}");
                ph.info.SetValue(ph.instance, Enum.Parse(ph.info.PropertyType, ph.list[y.SelectedIndex]), null);
            };

            frame.Children.Add(cb);
            return true;
        }

        /// <summary>
        /// booleanのチェックボックス生成
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateBooleanForm(Frame frame, PropHolder prop)
        {
            var msc = new SimpleCheckBox();
            var cb = new ToggleButtonGadget();
            cb.LabelString = prop.info.Name;
            cb.Set = ((bool)prop.info.GetValue(prop.instance, null)) ? ToggleButtonState.Set : ToggleButtonState.Unset;
            cb.UserData = prop;
            cb.ValueChangedEvent += (x, y) => {
                PropHolder p = (PropHolder)y.Sender.UserData;
                p.info.SetValue(p.instance, (bool)(y.Set == ToggleButtonState.Set), null);
            };
            if (!prop.info.CanWrite) {
                cb.Sensitive = false;
            }
            msc.Children.Add(cb);
            frame.Children.Add(msc);
            return true;
        }

        /// <summary>
        /// 書き込める文字列フォーム
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateStringRWForm(Frame frame, PropHolder prop)
        {
            var cb = new Text();
            cb.UserData = prop;

            cb.ValueChangedEvent += (x, y) => {
                PropHolder p = (PropHolder)y.Sender.UserData;
                p.info.SetValue(p.instance, cb.Value, null);
            };
            try {
                var v = prop.info.GetValue(prop.instance, null);
                cb.Value = null != v ? v.ToString() : "";
            }
            catch {
                return false;
            }
            if (!prop.info.CanWrite) {
                cb.Editable = false;
            }
            frame.Children.Add(cb);
            return true;
        }

        /// <summary>
        /// int(スピンボックス)
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateIntForm(Frame frame, PropHolder prop)
        {
            if (!prop.info.CanWrite) {
                var label = new Label();
                label.LabelString = prop.info.GetValue(prop.instance, null).ToString();
                frame.Children.Add(label);
                return true;
            }
            var msc = new SimpleSpinBox();
            msc.SpinBoxChildType = SpinBoxChildType.Numeric;
            msc.MinimumValue = 0;
            msc.MaximumValue = 9999;
            msc.Editable = true;
            msc.UserData = prop;

            msc.ValueChangedEvent += (x, y) => {
                PropHolder p = (PropHolder)y.Sender.UserData;
                p.info.SetValue(p.instance, y.Position, null);
            };
            try {
                msc.Position = (int)prop.info.GetValue(prop.instance, null);
            }
            catch {
                return false;
            }
            msc.WidgetCreatedEvent += (X, T) => {
                msc.TextField.ModifyVerifyEvent += (x, y) => {
                    if (!Regex.IsMatch(y.InputString, @"^[0-9]+$")) {
                        y.DoIt = false;
                    }
                };
            };

            frame.Children.Add(msc);


            return true;
        }

        /// <summary>
        /// 書き込めるColorフォーム
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateColorRWForm(Frame frame, PropHolder prop)
        {
            var cb = new Text();
            cb.UserData = prop;

            cb.ValueChangedEvent += (x, y) => {
                PropHolder p = (PropHolder)y.Sender.UserData;
                try {
                    var color = TonNurako.GC.Color.FromName(this, cb.Value);
                    p.info.SetValue(p.instance, color, null);
                }
                catch {
                    cb.Value = "";
                }
            };
            try {
                var v = prop.info.GetValue(prop.instance, null);
                cb.Value = null != v ? v.ToString() : "";
            }
            catch {
                return false;
            }
            if (!prop.info.CanWrite) {
                cb.Editable = false;
            }
            frame.Children.Add(cb);
            return true;
        }

        /// <summary>
        /// KeySym(text)
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateKeySymForm(Frame frame, PropHolder prop)
        {
            var cb = new Text();
            cb.UserData = prop;

            cb.ValueChangedEvent += (x, y) => {
                PropHolder p = (PropHolder)y.Sender.UserData;
                try {
                    var sym = TonNurako.Data.KeySym.FromName(cb.Value);
                    p.info.SetValue(p.instance, sym, null);
                }
                catch {
                    cb.Value = "";
                }
            };
            try {
                var v = prop.info.GetValue(prop.instance, null);
                cb.Value = null != v ? v.ToString() : "";
            }
            catch {
                return false;
            }
            if (!prop.info.CanWrite) {
                cb.Editable = false;
            }
            frame.Children.Add(cb);
            return true;
        }

        /// <summary>
        /// Pixmap(FileSelectionDialog)
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreatePixmapSelectorForm(Frame frame, PropHolder prop)
        {
            var frx = new Form();
            frame.Children.Add(frx);

            var cb = new Label();
            cb.LabelString = "(none)";
            cb.BorderWidth = 1;
            frx.Children.Add(cb);

            var sb = new PushButton();
            sb.UserData = prop;

            sb.LabelString = "...";
            sb.ActivateEvent += (x, y) => {
                PropHolder war = (PropHolder)y.Sender.UserData;
                var fsb = new FileSelectionDialog();
                fsb.PathMode = PathMode.Relative;
                fsb.DialogStyle = DialogStyle.FullApplicationModal;
                fsb.Pattern = "*.xpm";
                fsb.OkEvent += (Windows, XP) => {
                    var path = fsb.DirSpec;
                    if (System.IO.File.Exists(path)) {
                        try {
                            var pixmap = TonNurako.GC.PixmapFactory.FromXpm(this.Layout, path);
                            war.info.SetValue(war.instance, pixmap, null);
                            cb.LabelString = fsb.TextString;
                        }
                        catch {
                            cb.LabelString = "";
                        }
                    }
                    fsb.Destroy();
                };
                fsb.CancelEvent += (Windows, XP) => {
                    fsb.Destroy();
                };
                this.Children.Add(fsb);
                fsb.Visible = true;
            };

            frx.WidgetNowAvailableEvent += (x, y) => {
                sb.LeftAttachment = AttachmentType.Widget;
                sb.LeftWidget = cb;
            };
            frx.Children.Add(sb);
            return true;
        }

        /// <summary>
        /// 読み取り専用フォーム(label)
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        bool CreateLabelForm(Frame frame, PropHolder prop)
        {
            var msc = new Label();
            try {
                msc.LabelString = prop.info.PropertyType.ToString();
            }
            catch {
                return false;
            }
            frame.Children.Add(msc);
            return true;
        }
        #endregion


        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));
            var app = new TonNurako.ApplicationContext();
            app.Name = "UNKO";
            app.FallbackResource.Add("*fontList", "-misc-fixed-medium-r-normal--14-*-*-*-*-*-*-*:");
            app.FallbackResource.Add("*geometry", "+100+100");
            app.FallbackResource.Add("*title", "トンヌラコ");

            TonNurako.Application.Run(app, new Widgets());
        }
    }
}
