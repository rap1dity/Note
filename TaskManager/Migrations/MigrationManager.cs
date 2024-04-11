using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Models;

namespace TaskManager.Migrations
{
    public static class MigrationManager
    {
        public static void PerformMigration(Migration migration, ulong oldSchemaVersion)
        {
            // Color property has been added for Note class
            if(oldSchemaVersion < 13)
            {
                var notes = migration.NewRealm.All<Note>();

                foreach(var note in notes)
                {
                    Random random = new Random();
                    note.Color = string.Format("#{0:X6}", random.Next(0x1000000));
                }
            }
        }
    }
}
