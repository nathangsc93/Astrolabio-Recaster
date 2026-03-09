using System.Drawing;
using System.IO;
using Tesseract;

namespace Astrolabio_Recaster.Services
{
    public class OcrService
    {
        private readonly string _tessdataPath;

        public OcrService(string tessdataPath)
        {
            _tessdataPath = tessdataPath;
        }

        public string ReadText(Bitmap bitmap)
        {
            using var engine = CreateEngine();
            return ReadBitmapWithEngine(engine, bitmap);
        }

        public List<string> ReadLines(List<Bitmap> bitmaps)
        {
            List<string> results = new();

            using var engine = CreateEngine();

            foreach (Bitmap bmp in bitmaps)
            {
                string text = ReadBitmapWithEngine(engine, bmp).Trim();
                if (!string.IsNullOrWhiteSpace(text))
                    results.Add(text);
            }

            return results;
        }

        private TesseractEngine CreateEngine()
        {
            if (!Directory.Exists(_tessdataPath))
                throw new DirectoryNotFoundException($"Pasta tessdata não encontrada: {_tessdataPath}");

            string trainedDataFile = Path.Combine(_tessdataPath, "eng.traineddata");
            if (!File.Exists(trainedDataFile))
                throw new FileNotFoundException($"Arquivo eng.traineddata não encontrado: {trainedDataFile}");

            var engine = new TesseractEngine(_tessdataPath, "eng", EngineMode.Default);
            engine.SetVariable("preserve_interword_spaces", "1");
            engine.DefaultPageSegMode = PageSegMode.Auto;

            return engine;
        }

        private string ReadBitmapWithEngine(TesseractEngine engine, Bitmap bitmap)
        {
            using var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;

            using var pix = Pix.LoadFromMemory(ms.ToArray());
            using var page = engine.Process(pix);

            return page.GetText();
        }
    }
}
