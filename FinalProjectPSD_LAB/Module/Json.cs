using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FinalProjectPSD_LAB.Module
{
    public class Json<T>
    {
        public string Text { get; set; }
        public bool Success { get; set; }
        public T Response { get; set; }
    }
}