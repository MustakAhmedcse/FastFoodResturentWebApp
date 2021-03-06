﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Core.Gateway;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Core.Manager
{
    public class InterArrivalTimeMatchManager
    {
        InterArrivalTimeMatchGateway interArrivalTimeMatchGateway = new InterArrivalTimeMatchGateway();
        public string Insert(InterArrivalTimeMatch interArrivalTimeMatch)
        {
            if (interArrivalTimeMatchGateway.Insert(interArrivalTimeMatch)>0)
            {
                return "Save Successfull.";
            }
            else
            {
                return "Sory! Save Fail.";
            }
            
        }

        public List<InterArrivalTimeMatch> GetAllInterArrivalTimes()
        {
            return interArrivalTimeMatchGateway.GetAllInterArrivalTimes();
        }

        public int UpdateInterArrivalTimeRange(InterArrivalTimeMatch interArrivalTimeMatch)
        {
            return interArrivalTimeMatchGateway.UpdateInterArrivalTimeRange(interArrivalTimeMatch);
        }

        public InterArrivalTimeMatch GetInterArrivalTimeById(int id)
        {
            return interArrivalTimeMatchGateway.GetInterArrivalTimeById(id);
        }

        public void DeleteInterArrivalTimeById(int id)
        {
             interArrivalTimeMatchGateway.DeleteInterArrivalTimeById(id);
        }
    }
}