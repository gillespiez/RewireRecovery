using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RewireRecovery.Models
{
    [Table("Triggers")]
    public class Triggers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Trigger { get; set; }
    }
}
