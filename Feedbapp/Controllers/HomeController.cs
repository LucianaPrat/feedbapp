using Business;
using Business.Models;
using Dominio;
using Dominio.DTO;
using Feedbapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Feedbapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISistema _sistema;
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, ISistema sistema)
        {
            _logger = logger;
            _config = config;
            _sistema = sistema;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Lists
        public IActionResult Clients()
        {
            return View(_sistema.GetClients());
        }
        public IActionResult Developers()
        {
            return View(_sistema.GetDevelopers());
        }
        public IActionResult Positions()
        {
            return View(_sistema.GetPositions());
        }
        public IActionResult Deliveries()
        {
            return View(_sistema.GetDeliveries());
        }
        public IActionResult Leaders()
        {
            return View(_sistema.GetLeaders());
        }
        #endregion

        #region Creates
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateClient(ClientDTO c)
        {
            try {
                _sistema.CreateClient(c);
                ViewBag.Message = "Creado correctamente";
                return RedirectToAction("Clients");
            }
            catch(Exception e){
                ViewBag.Message = e.Message;
            }
            return View();            
        }
        public IActionResult CreateDeveloper()
        {
            ViewBag.leaders = _sistema.GetLeaders();
            return View();
        }

        [HttpPost]

        public IActionResult CreateDeveloper(Developer d)
        {
            ViewBag.leaders = _sistema.GetLeaders();
            try
            {
                _sistema.CreateDeveloper(d);
                ViewBag.Message = "Creado correctamente";
                return RedirectToAction("Developers");
            }
            catch (Exception e){
                ViewBag.Message = e.Message;
            }        
            return View();
        }
        public IActionResult CreatePosition()
        {
            ViewBag.developers = _sistema.GetDevelopers();
            return View();
        }

        [HttpPost]

        public IActionResult CreatePosition(Position p)
        {
            ViewBag.developers = _sistema.GetDevelopers();
            try
            {                
                _sistema.CreatePosition(p);                
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
            ViewBag.clients = _sistema.GetClients();
            return View();
        }

        [HttpPost]
        public IActionResult CreateLeader(Leader p)
        {
            try
            {
                ViewBag.clients = _sistema.GetClients();
                _sistema.CreateLeader(p);
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
            ViewBag.leaders = _sistema.GetLeaders();
            Developer? search = _sistema.SerchDeveloperId(id);
            return View(search);
        }
        [HttpPost]
        public IActionResult EditDeveloper(Developer d)
        {
            ViewBag.leaders = _sistema.GetLeaders();
            _sistema.EditDeveloper(d);
            return RedirectToAction("Developers"); ;
        }
        public IActionResult EditDeliveries(int id)
        {
            ViewBag.leaders = _sistema.GetLeaders();
            ViewBag.developers = _sistema.GetDevelopers();
            Developer? serch = _sistema.SerchDeveloperId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditDeliveries(Developer d)
        {
            ViewBag.leaders = _sistema.GetLeaders();
            ViewBag.developers = _sistema.GetDevelopers();
            _sistema.EditDeveloper(d);
            return View();
        }
        public IActionResult EditPosition(int id)
        {
            ViewBag.developers = _sistema.GetDevelopers();
            Position? serch = _sistema.SerchPositionId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditPosition(Position d)
        {
            ViewBag.developers = _sistema.GetDevelopers();
            _sistema.EditPosition(d);
            return View();
        }
        public IActionResult EditClient(int id)
        {
            ClientDTO? serch = _sistema.SearchClientId(id);
            return View(serch);
        }

        [HttpPost]
        public IActionResult EditClient(ClientDTO c)
        {
            _sistema.EditClient(c);
            return RedirectToAction("Clients");
        }
        public IActionResult EditLeader(int id)
        {
            ViewBag.clients = _sistema.GetClients();
            Leader? serch = _sistema.SerchLeaderId(id);
            return View(serch);
        }
        [HttpPost]
        public IActionResult EditLeader(Leader l)
        {
            ViewBag.clients = _sistema.GetClients();
            _sistema.EditLeader(l);
            return RedirectToAction("Leaders");
        }
        #endregion

        #region Deletes
        public IActionResult DeleteClient(int id)
        {
            try
            {
                ClientDTO? serch = _sistema.SearchClientId(id);
                _sistema.DeleteClient(serch);
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
                Leader? serch = _sistema.SerchLeaderId(id);
                _sistema.DeleteLeader(serch);
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
                Developer? serch = _sistema.SerchDeveloperId(id);
                _sistema.DeleteDeveloper(serch);
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
                Position? serch = _sistema.SerchPositionId(id);
                _sistema.DeletePosition(serch);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }

            return RedirectToAction("Leaders");
        }
        #endregion

        public IActionResult Login()
        {
           return View();            
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            try
            {   
                Admin? a = _sistema.Login(Email, Password);
                if (a != null)
                {//guarda su id y su rol
                    HttpContext.Session.SetInt32("LoggedId", a.Id);
                    HttpContext.Session.SetString("LoggedRol", a.GetType().Name);
                    //dependiendo el rol muestra los index correspondientes
                    if (a.GetType().Name.Equals("Administrador"))
                    {
                        return RedirectToAction("Index", "Administrador");
                    }
                }
            } 
            catch (Exception ex)
            {
                @ViewBag.message = ex.Message;
            }
            return View();
        }

        public IActionResult SendEmail(int id)
        {
           Position serch = _sistema.SerchPositionId(id);
           ViewBag.position = serch;
           return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDTO e, int PositionId)
        {
            EmailConfig emailConfig = new EmailConfig();
            emailConfig.Host = _config.GetSection("Email:Host").Value;
            emailConfig.Port = _config.GetSection("Email:Port").Value;
            emailConfig.UserName = _config.GetSection("Email:UserName").Value;
            emailConfig.Password = _config.GetSection("Email:Password").Value;
            _sistema.SendEmail(PositionId, e, emailConfig);
            return RedirectToAction("Positions","Home");
        }
        public IActionResult SingIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SingIn(Admin a)
        {
            try
            {                
                _sistema.AddAdmin(a);
                ViewBag.message = "Tu cuenta se ha creado correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
