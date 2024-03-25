using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Breakfast
{
    public record BreakfastResponse(
        Guid Id,
        string Name, 
        string Description,
        DateTime StartDatetime,
        DateTime LastModifiedDateTime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet
    );
}