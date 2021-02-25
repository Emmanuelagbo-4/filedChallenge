namespace filedChallenge.Models.Response
{
    public class APIResponse<T>
    {
         public string message { get; set; }
#nullable enable
        public object? errors { get; set; }
#nullable disable
        public T data { get; set; }
    }

     public class APIResponse : APIResponse<object> { }
}