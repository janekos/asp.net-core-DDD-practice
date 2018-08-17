using System;
using System.Collections.Generic;
using System.IO;
using ddd_asp_practice.Data.API.Services;
using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Data.Infrastructure;
using ddd_asp_practice.Data.Infrastructure.Repositories;
using ddd_asp_practice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ddd_asp_practice.Tests.DomainEntities {
    [TestClass]
    public class DBFunctionalityAndEntityTests {

        [TestMethod]
        public void TestFirmEntityForAcceptingCorrectTypes() {
            FirmPartyGoerDomainEntity entity = new FirmPartyGoerDomainEntity();
            Assert.IsNotNull(entity.dateAdded);
            Assert.ThrowsException<ArgumentException>(() => entity.setFirmNumber(1));
            Assert.ThrowsException<ArgumentException>(() => entity.setFirmParticipants(0));
            Assert.ThrowsException<ArgumentException>(() => entity.setPaymentType(2));
            Assert.ThrowsException<ArgumentException>(() => entity.setExtraInfo(new string('*', 5001)));
        }

        [TestMethod]
        public void TestPersonEntityForAcceptingCorrectTypes() {
            PersonPartyGoerDomainEntity entity = new PersonPartyGoerDomainEntity();
            Assert.IsNotNull(entity.dateAdded);
            Assert.ThrowsException<ArgumentException>(() => entity.setPersonalCode(1));
            Assert.ThrowsException<ArgumentException>(() => entity.setPaymentType(2));
            Assert.ThrowsException<ArgumentException>(() => entity.setExtraInfo(new string('*', 1501)));
        }

        [TestMethod]
        public void TestPartyEntityForAcceptingCorrectTypes() {
            PartyDomainEntity entity = new PartyDomainEntity();
            Assert.IsNotNull(entity.dateAdded);
            Assert.ThrowsException<ArgumentException>(() => entity.setName(new string('*', 101)));
            Assert.ThrowsException<ArgumentException>(() => entity.setDate(DateTime.Now.AddDays(-1)));
            Assert.ThrowsException<ArgumentException>(() => entity.setExtraInfo(new string('*', 1001)));
        }

        [TestMethod]
        public void TestPartyEntityForGettingId() {
            using(var pr = new PartyDBContext()) {
                pr.parties.Add(new PartyDomainEntity("testName", DateTime.Now.AddDays(1), "testLocation", "testExtrainfo"));

                int id = 0;
                foreach(var item in pr.parties) { id++; }

                try { var entity = pr.parties.Find(id); }
                catch (Exception ex) { Assert.Fail(); }
            }
        }

        [TestMethod]
        public void TestPersonEntityForGettingId() {
            using (var pr = new PartyDBContext()) {
                pr.personPartyGoers.Add(new PersonPartyGoerDomainEntity(1, "testName","testSurname", 11111111111, 1));

                int id = 0;
                foreach (var item in pr.personPartyGoers) { id++; }

                try { var entity = pr.personPartyGoers.Find(id); }
                catch{ Assert.Fail(); }
            }
        }

        [TestMethod]
        public void TestFirmEntityForGettingId() {
            using (var pr = new PartyDBContext()) {
                pr.firmPartyGoers.Add(new FirmPartyGoerDomainEntity(1, "testName", 111111111, 10, 1));

                int id = 0;
                foreach (var item in pr.firmPartyGoers) { id++; }

                try { var entity = pr.firmPartyGoers.Find(id); }
                catch { Assert.Fail(); }
            }
        }

    }
}
