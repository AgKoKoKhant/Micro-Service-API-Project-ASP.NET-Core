using Alpha.ServiceA.Model;

namespace Alpha.ServiceA.Interface

{
    public interface IServiceA
    {

        /// This is for get All Teachers Data.
        /// <returns>Teacher List</returns>
        List<TeacherModel> GetTeachers();
        List<StudentModel> GetStudents();

        /// Get Student data by Name

        /// <param name="name">Student Name (Sample - Thura Aung)</param>
        /// <returns>Get Student info by Name</returns>

        StudentModel GetStudent(string name);
        TeacherModel GetTeacher(string name);

        List<StudentModel> AddStudent(StudentModel student);
        bool RemoveStudent (string name);

    }
}