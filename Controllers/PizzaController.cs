namespace contossoPizza.Controllers;
using contossoPizza.Models;
using contossoPizza.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) 
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null) return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult Post(Pizza pizza) 
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Pizza pizza) 
    {
        PizzaService.Update(id, pizza);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        PizzaService.Delete(id);
        return NoContent();
    }

}