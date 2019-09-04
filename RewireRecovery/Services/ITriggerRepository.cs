using System;
using System.Collections.Generic;
using System.Text;
using RewireRecovery.Models;

namespace RewireRecovery.Services
{
    public interface ITriggerRepository
    {
        List<Triggers> GetAllTriggersData();

        //Get Specific Contact data  
        Triggers GetTriggersData(int triggerID);

        // Delete all Contacts Data  
        void DeleteAllTriggers();

        // Delete Specific Contact  
        void DeleteTrigger(int triggerID);

        // Insert new Contact to DB   
        void InsertTrigger(Triggers trigger);

        // Update Contact Data  
        void UpdateTrigger(Triggers trigger);

    }
}
