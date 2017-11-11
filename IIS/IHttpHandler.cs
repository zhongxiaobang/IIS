namespace IIS
{
    public interface IHttpHandler
    {
        void ProcessRequest(HttpContext context);
    }
}