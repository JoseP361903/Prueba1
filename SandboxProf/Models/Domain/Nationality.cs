namespace SandboxProf.Models.Domain
{
    public class Nationality
    {
        private int id;
        private string name;
        private string code;

        public Nationality()
        {
        }

        public Nationality(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }
    }
}
