using System;
using System.Collections.Generic;
using System.Text;

namespace PDIndexer
{
    static class Version
    {
        static public string Software =
            "PDIndexer"
            ;
        static public string VersionAndDate { get => History.Remove(0, 10).Remove(20); }
        static public string RecentHistory
        {
            get
            {
                var list = History.Remove(0, 10).Split(new string[] { "\r\n " }, StringSplitOptions.RemoveEmptyEntries);
                var str = "";
                for (int i = 0; i < 5; i++)
                    str += list[i] + "<br>\r\n";
                return str;
            }
        }

        /// <summary>
        /// 更新履歴
        /// </summary>
        static public string History = 
            "History" +
            "\r\n ver4.400(2021/07/05) Fixed a minor bug when loading gsa files." +
            "\r\n ver4.399(2021/07/02) Target framework is changed to .Net 5.0. Added new EOSs (Fratanduono+ 2021)." +
            "\r\n ver4.398(2021/05/13) Fixed a bug on loading 'NPD' format files." +
            "\r\n ver4.397(2021/05/01) Fixed minor bugs and improved computation speed on 'Stress Analysis'." +
            "\r\n ver4.396(2021/04/04) Fixed a minor bug on the recent update." +
            "\r\n ver4.395(2021/04/04) Improved loading of mutiple-EDX.  Added EOSs of molybdenum." +
            "\r\n ver4.394(2020/12/02) Fixed a GUI bug. Added the option: 'Save the crystal list when closing'" +
            "\r\n ver4.393(2020/12/01) Fixed a minor bug when loading crystal list." +
            "\r\n ver4.392(2020/10/22) Added: 3rd order Vinet equation to the EOS function." +
            "\r\n ver4.391(2020/10/17) Improved: Macro functions." +
            "\r\n ver4.390(2020/10/16) Improved: Speed up drawing profiles. Added: New macro functions." +
            "\r\n ver4.388(2020/10/15) Added new EOS foumulae (4th BM, AP2, Keane)." +
            "\r\n ver4.387(2020/10/14) Added three EOS for Re (Thank you, Dr. Sakai), and fixed minor bugs." +
            "\r\n ver4.386(2020/09/04) Fixed minor bugs. Thank you, Dr. Farla!" +
            "\r\n ver4.385(2020/09/03) Fixed minor bugs." +
            "\r\n ver4.384(2020/07/30) Added the AMCSD crystal database to 'Crystal Parameter' window." +
            "\r\n ver4.383(2020/05/01) Fixed GUIs." +
            "\r\n ver4.382(2020/04/26) Fixed a problem on loading Neutron TOF data." +
            "\r\n ver4.381(2020/03/27) Refixed a bug on loading multiple profiles." +
            "\r\n ver4.380(2020/03/22) Fixed a bug on loading multiple profiles." +
            "\r\n ver4.379(2020/03/03) Fixed a minor bug on distribution problem." +
            "\r\n ver4.378(2020/03/01) Changed: Download site is changed to GitHub." +
            "\r\n ver4.377(2019/11/08) Fixed a minor bug on 'Fitting Diffraction Peaks'." +
            "\r\n ver4.376(2019/11/07) Minor improvements when loading nxs format." +
            "\r\n ver4.375(2019/10/06) Improved. nxs format is available." +
            "\r\n ver4.367(2019/06/11) Minor improvements." +
            "\r\n ver4.365(2019/06/10) Minor improvements." +
            "\r\n ver4.364(2019/05/21) Fixed minor bugs." +
            "\r\n ver4.362(2019/04/10) Changed the installer. ClickOnce version will be not maintained in the future." +
            "\r\n ver4.351(2019/03/21) Minor improvement." +
            "\r\n ver4.350(2019/03/19) Fixed a bug on loading irregular space groups." +
            "\r\n ver4.349(2019/03/18) Added an option when exporting profiles." +
            "\r\n ver4.348(2019/02/20) Changed .Net framework version to 4.7.2." +
            "\r\n ver4.347(2018/12/20) Fixed minor bugs." +
            "\r\n ver4.346(2018/11/20) Modified some incosistensies." +
            "\r\n ver4.345(2018/10/29) Fixed a minor bug." +
            "\r\n ver4.344(2018/10/21) Renewed libraries." +
            "\r\n ver4.343(2018/02/21) Fixed a minor bug." +
            "\r\n ver4.342(2018/01/26) Improved a compatibility of CSV file format." +
            "\r\n ver4.341(2017/11/27) Fixed a minor bug." +
            "\r\n ver4.34 (2017/11/18) Added a new function '2 theta offset' in 'Profile parameter' form. It is designed for Bragg-Brentano diffractmetry, and possible to calibrate the offset parameters using internal standard. " +
            "\r\n ver4.329(2017/11/17) Moved 'Remove K_Alpha2' option to the 'Profile parameter' form." +
            "\r\n ver4.328(2016/12/04) Fixed a minor bug." +
            "\r\n ver4.327(2016/12/02) Fixed a digit separator (, or .) problem." +
            "\r\n ver4.326(2016/11/29) Fixed a digit separator (, or .) problem." +
            "\r\n ver4.325(2016/11/28) Minor improvements." +
            "\r\n ver4.324(2016/11/25) Minor improvements." +
            "\r\n ver4.323(2016/11/17) Minor improvements." +
            "\r\n ver4.322(2016/11/11) Added a shortcut key of Ctrl + Alt + Space, which changes a checked state of a selected plane in 'FormFitting'." +
            "\r\n ver4.321(2016/11/07) Added a shortcut key of Ctrl + Shift + Space, which changes a checked state of a selected crystal." +
            "\r\n ver4.32 (2016/06/15) Improved to read a '*.xbm' (XRayBinFile) files. Fixed minor bugs." +
            "\r\n ver4.316(2016/06/13) Fixed minor bugs." +
            "\r\n ver4.315(2015/12/23) Fixed a bugs on initial loading." +
            "\r\n ver4.314(2015/12/21) Added: Initializing steps are diplayed." +
            "\r\n ver4.313(2015/12/18) Fixed a minor bug on input form for rhombohedral settings." +
            "\r\n ver4.312(2015/12/11) Fixed a minor bug on Wyckoff position." +
            "\r\n ver4.312(2015/12/09) Fixed minor bugs." +
            "\r\n ver4.311(2015/11/30) Fixed minor bugs." +
            "\r\n ver4.31 (2015/10/31) Added: EOS of MgO (Tange+ 2009) and Pt, Au (Yokoo+ 2009)." +
            "\r\n ver4.306(2015/08/28) Fixed a minor bug." +
            "\r\n ver4.305(2015/03/18) Fixed a bug about the calculation of Debye-Waller factor" +
            "\r\n ver4.304(2015/03/06) Fixed: a bug on editing monocliic crystal. (thx Niwa-san)" +
            "\r\n ver4.303(2015/03/04) Improved macro functions." +
            "\r\n ver4.302(2015/03/02) Improved macro functions." +
            "\r\n ver4.301(2015/01/25) Fixed: a minor bug on an initial loading for ZIP version." +
            "\r\n ver4.30 (2014/12/26) Added macro functions." +
            "\r\n ver4.297(2014/12/03) Fixed a minor bugs on the clipboard operation." +
            "\r\n ver4.296(2014/11/20) Fixed bugs on the refinements of cell constants for triclinic symmetry." +
            "\r\n ver4.295(2014/11/14) Fixed minor bugs." +
            "\r\n ver4.294(2014/11/10) Fixed minor bugs." +
            "\r\n ver4.293(2014/11/08) Fixed a minor bug on UI. Added bliking mode, by right double clicks on crystal list" +
            "\r\n ver4.292(2014/10/28) Added: EOS of NaCl B1 (Matsui et al 2012) and NaCl B2 (Ueda et al. 2008)." +
            "\r\n ver4.291(2014/10/08) Fixed minor bugs." +
            "\r\n ver4.29 (2014/10/06) Improved: possible to receive multi profiles from IPAnalyzer" +
            "\r\n ver4.28 (2014/05/15) Improved: 'Fittng parameter' design. Fixed: load error on nertron TOF data format." +
            "\r\n ver4.273(2014/02/13) Fixed minor bugs." +
            "\r\n ver4.272(2014/02/12) Fixed minor bugs." +
            "\r\n ver4.271(2014/01/31) Fixed minor bugs." +
            "\r\n ver4.27 (2014/01/30) Added: Unit q (wavenumver) has been available as horizontal axis units." +
            "\r\n ver4.264(2013/12/26) Fixed minor bugs." +
            "\r\n ver4.263(2013/12/25) Fixed minor bugs." +
            "\r\n ver4.262(2013/12/17) Improved: Language option." +
            "\r\n ver4.261(2013/11/10) Fixed a minor bug when profile reading" +
            "\r\n ver4.26 (2013/11/10) Added: Comment option for profiles. A button which checks/uncheks all profiles " +
            "\r\n ver4.255(2013/11/10) Fixed a bug on design." +
            "\r\n ver4.254(2013/11/06) Fixed minor bug on a clipboard operation." +
            "\r\n ver4.253(2013/10/01) Fixed minor bug on an FFT calculation." +
            "\r\n ver4.252(2013/09/30) Fixed minor bug on form designs." +
            "\r\n ver4.251(2013/07/15) Fixed minor bug on CIF file conversion." +
            "\r\n ver4.25 (2013/06/14) Added: EOS of NaCl (B2) (Sakai et al. 2011) and Pt (Matsui et al., 2009) into 'EOS form'." +
            "\r\n ver4.242(2013/03/11) Fixed small bug." +
            "\r\n ver4.241(2013/02/26) Changed adress of help page." +
            "\r\n ver4.24 (2013/02/25) Added: Update check function." +
            "\r\n ver4.23 (2013/02/21) Added: CIF file export function" +
            "\r\n ver4.22 (2013/02/09) Imploved: GSAS export function" +
            "\r\n ver4.21 (2013/01/25) Imploved: speed of bandpass function" +
            "\r\n ver4.20 (2013/01/23) Added: Remove Kalpha2 function" +
            "\r\n ver4.19 (2013/01/07) Added 'Mask and Interpolation' function, and 'Remove diffraction peaks' function." +
            "\r\n ver4.184(2012/12/27) Fixed minor bugs." +
            "\r\n ver4.183(2012/12/05) Fixed minor bugs." +
            "\r\n ver4.182(2012/11/29) Fixed bugs about 'Profile Operation'." +
            "\r\n ver4.181(2012/11/28) Fixed: many minor bugs." +
            "\r\n ver4.18 (2012/11/26) Added: Algebraic operation of profile(s). Fixed many bugs." +
            "\r\n ver4.17 (2012/11/25) Improved: Appearance of profile list box, bug fixed: zoom out behaviour." +
            "\r\n ver4.161(2012/11/12) Improved: Appearance of vertical and horizontal unit." +
            "\r\n ver4.16 (2012/07/18) Added: A function to shift x-axis." +
            "\r\n ver4.15 (2012/06/29) Added: Error bar option." +
            "\r\n ver4.141(2012/06/29) Fixed A tiny bug ." +
            "\r\n ver4.14 (2012/06/28) Added: Export GSAS-ESD format function." +
            "\r\n ver4.131(2012/06/28) Fixed: problems when reading CIF files." +
            "\r\n ver4.13 (2012/05/23) Added: Logarithm intensity mode." +
            "\r\n ver4.12 (2012/05/22) Added: Conunts per second mode for vertical axis." +
            "\r\n ver4.11 (2011/12/25) Fixed: a multiplicity calculation for trigonal symmetry was corrected." +
            "\r\n ver4.1  (2011/11/15) Improved: color of diffraction peaks is shown next to the crystal name." +
            "\r\n ver4.02 (2011/11/14) Fixed: infinite loop error on EOS calculation and diffraction peak error of frexible crystal mode (thanks motty)." +
            "\r\n ver4.01 (2011/10/31) Fixed: crystal control design in Japanese mode (thanks riko)." +
            "\r\n ver4.00 (2011/10/21) Added language option (English/Japanese)." +
            "\r\n ver3.91 (2011/08/21) 横軸を角度にすると回折線の位置が表示できなかったバグを修正 (大藤さんに感謝)" +
            "\r\n ver3.90 (2011/07/22) 中性子回折強度の計算を導入。横軸の設定が大きく変わっていますので、バグがありましたらご連絡ください。" +
            "\r\n ver3.82 (2011/07/04) 「Crystal information」中の「Detailed Informatio」の機能が充実しました。" +
            "\r\n ver3.815(2011/03/23) FormFittingで初期半値幅が反映されないバグを修正" +
            "\r\n ver3.814(2011/03/22) 一部のCIFファイルなどで「.66667」などと記載されている場合に「2/3」と読み替えるように内部仕様を変更" +
            "\r\n ver3.813(2011/03/16) 点群6/mに属する結晶の多重度の計算ミスを修正" +
            "\r\n ver3.812(2011/01/19) 日本語名を含んだファイルを読み込んだとき、不具合で強制終了することがあったのを修正。文字化け自体は直ってません。" +
            "\r\n ver3.811(2010/12/08) FormEOS周りの動作を改良。MainForm側でチェックした結晶のみ表示するようにしました。" +
            "\r\n ver3.81 (2010/12/06) IPAnalyzerからUnrolled Imageを受け取って表示することができるようになりました。。" +
            "\r\n ver3.80 (2010/11/08) 初回起動時にバックグラウンドでネイティブコードを生成するように変更。二回目以降の起動が早くなります。" +
            "\r\n ver3.701(2010/11/08) 三斜晶系の対称性をうまく設定できない問題を修正" +
            "\r\n ver3.7  (2010/11/07) 起動を高速化" +
            "\r\n ver3.68 (2010/05/09) IPAnalyzerからのRadialPatternデータ受信にとりあえず対応。今後もう少し必要な機能を実装する予定" +
            "\r\n ver3.674(2010/04/18) IPAnalyzerからLPO(セクター)データを受信時、最後に一括して受け取るように仕様を変更。たぶん遅いPCでも安定して受け取れるはずです。" +
            "\r\n ver3.673(2010/04/05) Stress解析の機能を改良. Nishihara et al. (2009)を参考にSinghの公式をフィッティング. 細かい解説は後日" +
            "\r\n ver3.672(2010/04/01) Stress解析の機能を改良. フィッティングの都度、格子定数を最適化して、ピークを逃さない(?)ようにした。" +
            "\r\n ver3.671(2010/03/31) Stress解析の機能を改良. FWHMや強度も出力するようにしました。" +
            "\r\n ver3.67 (2010/03/31) Stress解析の機能を付けてみました。CTRL+SHIFT+Sで起動できますが、まだテスト中です。" +
            "\r\n ver3.66 (2010/03/28) レジストリの削除機能を追加(Optionの中です). && LPOのデータがうまく受け取れなかった問題を修正" +
            "\r\n ver3.65 (2010/03/03) AtomicPositionFinderなる機能を実装しつつあります。まだまだ不完全ですが取りあえず。" +
            "\r\n ver3.64 (2010/01/25) NPD(Nippon high Pressure Data Format)形式を読み込めるように改良しました。" +
            "\r\n ver3.63 (2009/12/28) 回折強度の計算がおかしいところがあったので修正" +
            "\r\n ver3.62 (2009/10/26) FormFittingで結晶が選択できなかったバグを修正＆FormFittingで、共通のSearchRange,FWHMを設定できるように変更しました" +
            "\r\n ver3.61 (2009/10/20) 菱面晶系の指数をきちんと計算できるようにしました。＆ cubicで 001 ではなく 100 のように hの指数が最大になるように表示を変更" +
            "\r\n ver3.61 (2009/09/24) Metafileの保存時、背景色が反映していなかったバグを修正 && 背景色などを記憶するようにした" +
            "\r\n ver3.60 (2009/09/17) 結晶リスト読み込み時にチェックを反映していなかったバグを修正 && 特性X線の元素、ラインを充実 (長迫さんありがとうございます。) " +
            "\r\n ver3.59 (2009/09/03) 64bit OS に対応しました。" +
            "\r\n ver3.58 (2009/08/19) VinetのEOSを利用できるようにしました。" +
            "\r\n ver3.57 (2009/08/18) 結晶ごとにEOSを利用できるようにしました。" +
            "\r\n ver3.56 (2009/08/03) Scalable Intensityがチェックされているとき、回折強度が表示されないことがあったバグを修正" +
            "\r\n ver3.55 (2009/07/23) MainFormとFormFittingでの結晶選択の同期がうまくいっていなかったバグを修正" +
            "\r\n ver3.54 (2009/07/06) CSManagerから結晶情報をインポートできなかったバグを修正 (ひとみちゃん、ありがとう。)" +
            "\r\n ver3.53 (2009/03/12) All Clearが効かなかったバグ、予約結晶(青ラベルと赤ラベル)が消せてしまったバグを修正。" +
            "\r\n ver3.52 (2009/03/11) Print時にラベルの位置などを選択できるようにしました。" +
            "\r\n ver3.51 (2009/03/10) CIFファイルのインポート時の不具合を修正+細かいバグ修正 (長迫さん、ありがとうございます。)" +
            "\r\n ver3.50 (2009/02/27) EOSにAr(Jephcoat)追加したが、あまり自信がない。" +
            "\r\n ver3.49 (2009/02/23) 結晶リスト周りを大幅に変更。EOSにAr(Ross et al.),Re(Zha et al.)を追加。その他、変更多数。" +
            "\r\n ver3.48 (2008/10/29) 範囲外の回折ピークが表示されないように修正。& 温度因子を一括して0に戻す機能を追加" +
            "\r\n ver3.47 (2008/09/13) データ読み込み部分を修正。　プロファイル表示で線が途切れることがあったのを修正。" +
            "\r\n ver3.46 (2008/07/06) d値のリストから格子定数を推定する機能 CellFinderをつけました。まだまだ発展途上です。" +
            "\r\n ver3.45 (2008/06/20) 作者異動にともない、連絡先など変更" +
            "\r\n ver3.44 (2008/04/29) 初期結晶ファイル中のSiO2 (CaCl2構造)の格子定数が間違っていたのを修正しました。" +
            "\r\n ver3.43 (2008/04/27) 印刷時に左上に出力プロファイル名を印刷するようにしました。" +
            "\r\n ver3.42 (2008/04/22) 読み込む/書き込む時に結晶を選択できるようにした。最初の6個の結晶はEOS予約済みで常にチェック状態。 & 原子リストボックスで右クリックすると原子の等価位置を表示。" + 
            "\r\n ver3.41 (2008/04/04) 点群4,-4,4/mに属する対称性のときの面の等価性判定ルーチンにバグがあったのを修正。" +
            "\r\n ver3.40 (2008/02/27) ファイルを正常に読み込めないバグを修正" +
            "\r\n ver3.39 (2008/02/24) X線回折強度計算を少しだけ高速化" +
            "\r\n ver3.38 (2008/02/11) 他ソフトとの連携を強化" +
            "\r\n ver3.37 (2008/02/07) プロファイルの線の太さを変えられるようにしました。「Profile Setting」から変更できます。" +
            "\r\n ver3.36 (2008/02/06) EMF(Enhanced windows MetaFile)形式で保存できるようにしました。各種ドロー系ソフトで読み込み可能(なはず)です。" +
            "\r\n ver3.35 (2008/01/25) 起動時にツールチップを追加。細かいバグ修正" +
            "\r\n ver3.34 (2008/01/24) 画面のデザインがおかしかったのを修正" +
            "\r\n ver3.33 (2008/01/22) 前回開いたディレクトリを記憶できるようにしました。" +
            "\r\n ver3.32 (2008/01/21) 発行元を変更しました" +
            "\r\n ver3.31 (2008/01/19) アイコンボタンを付けてみました" +
            "\r\n ver3.30 (2008/01/15) デザイン若干変更" +
            "\r\n ver3.29 (2008/01/07) 内部形式を変更 + 格子定数、原子位置の誤差に対応" +
            "\r\n ver3.28 (2007/12/20) CSVで出力機能を追加。ファイルメニューから。" +
            "\r\n ver3.27 (2007/12/08) 電子線の波長計算に対応" +
            "\r\n ver3.26 (2007/12/07  保存に関するバグを修正。プロファイルの拡大を右ドラッグに変更。" +
            "\r\n ver3.25 (2007/12/07) 軸変換にともなうバグを修正" +
            "\r\n ver3.24 (2007/12/06) 複数プロファイルの保存、読み込みに対応しました。" +
            "\r\n ver3.23 (2007/12/05) 大幅に更新。EDX(gennie)に対応。横軸を角度,エネルギー,d値(面間隔)に相互変換できるようにしました。" +
            "\r\n ver3.22 (2007/11/25) 結晶を選択したときにまれに起こる例外に対処。Crystal Parameterの画面が一部見えにくいバグ修正" +
            "\r\n ver3.21 (2007/11/16) Fitting Diffraction Peaksでフィッティング結果をクリップボードにコピーする機能を追加" +
            "\r\n ver3.20 (2007/11/14) 若干デザイン変更" +
            "\r\n ver3.19 (2007/10/27) 共通フォーム&コントロールの部分を分離しDLL化した" +
            "\r\n ver3.18 (2007/10/08) ファイル監視&自動読み込み機能を追加 (Optionから)" +
            "\r\n ver3.17 (2007/09/17) 回折強度比の表示がおかしかったのを改良" +
            "\r\n ver3.16 (2007/08/16) 回折強度の計算がおかしかったのを改良" +
            "\r\n ver3.15 (2007/08/10) バッググラウンド自動検索ののバグを改善" +
            "\r\n ver3.14 (2007/07/11) 選択した結晶・面の回折線の表示するところのバグを改善" +
            "\r\n ver3.13 (2007/07/05) 結晶軸の計算のバグを修正" +
            "\r\n ver3.12 (2007/06/22) ホームページアドレス変更" +
            "\r\n ver3.11 (2007/06/21) 初期配布ファイルの原子色の設定に問題があったのを修正" +
            "\r\n ver3.10 (2007/06/20) Drag&Drop機能がうまく動いていなかったのを修正 + 細かいバグ修正" +
            "\r\n ver3.09 (2007/06/19) CIF,AMC形式のデータをインポートできるようにしました。ファイルメニューから使えます。" +
            "\r\n ver3.08 (2007/06/15) キーボードショートカット機能をつけました。メインフォーム下部に表記。" +
            "\r\n ver3.07 (2007/06/10) ラウエ群m3のときに多重度計算がおかしかったバグを修正" +
            "\r\n ver3.06 (2007/06/06) Drag&Dropでプロファイルデータ、Crysltalリストデータを受け取れるようにした。" +
            "\r\n ver3.05 (2007/06/06) 初期結晶リストを変更&拡充。 & EOSのデザイン変更" +
            "\r\n ver3.04 (2007/06/04) マルチプロファイル時の表示のバグを修正" +
            "\r\n ver3.03 (2007/06/03) 回折線が消えてしまうバグを修正" +
            "\r\n ver3.02 (2007/05/25) FormCrystalの外観変更" +
            "\r\n ver3.02 (2007/04/09) 横軸(HorizontalAxis)の動作のバグ修正＆改良" +
            "\r\n ver3.01 (2007/03/19) 正方晶系時の格子定数フィッティングのバグ修正" +
            "\r\n ver3.00 (2007/02/28) 等価ではないが面間隔が等しくなる面の強度計算を正確に行えるようにしました。" +
            "\r\n ver2.99 (2007/02/16) 若干、対称性・結晶構造関係の計算が速くなりました" +
            "\r\n ver2.98 (2007/02/07) ↓の機能がうまく動いていなかったバグを修正" +
            "\r\n ver2.97 (2007/02/06) 前回起動時のフォームサイズ・位置や、波長・カメラ長といったパラメータを再現。" +
            "\r\n ver2.96 (2007/02/05) Crystal Dataを正常に読み込めなかったバグを修正。& 起動を高速化しました。" +
            "\r\n ver2.95 (2007/02/03) プログラムの署名が期限切れになったため再発行しました。" +
            "\r\n ver2.94 (2007/01/22) Database機能を分離し別ソフト(CSManager)として公開しました。" +
            "\r\n ver2.93 (2007/01/17) 横軸を2θ以外にもd-spacing, lengthで表示できるようにした。" +
            "\r\n ver2.92 (2007/01/15) Profile の強度ノーマライズを出来るようにした。" +
            "\r\n ver2.91 (2006/12/14) メイン画面の各コントロールをスプリットコンテナにした。" +
            "\r\n ver2.90 (2006/12/09) フィッティング関数にSplit Pseudo Voigtを導入しました。" +
            "\r\n ver2.82 (2006/11/28) マウスカーソルの表示を変更 & 真ん中ボタンドラッグで平行移動できるようにしました。" +
            "\r\n ver2.81 (2006/11/27) FittingParameterでConfirm時にExcelに貼付可能なデータをクリップボードにコピーします。" +
            "\r\n ver2.80 (2006/11/26) EOSを拡充しました。NaCl_B1(Brown 99)やAu(Tsuchiya 03)など。起動が重いな。" +
            "\r\n ver2.71 (2006/11/23) Fittingの収束性を向上させました。若干速度は落ちます。" +
            "\r\n ver2.70 (2006/11/19) Fitting関数にPearsonIV(対称/非対称)を導入しました。数学がむずかった。。。" +
            "\r\n ver2.64 (2006/11/14) FittingParameterに半値幅などを表示するようにしました。" +
            "\r\n ver2.63 (2006/11/12) ピーク分離モードで結晶間での分離を可能にしました。" +
            "\r\n ver2.62 (2006/11/05) PseudoVoigtフィッティング改良　かなり収束性が良くなりました。" +
            "\r\n ver2.61 (2006/11/03) FittingParameterで格子定数の誤差を計算できるようにしました" +
            "\r\n ver2.60 (2006/11/02) データベースまわりを更新 + ピーク分離フィッティング機能追加(これは重い！)" +
            "\r\n ver2.57 (2006/11/01) FittingParameterまわりをさらにバグ修正　良く分からん･･･" +
            "\r\n ver2.56 (2006/10/31) FittingParameterまわりを改良&バグ修正　直ったのか！？" +
            "\r\n ver2.55 (2006/10/12) CrystalParameterとProfileSettingのまわりのバグを修正" +
            "\r\n ver2.54 (2006/09/11) 強度とd値を逆に表示していたのを修正" +
            "\r\n ver2.53 (2006/09/08) Profileを削除できないバグを修正" +
            "\r\n ver2.52 (2006/07/13) CrystalParameterのあたりを修正" +
            "\r\n ver2.51 (2006/06/04) BackGroundの自動減算機能を改良" +
            "\r\n ver2.50 (2006/05/12) GUI変更(すっきりしたかな？), BackGroundの自動減算機能を追加" +
            "\r\n ver2.41 (2006/04/24) フィッティング周りの改善, SinmpleSearchの表示改善" +
            "\r\n ver2.40 (2006/04/10) 強度比から結晶の体積比を求める機能追加(吸収補正はまだ)" +
            "\r\n ver2.30 (2006/04/08) PseudoVoigtフィッティングの速度改善" +
            "\r\n ver2.20 (2006/04/??) 多くのバグフィックス　＋　パターンファイルの自動認識機能追加" +
            "\r\n ver2.10 (2006/04/??) ClickOnceによる自動更新機能追加　＋　データベース機能(とりあえず）" +
            "\r\n ver2.00 (2006/01/01) Multi Pattern Mode追加、IPAnalyzerとの連携機能追加" +
            "\r\n ver1.20 (2005/07/??) 回折強度計算機能追加" +
            "\r\n ver1.00 (2005/06/??) とりあえず動くものをつくる"
            ;

  

