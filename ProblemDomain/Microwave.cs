﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.ProblemDomain
{
    class Microwave : Appliance
    {
        public decimal Capacity { get; set; }
        public string RoomType { get; set; }

        public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, decimal price,
                         decimal capacity, string roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomType;
        }

        public override string DisplayDetails()
        {
            return $"Microwave Details:\nItem Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\nColor: {Color}\nPrice: {Price:C}\nCapacity: {Capacity}\n" +
                   $"Room Type: {RoomType}";
        }
    }
}
