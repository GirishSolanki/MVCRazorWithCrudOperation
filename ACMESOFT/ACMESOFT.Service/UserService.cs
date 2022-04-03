using ACMESOFT.Data;
using ACMESOFT.Entity;
using ACMESOFT.IService;

namespace ACMESOFT.Service
{
    public class UserService : IUserService
    {

        private readonly AcmesoftDataContext _acmesoftDataContext;
        public UserService(AcmesoftDataContext acmesoftDataContext)
        {
            this._acmesoftDataContext = acmesoftDataContext;
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(User entity)
        {
            throw new NotImplementedException();
        }

        public User Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> List(User entity)
        {
            return _acmesoftDataContext.User
                .Where(x => x.UserName == entity.UserName
                && x.Password == entity.Password 
                && x.IsDeleted == false)
                .ToList();
        }
    }
}
