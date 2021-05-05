using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class MainController : Controller
    {
        // 
        // GET: /Main/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /Main/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}