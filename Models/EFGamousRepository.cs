using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class EFGamousRepository : IGamousRepository
    {
        private fagelgamousContext _context;
        public EFGamousRepository(fagelgamousContext context)
        {
            _context = context;
        }
        public IQueryable<BurialRecords> BurialRecords => _context.BurialRecords;
        public IQueryable<BodyMeasurements> BodyMeasurements => _context.BodyMeasurements;
        public IQueryable<MainEntries> MainEntries => _context.MainEntries;
}
}