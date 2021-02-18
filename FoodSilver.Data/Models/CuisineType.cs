using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSilver.Data.Models
{
    // to limit the number of cuisines we add an enum
    public enum CuisineType
    {
        // the first represent a restaurant that have no cuisine
        None,
        Italian,
        Indian,
        Arabian
    }
}
