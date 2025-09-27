using Microsoft.AspNetCore.Mvc;
using YourApp.Models;

public class UsersController : Controller
{
    private readonly UserDbContext _context;

    public UsersController(UserDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }
    [HttpPost]
    public IActionResult Login([FromBody] User user)
    {
        var userList = _context.User.ToList();
        foreach (var item in userList)
        {
            if (item.Email == user.Email && item.Password == user.Password)
            {
                Cookie(user);
                return Ok("Login successful");
            }
        }
        return BadRequest("Invalid credentials");
    }
    //[HttpPost]
    public IActionResult Cookie([FromBody] User loginUser)
    {
        var user = _context.User
            .FirstOrDefault(u => u.Email == loginUser.Email && u.Password == loginUser.Password);

        if (user != null)
        {
            // ✅ set cookie with userId
            Response.Cookies.Append("UserId", user.Id.ToString(), new CookieOptions
            {
                HttpOnly = false,
                SameSite = SameSiteMode.Strict
            });

            return Json(new { success = true, username = user.Name });
        }

        return Json(new { success = false, message = "Invalid login" });
    }

    [HttpGet]
    public IActionResult GetUserInfo()
    {
        if (Request.Cookies.TryGetValue("UserId", out var userIdStr) && int.TryParse(userIdStr, out var userId))
        {
            var user = _context.User.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return Json(new { success = true , id = user.Id, name = user.Name , passowrd = user.Password, school = user.School , email = user.Email });
            }
        }
        return Json(new { success = false });
    }

    [HttpPost]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("UserId");
        return Ok(new { success = true });
    }
}
