using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitmapFpF.NetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetFrames(int imageId)
        {
            try
            {
                // Load the bitmap image
                Bitmap bitmap = new Bitmap(@"C://image.jpg");

                // Get the number of frames in the image
                int frameCount = bitmap.GetFrameCount(FrameDimension.Page);

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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}