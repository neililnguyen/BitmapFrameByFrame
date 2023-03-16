using BitmapFramePerFrame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;


namespace BitmapFramePerFrame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetFrames(int imageId)
        {
            try
            {
                // Load the bitmap image
                Bitmap bitmap = new Bitmap("path/to/image.jpg");

                // Get the number of frames in the image
                int frameCount = bitmap.GetFrameCount(FrameDimension.Time);

                // Loop through each frame and return it as a file result
                for (int i = 0; i < frameCount; i++)
                {
                    bitmap.SelectActiveFrame(FrameDimension.Time, i);
                    MemoryStream stream = new MemoryStream();
                    bitmap.Save(stream, ImageFormat.Png);
                    stream.Position = 0;
                    return new FileStreamResult(stream, "image/png");
                }

                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
