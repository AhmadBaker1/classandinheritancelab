using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.ProblemDomain
{
    class Refrigerator : Appliance
    {
        // Specifying the properties of the refrigerator for getter and setter methods
            public int NumberOfDoors { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }

            public Refrigerator(string itemNumber, string brand, int quantity, int wattage, string color, decimal price,
                                int numberOfDoors, int height, int width)
                : base(itemNumber, brand, quantity, wattage, color, price)
            {
                NumberOfDoors = numberOfDoors;
                Height = height;
                Width = width;
            }
            public override string DisplayDetails()
            {
            // Implement how refrigerator details are displayed
            return $"Refrigerator Details:\nItem Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\nColor: {Color}\nPrice: {Price:C}\nNumber of Doors: {NumberOfDoors}\n" +
                   $"Height: {Height} inches\nWidth: {Width} inches";
            }
    }
}
