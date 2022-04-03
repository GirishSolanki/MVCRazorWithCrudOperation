using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ACMESOFT.Web.Pages.Login
{
    public class LoginModel : PageModel
    {
        public ACMESOFT.Entity.User User { get; set; }
        private readonly WebApi _webApi = null;
        public LoginModel(WebApi webApi)
        {
            User = new Entity.User();
            this._webApi = webApi;
        }


        public void OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Person/PersonList");
            }
        }

        public void OnGetLogout()
        {
            new AuthenticationController(HttpContext);
            Response.Redirect("/Login/Login");
        }

        public void OnPost(Entity.User user)
        {
            this.ValidateUser(user);
            if (user != null)
            {
                new AuthenticationController(user, HttpContext);
                Response.Redirect("/Login/Login");
            }
        }

        private void ValidateUser(Entity.User user)
        {
            if (user != null)
            {
                this.User = this._webApi.CallApi<List<Entity.User>>("user-login", user, String.Empty).Result.FirstOrDefault();
            }
        }
    }
}
