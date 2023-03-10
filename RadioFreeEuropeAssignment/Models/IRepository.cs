namespace RadioFreeEuropeAssignment.Models
{
    public interface IRepository
    {
        public Status Add(int id, string side, InputData input);
        public Result Diff(int id);
        public Status CheckValidation(int id, InputData input);
    }
}
