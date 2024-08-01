using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using TallerMotos.Web.Util;

namespace TallerMotos.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServiceUsuarios _serviceUsuarios;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IServiceUsuarios serviceUsuarios, ILogger<LoginController> logger)
        {
            _serviceUsuarios = serviceUsuarios;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel viewModelLogin)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));


                _logger.LogInformation($"Error en login de {viewModelLogin}, Errores --> {errors}");
                return View("Index");
            }
            //Verificar sí el usuario existe
            var usuarioLog = await _serviceUsuarios.LoginAsync(viewModelLogin.User, viewModelLogin.Password);
            if (usuarioLog == null)
            {
                ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje(
                    "Login", "Error de Acceso", SweetAlertMessageType.warning
                    );
                _logger.LogInformation($"Error en login de {viewModelLogin.User}, Errores --> Error Acceso");
                return View("Index");
            }

            //Claim almacena información del usuario como nombre, rol y otros.
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioLog.Nombre),
                new Claim(ClaimTypes.Role, usuarioLog.IdrolNavigation.Nombre),
                new Claim(ClaimTypes.NameIdentifier, usuarioLog.ID.ToString())
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);
            _logger.LogInformation($"Conexion Correcta {viewModelLogin.User}");
            //Mensaje de notificación

            return RedirectToAction("Index", "Home");

        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
