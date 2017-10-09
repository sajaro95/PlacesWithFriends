using System;
using System.Collections.Generic;
using System.Text;

namespace PWF.Model
{
    public class Post
    {
        public int Id { get; set; }
        public Location Location { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
