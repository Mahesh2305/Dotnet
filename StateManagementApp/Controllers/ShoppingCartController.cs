using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagementApp.Models;
using System.Text.Json;

namespace StateManagementApp.Controllers;

public class ShoppingCartController : Controller
{
    private readonly ILogger<ShoppingCartController> _logger;

    public ShoppingCartController(ILogger<ShoppingCartController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string?  jsonString=HttpContext.Session.GetString("mycart");
        List<int> items=JsonSerializer.Deserialize<List<int>>(jsonString);
        ViewData["cart"]=items;
        return View();
    }
    
    public IActionResult AddToCart(int id){
        Cart theCart=null;
        if(HttpContext.Session.GetString("mycart") == null)
        {
            theCart=new Cart();  
            theCart.Items.Add(id);
            Console.WriteLine("Product Count "+ theCart.Items.Count);
            string jsonString=JsonSerializer.Serialize(theCart.Items);
            Console.WriteLine(jsonString);
            HttpContext.Session.SetString("mycart",jsonString);

            Console.WriteLine("new session collection creation");  
            Console.WriteLine("session id ="+ HttpContext.Session.Id); 
            
        }
        else{
            string jsonString=HttpContext.Session.GetString("mycart");
            List<int> items=JsonSerializer.Deserialize<List<int>>(jsonString);   
            items.Add(id);
            Console.WriteLine("Product Count "+ items.Count);
            jsonString=JsonSerializer.Serialize(items); 
            HttpContext.Session.SetString("mycart",jsonString);
            Console.WriteLine("Existing session receiving"); 
            Console.WriteLine(jsonString);
        }
        return RedirectToAction("Index","ShoppingCart");
    }

    public IActionResult RemoveFromCart(int id){
       

        return View();
    }

 
}
