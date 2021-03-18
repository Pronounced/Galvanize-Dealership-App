using System.Collections.Generic;
using System.Data;
using System.Linq;
using dealership_app.Models;

namespace dealership_app.Fake_Data
{
    public class CarRules
    {
        static private List<CarRule> rules = new List<CarRule>();

        static public List<CarRule> GetCarRules()
        {
            if(rules.Count != 0)
            {
                return rules;
            }
            
            rules.Add(new CarRule(){
                name = "First",
                startYear = "1960",
                endYear = "2020",
                make = "Chevrolet",
                model = "Impala",
                color = "black"
            });

            rules.Add(new CarRule(){
                name = "Second",
                startYear = "1990",
                endYear = "2010",
                make = "Ford",
                model = "Mustang",
                color = "red"
            });

            rules.Add(new CarRule(){
                name = "Third",
                startYear = "2000",
                endYear = "2005",
                make = "BMW",
                model = "M3",
                color = "blue"
            });

            return rules;
        }

        static public List<CarRule> PostCarRule(string name, string startYear, string endYear, string make, string model, string color)
        {
            rules.Add(new CarRule(){
                name = name,
                startYear = startYear,
                endYear = endYear,
                make = make,
                model = model,
                color = color
            });

            return rules;
        }

        static public void DeleteCarRule(string name)
        {
            foreach (var item in rules.ToList())
            {
                if(item.name == name)
                {
                    rules.Remove(item);
                }
            }
        }

    }
}