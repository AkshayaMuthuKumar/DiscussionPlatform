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
    public class AnswerController : ApiController
    {
        // GET api/<controller>
        //declare sql connection and command objects here
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;

        public IEnumerable<Answer> Get()
        {
            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            DataTable _dt = new DataTable();
            var query = "select * from Answer";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Answer> answers = new List<Models.Answer>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow answerrecord in _dt.Rows)
                {
                    answers.Add(new ReadAnswer(answerrecord));
                }
            }

            return answers;
        }

        // GET api/<controller>/5

        public IEnumerable<Answer> Get(int id)
        {
            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb; user id=sa; password=pass@word1;");
            DataTable _dt = new DataTable();
            var query = "select * from Answer where id=" + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Answer> answers = new List<Models.Answer>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow answerrecord in _dt.Rows)
                {
                    answers.Add(new ReadAnswer(answerrecord));
                }
            }

            return answers;

        }

        // POST api/<controller>
        public string Post([FromBody]createAnswer value)
        {
            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            var query = "insert into Answer(answer)values(@answer)";
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@answer", value.answer);

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
        public string Put(int id, [FromBody]createAnswer value)
        {

            _conn = new SqlConnection("data source=DESKTOP-O1N3VSU ; Initial catalog=qadb ; user id=sa; password=pass@word1;");
            var query = " update Answer set question=@question where id=" + id;
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@answer", value.answer);

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
            var query = "delete from Answer where id=" + id;
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


