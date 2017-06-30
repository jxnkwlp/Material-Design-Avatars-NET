using MaterialDesignAvatars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Avatar(string letter, int size = 512)
        {
            if (string.IsNullOrEmpty(letter))
                return Content("No letter");

            if (size < 0 && size > 5000)
            {
                return Content("Size for this test is not invalid.");
            }

            var avatar = new MdAvatar();

            byte[] result = avatar.Build(letter, size);

            return File(result, "image/png");
        }

    }
}