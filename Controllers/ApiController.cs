using FagElGamous.Models;
using FagElGamous.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        //this is an api controller to return JSON objects based off different API requests

        private fagelgamousContext _context;

        public ApiController( fagelgamousContext context)
        {
            _context = context;
        }

        //returns the info from the main entries table
        [HttpGet("mainentries/{id:int}")]
        public ActionResult<MainEntries> Get(int id)
        {
            MainEntries obj = _context.MainEntries.Where(e => e.BurialId == id).FirstOrDefault();

            if (obj is null)
            {
                obj = new MainEntries
                {
                    BurialId = id
                };
            }

            return obj;
        }

        //returns cranial data for the given id
        [HttpGet("cranial/{id:int}")]
        public ActionResult<Cranial> GetCranial(int id)
        {
            Cranial obj = _context.Cranial.Where(e => e.BurialId == id).FirstOrDefault();

            if (obj is null)
            {
                obj = new Cranial
                {
                    BurialId = id
                };
            }

            return obj;
        }

        //returns the biological data for the given id
        [HttpGet("bio/{id:int}")]
        public ActionResult<BiologicalSamples> GetBio(int id)
        {
            BiologicalSamples obj = _context.BiologicalSamples.Where(e => e.BurialId == id).FirstOrDefault();

            if (obj is null)
            {
                obj = new BiologicalSamples
                {
                    BurialId = id
                };
            }

            return obj;
        }

        //gives the burial records, mainly location associated with the given id
        [HttpGet("burial/{id:int}")]
        public ActionResult<BurialRecords> GetBurial(int id)
        {
            BurialRecords obj = _context.BurialRecords.Where(e => e.BurialId == id).FirstOrDefault();

            if (obj is null)
            {
                obj = new BurialRecords
                {
                    BurialId = id
                };
            }

            return obj;
        }

        //gives the body measurements associated with the given id
        [HttpGet("body/{id:int}")]
        public ActionResult<BodyMeasurements> GetBody(int id)
        {
            BodyMeasurements obj = _context.BodyMeasurements.Where(e => e.BurialId == id).First();

            if (obj is null)
            {
                obj = new BodyMeasurements
                {
                    BurialId = id
                };
            }

            return obj;
        }
    }
}
