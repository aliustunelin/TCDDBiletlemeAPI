using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Breakfast
{
    public record UpsertBreakfastRequest(
        string Name, 
        string Description,
        DateTime StartDatetime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet
    );
}