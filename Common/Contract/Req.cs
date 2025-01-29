
namespace Common.Contract
{
    public abstract class Req
    {
        protected Req()
        {
            Headers = new List<Header>();
            QueryParameters = new QueryParameters();
        }

        public IList<Header> Headers { get; set; }

        public QueryParameters QueryParameters { get; set; }
    }
}
