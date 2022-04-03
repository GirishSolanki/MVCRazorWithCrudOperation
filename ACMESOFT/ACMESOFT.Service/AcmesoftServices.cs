using ACMESOFT.Data;
using ACMESOFT.Entity;
using ACMESOFT.IService;
using Microsoft.EntityFrameworkCore;

namespace ACMESOFT.Service
{
    public class AcmesoftServices : IAcmesoftServices
    {
        private readonly AcmesoftDataContext _acmesoftDataContext;
        public AcmesoftServices(AcmesoftDataContext acmesoftDataContext)
        {
            this._acmesoftDataContext = acmesoftDataContext;
        }

        public bool Delete(Person entity)
        {
            var person = this._acmesoftDataContext
                .Person
                .Include(x => x.Employee)
                .FirstOrDefault(x => x.PersonId == entity.PersonId);

            if (person != null)
            {
                person.IsDeleted = true;
                person.Employee.IsDeleted = true;
                this._acmesoftDataContext.Update(person);
                this._acmesoftDataContext.SaveChanges();
                return true;
            }

            return false;
        }

        public Person GetById(Person entity)
        {
            return this._acmesoftDataContext.Person
                .Include(x => x.Employee)
                .FirstOrDefault(x => x.PersonId == entity.PersonId && (x.IsDeleted == false || x.IsDeleted == null));
        }

        public Person Insert(Person entity)
        {
            entity.IsDeleted = false;
            entity.Employee.IsDeleted = false;
            if (entity.PersonId == 0)
            {
                this._acmesoftDataContext.Add(entity);
            }
            else
            {
                this._acmesoftDataContext.Update(entity);
            }

            this._acmesoftDataContext.SaveChanges();
            return entity;
        }

        public List<Person> List(Person entity)
        {
            if (entity != null)
            {
                return this._acmesoftDataContext
                    .Person
                    .Include(x => x.Employee)
                    .Where(x =>
                    (
                     (x.FirstName.Contains(string.IsNullOrEmpty(entity.FirstName) ? "" : entity.FirstName)) ||
                    (x.LastName.Contains(string.IsNullOrEmpty(entity.LastName) ? "" : entity.LastName))
                    )
                    &&
                    (x.IsDeleted == false || x.IsDeleted == null))
                    .ToList();
            }
            else
            {
                return this._acmesoftDataContext
                                   .Person
                                   .Include(x => x.Employee).Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            }
        }
    }
}
