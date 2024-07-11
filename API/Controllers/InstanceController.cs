using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class InstanceController/* : AbstractController*/
{
    /*private readonly ISampleService _sampleService;

    public InstanceController(ISampleService sampleService, ILogger<SampleController> logger) 
        : base(logger)
    {
        _sampleService = sampleService;
    }

    [HttpGet("{id}")]
    public IActionResult GetSample(int id)
    {
        try
        {
            var result = _sampleService.GetSampleById(id);
            return HandleResult(result);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    [HttpPost]
    public IActionResult CreateSample([FromBody] SampleModel model)
    {
        var validationErrorResult = HandleValidationErrors();
        if (validationErrorResult != null)
        {
            return validationErrorResult;
        }

        try
        {
            var createdSample = _sampleService.CreateSample(model);
            return CreatedAtAction(nameof(GetSample), new { id = createdSample.Id }, createdSample);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }*/
}