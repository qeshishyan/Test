namespace Test.CustomModels.ResponseModel
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int Status { get; set; } = 1;
    }
}
