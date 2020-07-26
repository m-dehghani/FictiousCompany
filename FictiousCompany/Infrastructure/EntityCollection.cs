using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Infrastructure
{
    
        public sealed class EntityCollection<T>
        {
            public EntityCollection(List<T> entities, int take, int currentPage, int count)
            {
                Data = entities;
                Take = take;
                CurrentPage = currentPage;
                CountItems = count;
            }

            public int CountItems { get; }
            public int CurrentPage { get; }
            public List<T> Data { get; }
            public bool LastPage => CurrentPage * Take >= CountItems;
            public int Take { get; }

            public int TotalPages
            {
                get
                {
                    int pageCounts = CountItems / Take;
                    int remaining = CountItems % Take;

                    if (remaining > 0)
                        pageCounts++;

                    if (pageCounts == 0)
                        pageCounts = 1;

                    return pageCounts;
                }
            }
        }

        public sealed class CollectionRequest
        {
            public CollectionRequest()
            {
                Take = 5;
                PageNumber = 1;
                SortField = string.Empty;
                SortOrder = SortOrderType.None;
            }

            public int Take { get; set; }
            public int PageNumber { get; set; }
            public SortOrderType SortOrder { get; set; }
            public string SortField { get; set; }
        }
    
}
