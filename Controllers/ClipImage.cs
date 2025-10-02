using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using static Microsoft.EntityFrameworkCore.Query.Internal.ExpressionTreeFuncletizer;

namespace WebApplication2.Controllers
{
    public class ImageController : Controller
    {

        [SupportedOSPlatform("windows")]
        [HttpPost]
        public async Task<IActionResult> Crop([FromBody] CropRequest req)
        {
            var filename = req.name;
            string path = "D:\\VisualStudio\\WebApplication2\\FilePath\\" + filename;
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            using var ms = new MemoryStream(imageBytes);
            using var srcImage = Image.FromFile(path);
            using var bmp = new Bitmap(req.w, req.h);

            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(srcImage,
                    new Rectangle(0, 0, req.w, req.h),
                    new Rectangle(req.x, req.y, req.w, req.h),
                    GraphicsUnit.Pixel);
            }

            //using var ms = new MemoryStream();
            //bmp.Save(ms, ImageFormat.Jpeg);
            var afterpath = "";
            if (filename.Contains(".png"))
            {
                //string tempPath = "D:\\VisualStudio\\WebApplication2\\FilePath\\" + "temp.png";
                //bmp.Save(tempPath, ImageFormat.Png);
                //System.IO.File.Delete(path);
                //System.IO.File.Move(tempPath, path);
                afterpath = filename.Split("_")[0] + "_" + DateTime.Now.Ticks.ToString() + ".png";
                //bmp.Save("D:\\VisualStudio\\WebApplication2\\FilePath\\ " + afterpath, ImageFormat.Png);

                //var file = System.IO.File.OpenRead("D:\\VisualStudio\\WebApplication2\\FilePath\\" + filename);
                //var savePath = Path.Combine(@"D:\VisualStudio\WebApplication2\FilePath", afterpath);
                //var filedata = req.file;
                //using (var stream = new FileStream(savePath, FileMode.Create))
                //{
                //    await filedata.CopyToAsync(stream);
                //}
                //var file = System.IO.File.OpenRead("D:\\VisualStudio\\WebApplication2\\FilePath\\" + filename);
                var filePath = Path.Combine("D:\\VisualStudio\\WebApplication2\\FilePath", afterpath);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    bmp.Save(fs, ImageFormat.Jpeg); // write into the FileStream
                    fs.Flush(true);                 // flush everything to disk
                }
            }
            else
            {
                //string tempPath = "D:\\VisualStudio\\WebApplication2\\FilePath\\" + "temp.jpg";
                //bmp.Save(tempPath, ImageFormat.Jpeg);
                //System.IO.File.Delete(path);
                //System.IO.File.Move(tempPath, path);

                afterpath = filename.Split("_")[0] + "_" + DateTime.Now.Ticks.ToString() + ".jpg";
                //bmp.Save("D:\\VisualStudio\\WebApplication2\\FilePath\\ " + afterpath, ImageFormat.Jpeg);

                var filePath = Path.Combine("D:\\VisualStudio\\WebApplication2\\FilePath", afterpath);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    bmp.Save(fs, ImageFormat.Jpeg); // write into the FileStream
                    fs.Flush(true);                 // flush everything to disk
                }
            }

            //return File(ms.ToArray(), "image/jpeg");
            return Ok(afterpath);
        }

        public class CropRequest
        {
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
            public string name { get; set; }
            public IFormFile file { get; private set; }
        }
    }
}
