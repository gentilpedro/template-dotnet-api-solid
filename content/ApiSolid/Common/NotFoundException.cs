namespace SolidApiTemplate.Common;

public class NotFoundException(string message) : Exception(message)
{
}
