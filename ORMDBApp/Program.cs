using BOL;
using BLL;

Console.WriteLine("Hello, World!\n\n\n");

List<Employee> employees=HRManager.GetAll();
foreach(Employee emp in employees){
    Console.WriteLine(emp.FirstName + "  "+ emp.LastName);
}

Employee e1=new Employee{
     Id=89,
     FirstName="Chandra",
     LastName="Sinha",
     Email="chandra.sinha@gmail.com",
     ManagerId=1,
     Address="Patna",
    DeptId=1,
    Password="chandra"
};

Console.WriteLine("After insertion ....");

bool status=HRManager.Insert(e1);
if(status){
     employees=HRManager.GetAll();
    foreach(Employee emp in employees){
        Console.WriteLine(emp.FirstName + "  "+ emp.LastName);
    }
}