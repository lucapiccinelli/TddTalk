using System;

namespace BirthdayGreetings.Exceptions
{
    public class ParsingError
    {
        public int LineNumber { get; }
        public ArgumentException Exception { get;  }

        public ParsingError(int lineNumber, ArgumentException exception)
        {
            LineNumber = lineNumber;
            Exception = exception;
        }
    }
}