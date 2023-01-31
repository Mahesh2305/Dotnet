using BOL;
using DAL;
namespace BLL;
public static class HRManager{

public static List<Employee> GetAll(){
    CollectionContext ctx=new CollectionContext();
    var employees=from emp in ctx.Employees select emp;
    return employees.ToList<Employee>();
}

public static bool Insert(Employee emp){

    bool  status=false;
    CollectionContext ctx=new CollectionContext();
    ctx.Employees.Add(emp);
    ctx.SaveChanges();
    status=true;
    return status;
}

public static bool Delete(Employee emp){
    bool  status=false;
    CollectionContext ctx=new CollectionContext();
    ctx.Employees.Remove(emp);
    ctx.SaveChanges();
    status=true;
    return status;
}

public static bool Update(Employee emp){
    bool  status=false;
    CollectionContext ctx=new CollectionContext();
    ctx.Employees.Update(emp);
    ctx.SaveChanges();
    status=true;
    return status;

}

}