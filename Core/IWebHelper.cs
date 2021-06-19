namespace Core
{
    public partial interface IWebHelper
    {
        string ModifyQueryString(string url, string queryStringModification, string anchor);
    }
}
