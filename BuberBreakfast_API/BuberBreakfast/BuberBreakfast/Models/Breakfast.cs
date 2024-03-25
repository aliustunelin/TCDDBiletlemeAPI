using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberBreakfast.Models
{   
    public class Breakfast
    {

        // min max için veri girişi
        public const int MinNameLen = 3;
        public const int MaxNameLen = 50;
        public const int MinDescriptionLen = 10;
        public const int MaxDescriptionLen = 100;

        public Guid Id { get;   }
        public string Name { get;   }
        public string Description { get;   }
        public DateTime StartDateTime { get;   }
        public DateTime EndDateTime { get;   }
        public DateTime LastModifiedDateTime { get;   }
        public List<string> Savory { get;   }
        public List<string> Sweet { get;   }





         public Breakfast(Guid id,
                          string name,
                          string description,
                          DateTime startDateTime,
                          DateTime endDateTime,
                          DateTime lastModifiedDateTime,
                          List<string> savory,
                          List<string> sweet)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Savory = savory;
            Sweet = sweet;
        }

    }
}