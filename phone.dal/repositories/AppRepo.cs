using scholarship.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.dal.repositories
{
    public class AppRepo : IRepository<Applicant>
    {
        private PhoneDBEntities _context = null;
        public AppRepo()
        {
            _context = new PhoneDBEntities();
        }
        public Applicant getById(Applicant object2Add)
        {
            return _context.Applicants.Find(object2Add.APPLICANT_ID);
        }

        public Applicant[] getAll()
        {
            return _context.Applicants.ToArray();
        }

        public void add(Applicant object2Add)
        {
            object2Add.MOD_DT = DateTime.Now;
            _context.Applicants.Add(object2Add);
            _context.SaveChanges();
        }

        public void update(Applicant object2Update)
        {
            object2Update.MOD_DT = DateTime.Now;
            _context.Entry(object2Update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void remove(Applicant object2Remove)
        {
            _context.Applicants.Remove(object2Remove);
            _context.SaveChanges();
        }

        public IQueryable<Applicant> query(System.Linq.Expressions.Expression<Func<Applicant, bool>> filter)
        {
            ///return _context.Phones.Where(filter);
            return _context.Applicants.Where(filter); ;
        }
    }
}