namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;
 

public static class DBManagerDisconnected {

    public static List<Department> GetAllDepartments()
    {

    //1.Create empty List
    List<Department> departments=new List<Department>();
    
    //2.set connection string
    string conString=@"server=127.0.0.1;uid=root;" +  "pwd=password;database=transflower";
    
    //3.Create connection
    MySqlConnection con=new MySqlConnection(conString);

    //4.Create command object

    //string query="SELECT  * FROM  departments ;SELECT * FROM employees; SELECT * FROM roles";
    string query="SELECT  * FROM  departments ";
    //string query="GetAllDepartments"; //name of stored procedure
    MySqlCommand cmd=new MySqlCommand();
    cmd.Connection=con;
    cmd.CommandText=query;
    //cmd.CommandType=CommandType.StoredProcedure;

    //5.Access data using disconnected way
    MySqlDataAdapter da=new MySqlDataAdapter(cmd);

    //6.Create empty data
    DataSet ds=new DataSet();

    //7. fill data from backend with the help of data adapter
    da.Fill(ds);
    DataTable dt=ds.Tables[0];
    DataRowCollection rows=dt.Rows;
    foreach( DataRow row in rows)
    {
        int deptId=int.Parse(row["id"].ToString());
        string name=row["name"].ToString();
        string location=row["location"].ToString();
    
        Department dept=new Department{
            Id=deptId,
            Name=name,
            Location=location
        };
        departments.Add(dept);
    }
    return departments;
}
    

    public static bool Insert(Department dept)
    {
        bool status= false;
        List<Department> departments=new List<Department>();
        string conString=@"server=127.0.0.1;uid=root;" +  "pwd=password;database=transflower";
        MySqlConnection con=new MySqlConnection(conString);
        string query="SELECT  * FROM  departments ";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        MySqlDataAdapter da=new MySqlDataAdapter(cmd);
        MySqlCommandBuilder cmdBuilider=new MySqlCommandBuilder(da);
        DataSet ds=new DataSet();
        da.Fill(ds);
        DataTable dt=ds.Tables[0];
        DataRowCollection rows=dt.Rows;  
        DataRow theRow=dt.NewRow();;
        theRow["name"]="Sales";
        theRow["location"]="Nagpur";
        rows.Add(theRow);
        da.Update(ds);
       return status;

    }
}