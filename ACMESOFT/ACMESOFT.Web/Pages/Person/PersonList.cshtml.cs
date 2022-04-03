using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ACMESOFT.Web.Pages.Person
{
    [Authorize]
    public class PersonListModel : PageModel
    {
        public ACMESOFT.Entity.Person Person { get; set; }
        public List<ACMESOFT.Entity.Person> PersonList { get; set; }

       
        public int PersonId { get; set; }

        private readonly WebApi _webApi = null;
        public PersonListModel(WebApi webApi)
        {
            Person = new ACMESOFT.Entity.Person();
            PersonList = new List<Entity.Person>();
            this._webApi = webApi;
        }
        public void OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("/Login/Login");
            }

            this.GetPerson(new Entity.Person());
        }

        public void OnGetDeletePerson(int personId)
        {
            this.DeletePerson(new Entity.Person() { PersonId = personId });
            this.GetPerson(new Entity.Person());
        }

        private void GetPerson(ACMESOFT.Entity.Person person)
        {
            this.PersonList = this._webApi.CallApi<List<Entity.Person>>("person-list", person, String.Empty).Result;
        }

        private void DeletePerson(ACMESOFT.Entity.Person person)
        {
            this._webApi.CallApi<List<Entity.Person>>("person-delete", person, String.Empty);
        }
    }
}
