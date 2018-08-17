using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ddd_asp_practice.Data.API.Services;
using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ddd_asp_practice.Controllers {
    public class PartyController : Controller {

        private readonly IPartyService partyService;
        private readonly IService<FirmPartyGoerViewModel> firmPartyGoerService;
        private readonly IService<PersonPartyGoerViewModel> personPartyGoerService;

        public PartyController(IPartyService _partyService, IService<FirmPartyGoerViewModel> _firmPartyGoerService, IService<PersonPartyGoerViewModel> _personPartyGoerService) {
            partyService = _partyService;
            firmPartyGoerService = _firmPartyGoerService;
            personPartyGoerService = _personPartyGoerService;
        }

        public IActionResult Index() {
            var partyList = partyService.getAll();
            var tuplePartyList = new Tuple<List<PartyViewModel>, List<PartyViewModel>>(
                partyList.Where(item => item.date > DateTime.Now).ToList(),
                partyList.Where(item => item.date <= DateTime.Now).ToList()
            );

            return View(tuplePartyList);
        }

        public IActionResult DeleteParty(int id) {
            partyService.delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddParty() {
            ViewData["errorName"] = "none";
            ViewData["errorDate"] = "none";
            ViewData["errorLocation"] = "none";
            ViewData["errorExtraInfo"] = "none";
            ViewData["currTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
            return View();
        }

        [HttpPost]
        public IActionResult AddParty(PartyViewModel model) {
            if (!ModelState.IsValid) {
                ViewData["errorName"] = ModelState["name"].Errors.Count == 0 ? "none" : "inline-block"; 
                ViewData["errorDate"] = ModelState["date"].Errors.Count == 0 ? "none" : "inline-block"; 
                ViewData["errorLocation"] = ModelState["location"].Errors.Count == 0 ? "none" : "inline-block"; 
                ViewData["errorExtraInfo"] = ModelState["extraInfo"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["currTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                return View(model);
            } else {
                partyService.add(model);
                return RedirectToAction("Index");
            }
        }

        public IActionResult AddPersonPartyGoer(int id) {

            ViewData["partyId"] = id;
            ViewData["errorName"] = "none";
            ViewData["errorSurname"] = "none";
            ViewData["errorPersonalCode"] = "none";
            ViewData["errorPaymentType"] = "none";
            ViewData["errorExtraInfo"] = "none";
            return View();
        }

        [HttpPost]
        public IActionResult AddPersonPartyGoer(PersonPartyGoerViewModel model, int id) {

            if (!ModelState.IsValid) {
                ViewData["partyId"] = id;
                ViewData["errorName"] = ModelState["name"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorSurname"] = ModelState["surname"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorPersonalCode"] = ModelState["personalCode"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorPaymentType"] = ModelState["paymentType"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorExtraInfo"] = ModelState["extraInfo"].Errors.Count == 0 ? "none" : "inline-block";
                return View(model);
            }
            else {
                personPartyGoerService.add(model);
                return RedirectToAction("Index");
            }
        }

        public IActionResult AddFirmPartyGoer(int id) {

            ViewData["partyId"] = id;
            ViewData["errorName"] = "none";
            ViewData["errorFirmNumber"] = "none";
            ViewData["errorFirmParticipants"] = "none";
            ViewData["errorPaymentType"] = "none";
            ViewData["errorExtraInfo"] = "none";
            return View();
        }

        [HttpPost]
        public IActionResult AddFirmPartyGoer(FirmPartyGoerViewModel model, int id) {

            if (!ModelState.IsValid) {
                ViewData["partyId"] = id;
                ViewData["errorName"] = ModelState["name"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorFirmNumber"] = ModelState["firmNumber"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorFirmParticipants"] = ModelState["firmParticipants"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorPaymentType"] = ModelState["paymentType"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorExtraInfo"] = ModelState["extraInfo"].Errors.Count == 0 ? "none" : "inline-block";
                return View(model);
            }
            else {
                firmPartyGoerService.add(model);
                return RedirectToAction("Index");
            }
        }

        public IActionResult PartyGoers(int id) {
            ViewData["partyId"] = id;
            ViewData["partyName"] = partyService.getById(id).name;
            var partyGoers = partyService.getAllPartyGoers(id);
            return View(partyGoers);
        }

        public void DeletePersonPartyGoer(int id) {
            System.Diagnostics.Debug.WriteLine("----------------------------------------------");
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine("----------------------------------------------");
            personPartyGoerService.delete(id);
        }
        public void DeleteFirmPartyGoer(int id) => firmPartyGoerService.delete(id);

        public IActionResult EditPersonPartyGoer(int id) {
            ViewData["errorName"] = "none";
            ViewData["errorSurname"] = "none";
            ViewData["errorPersonalCode"] = "none";
            ViewData["errorPaymentType"] = "none";
            ViewData["errorExtraInfo"] = "none";
            return View(personPartyGoerService.getById(id));
        }

        [HttpPost]
        public IActionResult EditPersonPartyGoer(PersonPartyGoerViewModel model) {
            if (!ModelState.IsValid) {
                ViewData["errorName"] = ModelState["name"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorSurname"] = ModelState["surname"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorPersonalCode"] = ModelState["personalCode"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorPaymentType"] = ModelState["paymentType"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorExtraInfo"] = ModelState["extraInfo"].Errors.Count == 0 ? "none" : "inline-block";
                return View(model);
            }
            else {
                personPartyGoerService.update(model);
                return RedirectToAction("PartyGoers/"+model.partyRefId);
            }
        }

        public IActionResult EditFirmPartyGoer(int id) {
            ViewData["errorName"] = "none";
            ViewData["errorFirmNumber"] = "none";
            ViewData["errorFirmParticipants"] = "none";
            ViewData["errorPaymentType"] = "none";
            ViewData["errorExtraInfo"] = "none";
            return View(firmPartyGoerService.getById(id));
        }

        [HttpPost]
        public IActionResult EditFirmPartyGoer(FirmPartyGoerViewModel model) {
            if (!ModelState.IsValid) {
                ViewData["errorName"] = ModelState["name"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorFirmNumber"] = ModelState["firmNumber"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorFirmParticipants"] = ModelState["firmParticipants"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorPaymentType"] = ModelState["paymentType"].Errors.Count == 0 ? "none" : "inline-block";
                ViewData["errorExtraInfo"] = ModelState["extraInfo"].Errors.Count == 0 ? "none" : "inline-block";
                return View(model);
            }
            else {
                firmPartyGoerService.update(model);
                return RedirectToAction("PartyGoers/" + model.partyRefId);
            }
        }
    }
}