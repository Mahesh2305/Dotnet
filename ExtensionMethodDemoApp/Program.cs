using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

using BOL;
using DAL;
using Maths;
using Utility;
MathEngine calc=new MathEngine();
int number1=34;
int number2=4;
calc.Addition(number1,number2);
Console.WriteLine(calc.Result);
 calc.Subtraction(number1,number2);
Console.WriteLine(calc.Result);

calc.Multiplication(number1, number2);
Console.WriteLine(calc.Result);
calc.Division(number1,number2);
Console.WriteLine(calc.Result);

List<Product> allProducts=new List<Product>();

    allProducts.Add(new Product { ProductId = 2, Title = "Rose", Description = "Valentine Flower", UnitPrice = 15, Category = "Flower", Balance = 7000 });
    allProducts.Add(new Product { ProductId = 3, Title = "Lotus", Description = "Worship Flower", UnitPrice = 26, Category = "Flower", Balance = 3400 });
    allProducts.Add(new Product { ProductId = 4, Title = "Carnation", Description = "Pink carnations signify a mother's love, red is for admiration and white for good luck", UnitPrice = 16, Category = "Flower", Balance = 27000 });
    allProducts.Add(new Product { ProductId = 5, Title = "Lily", Description = "Lilies are among the most popular flowers in the U.S.", UnitPrice = 6, Category = "Flower", Balance = 1000 });
    allProducts.Add(new Product { ProductId = 6, Title = "Jasmine", Description = "Jasmine is a genus of shrubs and vines in the olive family", UnitPrice = 26, Category = "Flower", Balance = 2000 });
    allProducts.Add(new Product { ProductId = 7, Title = "Daisy", Description = "Give a gift of these cheerful flowers as a symbol of your loyalty and pure intentions.", UnitPrice = 36, Category = "Flower", Balance = 159 });
    allProducts.Add(new Product { ProductId = 8, Title = "Aster", Description = "Asters are the September birth flower and the the 20th wedding anniversary flower.", UnitPrice = 16, Category = "Flower", Balance = 67 });
    allProducts.Add(new Product { ProductId = 9, Title = "Daffodil", Description = "Wedding Flower", UnitPrice = 6, Category = "Flower", Balance = 5000 });
    allProducts.Add(new Product { ProductId = 10, Title = "Dahlia", Description = "Dahlias are a popular and glamorous summer flower.", UnitPrice = 7, Category = "Flower", Balance = 0 });
    allProducts.Add(new Product { ProductId = 11, Title = "Hydrangea", Description = "Hydrangea is the fourth wedding anniversary flower", UnitPrice = 12, Category = "Flower", Balance = 0 });
    allProducts.Add(new Product { ProductId = 12, Title = "Orchid", Description = "Orchids are exotic and beautiful, making a perfect bouquet for anyone in your life.", UnitPrice = 10, Category = "Flower", Balance = 700 });
    allProducts.Add(new Product { ProductId = 13, Title = "Statice", Description = "Surprise them with this fresh, fabulous array of Statice flowers", UnitPrice = 16, Category = "Flower", Balance = 1500 });
    allProducts.Add(new Product { ProductId = 14, Title = "Sunflower", Description = "Sunflowers express your pure love.", UnitPrice = 8, Category = "Flower", Balance = 2300 });
    allProducts.Add(new Product { ProductId = 15, Title = "Tulip", Description = "Tulips are the quintessential spring flower and available from January to June.", UnitPrice = 17, Category = "Flower", Balance = 10000 });

   /* foreach ( Product p in allProducts)
    {
        if(p.ProductId==6){
            Console.WriteLine(p.Title + " "+ p.Description + p.UnitPrice);
        }
    }
*/
var products=from product in allProducts  where product.ProductId==6  select product;
Product p=products.First<Product>();
Console.WriteLine(p.Title + " "+ p.Description + p.UnitPrice);
    

var outOfStockProducts=from product in allProducts
                       where product.Balance ==0
                       orderby product.UnitPrice descending
                       select product;

Console.WriteLine("OutofStock Products :");
List<Product> outOfStockProductsList=outOfStockProducts.ToList();
foreach( Product currentProduct in outOfStockProducts){
  Console.WriteLine(currentProduct.Title + "  "+ currentProduct.Description +"  " + currentProduct.UnitPrice+ " Stock="+currentProduct.Balance);  
}

///////////////////////////////////////////////////////////////////////////////////////////////


Department deptNew=new Department{ Name="Research", Location="Pune"};
bool status=DBManager.Insert(deptNew);


List<Department> allDepartments=DBManager.GetAllDepartments();
foreach( Department dept in allDepartments){
    Console.WriteLine(dept.Id + " "+ dept.Name + " "+ dept.Location);
}


Console.WriteLine("Found Department is.......");

Department theDept=DBManager.GetById(2);
 Console.WriteLine(theDept.Id + " "+ theDept.Name + " "+ theDept.Location);


Console.WriteLine("\nData Access using disconnected....");

 List<Department> allDeptDis=DBManagerDisconnected.GetAllDepartments();
 foreach( Department dept in allDeptDis){
    Console.WriteLine(dept.Id + " "+ dept.Name + " "+ dept.Location);
}
