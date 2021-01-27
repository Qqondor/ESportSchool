﻿using System;
using System.Runtime.Serialization;
using ESportSchool.Domain.Entities.NotMapped;

namespace ESportSchool.Domain.Entities
{
    public class ScheduleInterval : BaseEntity
    {
        public DateTime Start { get; set; }
        public byte Duration { get; set; }
        public bool RepeatWeekly { get; set; } = false;

        //relations
        public CoachProfile CoachProfile { get; set; }


        public bool IsOverlapped(ScheduleInterval other)
        {
            if (Start.Date != other.Start.Date)
            {
                return false;
            }
            if (other.Start.Hour >= Start.Hour && other.Start.Hour <= Start.Hour + Duration)
            {
                return true;
            }
            if (other.Start.Hour + Duration >= Start.Hour && other.Start.Hour + Duration <= Start.Hour + Duration)
            {
                return true;
            }

            return false;
        }

        public bool Contain(ScheduleInterval other)
        {
            if (Start.Date != other.Start.Date)
            {
                return false;
            }

            if (Start.Hour <= other.Start.Hour && Start.Hour + Duration >= other.Start.Hour + other.Duration)
            {
                return true;
            }

            return false;
        }
    }
}