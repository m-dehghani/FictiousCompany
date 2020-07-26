using FictiousCompany.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Infrastructure
{
    public class DoneResult
    {
        public DoneResult(ResultType resultType)
            : this(resultType == ResultType.Successful, resultType.ToDescription())
        {
        }

        public DoneResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public DoneResult(ResultType resultType, object data)
        {
            Success = resultType == ResultType.Successful;
            Message = resultType.ToDescription();
            Data = data;
        }

        public DoneResult(ResultType resultType, string message, string exception)
        {
            Success = resultType == ResultType.Successful;
            Message = message;
            Exception = exception;
        }

        public string Exception { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
    }
}
