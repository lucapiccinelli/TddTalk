using System;
using System.Collections.Generic;

namespace BirthdayGreetings.Exceptions
{
    public class BadFormatException: Exception
    {
        public List<ParsingError> Errors { get; }

        public BadFormatException(List<ParsingError> errors)
        {
            Errors = errors;
        }
    }
}