using Microsoft.AspNetCore.Mvc;

namespace SaveFileNET.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult FileUploadPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveFile(IFormFile[] FileArray)
        {
            if(FileArray != null && FileArray.Count()>0)
            {
                foreach(var file in FileArray)
                {
                    if (file != null)
                    {
                        string FileNmae = file.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", FileNmae);

                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);

                        string url = "/files/" + FileNmae;
                    }
                }
            }       
            return RedirectToAction("FileUploadPage", "FileUpload");
        }
    }
}
