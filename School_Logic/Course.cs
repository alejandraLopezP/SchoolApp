using School_Logic.Infrastructure;

namespace School_Logic
{
    public class Course : INameable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public override string ToString()
        {
            return $"{Id} ; {Code} ; {Name} ; {Point}";
        }
    }
}
