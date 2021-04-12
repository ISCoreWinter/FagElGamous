using FagElGamous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public interface IGamousRepository
    {
        IQueryable<BurialRecords> BurialRecords { get; }

        IQueryable<BodyMeasurements> BodyMeasurements { get; }
        IQueryable<MainEntries> MainEntries { get; }
}
}
