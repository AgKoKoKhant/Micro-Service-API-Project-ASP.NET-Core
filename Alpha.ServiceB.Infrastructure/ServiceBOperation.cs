using Alpha.ServiceB.Interface;
using Alpha.ServiceB.Model;
using Microsoft.Extensions.Logging;
using Alpha.Shared.Utils.Extensions;

namespace Alpha.ServiceB.Infrastructure
{
    public class ServiceBOperation : IServiceB
    {
        private readonly ILogger<ServiceBOperation> _logger;
        List<TeacherModel> teachers = new List<TeacherModel>();
        List<StudentModel> students = new();

        public ServiceBOperation(ILogger<ServiceBOperation> logger)
        {
            _logger = logger;
            teachers.Add(new TeacherModel()
            {
                name = "Aung Ko Ko Khant",
                age = 31,
                course = "DotNet",
                dob = DateTime.Now,
                gender = "Male"
            });
            students.Add(new StudentModel()
            {
                name = "Eaint Myat Chel",
                age = 31,
                score = "21",
                dob = DateTime.Now,
                gender = "Female"
            });
           
        }
        #region Student Functions
        public List<StudentModel> AddStudentSB(StudentModel student)
        {
            students.Add(new StudentModel()
            {
                name = student.name,
                age = student.age,
                score = student.score,
                dob = DateTime.Now,
                gender = student.gender,
            });
            _logger.InformationLog("Added Student");
            return students;
        }
        public List<StudentModel> GetStudentSB()
        {
            _logger.InformationLog("Started GetStudent");
            return students;
        }
        public StudentModel GetStudentSB(string name)
        {
            _logger.InformationLog("Started GetStudentbyName");
            if (string.IsNullOrEmpty(name))
            {
                _logger.ErrorLog(new ArgumentException("The teacher's name cannot be null or empty.", nameof(name)));
                throw new ArgumentException("The teacher's name cannot be null or empty.", nameof(name));

            }
            return students.FirstOrDefault(x => x.name.StartsWith(name));
        }
        public bool RemoveStudent(string name)
        {
            _logger.WarningLog("Started RemoveStudentbyName");
            students.Remove(students.FirstOrDefault(x => x.name.StartsWith(name)));
            return true;
        }
        #endregion

        #region Teacher Functions
        public List<TeacherModel> AddTeacherSB(TeacherModel teacher)
        {
            teachers.Add(new TeacherModel()
            {
                name = teacher.name,
                age = teacher.age,
                course = teacher.course,
                dob = DateTime.Now,
                gender = teacher.gender,
            });
            _logger.InformationLog("Added Student");
            return teachers;
        }
        public List<TeacherModel> GetTeacherSB()
        {
            _logger.InformationLog("Started GetTeacherSB");
            return teachers;
        }
        //public TeacherModel GetTeacherSB(string name)
        //{
        //    return teachers.FirstOrDefault(x => x.name.StartsWith(name));
        //}
        public TeacherModel GetTeacherSB(string name)
        {
            // Validate the input name
            if (string.IsNullOrEmpty(name))
            {
                _logger.ErrorLog(new ArgumentException("The teacher's name cannot be null or empty.", nameof(name)));
                throw new ArgumentException("The teacher's name cannot be null or empty.", nameof(name));

            }
            // Attempt to find the teacher by name
            return teachers.FirstOrDefault(x => x.name.StartsWith(name, StringComparison.OrdinalIgnoreCase));
        } 
        
    public bool RemoveTeacher(string name)
        {

            teachers.Remove(teachers.FirstOrDefault(x => x.name.StartsWith(name)));
            _logger.WarningLog("Started RemoveStudentbyName");
            return true;
        }
        #endregion
    }
}