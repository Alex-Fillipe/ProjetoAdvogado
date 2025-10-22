using Dominio.Login;
using Repositorio.Implementacao;
using System.Web.Mvc;
using ViewModel;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepositorio _repositorio;

        public LoginController()
        {
            _repositorio = new LoginRepositorio();
        }

        // GET: Login 
        public ActionResult Index()
        {
            var model = new LoginViewModel();   
            return View(model);
        }

        // POST: Login 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool autenticado = _repositorio.Autenticar(model.Usuario, model.Senha);
                if (autenticado)
                {
                    var login = _repositorio.ObterPorUsuario(model.Usuario);
                    Session["UsuarioNome"] = login.Nome;  
                    Session["UsuarioLogado"] = login.Usuario; 
                    return RedirectToAction("Index", "Advogado");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário ou senha inválidos.");
                }
            }

            return View(model);
        }

        // GET: Register 
        public ActionResult Register()
        {
            var model = new RegisterViewModel();  
            return View(model);
        }

        // POST: Register 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginExistente = _repositorio.ObterPorUsuario(model.Usuario);
                if (loginExistente != null)
                {
                    ModelState.AddModelError("", "Usuário já existe.");
                    return View(model);
                }

                var login = new Login
                {
                    Nome = model.Nome,
                    Usuario = model.Usuario,
                    Senha = model.Senha  
                };

                _repositorio.Adicionar(login);
                TempData["Mensagem"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