        /// <summary>
        /// はじめに
        /// </summary>
        static public string Introduction = 
            "はじめに:\r\n"
            + "　このソフトはX線粉末回折実験における角度-強度プロファイルを解析するためのプラグラムです。主な特徴は"
            + "\r\n ・テキスト形式の角度－強度データ(タブ･カンマ･スペース)区切りのデータを読み込み、表示"
            + "\r\n ・スムージング、バッググラウンド除去、複数のプロファイルの同時表示が可能"
            + "\r\n ・任意の結晶(CIF,AMCデータをインポート可能)の回折線位置、強度を表示"
            + "\r\n ・回折ピークの関数フィッティングと最小2乗法による格子定数精密化"
            + "\r\n ・標準的な物質(Au,Pt,NaCl,MgO,Al2O3）の状態方程式を内蔵"
            + "\r\n ・拙作ソフト「IPAnalyzer」や「CSManager」との連携"
            + "\r\nなどです。"
            ;

        /// <summary>
        /// 謝辞
        /// </summary>
        static public string Acknowledge = 
            "謝辞:\r\n"
            + "　本ソフトのエラーの報告、改良の助言にあたっては東京大学の浜根様、北海道大学の永井様、IFREEの佐多様を中心に"
            + "多くの方の協力を頂いております。この場を借りて御礼申し上げます。"
            ;

