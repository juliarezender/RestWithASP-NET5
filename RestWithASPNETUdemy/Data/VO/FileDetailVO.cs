using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class FileDetailVO
    {
        public string DocumentName { get; set; }
        public string DocType { get; set; }
        public string DocUrl { get; set; }

        public static implicit operator List<object>(FileDetailVO v)
        {
            throw new NotImplementedException();
        }
    }
}