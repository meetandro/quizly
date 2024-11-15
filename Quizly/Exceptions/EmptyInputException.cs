namespace Quizly.Exceptions;

public class EmptyInputException : Exception
{
    public EmptyInputException() { }

    public EmptyInputException(string message) : base(message) { }

    public EmptyInputException(string message, Exception inner) : base(message, inner) { }
}