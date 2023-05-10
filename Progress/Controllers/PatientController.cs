using System.Xml;
using System.Reflection.Metadata;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Progress.Models;
using Progress.Services;

namespace Progress.Controllers;

[Route("patients")]
public class PatientController : Controller
{
    private readonly ILogger<PatientController> _logger;
    private readonly PatientManagementService _patientManagement;

    public PatientController(ILogger<PatientController> logger,
                             PatientManagementService service)
    {
        _logger = logger;
        _patientManagement = service;
    }

    public async Task<ActionResult> Index(PatientFilter filter = null)
    {
        var patients = await _patientManagement.GetPatients(filter);
        return View((filter,patients));
    }

    [Route("new")]
    public IActionResult NewPatient([FromForm] Patient patient = null) => View(nameof(NewPatient), patient);

    [Route("{patientId}")]
    public async Task<ActionResult> PatientProfile([FromRoute] string patientId)
    {
        var patient = await _patientManagement.GetPatient(patientId);
        return View(nameof(PatientProfile), patient);
    }

    [HttpPost]
    [Route("new")]
    public async Task<ActionResult> AddPatient([FromForm] Patient patient)
    {
        if (ModelState.IsValid)
        {
            var patientId = await _patientManagement.AddPatient(patient);
            return Redirect($"{patientId}");
        }

        return View(nameof(NewPatient), patient);
    }

    [Route("{patientId}/export")]
    public async Task<ActionResult> Export([FromRoute] string patientId)
    {
        var xml = await _patientManagement.ExportXml(patientId);
        var document = new XmlDocument();
        document.LoadXml(xml);

        var stream = new MemoryStream();
        document.Save(stream);

        return File(stream.ToArray(), "application/xml", $"Export_{patientId}.xml", true);
    }

    [Route("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
