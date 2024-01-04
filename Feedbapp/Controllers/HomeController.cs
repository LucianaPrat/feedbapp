using Dominio;
using Feedbapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Feedbapp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Lists
        public IActionResult Clients()
        {
            return View(s.GetClients());
        }
        public IActionResult Developers()
        {
            return View(s.GetDevelopers());
        }
        public IActionResult Positions()
        {
            return View(s.GetPositions());
        }
        public IActionResult Deliveries()
        {
            return View(s.GetDeliveries());
        }
        public IActionResult Leaders()
        {
            return View(s.GetLeaders());
        }
        #endregion

        #region Creates
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateClient(Client c)
        {
            try {
                s.CreateClient(c);
                ViewBag.mensaje = "Creado correctamente";
            }
            catch(Exception e){
                ViewBag.mensaje = e.Message;
            }
            
            return RedirectToAction("Clients");
        }
        public IActionResult CreateDeveloper()
        {
            ViewBag.leaders = s.GetLeaders();
            return View();
        }

        [HttpPost]

        public IActionResult CreateDeveloper(Developer d)
        {
            ViewBag.leaders = s.GetLeaders();
            try
            {
                s.CreateDeveloper(d);
                ViewBag.mensaje = "Creado correctamente";
            }catch (Exception e){
                ViewBag.mensaje = e.Message;
            }        
            return RedirectToAction("Developers");
        }
        public IActionResult CreatePosition()
        {
            ViewBag.developers = s.GetDevelopers();
            return View();
        }

        [HttpPost]

        public IActionResult CreatePosition(Position p)
        {
            ViewBag.developers = s.GetDevelopers();
            try
            {                
                s.CreatePosition(p);                
                ViewBag.mensaje = "Creado correctamente";
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Positions");
        }
        
        public IActionResult CreateLeader()
        {
            ViewBag.clients = s.GetClients();
            return View();
        }

        [HttpPost]
        public IActionResult CreateLeader(Leader p)
        {
            try
            {
                ViewBag.clients = s.GetClients();
                s.CreateLeader(p);
                ViewBag.mensaje = "Creado correctamente";
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Leaders");
        }
        #endregion

        #region Edits
        public IActionResult EditDeveloper(int id)
        {
            ViewBag.leaders = s.GetLeaders();
            Developer? serch = s.SerchDeveloperId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditDeveloper(Developer d)
        {
            ViewBag.leaders = s.GetLeaders();
            s.EditDeveloper(d);
            return View();
        }
        public IActionResult EditDeliveries(int id)
        {
            ViewBag.leaders = s.GetLeaders();
            ViewBag.developers = s.GetDevelopers();
            Developer? serch = s.SerchDeveloperId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditDeliveries(Developer d)
        {
            ViewBag.leaders = s.GetLeaders();
            ViewBag.developers = s.GetDevelopers();
            s.EditDeveloper(d);
            return View();
        }
        public IActionResult EditPosition(int id)
        {
            ViewBag.developers = s.GetDevelopers();
            Position? serch = s.SerchPositionId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditPosition(Position d)
        {
            ViewBag.developers = s.GetDevelopers();
            s.EditPosition(d);
            return View();
        }
        public IActionResult EditClient(int id)
        {
            Client? serch = s.SerchClientId(id);
            return View(serch);
        }

        [HttpPost]
        public IActionResult EditClient(Client c)
        {
            s.EditClient(c);
            return View();
        }
        public IActionResult EditLeader(int id)
        {
            ViewBag.clients = s.GetClients();
            Leader? serch = s.SerchLeaderId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditLeader(Leader l)
        {
            ViewBag.clients = s.GetClients();
            s.EditLeader(l);
            return View();
        }
        #endregion

        #region Deletes
        public IActionResult DeleteClient(int id)
        {
            try
            {
                Client? serch = s.SerchClientId(id);
                s.DeleteClient(serch);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Clients");
        }
        public IActionResult DeleteLeader(int id)
        {
            try
            {
                Leader? serch = s.SerchLeaderId(id);
                s.DeleteLeader(serch);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Leaders");
        }
        public IActionResult DeleteDeveloper(int id)
        {
            try
            {
                Developer? serch = s.SerchDeveloperId(id);
                s.DeleteDeveloper(serch);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Leaders");
        }
        public IActionResult DeletePosition(int id)
        {
            try
            {
                Position? serch = s.SerchPositionId(id);
                s.DeletePosition(serch);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Leaders");
        }
        #endregion


        public IActionResult SendEmail()
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
