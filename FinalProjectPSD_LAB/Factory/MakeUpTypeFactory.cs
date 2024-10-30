using FinalProjectPSD_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD_LAB.Factory
{
    public class MakeUpTypeFactory
    {
        public static MakeUpType CreateMakeupType(int makeupID, string makeuptypeName)
        {
            return new MakeUpType
            {
                MakeupTypeID = makeupID,
                MakeupTypeName = makeuptypeName
            };
        }
    }
}