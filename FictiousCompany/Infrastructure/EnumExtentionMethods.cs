using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Infrastructure
{
    public static class EnumExtentionMethods
    {
        public static string ToDescription<Enum>(this Enum e)
        {
            string description = string.Empty;

            try
            {
                var memInfo = e.GetType().GetMember(e.GetType().GetEnumName(e));
                var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = (descriptionAttributes.Length > 0) ? ((DescriptionAttribute)descriptionAttributes[0]).Description : e.ToString();
            }
            catch { }

            return description;
        }
    }
}
