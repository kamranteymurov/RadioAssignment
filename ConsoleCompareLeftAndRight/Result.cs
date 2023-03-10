using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCompareLeftAndRight
{
    public class Result
    {
        public string Input { get; set; }
    }
    public class ApiResponse
    {
        public string result { get; set; }
        public List<Offset> offset { get; set; }
    }

    public class Offset
    {
        public int offset { get; set; }
        public int length { get; set; }
    }
}
