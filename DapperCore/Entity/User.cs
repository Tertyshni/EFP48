namespace EFP48.DapperCore.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        public List<Post> Posts { get; set; }
        public override string ToString()
        {
            return $@"
--------------------------------
UserID: {Id}
Name -> {Name}
Surname -> {Surname}
Age -> {Age}
--------------------------------
";
        }
    }
}
