using Alpha.ServiceA.Interface;
using Alpha.ServiceA.Model;
using Alpha.Shared.Utils.Extensions;
using Microsoft.Extensions.Logging;

namespace Alpha.ServiceA.Infrastructure
{
    /// <summary>
    /// Service A Implementation Class. Implements the functions defined in IServiceA.
    /// </summary>
    public class ServiceAOperation : IServiceA
    {
        #region CommentSection
        //List<StudentModel> students = new();
        //List<TeacherModel> teachers = new List<TeacherModel>();

        //public ServiceAOperation()
        //{
        //    teachers.Add(new TeacherModel()
        //    {
        //        name = "Aung Ko Ko Khant",
        //        age = 27,
        //        course = "ASP.NET",
        //        dateOfBirth = DateTime.Now,
        //        gender = "Male",
        //    });
        //    students.Add(new StudentModel()
        //    {
        //        name = "Eaint Myat Chel",
        //        age = 25,
        //        score = "DotNet",
        //        dateOfBirth = DateTime.Now,
        //        gender = "Female",
        //    });
        //}
        #endregion

        private readonly ILogger<ServiceAOperation> _logger;
        private readonly AppDbContext _context;
        public ServiceAOperation(AppDbContext context,ILogger<ServiceAOperation> logger)
        {
            _logger = logger;
            _context = context;
        }

        #region Student Funcitons

        public List<StudentModel> AddStudent(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return _context.Students.ToList();
        }
        public List<StudentModel> GetStudents()
        {
            _logger.InformationLog("Started GetStudents");
            _logger.WarningLog("Started GetStudents");
            return _context.Students.ToList(); 
        }
        public StudentModel GetStudent(string name)
        {
            _logger.InformationLog("Started GetStudent"+ name);
            _logger.WarningLog("Started GetStudents" + name);
            return _context.Students.FirstOrDefault(x => x.name.StartsWith(name));
        }

        public bool RemoveStudent(string name)
        {
            var student = _context.Students.FirstOrDefault(x => x.name.StartsWith(name));
            if (student != null)
            {
                _logger.InformationLog("Started GetStudent" + name);
                _logger.WarningLog("Started GetStudents" + name);
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            _logger.ErrorLog(new Exception("Student not found"), "Started GetStudent: " + name);

            return false;
        }
        #endregion


        #region TeacherN Funcitons
        public TeacherModel GetTeacher(string name)
        {
            return _context.Teachers.FirstOrDefault(x => x.name.StartsWith(name));
        }

        public List<TeacherModel> GetTeachers()
        {
            return _context.Teachers.ToList();
        }
        #endregion






    }
}