using Microsoft.AspNetCore.Mvc;
using WorkHub.Data;

namespace WorkHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var databaseConnected = await db.Database.CanConnectAsync(cancellationToken);

        return Ok(new
        {
            status = "ok",
            database = databaseConnected ? "connected" : "unreachable",
            timestamp = DateTime.UtcNow
        });
    }
}
