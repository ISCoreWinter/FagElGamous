using FagElGamous.Models.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class DataListViewModel
    {
        public IEnumerable<BurialRecords> records { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public BurialSearchModel burialSearchModel { get; set; }
    }
}
