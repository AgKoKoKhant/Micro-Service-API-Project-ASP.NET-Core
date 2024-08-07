namespace Alpha.ServiceB.Model
{
    public class ServiceBModel
    {
        public string name { get; set; }
        public string gender { get; set; }

        public DateTime dob { get; set; }

        public int age { get; set; }
    }
    public class StudentModel : ServiceBModel
    {
        public string score { get; set; }
    }
    public class TeacherModel : ServiceBModel
    {
        public string course { get; set; }
    }
}