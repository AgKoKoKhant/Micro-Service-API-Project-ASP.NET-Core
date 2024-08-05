namespace Alpha.ServiceA.Model
{
    public class ServiceAModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int age { get; set; }

    }

    public class StudentModel : ServiceAModel
    {
        
        public string score { get; set; }
    }
    public class TeacherModel : ServiceAModel
    {
        public string course { get; set; }
    }
}