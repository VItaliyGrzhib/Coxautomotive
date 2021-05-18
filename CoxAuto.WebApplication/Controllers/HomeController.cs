using CoxAuto.Loader.Model;
using CoxAuto.Service.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;


namespace CoxAuto.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private const string _root = "csvFiles";
        private string _dir { get; }
        private IFileLoadManager _ldrmngr { get; }


        public HomeController(IWebHostEnvironment env,
            IFileLoadManager ldrmngr)

        {
            _dir = env.ContentRootPath;
            _ldrmngr = ldrmngr;
        }
        public IActionResult Index() => View();

        [HttpGet]
        [Route ("/getpath")]
        public  string GetPath()
        {
            return  Path.Combine(_dir, _root);
        }

        public IEnumerable<SalesDataModel> FileInModel(IFormFile file)
        {
            var path = Path.Combine(_dir, _root, file.FileName);
            
            return _ldrmngr.GetData(path);
        }

    }
}