        /// <summary>
        /// 使い方
        /// </summary>
        static public string Manual =
            "使い方:\r\n"
            + "　このソフトは「PDIndexer.exe」を実行することで起動します。プロファイルデータはファイルメニューから読み込むことができます。"
            + "結晶リストから結晶を選択すると回折線が表示されます。回折線はマウスドラッグで移動することができます。"
            + "より詳しい使い方は下記ホームページをご覧ください。"
            ;

        /// <summary>
        /// 著作権
        /// </summary>
        static public string CopyRight = 
            "著作権:\r\n "
            + "　本プログラムの著作権は、作者である瀬戸雄介、"
            + "およびその所属機関である神戸大学大学院理学研究科地球惑星科学専攻が保有しています。"
            ;

        /// <summary>
        /// 使用条件
        /// </summary>
        static public string Condition =
            "使用条件:\r\n " +
            "本プログラムは学術目的で作成されたフリーソフトウェアです。" +
            "\r\n  ・商用/非商用を問わず、誰でもご自由にお使いいただけます。" +
            "\r\n  ・ただし、軍事目的あるいは違法な目的での使用は固く禁じます。" +
            "\r\n  ・如何なる商用目的の販売、あるいは有償のサポートを行いません。"
             ;

        /// <summary>
        /// 免責事項
        /// </summary>
        static public string Exemption =
            "免責:"
            + "\r\n　作者は本プログラムの"
            + "\r\n　 ・動作保証を致しません。"
            + "\r\n　 ・使用によって直接的あるいは間接的に生じた障害、損害についての責任を負いません。"
            + "\r\n　 ・修正、及びバージョンアップの義務を負いません。"
            ;

