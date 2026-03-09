using System.Drawing;
using System.Drawing.Imaging;

namespace Astrolabio_Recaster.Services
{
    public class ScreenCaptureService
    {
        public Bitmap CaptureRegion(Rectangle region)
        {
            Bitmap bitmap = new Bitmap(region.Width, region.Height, PixelFormat.Format32bppArgb);

            using Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(region.Location, Point.Empty, region.Size);

            return bitmap;
        }
    }
}