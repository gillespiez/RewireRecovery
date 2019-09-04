using System;
using System.Collections.Generic;
using System.Text;
using RewireRecovery.Helpers;
using RewireRecovery.Models;

namespace RewireRecovery.Services
{
    public class TriggerRepository : ITriggerRepository
    {
        DatabaseHelper _databaseHelper;
        public TriggerRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteTrigger(int triggerID)
        {
            _databaseHelper.DeleteTrigger(triggerID);
        }

        public void DeleteAllTriggers()
        {
            _databaseHelper.DeleteAllTriggers();
        }

        public List<Triggers> GetAllTriggersData()
        {
            return _databaseHelper.GetAllTriggersData();
        }

        public Triggers GetTriggersData(int triggerID)
        {
            return _databaseHelper.GetTriggersData(triggerID);
        }

        public void InsertTrigger(Triggers trigger)
        {
            _databaseHelper.InsertTrigger(trigger);
        }

        public void UpdateTrigger(Triggers trigger)
        {
            _databaseHelper.UpdateTrigger(trigger);
        }
    }
}
