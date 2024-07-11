using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public abstract class AbstractController : ControllerBase
{
    protected readonly ILogger<AbstractController> _logger;

    protected AbstractController(ILogger<AbstractController> logger)
    {
        _logger = logger;
    }

    protected IActionResult HandleException(Exception ex)
    {
        _logger.LogError(ex, ex.Message);
        return StatusCode(500, $"An unexpected error occurred. Please try again later.\n{ex.Message}");
    }

    protected IActionResult HandleResult<T>(T result) => result is not null ? Ok(result) : NotFound();

    protected IActionResult HandleValidationErrors() => !ModelState.IsValid ? BadRequest(ModelState) : null;
}