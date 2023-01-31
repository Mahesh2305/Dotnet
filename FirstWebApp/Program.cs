
using System.Collections.Generic;
using BOL;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/aboutus",()=>"Transflower Learning Pvt. Ltd.");
app.MapGet("/contact",()=>"ravi.tambade@transflower.in");

List<Product> products=new List<Product> ();
products.Add(new Product{ Id=1, Title="Gerbera", Description="Wedding Flower", UnitPrice=5, Quantity=78000});
products.Add(new Product{ Id=2, Title="Rose", Description="Valentine Flower", UnitPrice=15, Quantity=56000});
products.Add(new Product{ Id=3, Title="Lotus", Description="Worship Flower", UnitPrice=25, Quantity=7600});
products.Add(new Product{ Id=4, Title="Jasmine", Description="Fregrance Flower", UnitPrice=2, Quantity=9000});


app.MapGet("/api/products",()=>products);
app.MapGet("/api/products/{id}",()=>new Product{ Id=67, Title="Jasmine", Description="Fregrance Flower", UnitPrice=2, Quantity=9000});


app.MapGet("/api/employees",()=>{
    List<Employee> employees=new List<Employee>();
    employees.Add(new Employee{Id=1, FirstName="Rajiv", LastName="Kulkarni"});
    employees.Add(new Employee{Id=2, FirstName="Meenal", LastName="Patil"});
    employees.Add(new Employee{Id=3, FirstName="Sameer", LastName="Kumar"});
    return Results.Ok(employees);
});

app.MapGet("/api/employees/{id}",(int id) =>
    {
    bool status=true; 
    var emp=new Employee{ Id=id, FirstName="Ravi", LastName="Tambade"};
    if(status){
        return Results.Ok(emp);
    }      
    return Results.NotFound();
});

app.MapPost("/api/employees",(Employee emp) =>
{
    List<Employee> employees=new List<Employee>();
    employees.Add(emp);
    return Results.Created($"/employees/{emp.Id}", emp);
});

app.MapPut("/api/employees/{id}",   (int id, Employee emp) =>
{
    var existingEmp =  new Employee{ Id=id, FirstName="Ravi", LastName="Tambade"};  ;
    if (existingEmp is null) return Results.NotFound();
    existingEmp.FirstName = emp.FirstName;
    existingEmp.LastName = emp.LastName;
    return Results.NoContent();
});

app.MapDelete("/api/employees/{id}",   (int id) =>
{
    bool status= false;
    if (status){
        return Results.Ok();
    }
     return Results.NotFound();
});


app.MapPost("/api/login", (Claim credential)=>{
    if(credential.Email =="ravi.tambade@transflower.in" 
       && credential.Password =="seed123"){
            return Results.Ok("Valid User");
       }
       else{
            return Results.NotFound();
       }
});


app.MapPost("/api/register",( Customer cust)=>{
   Console.WriteLine(cust);
});

app.Run();
