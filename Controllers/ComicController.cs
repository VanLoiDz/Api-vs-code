using API_COMIC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_COMIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ComicController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "Select id, comic_name, avatar, id_genre, author, describe, status from Comic";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("COMIC");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Comic comic)
        {
            string query = @"Insert into Comic values
                         (N'" + comic.comic_name + "' " +
                         ", N'" + comic.avatar + "' " + 
                         ", N'" + comic.id_genre + "' " + 
                         ", N'" + comic.author + "' " + 
                         ", N'" + comic.describe + "' " + 
                         ", N'" + comic.status + "' " + 
                         ")";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("COMIC");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm mới thành công");
        }

        [HttpPut]
        public JsonResult Put(Comic comic)
        {
            string query = @"Update Comic set 
                    comic_name = N'" + comic.comic_name + "' "
                  + ", avatar   = N'" + comic.avatar + "' "
                  + ", id_genre   = N'" + comic.id_genre + "' "
                  + ", author   = N'" + comic.author + "' "
                  + ", describe   = N'" + comic.describe + "' "
                  + ", status   = N'" + comic.status + "' "
                   + " where id = " + comic.id;
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("COMIC");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Cập nhật thành công");
        }
        
        [HttpDelete("{ma}")]
        public JsonResult Delete(int ma)
        {
            string query = @"Delete from Comic " + " where id = " + ma;
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("COMIC");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Xoá thành công");
        }

        [Route("GetAllIdGenreName")]
        [HttpGet]
        public JsonResult GetAllIdGenreName()
        {
            string query = "Select id, genre_name from ComicGenre";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("COMIC");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}