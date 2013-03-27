using Microsoft.VisualStudio.TestTools.UnitTesting;
using phone.dal;
using phone.dal.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.test.dal
{
    [TestClass]
    public class ApplicantTest
    {
        AppRepo aRepo;
        Applicant a1;
        Applicant a2;
        [TestInitialize]
        public void setup()
        {
            aRepo = new AppRepo();
            a1 = new Applicant
            {
                APPLICANT_ID = 1,
                FIRST_NAME_TX = "John",
                LAST_NAME_TX = "Stinson",
                MIDDLE_INITIAL_TX = "C",
                MOD_DT = DateTime.Now,
                SSN_TX = "123456789",
                SUFFIX_TX = ""
            };
            aRepo.add(a1);

            a2 = new Applicant
              {    APPLICANT_ID = 2,
                FIRST_NAME_TX = "Trina",
                LAST_NAME_TX = "Stinson",
                MIDDLE_INITIAL_TX = "R",
                MOD_DT = DateTime.Now,
                SSN_TX = "987654321",
                SUFFIX_TX = ""
         
              };
            aRepo.add(a2);

              
            aRepo.add(new Applicant
            {
                APPLICANT_ID = 3,
                FIRST_NAME_TX = "Pancake",
                LAST_NAME_TX = "TheCat",
                MIDDLE_INITIAL_TX = "C",
                MOD_DT = DateTime.Now,
                SSN_TX = "111111122",
                SUFFIX_TX = ""
            });
        }
        [TestMethod]
        public void applicantTest()
        {
            //test to see if an applicant is added
            Applicant ap3 = aRepo.getById(new Applicant { APPLICANT_ID = 3 });
            Assert.AreNotEqual(null, ap3, "Test Data is NOT in the DB");

            //see if all are added
            IQueryable<Applicant> applicants = aRepo.query(p => p.FIRST_NAME_TX == "John" || p.FIRST_NAME_TX == "Trina" || p.FIRST_NAME_TX == "Pancake");
            Assert.AreEqual(3, applicants.Count());
        }
        [TestMethod]
        public void appLastName()
        {
            //Test to see if the married applicants have the last name "Stinson"
            Assert.AreEqual("Stinson", a1.LAST_NAME_TX, a2.LAST_NAME_TX);
        }
        [TestCleanup]
        public void cleanup()
        {
            IQueryable<Applicant> applicants = aRepo.query(a => a.APPLICANT_ID == 1 || a.APPLICANT_ID == 2 || a.APPLICANT_ID == 3);
            foreach (Applicant applicant in applicants.ToList<Applicant>())
            {
                aRepo.remove(applicant);
            }
        }
    }
}
