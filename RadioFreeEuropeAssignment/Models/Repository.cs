using System;

namespace RadioFreeEuropeAssignment.Models
{
    public class Repository : IRepository
    {
        public Dictionary<int, (string left, string right)> input = new Dictionary<int, (string left, string right)>();
        public Status Add(int id, string side, InputData newData)
        {
            //if Id not exsist add new with null data
            if (!input.ContainsKey(id))
            {
                input.Add(id, (null, null));
            }
            if (side == "left")
            {
                input[id] = (newData.Input, input[id].right);
            }
            else
            {
                input[id] = (input[id].left, newData.Input);
            }
            return Status.Success;
        }
        /* 1. Return if it is equal
         * 2. Return if size is differnt
         * 3. find diffs of offsets, lens
         */
        public Result Diff(int id)
        {
            // Handle not found and null cases 
            if (!input.ContainsKey(id))
            {
                return new Result { result = Status.IdNotFound.Result };
            }
            if (input[id].left == null)
            {
                return new Result { result = Status.LeftDataIsNull.Result };
            }
            if (input[id].right == null)
            {
                return new Result { result = Status.RightDataIsNull.Result };
            }
            // taking all left and right datas and lens
            string left = input[id].left;
            string right = input[id].right;
            int leftLen = left.Length;
            int rightLen = right.Length;

            //left and right is equal
            if (left.Equals(right))
            {
                return new Result { result = Status.LeftAndRightIsEqual.Result };
            }

            //left and right is in diff size
            if (leftLen != rightLen)
            {
                return new Result { result = Status.LeftAndRighrIsInDifferentSize.Result };
            }

            //Find offsets and lengths of diff
            List<Offset> offset = new List<Offset>();
            int temp = 0;
            for (int i = 0; i < leftLen; i++)
            {
                if (temp > 0 && left[i] == right[i])
                {
                    offset.Add(new Offset { offset = temp, length = i - temp + 1 });
                    temp = 0;
                }
                else if (temp == 0 && left[i] != right[i])
                {
                    temp = i + 1;
                }
            }
            if (temp > 0) offset.Add(new Offset { offset = temp, length = leftLen - temp + 1 });

            return new Result { offset = offset, result = Status.Success.Result };
        }
        public Status CheckValidation(int id, InputData newData)
        {
            //check if id is negative
            if (id < 0)
            {
                return Status.IdIsNegative;
            }

            //Add new validations here

            return Status.Success;
        }
    }
}
