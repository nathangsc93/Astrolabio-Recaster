using System.Drawing;

namespace Astrolabio_Recaster.Services
{
    public class ImagePreprocessService
    {
        public Bitmap PrepareForOcr(Bitmap original)
        {
            Bitmap enlarged = ResizeImage(original, original.Width * 2, original.Height * 2);
            Bitmap processed = new Bitmap(enlarged.Width, enlarged.Height);

            for (int y = 0; y < enlarged.Height; y++)
            {
                for (int x = 0; x < enlarged.Width; x++)
                {
                    Color pixel = enlarged.GetPixel(x, y);

                    int brightness = (pixel.R + pixel.G + pixel.B) / 3;

                    bool keepPixel =
                        brightness > 110 ||
                        (pixel.B > 120) ||
                        (pixel.R > 140);

                    processed.SetPixel(x, y, keepPixel ? Color.White : Color.Black);
                }
            }

            enlarged.Dispose();
            return processed;
        }

        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using Graphics g = Graphics.FromImage(result);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, width, height);
            return result;
        }
    }
}