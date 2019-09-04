using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using RewireRecovery.Models;

namespace RewireRecovery.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "Triggers.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<Triggers>();
        }

        // Get All Contact data      
        public List<Triggers> GetAllTriggersData()
        {
            return (from data in sqliteconnection.Table<Triggers>()
                    select data).ToList();
        }

        //Get Specific Contact data  
        public Triggers GetTriggersData(int id)
        {
            return sqliteconnection.Table<Triggers>().FirstOrDefault(t => t.Id == id);
        }

        // Delete all Contacts Data  
        public void DeleteAllTriggers()
        {
            sqliteconnection.DeleteAll<Triggers>();
        }

        // Delete Specific Contact  
        public void DeleteTrigger(int id)
        {
            sqliteconnection.Delete<Triggers>(id);
        }

        // Insert new Contact to DB   
        public void InsertTrigger(Triggers trigger)
        {
            sqliteconnection.Insert(trigger);
        }

        // Update Contact Data  
        public void UpdateTrigger(Triggers trigger)
        {
            sqliteconnection.Update(trigger);
        }
    }
}

