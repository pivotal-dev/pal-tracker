using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        public readonly IDictionary<long, TimeEntry> _timeEntries = new Dictionary<long, TimeEntry>();
      
       public TimeEntry Create(TimeEntry timeEntry)
        {
            var id = _timeEntries.Count+1;
            timeEntry.Id = id;
            _timeEntries.Add(id, timeEntry);
            return timeEntry;
        }

        public TimeEntry Find(long id) => _timeEntries[id];
        public bool Contains(long Id) => _timeEntries.ContainsKey(Id);

        public IEnumerable<TimeEntry> List() => _timeEntries.Values.ToList();
        

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            timeEntry.Id = id;
            _timeEntries[id] = timeEntry;
            return timeEntry;
        }

        public void Delete(long Id) => _timeEntries.Remove(Id);
        
    }
}