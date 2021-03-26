using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSilver.Data.Models
{
    // add public modifier to use the class outside of the project
    // we add a folder named 'Model' as classification in terms of namespaces in c#

    // Restaurant is an Entity becuase it's represent the information that will be persisted into a db
    public class Restaurant
    {
        // EF will make this by default PK and identity
        public int Id { get; set; }

        // any time mvc model binder run validation logic accross my model if i use restaurant as input model to the action
        // the mvc will see this data annotation and inspect the name to see if it's not null or empty and if it is the model binder will set an error into model state to mark model state as invalid
        
        // data annotation may do the validation or add meta data for html helper like display the name
        //[DisplayFormat(DataFormatString = "")] // or format any type
        //[DisplayFormat(NullDisplayText = "")] // if it's a null and you want to display something
        //[DataType(DataType.Password)]
        //[Range(0, 10)]
        [Required] // not null in db
        [MaxLength(255)]
        public string Name { get; set; }
        
        [Display(Name = "Type of food")]
        // to enforce a limited number of choices to user we use a 'enum' type
        public CuisineType Cuisine { get; set; }

        // any edit on db need migration in EF-Code-First
        // first time in Package Manager Consol: enable-migrations --> [choose FoodSilver.Data] this will create a migration folder in the solution
        // add-migration message-here
        // update-database
    }
}
