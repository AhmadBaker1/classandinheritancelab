using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.ProblemDomain
{
    class Vacuum : Appliance
    {
        public string Grade { get; set; }
        public int BatteryVoltage { get; set; }

        public Vacuum(string itemNumber, string brand, int quantity, int wattage, string color, decimal price,
                      string grade, int batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            BatteryVoltage = batteryVoltage;
        }
        public override string DisplayDetails()
        {
            string voltageDescription = (BatteryVoltage == 18) ? "Low" : "High";
            // Implement how vacuum details are displayed
            return $"Vacuum Details:\nItem Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\nColor: {Color}\nPrice: {Price:C}\nGrade: {Grade}\nBattery Voltage: {voltageDescription}";
        }
    }
}
