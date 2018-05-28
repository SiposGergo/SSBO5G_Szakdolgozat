﻿using SSBO5G__Szakdolgozat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSBO5G__Szakdolgozat.Dtos
{
    public class HikeCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Melyik túra
        public int HikeId { get; set; }
        public int Price { get; set; }
        public DateTime RegisterDeadline { get; set; }
        public int MaxNumOfHikers { get; set; }
        public int NumOfRegisteredHikers { get; set; }
        public string PlaceOfStart { get; set; }
        public string PlaceOfFinish { get; set; }
        // méterben
        public int Distance { get; set; }
        public int Elevation { get; set; }
        public DateTime BeginningOfStart { get; set; }
        public DateTime EndOfStart { get; set; }
        public TimeSpan LimitTime { get; set; }

        public virtual ICollection<CheckPointDto> CheckPoints { get; set; }
        
        public virtual ICollection<RegistrationDto> Registrations { get; set; }

        //// Teljesítések
        //public virtual ICollection<Participation> Participations { get; set; }
    }
}
