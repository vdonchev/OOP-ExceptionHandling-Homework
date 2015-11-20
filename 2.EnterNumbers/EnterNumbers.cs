namespace _2.EnterNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnterNumbers
    {
        private const int Count = 10;
        private const int StartNum = 1;
        private const int EndNum = 100;

        private static List<int> nums;

        public static void Main(string[] args)
        {
            nums = new List<int>();
            while (nums.Count < Count)
            {
                try
                {
                    nums.Add(!nums.Any() ? ReadNumber(StartNum, EndNum) : ReadNumber(nums[nums.Count - 1], EndNum));
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine(MessageConstants.NotANumber);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Error.WriteLine(MessageConstants.NumberOutOfRange, StartNum + 1, EndNum - 1);
                }
                catch (OverflowException)
                {
                    Console.Error.WriteLine(MessageConstants.NumberOverflow);
                }
                catch (InfiniteLoopException)
                {
                    Console.Error.WriteLine(MessageConstants.FatalError, Count);
                    return;
                }
            }

            Console.WriteLine(MessageConstants.Success, string.Join(", ", nums));
        }

        private static int ReadNumber(int start, int end)
        {
            Console.Write(MessageConstants.InsertNum, start + 1, end - 1);
            int num = int.Parse(Console.ReadLine());

            if (num >= end || num <= start)
            {
                throw new ArgumentOutOfRangeException(string.Format(MessageConstants.NumberOutOfRange, start + 1, end - 1));
            }

            if (end - num < Count - nums.Count)
            {
                throw new InfiniteLoopException(string.Format(MessageConstants.FatalError, Count));
            }

            return num;
        }
    }
}