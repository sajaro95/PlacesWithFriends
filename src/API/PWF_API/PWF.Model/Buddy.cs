﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PWF.Model
{
    public class Buddy
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
