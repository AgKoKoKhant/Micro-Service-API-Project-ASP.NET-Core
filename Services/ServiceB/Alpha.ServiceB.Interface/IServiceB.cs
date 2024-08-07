using Alpha.ServiceB.Model;

namespace Alpha.ServiceB.Interface
{
    public interface IServiceB
    {

        List<StudentModel> GetStudentSB();
        List<TeacherModel> GetTeacherSB();

        StudentModel GetStudentSB(string name);
        TeacherModel GetTeacherSB(string name);

        List<StudentModel> AddStudentSB(StudentModel student);
        List<TeacherModel> AddTeacherSB(TeacherModel teacher);

        bool RemoveStudent(string name);
        bool RemoveTeacher(string name);


    }
}