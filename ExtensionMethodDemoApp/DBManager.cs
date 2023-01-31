namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;
 

public static class DBManager {

public static List<Department> GetAllDepartments()
{
    List<Department> departments=new List<Department>();
    //database connectivity Code
    string conString=@"server=127.0.0.1;uid=root;" +  "pwd=password;database=transflower";
    MySqlConnection con=new MySqlConnection(conString);
    string query="SELECT  * FROM  departments ";
    MySqlCommand cmd=new MySqlCommand();
    cmd.Connection=con;
    cmd.CommandText=query;
    con.Open();
    MySqlDataReader reader=cmd.ExecuteReader();
    Console.WriteLine("Records from MySQL database Transflower");
    while(reader.Read())
    {
        int deptId=int.Parse(reader["id"].ToString());
        string name=reader["name"].ToString();
        string location=reader["location"].ToString();
        Department dept=new Department{
            Id=deptId,
            Name=name,
            Location=location
        };
        departments.Add(dept);
    }
    con.Close();
    return departments;
}
    public static Department GetById(int id)
    {
        Department dept=null;
        //database connectivity Code
        string conString=@"server=127.0.0.1;uid=root;" +  "pwd=password;database=transflower";
        MySqlConnection con=new MySqlConnection(conString);
        string query="SELECT  * FROM  departments WHERE id="+id;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        MySqlDataReader reader=cmd.ExecuteReader();
        Console.WriteLine("Records from MySQL database Transflower");
        while(reader.Read())
        {
            int deptId=int.Parse(reader["id"].ToString());
            string name=reader["name"].ToString();
            string location=reader["location"].ToString();
            dept=new Department{
                Id=deptId,
                Name=name,
                Location=location
            };
        
        }
        con.Close();
        return dept;
        }

    public static bool Insert(Department dept){
        bool status=false;
        string conString=@"server=127.0.0.1;uid=root;" +  "pwd=password;database=transflower";
        MySqlConnection con=new MySqlConnection(conString);
        string query="Insert into departments (name, location) values('"+dept.Name+ "','"+ dept.Location+ "')";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record is inserted...");
        status=true;
        con.Close();
        return status;
    }


}