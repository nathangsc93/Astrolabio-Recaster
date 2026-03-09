using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astrolabio_Recaster.Models;

namespace Astrolabio_Recaster.Services
{
    public class StatMatchService
    {
        public bool Matches(List<string> detectedStats, List<DesiredStat> desiredStats)
        {
            if (detectedStats == null || desiredStats == null)
                return false;

            Dictionary<string, int> detectedCount = detectedStats
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (DesiredStat desired in desiredStats)
            {
                if (!detectedCount.TryGetValue(desired.Name, out int foundCount))
                    return false;

                if (foundCount < desired.Quantity)
                    return false;
            }

            return true;
        }
    }
}
