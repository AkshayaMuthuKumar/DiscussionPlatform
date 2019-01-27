using DiscussionPlatform.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiscussionPlatform.API.Controllers
{
    public class QuestionController : ApiController
    {
        // GET api/<controller>
        //declare sql connection and command objects here
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;

        public IEnumerable<Question> Get()
        {
            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            DataTable _dt = new DataTable();
            var query = "select * from Question";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Question> questions = new List<Models.Question>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow questionrecord in _dt.Rows)
                {
                   questions.Add(new ReadQuestion(questionrecord));
                }
            }

            return questions;
        }

        // GET api/<controller>/5

        public IEnumerable<Question> Get(int id)
        {
            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb; user id=sa; password=pass@word1;");
            DataTable _dt = new DataTable();
            var query = "select * from Question where id=" + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Question> questions = new List<Models.Question>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow questionrecord in _dt.Rows)
                {
                    questions.Add(new ReadQuestion(questionrecord));
                }
            }

            return questions;

        }

        // POST api/<controller>
        public string Post([FromBody]createQuestion value)
        {
            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            var query = "insert into Question(question)values(@question)";
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@question", value.question);
            
            _conn.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";

            }
            else
            {
                return "false";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody]createQuestion value)
        {

            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            var query = " update Question set question=@question where id=" + id;
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@question", value.question);
            
            _conn.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";

            }
            else
            {
                return "false";
            }

        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {

            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            var query = "delete from Question where id=" + id;
            SqlCommand insertcommand = new SqlCommand(query, _conn);

            _conn.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";

            }
            else
            {
                return "false";
            }
        }
    }
}


