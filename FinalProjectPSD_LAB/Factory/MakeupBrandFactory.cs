using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FinalProjectPSD_LAB.Factory
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand CreateMakeupBrand(int makeupbrandID, string makeupbrandName, int makeupbrandRating)
        {
            return new MakeupBrand
            {
                MakeupBrandID = makeupbrandID,
                MakeupBrandName = makeupbrandName,
                MakeupBrandRating = makeupbrandRating
            };
        }
    }
}