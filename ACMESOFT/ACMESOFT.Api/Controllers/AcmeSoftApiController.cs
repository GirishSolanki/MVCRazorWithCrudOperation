using ACMESOFT.Common;
using ACMESOFT.Entity;
using ACMESOFT.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ACMESOFT.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AcmeSoftApiController : ControllerBase
    {
        private readonly IAcmesoftServices _acmesoftServices;
        private readonly IUserService _userService;

        public AcmeSoftApiController(IAcmesoftServices acmesoftServices, IUserService userService)
        {
            this._acmesoftServices = acmesoftServices;
            this._userService = userService;
        }

        #region Person

        [HttpPost("add-person")]
        public IActionResult AddPerson(Person person)
        {
            person = this._acmesoftServices.Insert(person);

            return Ok(new GenericResponse<Person>(
                "Data Saved Successfully."
                , true
                , HttpStatusCode.OK.ToString()
                , person));
        }

        [HttpPost("person-by-id")]
        public IActionResult GetById(Person person)
        {
            person = this._acmesoftServices.GetById(person);
            return Ok(new GenericResponse<Person>(
                "Data Fetched Successfully."
                , true
                , HttpStatusCode.OK.ToString()
                , person));
        }

        [HttpPost("person-list")]
        public IActionResult GetList(Person person)
        {
            var personList = this._acmesoftServices.List(person);
            return Ok(new GenericResponse<List<Person>>(
                 "Data Fetched Successfully."
                 , true
                 , HttpStatusCode.OK.ToString()
                 , personList));
        }

        [HttpPost("person-delete")]
        public IActionResult Delete(Person person)
        {
            bool result = this._acmesoftServices.Delete(person);
            return Ok(new GenericResponse<Person>(
                "Data Deleted Successfully."
                , true
                , HttpStatusCode.OK.ToString()
                , null));
        }

        #endregion

        #region User

        [HttpPost("user-login")]
        public IActionResult UserLogin(User user)
        {
            var userList = this._userService.List(user);
            if (userList != null && userList.Any())
            {
                return Ok(new GenericResponse<List<User>>(
                    "Login Successfully."
                    , true
                    , HttpStatusCode.OK.ToString()
                    , userList));
            }
            else
            {
                return Unauthorized(new GenericResponse<List<User>>(
                    "Unauthorized User."
                    , true
                    , HttpStatusCode.Unauthorized.ToString()
                    , null));
            }
        }

        #endregion



    }
}
