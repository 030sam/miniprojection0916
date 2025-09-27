using Microsoft.AspNetCore.Mvc;
using YourApp.Models;

public class ReacterController : Controller
{
    private readonly ReacterDbContext ReacterContext;

    public ReacterController(ReacterDbContext context)
    {
        ReacterContext = context;
    }


    [HttpPost]
    public IActionResult Create([FromBody] Reacter reacter)
    {
        if (reacter == null)
            return BadRequest("Invalid reacter");
        ReacterContext.Reacters.Add(reacter);
        ReacterContext.SaveChanges();
        return Ok(reacter);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(ReacterContext.Reacters.ToList());
    }

}
