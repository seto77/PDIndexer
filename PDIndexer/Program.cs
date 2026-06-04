global using Crystallography.Controls; //260604Cl 追加: 全FormをFormBase継承にするため
using System;
using System.Windows.Forms;

namespace PDIndexer
{
    internal static class Program
    {
        // 260601Cl 追加: GitHub Pages マニュアル用スクショ一括取得モードの起動引数 (Main 内で 2 箇所判定するため定数化)。ReciPro と同じロジック。
        private const string CaptureArg = "--capture";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        // private static void Main() // 260601Cl 旧シグネチャ (--capture 引数対応のため string[] args を追加)
        [STAThread]
        private static void Main(string[] args)
        {
            // 260601Cl 追加: --capture の言語指定を各フォームの resx ローカライズ (CurrentUICulture 参照) より前に確定させる。
            //   PDIndexer.exe --capture [出力ディレクトリ] [カルチャ(en/ja)]   (出力先を明示)
            //   PDIndexer.exe --capture [カルチャ(en/ja)]                      (出力先省略=既定の docs/src/assets/cap-*-auto)
            string captureDir = null, captureCulture = null;
            if (args.Length >= 2 && args[0] == CaptureArg)
            {
                // args[1] が en/ja なら「カルチャのみ指定 (出力先は既定)」、それ以外なら出力先ディレクトリとみなす。
                if (args[1] is "en" or "ja") captureCulture = args[1];
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
    }
}
