namespace RadioFreeEuropeAssignment.Models
{
    public class Offset
    {
        public int? offset { get; set; }
        public int length { get; set; }
    }
    public class Result
    {
        public string result { get; set; }
        public List<Offset> offset { get; set; }
    }
}
