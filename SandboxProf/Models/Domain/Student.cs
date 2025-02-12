namespace SandboxProf.Models.Domain
{
    public class Student
    {
        private int id;
        private string name;
        private string email;
        private string password;
        private Nationality nationality;

        public Student(int id, string name, string email, string password, Nationality nationality)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Nationality = nationality;
        }

        public Student()
        {

        }

        //Propiedades
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public Nationality Nationality { get => nationality; set => nationality = value; }
        public int Id { get => id; set => id = value; }
    }
}
