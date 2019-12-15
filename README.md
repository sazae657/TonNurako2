# ﾄﾝﾇﾗｺ

＜ﾄﾝﾇﾗｺ＞.NetでX/Motifをなんとかしようというﾊﾞﾍﾞﾙの塔＜ﾄﾝﾇﾗｺ＞

ﾗｲｾﾝｽはOpenMotifに従いLGPLとします


![VSS](https://raw.githubusercontent.com/sazae657/TonNurako2/degelop/ScreenShot.png)
[![Build Status](https://travis-ci.org/sazae657/TonNurako2.svg?branch=degelop)](https://travis-ci.org/sazae657/TonNurako2)

## ﾋﾞﾙﾄﾞ

### 必要なもの

* 広い心
* .NET Core SDK 3.0+
* OpenMotif 2.3+
* Python 3.6.0+
* GNU Make

## ｿーｽを取ってくる
```
% git clone https://github.com/sazae657/TonNurako2.git
% cd TonNurako
```

## TonNurako.extremesportsのﾋﾞﾙﾄﾞ準備

以下のｼｽﾃﾑでは事前に準備が必要です

* X11やMotifが一般的でない場所にｲﾝｽﾄーﾙされている場合
* 一部の不自由ｼｽﾃﾑで検疫ﾌｫﾙﾀﾞーにMotifが移動されてしまっている場合
* msbuildを叩いたら *PrePareExtremeSports* もしくは *BuildExtremeSports* でｴﾗーになった場合

該当しない場合はこの手順をすっ飛ばして構いません
<details>
<summary>手順詳細</summary>
1. 依存ﾗｲﾌﾞﾗﾘーを自動検索させる場合
    TonNurako/TonNurakoExで *make audio* を叩いてください

    *AUDIO OK*と表示されれば成功です
    ```
    % make audio
    (中略)
    -- AUDIO OK --
    %
    ```

1. ﾊﾟｽを指定する場合

    TonNurako/TonNurakoEx/Config.mp3 を TonNurako/TonNurakoEx/Site.mp3にｺﾋﾟーしてﾊﾟｽを調整してください
    ```
    % cd TonNurakoEx
    % cp -i Config.mp3 Site.mp3
    % dtpad Site.mp3
    ```

1. Config.mp3編集するのが面倒くさい場合

    TonNurako/TonNurakoEx/import.app フォルダー直下にX11とXmへのｼﾝﾎﾞﾘｯｸﾘﾝｸを作成してください

    ```
    # 例: Motifがｳｲﾙｽ並の扱いを受けて検疫ﾌｫﾙﾀﾞーに移動されてしまっている不自由ｼｽﾃﾑの場合

    % cd TonNurako/TonNurakoEx/import.app
    % ln -sv /Library/SystemMigration/History/Migration-{UUID}/QuarantineRoot/usr/include/X11 .
    % ln -sv /Library/SystemMigration/History/Migration-{UUID}/QuarantineRoot/usr/include/Xm .
    % ln -sv /Library/SystemMigration/History/Migration-{UUID}/QuarantineRoot/usr/lib .
    ```

ﾋﾞﾙﾄﾞ出来る事の確認
```
% make clean all
```
</details>

## ﾄﾝﾇﾗｺ本体とﾃﾞﾓのﾋﾞﾙﾄﾞ
```
% dotnet build
---
% ls bin/Debug/netstandard2.1/*Ton*
 bin/netstandard2.1/Debug/TonNurako.dll
 bin/netstandard2.1/Debug/TonNurako.pdb
 bin/netstandard2.1/Debug/libTonNurako.extremesports
%
```

BSD系などで *make* がGNU Makeでない場合は環境変数 MAKE を設定して msbuild を実行してください
```
% env MAKE=gmake msbuild
```


## ﾃﾞﾓの実行
```
% ./Demo/Widgets/bin/Debug/netcoreapp3.0/Widgets  
```

Visual Studio Codeがあればﾃﾞﾊﾞｯｸﾞﾎﾞﾀﾝから実行できます

ﾄﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺ

### ｳｲﾝﾄﾞｳにﾎﾞﾀﾝが出来るだけのｻﾝﾌﾟﾙ

```
using TonNurako.Widgets;
using TonNurako.Widgets.Xm;

namespace Simple
{
    class Program : Window
    {
        public override void ShellCreated() {
            var button = new PushButton();
            button.LabelString = "TonNurako!!";
            this.Children.Add(button);
        }

        static void Main(string[] args) {
            TonNurako.Application.Run(
                new TonNurako.ApplicationContext(), new Program());
        }
    }
}

```

ﾄﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺﾝﾇﾗｺ
