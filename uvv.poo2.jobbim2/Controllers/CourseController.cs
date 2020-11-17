using System;
using ajj.Dtos;
using ajj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ajj.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase {
        private readonly ConnectionStrings _strings;

        public CourseController(ConnectionStrings strings) {
            _strings = strings;
        }

        [HttpGet("{id}")]
        public ActionResult<Course> Get(long id) {
            using var connection = CreateConnection();

            const string QUERY = "SELECT * FROM courses WHERE id = @id";
            var command = new SqlCommand(QUERY, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows) {
                while (reader.Read()) {
                    return new Course {
                        Id = reader.GetInt64(0),
                        Name = reader.GetString(1),
                        Program = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Workload = reader.GetInt32(3),
                    };
                }
            }

            return NotFound();
        }

        [HttpPost]
        public void Create([FromBody] CourseDto dto) {
            using var connection = CreateConnection();

            const string QUERY =
                "INSERT INTO courses (name, program, workload) VALUES (@name, @program, @workload)";

            var command = new SqlCommand(QUERY, connection);
            command.Parameters.AddWithValue("@name", dto.Name);
            command.Parameters.AddWithValue("@program", dto.Program);
            command.Parameters.AddWithValue("@workload", dto.Workload);

            try {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read()) { }

                reader.Close();
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        [HttpPost("{id}")]
        public void Update(long id, [FromBody] CourseDto dto) {
            using var connection = CreateConnection();

            const string QUERY = @"UPDATE courses
                                    SET Name = @name,
                                    Program = @program,
                                    Workload = @workload
                                    WHERE id = @id
";
            var command = new SqlCommand(QUERY, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", dto.Name);
            command.Parameters.AddWithValue("@program", dto.Program);
            command.Parameters.AddWithValue("@workload", dto.Workload);

            connection.Open();
            using var reader = command.ExecuteReader();
        }

        [HttpDelete("{id}")]
        public void Delete(long id) {
            using var connection = CreateConnection();

            const string QUERY = "DELETE FROM courses WHERE id = @id";
            var command = new SqlCommand(QUERY, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();
        }

        private SqlConnection CreateConnection() {
            return new SqlConnection(_strings.Default);
        }
    }
}
