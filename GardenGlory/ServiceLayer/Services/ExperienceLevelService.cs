using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class ExperienceLevelService
    {
        private GardenGloryContext _context;
        // get, and update only
        //fix to 4 types: Junior, senior, master, and super master
        public ExperienceLevelService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<ExperienceLevel> GetExperienceLevels()
        {
            return _context.ExperienceLevels;
        }

        public void UpdateExperienceLevel(int experienceLevelId, string level)
        {
            var experienceLevel = _context.ExperienceLevels.Find(experienceLevelId);
            experienceLevel.Level = level;
            _context.SaveChanges();
        }
    }
}
