using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public string User { get; set; }
        public List<LogParameter> LogParameters { get; set; }

        public LogDetail()
        {
            LogParameters = new List<LogParameter>();
            MethodName = string.Empty;
            User = string.Empty;
            FullName = string.Empty;
        }

        public LogDetail(string fullName, string methodName, string user, List<LogParameter> logParameters)
        {
            FullName = fullName;
            MethodName = methodName;
            User = user;
            LogParameters = logParameters;
        }
    }
}