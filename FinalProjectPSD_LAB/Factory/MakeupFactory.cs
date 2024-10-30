using FinalProjectPSD_LAB.Models;
using FinalProjectPSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FinalProjectPSD_LAB.Factory
{
    public class MakeupFactory
    { 
        public static Makeup CreateMakeUp(int makeupID , string makeupname, int makeupprice, int makeupweight, int makeuptypeID, int makeupbrandID)
        {
            return new Makeup
            {
                MakeupID = makeupID,
                MakeupName = makeupname,
                MakeupPrice = makeupprice,
                MakeupWeight = makeupweight,
                MakeupTypeID = makeuptypeID,
                MakeupBrandID = makeupbrandID
            };
        }
    }
}