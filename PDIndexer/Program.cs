global using Crystallography.Controls; //260604Cl 追加: 全FormをFormBase継承にするため
using System;
using System.Windows.Forms;

namespace PDIndexer
{
    internal static class Program
    {
        // 260601Cl 追加: GitHub Pages マニュアル用スクショ一括取得モードの起動引数 (Main 内で 2 箇所判定するため定数化)。ReciPro と同じロジック。
        private const string CaptureArg = "--capture";
        // 260625Cl 追加: 軽量 smoke テストの起動引数 (WiX 移行 Phase C / D-PDI-3)。arm64 の「ビルド緑・実行時死亡」型故障を CI で検出する。
        private const string SmokeArg = "--smoke";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        // private static void Main() // 260601Cl 旧シグネチャ (--capture 引数対応のため string[] args を追加)
        [STAThread]
        private static void Main(string[] args)
        {
            // 260625Cl 追加: --smoke (WiX 移行 Phase C / D-PDI-3)。GUI を作らず Xraylib.Enabled を参照するだけで
            //   static ctor (libxrl-11.dll ロード + self-test) を起動し、実機で xraylib が本当にロードできるか検査する。
            //   引数なしの通常起動には一切影響しない (--capture と同様、先頭引数判定のみ)。
            if (args.Length >= 1 && args[0] == SmokeArg)
            {
                RunSmoke(args.Length >= 2 ? args[1] : "smoke-result.txt");
                return; // RunSmoke は Environment.Exit するため通常ここには到達しない
            }

            // 260625Cl 追加 (多言語化 Phase 2): Localizable=false フォーム (FormExportGSAS/FormLimitChanger/FormLPO 等) の
            //   Designer 直書きラベルの 11 言語訳テーブルを、フォーム生成前に共有 Crystallography.Localization の中央
            //   レジストリへ app-local provider として登録する。CodeLocalizer が FullName キーで引き OnLoad で差し替える。
            PDIndexerLocalizationData.Register();

            // 260601Cl 追加: --capture の言語指定を各フォームの resx ローカライズ (CurrentUICulture 参照) より前に確定させる。
            //   PDIndexer.exe --capture [出力ディレクトリ] [カルチャ(en/ja)]   (出力先を明示)
            //   PDIndexer.exe --capture [カルチャ(en/ja)]                      (出力先省略=既定の docs/src/assets/cap-*-auto)
            string captureDir = null, captureCulture = null;
            if (args.Length >= 2 && args[0] == CaptureArg)
            {
                // args[1] が対応カルチャ名なら「カルチャのみ指定 (出力先は既定)」、それ以外なら出力先ディレクトリとみなす。
                // 260625Cl 変更: en/ja 固定判定から SupportedCultures 駆動へ (多言語化 Phase 0。--capture <dir> de 等が通る)。
                //   旧: if (args[1] is "en" or "ja") captureCulture = args[1];
                if (Array.Exists(Crystallography.SupportedCultures.All, c => string.Equals(c.Name, args[1], StringComparison.OrdinalIgnoreCase)))
                    captureCulture = args[1];
                else { captureDir = args[1]; captureCulture = args.Length >= 3 ? args[2] : null; }
            }
            if (captureCulture != null)
            {
                var ci = new System.Globalization.CultureInfo(captureCulture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = ci;
                GuiCapture.ForcedUICulture = ci;
            }

            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // 260601Cl 追加: GUI 監査/マニュアル用スクショ一括取得モード。通常起動 (引数なし) には一切影響しない。
            if (args.Length >= 1 && args[0] == CaptureArg)
            {
                GuiCapture.Run(captureDir);  // captureDir が null なら docs/src/assets/cap-{en|ja}-auto が既定
                Environment.Exit(0); // --capture 完了後は開発者ツールとしてプロセスを確実に終了させる
            }

            Application.Run(new FormMain());
        }

        // 260625Cl 追加: --smoke の本体 (WiX 移行 Phase C / D-PDI-3)。Crystallography.Xraylib.Enabled の参照が
        //   static ctor (libxrl-11.dll ロード + self-test) を起動するので、これだけで「実機で xraylib が本当に
        //   ロードできるか」の検査になる。PDIndexer は Crystallography.Native を同梱しないため native 検査はしない。
        //   glfw3.dll は実行時未使用 (D-PDI-2) のため smoke では問わない (CI 側の PE 検査で arm64 混入を担保)。
        private static void RunSmoke(string outPath)
        {
            System.IO.File.WriteAllLines(outPath,
            [
                $"arch={System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}",
                $"baseDir={AppContext.BaseDirectory}",
                $"xraylibEnabled={Crystallography.Xraylib.Enabled}",
                $"xraylibError={Crystallography.Xraylib.LastLoadError}",
            ]);
            Environment.Exit(Crystallography.Xraylib.Enabled ? 0 : 2);
        }
    }
}
