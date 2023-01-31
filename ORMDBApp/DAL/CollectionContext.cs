namespace DAL;
using BOL;

using Microsoft.EntityFrameworkCore;

public class CollectionContext:DbContext{

    public DbSet<Employee> Employees {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
       string conString=@"server=127.0.0.1;uid=root;" +  "pwd=password;database=transflower";
       optionBuilder.UseMySQL(conString);
    }
}