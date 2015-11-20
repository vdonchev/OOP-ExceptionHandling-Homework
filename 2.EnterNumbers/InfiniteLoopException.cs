namespace _2.EnterNumbers
{
    using System;

    public class InfiniteLoopException : Exception
    {
        public InfiniteLoopException(string msg)
            : base(msg)
        {
        }
    }
}