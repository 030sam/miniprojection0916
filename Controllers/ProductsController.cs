using Microsoft.AspNetCore.Mvc;
using YourApp.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/products
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Products.ToList());
    }

    // POST: api/products
    //[HttpPost]
    //public IActionResult Create([FromBody] Product product)
    //{
    //    if (product == null) return BadRequest();
    //    _context.Products.Add(product);
    //    _context.SaveChanges();
    //    return Ok(product);
    //}
    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        var Productlist = _context.Products.ToList();
        foreach (var item in Productlist)
        {
            if (item.Title == product.Title)
            {
                return BadRequest("Invalid product");
            }
        }
        if (product == null)
            return BadRequest("Invalid product");

        _context.Products.Add(product);
        _context.SaveChanges();

        return Ok(product);
    }

    // PUT: api/products/5
    //[HttpPut("{id}")]
    //public IActionResult Update(int id, [FromBody] Product product)
    //{
    //    var existing = _context.Products.Find(id);
    //    if (existing == null) return NotFound();

    //    existing.User = product.User;
    //    _context.SaveChanges();

    //    return Ok(existing);
    //}

    // DELETE: api/products/5
    //[HttpDelete("{id}")]
    //public IActionResult Delete(int id)
    //{
    //    var product = _context.Products.Find(id);
    //    if (product == null) return NotFound();

    //    _context.Products.Remove(product);
    //    _context.SaveChanges();

    //    return Ok();
    //}
}
