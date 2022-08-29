using Microsoft.AspNetCore.Mvc;
using Assignment_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Assignment_4.Exceptionfilterr;


namespace Assignment_4.Controllers
{
    [UserClassExceptionfilter]
    public class UserStoryController : Controller
    {
        
        //logs will not be used here
        
        public static SqlConnection con;
        public static SqlCommand cmd;
            
        [UserClassExceptionfilter]
        [System.Web.Mvc.HandleError(ExceptionType = typeof(SqlException), View = "AnotherError")]
        public IActionResult ShowData()
        {
                con = getcon();
                cmd = new SqlCommand("select * from dbo.User_Story", con);
                // cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                List<UserStory> model = new List<UserStory>();
                while (dr.Read())
                {
                    UserStory details = new UserStory();
                    details.UserStoryName = dr["UserStoryName"].ToString();
                    details.UserStoryId = Convert.ToInt32(dr["UserStoryId"]);
                    details.StoryPoints = Convert.ToInt32(dr["StoryPoints"]);
                    details.StoryOwner = dr["StoryOwner"].ToString();
                    details.StoryDescription = dr["StoryDescription"].ToString();
                    model.Add(details);
                }
           
                return View(model);
            
   
                }
            
            private static SqlConnection getcon()
            {
            con = new SqlConnection(@"Data Source=BYODHSQ5DX2\MSSQLSERVERNEW;Initial Catalog=db;Integrated Security=true");
                con.Open();
                return con;
            }
        }
}