        /// <summary>
        /// 連絡先
        /// </summary>
        static public string Adress =
            "連絡先:\r\n"
            +"　プログラムの不具合、改善要望などがありましたらメールにてご連絡ください。"
            +"また詳しい使い方についてはホームページでも解説しています。"
            + "\r\n mail: seto@crystal.kobe-u.ac.jp" 
            + "\r\n Home Page: http://pmsl.planet.sci.kobe-u.ac.jp/~seto/"
            + "\r\nできるだけご要望にお応えしたいと思います。"
            ;

        static public string[] HintJa = new string[]{

            "キーボードショートカット\r\n    Ctrl + Shift + C : Crystal Parameter\r\n    Ctrl + Shift + P : Profile Setting\r\n    Ctrl + Shift + E : Equation of State\r\n    Ctrl + Shift + F : Fitting Diffraction",
            "Ctrl+Shift+Dキーを押すと回折線の描画モードを以下のように切り替えることができます。\r\n 非表示 -> 表示(強度計算なし) -> 表示(強度計算あり)",
            "プロファイル画面で真中ボタンドラッグすると描画範囲を平行移動できます。 ",
            "Fitting Diffraction Peaks 画面で、Changeボタンを押すと自動的にエクセル貼り付け可能な形式のデータがクリップボードにコピーされます。",
            "自動更新版で更新がうまく完了しないときがあります。その場合はコントロールパネルからいったん削除の上、再度インストールしてください。",
            "IPAnalyzerからうまくクリップボード経由の受信ができないときは、'Option'から'Watch Clipboard'を一旦OFFにしたのち再度ONにしてみてださい。",
            "Crystal List　(xml形式)は拙作ソフトReciProと同形式です。互いに編集したファイルを読み書きすることができます。",
            "'Crystal Parameter'ウィンドウの'Crystal Information'部分にCIF形式およびAMC形式のファイルをドラッグドロップすると、結晶構造を読み込むことができます。( 'Add'をするとリストに加えることができます。)",
            "メインウィンドウにファイルをドラッグドロップするとプロファイルを読み込むことができます。",
            "複数のプロファイルの保存・読み込みが可能です。(pdi形式のみ)",
            "英語のマニュアルを作成していただける方募集中です。",

        };

