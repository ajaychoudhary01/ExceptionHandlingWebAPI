using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionHandlingWebAPI.Models
{
    public class Tag
    {
        public bool HasSynonyms { get; set; }

        public string Name { get; set; }

        public int TotalCount { get; set; }
    }
}