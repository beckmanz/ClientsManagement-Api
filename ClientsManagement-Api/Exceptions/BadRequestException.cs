namespace ClientsManagement_Api.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message){}
}