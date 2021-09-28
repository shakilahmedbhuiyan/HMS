﻿using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypesService
    {
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            var context = new HMSContext();
            return context.AccomodationTypes.AsEnumerable();
        }

        public AccomodationType GeAccomodationTypeByID(int Id)
        {
            var context = new HMSContext();
            return context.AccomodationTypes.Find(Id);
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();
             context.AccomodationTypes.Add(accomodationType);
            return context.SaveChanges() > 0;
;        }


        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
            ;
        }


        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
            ;
        }
    }
}
