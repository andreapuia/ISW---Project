using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DentalOffice.Models.DataAccesslayer.Tests
{
    [TestClass()]
    public class UserDALTests
    {
        //TESTS FOR USER
        [TestMethod()]
        public void CheckUserName()
        {
            var user = UserDAL.generateUser(1, "Andrea", "Parola", "Andrea", "Puia", Role.doctor, Enum.Deleted.no);
            Assert.AreEqual(user.Username, "Andrea");
        }

        [TestMethod()]
        public void CheckUserPassword()
        {
            var user = UserDAL.generateUser(1, "Andrea", "q1w2e3", "Andrea", "Puia", Role.doctor, Enum.Deleted.no);
            Assert.AreSame(user.Password, "q1w2e33", "Incorrect password");
        }

        [TestMethod()]
        public void CheckFirstNameType()
        {
            var user = UserDAL.generateUser(1, "cris", "q1w2e3", "Cristina", "Calin", Role.administrator, Enum.Deleted.no);
            Assert.IsInstanceOfType(user.FirstName, typeof(string));
        }


        //TESTS FOR PATIENT
        [TestMethod()]
        public void CheckExistingPatient()
        {
            var patient = PatientDAL.generatePatient(1, 1, "Corina", "Corina", "120", "BV", Enum.Deleted.no, 50);
            Assert.AreEqual(patient.FirstName, "Corina");
        }

        [TestMethod()]
        public void CheckPatientCNP()
        {
            var patient = PatientDAL.generatePatient(1, 1, "Corina", "Corina", "120", "BV", Enum.Deleted.no, 80);
            Assert.AreNotSame(patient.CNP, 7633, "Correct value for CNP");
        }

        [TestMethod()]
        public void CheckNotOKCityForPatient()
        {
            var patient = PatientDAL.generatePatient(4, 3, "Mihai", "Corina", "763", "AG", Enum.Deleted.no, 100);
            Assert.AreNotEqual(patient.City, "B");
        }


        //TEST FOR PRICE
        [TestMethod()]
        public void CheckCorrectPrice()
        {
            var price = PriceDAL.generatePrice(1, 2, 20, DateTime.Now, DateTime.Now, Enum.Deleted.no);
            Assert.AreEqual(price.Value, 20);
        }

        [TestMethod()]
        public void CheckNotNullPrice()
        {
            var price = PriceDAL.generatePrice(8, 7, 290, DateTime.Now, DateTime.Now, Enum.Deleted.no);
            Assert.IsNotNull(price.Value);
        }

        [TestMethod()]
        public void CheckIncorrectPrice()
        {
            var price = PriceDAL.generatePrice(8, 7, 290, DateTime.Now, DateTime.Now, Enum.Deleted.no);
            Assert.AreNotEqual(price.Value, null);
        }


        //TESTS FOR AGENDA
        [TestMethod()]
        public void CheckNotExistingAgenda()
        {
            var agenda = AgendaDAL.generateAgenda(4, 1, 2, Enum.Deleted.no);
            Assert.AreNotEqual(agenda.ID, 1);
        }

        [TestMethod()]
        public void CheckExistingAgenda()
        {
            var agenda = AgendaDAL.generateAgenda(4, 1, 2, Enum.Deleted.yes);
            Assert.AreEqual(agenda.ID, 4);
        }

        [TestMethod()]
        public void CheckDeletedAgenda()
        {
            var agenda = AgendaDAL.generateAgenda(4, 1, 2, Enum.Deleted.yes);
            Assert.AreEqual(agenda.Deleted, Enum.Deleted.yes);
        }


        //TEST FOR INTERVENTIONS
        [TestMethod()]
        public void CheckExistingIntervention()
        {
            var intervention = InterventionDAL.generateIntervention(1, "Aparat dentar", Enum.Deleted.yes);
            Assert.AreEqual(intervention.Deleted, Enum.Deleted.yes);
        }

        [TestMethod()]
        public void CheckInterventionType()
        {
            var intervention = InterventionDAL.generateIntervention(1, "Aparat dentar", Enum.Deleted.no);
            Assert.IsInstanceOfType(intervention.Name, typeof(string));
        }

        [TestMethod()]
        public void CheckNotAvailableIntervention()
        {
            var intervention = InterventionDAL.generateIntervention(1, "Aparat dentar", Enum.Deleted.no);
            Assert.IsNotNull(intervention.Name, "Unavailable intervention");
        }
    }

}
