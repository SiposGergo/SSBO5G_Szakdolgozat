﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSBO5G__Szakdolgozat.Models
{
    public class CheckPointPass
    {
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }

        public TimeSpan? NettoTime { get; set; }

        // Melyik ellenőrzőpont
        public int CheckPointId { get; set; }
        public CheckPoint CheckPoint { get; set; }
        
        // melyik teljesítéshez
        public int RegistrationId { get; set; }
        public Registration Registration { get; set; }
    }
}
