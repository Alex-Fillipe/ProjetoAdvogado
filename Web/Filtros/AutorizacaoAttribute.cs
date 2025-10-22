using System.Web;
using System.Web.Mvc;

namespace Web.Filtros
{
    public class AutorizacaoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
            {
              
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
