using FictiousCompany.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Infrastructure
{
    public sealed class Common
    {
        private static Common _instance;
        public static Common Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Common();

                return _instance;
            }
        }
        public DoneResult GetExceptionResult(Exception ex)
        {
            return new DoneResult(ResultType.Error, ResultType.Error.ToDescription(), GetFullErrorMessage(ex));
        }
        public string GetFullErrorMessage(Exception ex) => $"Message: {ex.Message}, " +
           $"StackTrace: {ex.StackTrace}, " +
           $"HelpLink: {ex.HelpLink}, " +
           $"Source: {ex.Source}, " +
           $"InnerExceptionMessage: {ex.InnerException?.Message}";


    }
}
