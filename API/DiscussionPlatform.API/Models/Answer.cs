using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DiscussionPlatform.API.Models
{
    public class Answer
    {
        public string id { get; set; }

        public string answer { get; set; }
    }
    public class createAnswer : Answer
    {
    }
    public class ReadAnswer : Answer
    {
        public ReadAnswer(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            answer = row["answer"].ToString();

        }
        public int Id { get; set; }

        public string  Answer { get; set; }
    }
}
