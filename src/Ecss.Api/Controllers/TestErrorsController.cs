using Asp.Versioning;
using Ecss.Common.Exceptions;
using Ecss.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecss.Api.Controllers;

[ApiVersionNeutral]
public class TestErrorsController : ApiController
{
    private readonly EcssDbContext _dbContext;

    public TestErrorsController(EcssDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetNotFoundRequest()
    {
        throw new NotFoundException("Not found test");
    }

    [HttpGet]
    public IActionResult GetBadRequest()
    {
        throw new BadRequestException("Bad request test");
    }

    [HttpGet]
    public IActionResult GetConflictRequest()
    {
        throw new ConflictException("Conflict request test");
    }

    [HttpGet]
    public IActionResult GetValidationRequest()
    {
        var validationErrors = new List<ValidationError>
        {
            new ValidationError("propertyName1", "Error message 1."),
            new ValidationError("propertyName2", "Error message 2.")
        };
        throw new ValidationException(validationErrors);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAuthErrorRequest()
    {
        return Ok("Authorized");
    }

    [HttpGet]
    public IActionResult GetInternalServerErrorRequest()
    {
        var thing = _dbContext.Products.Find(-1);
        var thingToReturn = thing!.ToString();
        return Ok(thingToReturn);
    }
}
