﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MessageParams : PanigationParams
    {
        public string Username { get; set; }
        public string Container { get; set; } = "Unread";

    }
}
