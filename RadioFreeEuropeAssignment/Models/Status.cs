namespace RadioFreeEuropeAssignment.Models
{
    public class Status
    {
        private Status(string result) { Result = result; }
        public string Result { get; private set; }
        public static Status Success { get { return new Status("Success"); } }
        public static Status Fail { get { return new Status("Fail"); } }
        public static Status IdIsNull { get { return new Status("ID is null"); } }
        public static Status IdNotFound { get { return new Status("ID not found"); } }
        public static Status IdIsNegative { get { return new Status("ID id is negative"); } }
        public static Status LeftDataIsNull { get { return new Status("Left data is null"); } }
        public static Status RightDataIsNull { get { return new Status("Right data is null"); } }
        public static Status LeftAndRightIsEqual { get { return new Status("Inputs were equal"); } }
        public static Status LeftAndRighrIsInDifferentSize { get { return new Status("Inputs are in different size"); } }
        
    }
}
