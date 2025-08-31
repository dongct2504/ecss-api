using Microsoft.AspNetCore.Mvc;

namespace Ecss.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
}
