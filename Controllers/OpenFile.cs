//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.IO;
//using Microsoft.AspNetCore.StaticFiles;
//namespace WebApplication2.Controllers
//{

//    public class FileController : Controller
//    {
//        private readonly string _fileFolder = @"D:\VisualStudio\WebApplication2\FilePath";

//        [HttpPost]
//        public ActionResult Create(string filename)
//        {
//            if (string.IsNullOrEmpty(filename))
//                return new BadRequestObjectResult("File name is required");

//            Directory.CreateDirectory(_fileFolder);

//            var filePath = Path.Combine(_fileFolder, filename);

//            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
//            using (var writer = new StreamWriter(fs))
//            {
//                writer.Write("Hello, this file was created on the fly!");
//                writer.Flush();
//                fs.Flush(true);
//            }

//            // Return plain URL like /example.txt
//            string fileUrl = "/" + filename;
//            return Json(new { success = true, url = fileUrl });
//        }

//        public ActionResult Get(string id)
//        {
//            if (string.IsNullOrEmpty(id))
//                return new BadRequestObjectResult("File name is required");

//            var filePath = Path.Combine(_fileFolder, id);
//            if (!System.IO.File.Exists(filePath))
//                return NotFound("File not found");

//            var provider = new FileExtensionContentTypeProvider();
//            string contentType;
//            if (!provider.TryGetContentType(filePath, out contentType))
//            {
//                contentType = "application/octet-stream";
//            }
//            return File(filePath, contentType, id);
//        }
//    }

//}
