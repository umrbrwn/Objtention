namespace Objtention
{
    /// <summary>
    /// A business exception
    /// </summary>
    public class BusinessException : System.Exception
    {
        public BusinessException() : base()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, System.Exception innerException) : base(message, innerException)
        {
        }


    }
}
