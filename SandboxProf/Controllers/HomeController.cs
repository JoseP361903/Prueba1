using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SandboxProf.Models;
using SandboxProf.Models.DAO;
using SandboxProf.Models.Domain;

namespace SandboxProf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        StudentDAO studentDAO;
        NationalityDAO nationalityDAO;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            //TODO INSTANCIAR UN STUDENTDAO

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllStudents()
        {
            studentDAO = new StudentDAO(_configuration);

            return Ok(studentDAO.Get());
        }

        public IActionResult Insert([FromBody] Student student)
        {
            try
            {
                studentDAO = new StudentDAO(_configuration);
                if (studentDAO.Get(student.Email).Email == null) //the student doesn't exist
                {
                    int result = studentDAO.Insert(student);
                    return Ok(result);
                }
                else
                {
                    return Error();
                }
            }
            catch (SqlException e) 
            {
                //TODO send most meaninful message to the front end for the user seed
                //Se puede retornar una view
                //ViewBag Message = e.message();
                return Error();
            }
            
        }

        public IActionResult GetStudentByEmail(string email)
        {
            studentDAO = new StudentDAO(_configuration);

            return Ok(studentDAO.Get(email));
        }

        //New Controller
        public IActionResult GetStudentByName(string name)
        {
            try
            {
                studentDAO = new StudentDAO(_configuration);
                if (studentDAO.GetStudent(name).Count() != 0) {
                    return Json(studentDAO.GetStudent(name));
                }
                else 
                {
                    return Error();
                }
            }
            catch 
            {
               return Error();
            }
        }

        public IActionResult DeleteStudent(string email)
        {
            try
            {
                studentDAO = new StudentDAO(_configuration);
                studentDAO.Delete(email);
                return Ok();
            }
            catch (Exception e) {
                //todo
                return Error();
            }
        }

        public IActionResult GetNationalities()
        {
            nationalityDAO = new NationalityDAO(_configuration);

            return Json(nationalityDAO.Get());
        }

        public IActionResult UpdateStudent([FromBody] Student student)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            studentDAO = new StudentDAO(_configuration);
            return Ok(studentDAO.Update(student));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