        static public string[] HintEn = new string[]{

            "Keyboard shortcut\r\n    Ctrl + Shift + C : Crystal Parameter\r\n    Ctrl + Shift + P : Profile Setting\r\n    Ctrl + Shift + E : Equation of State\r\n    Ctrl + Shift + F : Fitting Diffraction",
          //  "Ctrl+Shift+Dキーを押すと回折線の描画モードを以下のように切り替えることができます。\r\n 非表示 -> 表示(強度計算なし) -> 表示(強度計算あり)",
          //  "プロファイル画面で真中ボタンドラッグすると描画範囲を平行移動できます。 ",
          //  "Fitting Diffraction Peaks 画面で、Changeボタンを押すと自動的にエクセル貼り付け可能な形式のデータがクリップボードにコピーされます。",
          //  "自動更新版で更新がうまく完了しないときがあります。その場合はコントロールパネルからいったん削除の上、再度インストールしてください。",
          //  "IPAnalyzerからうまくクリップボード経由の受信ができないときは、'Option'から'Watch Clipboard'を一旦OFFにしたのち再度ONにしてみてださい。",
          //  "Crystal List　(xml形式)は拙作ソフトReciProと同形式です。互いに編集したファイルを読み書きすることができます。",
          //  "'Crystal Parameter'ウィンドウの'Crystal Information'部分にCIF形式およびAMC形式のファイルをドラッグドロップすると、結晶構造を読み込むことができます。( 'Add'をするとリストに加えることができます。)",
          //  "メインウィンドウにファイルをドラッグドロップするとプロファイルを読み込むことができます。",
          //  "複数のプロファイルの保存・読み込みが可能です。(pdi形式のみ)",
          //  "英語のマニュアルを作成していただける方募集中です。",

        };


    }
}
