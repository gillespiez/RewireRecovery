using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RewireRecovery.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        //SQLiteAsyncConnection GetConnection();
       
    }
}
