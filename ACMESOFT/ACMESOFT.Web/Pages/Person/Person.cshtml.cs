using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ACMESOFT.Web.Pages.Person
{
    [Authorize]
    public class PersonModel : PageModel
    {
        public ACMESOFT.Entity.Person Person { get; set; }
        public List<ACMESOFT.Entity.Person> PersonList { get; set; }

        private readonly WebApi _webApi = null;
        public PersonModel(WebApi webApi)
        {
            Person = new ACMESOFT.Entity.Person();
            PersonList = new List<Entity.Person>();
            this._webApi = webApi;
        }


        public void OnGet()
        {
            
            if(Request.QueryString.HasValue)
            {
                int personId = Convert.ToInt32(HttpContext.Request.Query["PersonId"].ToString());
                if (personId > 0)
                {
                    this.GetPersonDetails(personId);
                }
            }
        }
        public void OnPost(Entity.Person person)
        {
            this.SavePerson(person);
            ViewData["IsSaved"] = "1";
        }

        private void SavePerson(Entity.Person person)
        {
            this.Person = this._webApi.CallApi<Entity.Person>("add-person", person, String.Empty).Result;
        }

        private void GetPersonDetails(int personId)
        {
            this.Person = this._webApi.CallApi<Entity.Person>("person-by-id", new Entity.Person() { PersonId = personId }, String.Empty).Result;
        }
    }
}

