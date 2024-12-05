namespace Employee.Management.Api.Models.Authentication
{
    public class Response
    {
        // Indicates whether the operation was successful
        public bool IsSuccess { get; set; }

        // Holds any messages related to the operation (e.g., error or success messages)
        public string Message { get; set; }

        // Optional data payload for the response
        public object Data { get; set; }

        // Optional error details for failed operations
        public string ErrorDetails { get; set; }
    }
}
