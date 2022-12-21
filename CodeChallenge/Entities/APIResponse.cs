namespace CodeChallenge.Api.Entities
{
    public class APIResponse
    {
        public APIResponse(string message, object? data, bool error)
        {
            Error = error;
            Data= data;
            Message= message;
        }
        public APIResponse()
        {

        }

        public string? Message { get; set; }
        public bool Error { get; set; }
        public object? Data { get; set; }
    }
}
