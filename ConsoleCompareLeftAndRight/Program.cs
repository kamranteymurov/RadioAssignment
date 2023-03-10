using ConsoleCompareLeftAndRight;

namespace MyCLIApp
{
    class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Application compare left and right side of data given by user.");
            UserGuide();
            String input = "";
            List<string> inputList;

            while (!input.Equals("exit"))
            {
                Console.Write("Input: ");
                input = Console.ReadLine().Trim();
                inputList = new List<string>();

                // remove all quates if have any from input
                input = input.Replace("'", string.Empty);
                input = input.Replace("\"", string.Empty);

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Enter correct data");
                    UserGuide();
                    continue;
                }
                // close
                if (input.Equals("exit"))
                {
                    break;
                }
                //adding input string to the list
                if (!string.IsNullOrEmpty(input))
                {
                    int start = 0;
                    int len = input.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (input[i] == ' ')
                        {
                            if (start == 0) // first data
                            {
                                inputList.Add(input.Substring(start, i));
                                start = i + 1;
                            }
                            else if (input[i - 1] != ' ') // if data in middle
                            {
                                inputList.Add(input.Substring(start, i - start).Trim());
                                start = i + 1;
                            }
                        }
                    }
                    inputList.Add(input.Substring(start, len - start).Trim()); // last data
                }

                //checking if input is entered correctly
                if (!(inputList[0].Equals("add") || inputList[0].Equals("diff")))
                {
                    Console.WriteLine(inputList[0] + "is not right command, possible command is add or diff");
                    UserGuide();
                    continue;
                }
                int listCount = inputList.Count;
                if (listCount == 4 && !(inputList[1].Equals("left") || inputList[1].Equals("right")))
                {
                    Console.WriteLine(inputList[1] + "is not right command, possible commands are left and right");
                    UserGuide();
                    continue;
                }
                if (!(listCount == 4 || listCount == 2))
                {
                    Console.WriteLine("Please write correctly the input.");
                    UserGuide();
                    continue;
                }
                bool isNumeric = int.TryParse(inputList[1], out int n); //diff
                if(listCount == 4)
                {
                    isNumeric = int.TryParse(inputList[2], out int m); //add
                }
                if (!isNumeric)
                {
                    Console.WriteLine("Id should be a number");
                    UserGuide();
                    continue;
                }
                
                CallApi api = new CallApi();
                string addResponse;
                ApiResponse apiDiffResponse;
                if(listCount == 4) // call add api (add left 1 test)
                {
                    addResponse = api.AddDataAsync(Int32.Parse(inputList[2]), inputList[1], inputList[3]).Result;
                    Console.WriteLine("Response: " + addResponse);
                }
                else // cal diff with id
                {
                    apiDiffResponse = api.CallGetDiffApi(int.Parse(inputList[1])).Result;
                    if (apiDiffResponse.offset != null)
                    {
                        foreach (Offset offset in apiDiffResponse.offset.ToList())
                        {
                            Console.WriteLine($"Offset: {offset.offset}, Length: {offset.length}");
                        }
                    }
                    else if(apiDiffResponse.result != null)
                    {
                        Console.WriteLine($"Result: {apiDiffResponse.result}");
                    }
                }
            }
            Console.WriteLine("Program closed.");
        }
        public static void UserGuide()
        {
            Console.WriteLine("For adding  left data write: \"add left  'id' 'compare_left_data\'\"");
            Console.WriteLine("For adding right data write: \"add right 'id' 'compare_left_data\'\"");
            Console.WriteLine("Example: add left 1 Test");
            Console.WriteLine("To see the diffrence of result write: diff 'id'");
            Console.WriteLine("To close the program write \"exit\"");
        }

    }
}
