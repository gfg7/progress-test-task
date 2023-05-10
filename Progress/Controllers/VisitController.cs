using Microsoft.AspNetCore.Mvc;
using Progress.Interfaces;
using Progress.Models;
using Progress.Services;

namespace Progress.Controllers
{
    [Route("visits")]
    public class VisitController : Controller
    {
        private readonly VisitManagementService _visitManagement;
        private readonly IMBKDictionary _diagnosisService;

        public VisitController(VisitManagementService visitManagement, IMBKDictionary diagnosisService)
        {
            _visitManagement = visitManagement;
            _diagnosisService = diagnosisService;
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult> AddVisit([FromForm] Visit visit)
        {
            if (ModelState.IsValid)
            {
                await _visitManagement.AppointVisit(visit);
                return RedirectToAction(visit.PatientId, "patients");
            }

            return View(nameof(NewVisit), visit);
        }

        [Route("{patientId}")]
        public async Task<IEnumerable<Visit>> GetVisits([FromRoute] string patientId) => await _visitManagement.GetVisits(patientId);

        [Route("{patientId}/new")]
        public ActionResult NewVisit([FromRoute] string patientId, [FromForm] Visit visit = null)
        {
            visit??=new();
            visit.PatientId = patientId;

            return View(nameof(NewVisit), visit);
        }
    }
}