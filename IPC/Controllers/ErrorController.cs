using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ViewResult Index()
        {
            return View("Error");
        }
        [HttpGet]
        public ViewResult NotFound()
        {
            //Response.StatusCode = 404;
            return View("NotFound");
        }
    }
}