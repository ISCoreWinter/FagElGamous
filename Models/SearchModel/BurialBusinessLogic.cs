using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.SearchModel
{
    public class BurialBusinessLogic
    {
        private fagelgamousContext Context { get; set; }
        public BurialBusinessLogic(fagelgamousContext burialContext)
        {
            Context = burialContext;
        }

        public IQueryable<BurialRecords> GetBurial(BurialSearchModel searchModel, int pageNum = 1, int pageSize = 5)
        {
            var result = Context.BurialRecords.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.BurialId.HasValue)
                {
                    result = result.Where(x => x.BurialId == searchModel.BurialId);
                }
                if (!string.IsNullOrEmpty(searchModel.BurialSubplot))
                {
                    result = result.Where(x => x.BurialSubplot.Contains(searchModel.BurialSubplot));
                }
                if (!string.IsNullOrEmpty(searchModel.BurialNumber))
                {
                    result = result.Where(x => x.BurialNumber.Contains(searchModel.BurialNumber));
                }
                if (!string.IsNullOrEmpty(searchModel.LowPairNs))
                {
                    result = result.Where(x => x.LowPairNs.Contains(searchModel.LowPairNs));
                }
                if (!string.IsNullOrEmpty(searchModel.BurialLocationNs))
                {
                    result = result.Where(x => x.BurialLocationNs.Contains(searchModel.BurialLocationNs));
                }
                if (!string.IsNullOrEmpty(searchModel.BurialLocationEw))
                {
                    result = result.Where(x => x.BurialLocationEw.Contains(searchModel.BurialLocationEw));
                }
                if (searchModel.HighPairNs.HasValue)
                {
                    result = result.Where(x => x.HighPairNs == searchModel.HighPairNs);
                }
                if (searchModel.LowPairEw.HasValue)
                {
                    result = result.Where(x => x.LowPairEw == searchModel.LowPairEw);
                }
                if (searchModel.HighPairEw.HasValue)
                {
                    result = result.Where(x => x.HighPairEw == searchModel.HighPairEw);
                }
                if (searchModel.Area.HasValue)
                {
                    result = result.Where(x => x.Area == searchModel.Area);
                }
            }
            return result;

        }
    }
}