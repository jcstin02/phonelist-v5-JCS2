using Microsoft.VisualStudio.TestTools.UnitTesting;
using phone.dal;
using phone.dal.repositories;
using phone.dal.respositories;
using scholarship.dal;
using scholarship.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholarship.test.dal.tests
{
    [TestClass]
    public class PhoneTest
    {
        private PhoneRepo phoneRepo;
        private PhoneCodeRepo codeRepo;
       private AppRepo appRep;

        [TestInitialize]
        public void setup()
        {
            codeRepo = new PhoneCodeRepo();
            codeRepo.add(new PhoneCD { PHONE_CD = "AA", PHONE_TX = "Home", MOD_DT = DateTime.Now });
            codeRepo.add(new PhoneCD { PHONE_CD = "BB", PHONE_TX = "Mobile", MOD_DT = DateTime.Now });
            codeRepo.add(new PhoneCD { PHONE_CD = "CC", PHONE_TX = "Batphone", MOD_DT = DateTime.Now });

            /*
             * Add the logic here to create a new AppRepo() and then add an applicant with an
             * applicant_id of 1. When you do this, the next part should work.
             */

/*            phoneRepo = new PhoneRepo();
            phoneRepo.add(new Phone { PHONE_CD = "AA", PHONE_TX = 5028011112, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });
            phoneRepo.add(new Phone { PHONE_CD = "BB", PHONE_TX = 5028011113, MOD_DT = DateTime.Now, APPLICANT_ID = 2, CREATE_DT = DateTime.Now });
            phoneRepo.add(new Phone { PHONE_CD = "CC", PHONE_TX = 5028011114, MOD_DT = DateTime.Now, APPLICANT_ID = 3, CREATE_DT = DateTime.Now });
            */
                        appRep = new AppRepo();
            appRep.add(new Applicant { 
                APPLICANT_ID = 1, FIRST_NAME_TX = "John", LAST_NAME_TX = "Stinson", MIDDLE_INITIAL_TX = "C", 
                MOD_DT = DateTime.Now, SSN_TX = "901111134", SUFFIX_TX = "" }
            );

            phoneRepo = new PhoneRepo();
            phoneRepo.add(new Phone { PHONE_CD = "AA", PHONE_TX = 5021111111, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });
            phoneRepo.add(new Phone { PHONE_CD = "BB", PHONE_TX = 5021234567, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });
            phoneRepo.add(new Phone { PHONE_CD = "CC", PHONE_TX = 5027891011, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });

        }

        
        [TestMethod]
        public void phoneTest()
        {
                    PhoneCD phoneCd = codeRepo.getById(new PhoneCD { PHONE_CD="AA"});
            Assert.AreNotEqual(null, phoneCd, "Test Data is NOT in the DB");

            IQueryable<Phone> phones = phoneRepo.query(p => p.PHONE_CD == "AA" || p.PHONE_CD == "BB" || p.PHONE_CD == "CC");
            Assert.AreEqual(3, phones.Count());
            /*IQueryable<Phone> phones = phoneRepo.query(p => p.PHONE_CD == "AA" || p.PHONE_CD == "BB" || p.PHONE_CD == "CC");
            Assert.AreEqual(3, phones.Count());*/
                }
        [TestCleanup]
        public void cleanUp()
        {
    
       
         IQueryable<Phone> phones = phoneRepo.query(p => p.PHONE_CD == "AA" || p.PHONE_CD == "BB" || p.PHONE_CD == "CC");
            foreach (Phone p in phones.ToList<Phone>()) {
                phoneRepo.remove(p);
            }

       //delete
            IQueryable<Applicant> applicants = appRep.query(a => a.APPLICANT_ID == 1);
            foreach (Applicant applicant in applicants.ToList<Applicant>()) {
                appRep.remove(applicant);
            }
            
                    IQueryable<PhoneCD> codes = codeRepo.query(c => c.PHONE_CD == "AA" || c.PHONE_CD == "BB" || c.PHONE_CD == "CC");
            foreach (PhoneCD code in codes.ToList<PhoneCD>())
            {
                codeRepo.remove(code);
            }
        }
    }
}

