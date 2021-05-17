using Dapper;
using WebApi_Net5.DTO;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace WebApi_Net5.Helper
{
    public class DbParamHelper
    {
        public static DynamicParameters Generate(object data = null)
        {
            var result = new DynamicParameters();

            if (data != null)
            {
                result.AddDynamicParams(data);
            }

            return result;
        }
    }
}
