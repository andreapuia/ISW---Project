using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalOffice.Models.DataAccesslayer;

namespace DentalOffice.Models.DataAccesslayer.Tests
{
    [TestClass()]
    public class UserDALTests
    {
        [TestMethod()]
        public void AddDoctorPrTest()
        {
            var a = 10;
            Assert.AreEqual(a, 10);
        }

        [TestMethod()]
        public void CheckUserName()
        {
            var user = UserDAL.generateUser(1, "Andrea", "Parola", "Andrea", "Puia", Role.doctor, Enum.Deleted.no);
           
            Assert.AreEqual(user.Username, "Andrea");
        }

        [TestMethod()]
        public void CheckNotOKUserName()
        {
            var user = UserDAL.generateUser(1, "Andrea", "Parola", "Andrea", "Puia", Role.doctor, Enum.Deleted.no);

            Assert.AreNotEqual(user.Username, "Andreea");
        }
    }
}