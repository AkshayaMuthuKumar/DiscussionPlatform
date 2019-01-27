using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DiscussionPlatform.API.Models
{
    public class Question
    {
        public string id { get; set; }
      
        public string question { get; set; }
    }
    public class createQuestion : Question
    {
    }
    public class ReadQuestion : Question
    {
        public ReadQuestion(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            question = row["question"].ToString();
           
        }
        public int Id { get; set; }
     
        public string Question { get; set; }
    }
}
