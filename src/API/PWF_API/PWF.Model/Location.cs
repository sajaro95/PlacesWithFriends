using System;
using System.Collections.Generic;
using System.Text;

namespace PWF.Model
{
    public class Location
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
