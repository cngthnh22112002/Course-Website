namespace CourseWebsite.Commons
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }
        public object Details { get; }

        public Error(string code, string message, object details = null)
        {
            Code = code;
            Message = message;
            Details = details;
        }

        public override string ToString()
        {
            return Details == null ? $"{Code}: {Message}" : $"{Code}: {Message} - Details: {Details}";
        }
    }
}
