using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.ProblemDomain
{
    class Dishwasher : Appliance
    {
        public string Feature { get; set; }
        public string SoundRating { get; set; }

        public Dishwasher(string itemNumber, string brand, int quantity, int wattage, string color, decimal price,
                          string feature, string soundRating)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Feature = feature;
            SoundRating = soundRating;
        }

        public override string DisplayDetails()
        { 
            string soundRatingName;

            switch (SoundRating.ToUpper())
            {
                case "QT":
                    soundRatingName = "Quietest";
                    break;
                case "QR":
                    soundRatingName = "Quieter";
                    break;
                case "QU":
                    soundRatingName = "Quiet";
                    break;
                case "M":
                    soundRatingName = "Moderate";
                    break;
                default:
                    soundRatingName = SoundRating; // Display as is if not recognized
                    break;
            }
    
        
            return $"Dishwasher Details:\nItem Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\n" +
                    $"Wattage: {Wattage}\nColor: {Color}\nPrice: {Price:C}\nFeature: {Feature}\nSound Rating: {soundRatingName}";
        }
    }
}
