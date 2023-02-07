using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;


namespace DataRoom.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        //[AllowAnonymous]
        //[Route("Error/{statusCode}")]
        //public IActionResult HttpStatusCodeHandler(int statusCode)
        //{
        //    var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

        //    switch (statusCode)
        //    {
        //        case 404:
        //            ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
        //            ViewBag.Path = statusCodeResult.OriginalPath;
        //            ViewBag.QS = statusCodeResult.OriginalQueryString;
        //            break;
        //    }

        //    return View("NotFound");
        //}

        [AllowAnonymous]
        //[Route("Error")]
        public IActionResult Error()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Error");
        }

        /*
         In a production application, we do not display the exception details on the error view as above. 
         We instead log them to a database table, file, event viewer etc, so a developer 
         can review them and provide a code fix if required
        */
        //[AllowAnonymous]
        //[Route("Error")]
        //public IActionResult Error()
        //{
        //    var exceptionHandlerPathFeature =
        //        HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        //    logger.LogError($"The path {exceptionHandlerPathFeature.Path} " +
        //        $"threw an exception {exceptionHandlerPathFeature.Error}");

        //    return View("Error");
        //}
    }
}
