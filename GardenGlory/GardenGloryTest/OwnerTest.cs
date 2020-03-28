using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GardenGloryTest
{
    [TestFixture]
    public class OwnerTest
    {
        [Test]
        public void Owner_GetOwner()
        {
            using (var context = new GardenGloryContext())
            {
                var owners = context.Owners.Where(c => c.IsDeleted != true)
                    .Include(c => c.OwnerTypeLink).ToList();

                foreach (var owner in owners)
                {
                    Console.WriteLine($"OwnerId: {owner.OwnerTypeId} OwnerType: {owner.OwnerTypeLink.Type} OwnerName: {owner.OwnerName} OwnerEmail: {owner.OwnerEmail}" +
                                      $" ContactNumber: {owner.ContactNumber}");
                }
            }
        }

        
    }
}
