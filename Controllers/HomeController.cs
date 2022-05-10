using Microsoft.AspNetCore.Mvc;
using smsproject.Models;
using System.Data.SqlClient;

using System.Data;

namespace smsproject.Controllers;

public class HomeController : Controller
{
        public IActionResult Index()
        {  
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult UserTemplate()
        {
            return View();
        }
        public IActionResult AdminTemplate()
        {
            return View();
        }
        public IActionResult Preview()
        {
            return View();
        }

   

    //To add Records into database    

  [HttpPost]
    public int Index(LoginModel obj)    
    {    
        int loginCode = 0;  
        int res = 0;
        string connectionString = "Integrated Security=False;Persist Security Info=False;Server=CLAP2589\\SQLEXPRESS;Database=task;User Id=Dev_User;Password=m@dhummitha21;";  
        try{
            string countQuery = $"select count(*) from EmpDB where Email='{obj.Email}' and Password='{obj.Password}'";
            string dataQuery = $"select Email, Role from EmpDB where Email='{obj.Email}' and Password='{obj.Password}'";
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cq = new SqlCommand(countQuery, con);    
                cq.CommandType = CommandType.Text;         
                con.Open();    
                res = Convert.ToInt32(cq.ExecuteScalar());  
                if(res>0){

                    SqlCommand dq = new SqlCommand(dataQuery, con);
                    SqlDataReader dataReader = dq.ExecuteReader();
                    while(dataReader.Read()){
                        
                        string role = Convert.ToString(dataReader.GetValue(1));
                        if(role == "user"){
                            loginCode = 1;
                        }
                        else if(role == "admin"){
                            loginCode = 2;
                        }                      
                    }
                }     
                con.Close();    
            }
        }catch(Exception ex){
            Console.Write(ex.Message);
            throw ex;
        }  
    return loginCode; 
    } 

    [HttpPost]
    public int Register(RegisterModel obj)    
    {      
        int registerCode = 0;
        string connectionString = "Integrated Security=False;Persist Security Info=False;Server=CLAP2589\\SQLEXPRESS;Database=task;User Id=Dev_User;Password=m@dhummitha21;";  
        try{
            using (SqlConnection con = new SqlConnection(connectionString)){    
            SqlCommand com = new SqlCommand("AddEmp2", con);    
            com.CommandType = CommandType.StoredProcedure;      
            com.Parameters.AddWithValue("Username", obj.UserName);
            com.Parameters.AddWithValue("Password", obj.Password);
            com.Parameters.AddWithValue("Email", obj.Email);        
            com.Parameters.AddWithValue("Role", obj.Role);        
            
            con.Open();    
            com.ExecuteNonQuery();    
            con.Close(); 
            }
            registerCode = 1;
        }
        catch(Exception ex){
         Console.Write(ex.Message);
         //throw ex;
        }  
    return registerCode;  
    }

    [HttpPost]
    public int Send(MsgModel obj)    
    {      
        int registerCode = 0;
        string connectionString = "Integrated Security=False;Persist Security Info=False;Server=CLAP2589\\SQLEXPRESS;Database=task;User Id=Dev_User;Password=m@dhummitha21;";  
        try{
            using (SqlConnection con = new SqlConnection(connectionString)){    
            SqlCommand com = new SqlCommand("SaveMsg", con);    
            com.CommandType = CommandType.StoredProcedure;      
            com.Parameters.AddWithValue("ToEmail", obj.toEmail);
            com.Parameters.AddWithValue("Message", obj.message);
            com.Parameters.AddWithValue("SentTime", obj.sentTime);        
            com.Parameters.AddWithValue("FromEmail", obj.fromEmail);        
            
            con.Open();    
            com.ExecuteNonQuery();    
            con.Close(); 
            }
            registerCode = 1;
        }
        catch(Exception ex){
         Console.Write(ex.Message);
         //throw ex;
        }  
    return registerCode;  
    }


}