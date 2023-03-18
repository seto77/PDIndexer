using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Crystallography.Controls
{
    public static class CheckLocation
    {
        public static void Adjust(Form form)
        {
            double fX = form.Location.X, fY = form.Location.Y, fW = form.Size.Width, fH = form.Size.Height;

            var needsAdjust = true;
            foreach (var scr in Screen.AllScreens)
            {
                double bX = scr.Bounds.X, bY = scr.Bounds.Y, bW = scr.Bounds.Width, bH = scr.Bounds.Height;
                //どれかのウィンドウの中に20%以上含まれていたら、needsAdjustをfalse (=更新の必要なし) にする。
                if ((fX - bX) / fW > -0.8 && (bX + bW - fX - fW) / fW > -0.8 && (fY - bY) / fH > -0.8 && (bY + bH - fY - fH) / fH > -0.8)
                    needsAdjust = false;
            }

            if (needsAdjust)
            {
                var scr = Screen.AllScreens.First(e => e.DeviceName == Screen.FromControl(form).DeviceName);
                form.Location = new Point(scr.Bounds.X + 100, scr.Bounds.Y + 100);
            }
        }
    }
}
