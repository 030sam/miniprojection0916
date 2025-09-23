using Microsoft.AspNetCore.Mvc;
using System.Globalization;

[Route("upload")]
[ApiController]
public class UploadController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Upload(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return BadRequest(new { error = "No files uploaded" });
        var results = new List<object>();
        var pathname = "";
        foreach (var file in files)
        {
            if (file.Length > 25*1024*1024)
            {
                continue;
            }
            pathname = file.FileName.Split(".")[0] + "_" + DateTime.Now.Ticks.ToString() + "." + file.FileName.Split(".")[1];
            var savePath = Path.Combine(@"D:\VisualStudio\WebApplication2\wwwroot", pathname);

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            results.Add(new
            {
                fileName = pathname,
                size = file.Length
            });
        }

        return Ok(results);
    }
}
