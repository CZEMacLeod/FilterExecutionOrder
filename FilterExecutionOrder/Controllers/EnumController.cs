using FilterExecutionOrder.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;

namespace FilterExecutionOrder.Controllers
{

    public class EnumController : ApiController
    {

        [MyTruncatingFilter]
        [HttpGet()]
        [ActionName("array")]
        public IEnumerable<string> Array()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet()]
        [ActionName("arraytrunc")]
        public IEnumerable<string> ArrayTrunc()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet()]
        [ActionName("lazy")]
        public IEnumerable<string> Lazy()
        {
            yield return "value1";
            Thread.Sleep(5000);
            yield return "value2";
        }

        [MyTruncatingFilter]
        [HttpGet()]
        [ActionName("lazytrunc")]
        public IEnumerable<string> LazyTrunc()
        {
            yield return "value1";
            Thread.Sleep(5000);
            yield return "value2";
        }

        [MyTruncatingFilter]
        [HttpGet()]
        [ActionName("lazydata")]
        public IEnumerable<string> LazyData()
        {
            System.Diagnostics.Debug.WriteLine("Middle");
            return GetMyData("value");
        }

        [MyTruncatingFilter]
        [HttpGet()]
        [ActionName("data")]
        public IEnumerable<string> Data()
        {
            System.Diagnostics.Debug.WriteLine("Middle");
            return GetMyData("value").ToList();
        }

        private IEnumerable<string> GetMyData(string prefix)
        {
            System.Diagnostics.Debug.WriteLine("Lazy");
            yield return prefix + "1";
            System.Diagnostics.Debug.WriteLine("Delay");
            Thread.Sleep(5000);
            System.Diagnostics.Debug.WriteLine("More");
            yield return prefix + "2";
            System.Diagnostics.Debug.WriteLine("End");
        }
    }
}
