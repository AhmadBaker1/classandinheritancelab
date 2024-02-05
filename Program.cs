using assignment1.ProblemDomain;
using System.Security.Cryptography;

namespace assignment1
{
    class Program
    {
        static List<Appliance> appliances = new List<Appliance>();

        static void Main(string[] args)
        {
            LoadAppliancesFromFile("C:\\Users\\Ahmad Baker\\OneDrive\\Desktop\\CPRG211G\\labs\\assignment1\\appliances.txt");
            DisplayMainMenu();
        }

        static void LoadAppliancesFromFile(string filePath)
        {
            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Split the line into individual components using semicolon as the separator
                    string[] components = line.Split(';');

                    // Check if the components array has at least the expected number of elements
                    if (components.Length >= 7)
                    {
                        string itemNumber = components[0];
                        string brand = components[1];
                        int quantity = int.Parse(components[2]);
                        int wattage = int.Parse(components[3]);
                        string color = components[4];
                        decimal price = decimal.Parse(components[5]);

                        // Determine the appliance type based on the first digit of the item number
                        switch (itemNumber[0])
                        {
                            case '1':
                                // Refrigerator
                                int numberOfDoors = int.Parse(components[6]);
                                int height = int.Parse(components[7]);
                                int width = int.Parse(components[8]);
                                appliances.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, numberOfDoors, height, width));
                                break;
                            case '2':
                                // Vacuum
                                string grade = components[6];
                                int batteryVoltage = int.Parse(components[7]);
                                appliances.Add(new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage));
                                break;
                            case '3':
                                // Microwave
                                decimal capacity = decimal.Parse(components[6]);
                                string roomType = components[7];
                                appliances.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType));
                                break;
                            case '4':
                            case '5':
                                // Dishwasher
                                string feature = components[6];
                                string soundRating = components[7];
                                appliances.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating));
                                break;
                            default:
                                // Invalid appliance type
                                Console.WriteLine($"Invalid appliance type for item number {itemNumber}");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line format: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
        }

        static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("How may we assist you?");
                Console.WriteLine("1 – Check out appliance");
                Console.WriteLine("2 – Find appliances by brand");
                Console.WriteLine("3 – Display appliances by type");
                Console.WriteLine("4 – Produce random appliance list");
                Console.WriteLine("5 – Save & exit");
                Console.Write("Enter option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            CheckOutAppliance();
                            break;
                        case 2:
                            FindAppliancesByBrand();
                            break;
                        case 3:
                            DisplayAppliancesByType();
                            break;
                        case 4:
                            ProduceRandomApplianceList();
                            break;
                        case 5:
                            SaveAndExit();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void CheckOutAppliance()
        {
            Console.Write("Enter the item number of an appliance: ");
            string itemNumber = Console.ReadLine();

            Appliance selectedAppliance = appliances.FirstOrDefault(appliance => appliance.ItemNumber == itemNumber);

            if (selectedAppliance == null)
            {
                Console.WriteLine($"No appliances found with item number {itemNumber}.");
            }
            else
            {
                if (selectedAppliance.Quantity > 0)
                {
                    selectedAppliance.Quantity--;
                    Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
                    Console.WriteLine(selectedAppliance.DisplayDetails());
                }
                else
                {
                    Console.WriteLine($"Sorry, the appliance \"{itemNumber}\" is not available.");
                }
            }
        }

        static void FindAppliancesByBrand()
        {
            Console.Write("Enter brand to search for: ");
            string searchBrand = Console.ReadLine();

            var matchingAppliances = appliances
                .Where(appliance => appliance.Brand.Equals(searchBrand, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingAppliances.Any())
            {
                Console.WriteLine($"Matching Appliances for Brand \"{searchBrand}\":");
                foreach (var appliance in matchingAppliances)
                {
                    Console.WriteLine(appliance.DisplayDetails());
                }
            }
            else
            {
                Console.WriteLine($"No appliances found for brand \"{searchBrand}\".");
            }
        }

        static void DisplayAppliancesByType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance: ");
            if (int.TryParse(Console.ReadLine(), out int applianceType))
            {
                switch (applianceType)
                {
                    case 1:
                        DisplayRefrigeratorsByNumberOfDoors();
                        break;
                    case 2:
                        DisplayVacuumsByBatteryVoltage();
                        break;
                    case 3:
                        DisplayMicrowavesByRoomType();
                        break;
                    case 4:
                        DisplayDishwashersBySoundRating(); 
                        break;
                    default:
                        Console.WriteLine("Invalid appliance type. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        static void DisplayRefrigeratorsByNumberOfDoors()
        {
            Console.WriteLine("Refrigerator Types");
            Console.WriteLine("2 – Double Door");
            Console.WriteLine("3 – Three Doors");
            Console.WriteLine("4 – Four Doors");

            Console.Write("Enter number of doors: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfDoors))
            {
                if (numberOfDoors >= 2 && numberOfDoors <= 4)
                {
                    var matchingRefrigerators = appliances
                        .OfType<Refrigerator>()
                        .Where(refrigerator => refrigerator.NumberOfDoors == numberOfDoors)
                        .ToList();

                    if (matchingRefrigerators.Any())
                    {
                        Console.WriteLine($"Matching refrigerators with {numberOfDoors} doors:");
                        foreach (var refrigerator in matchingRefrigerators)
                        {
                            Console.WriteLine(refrigerator.DisplayDetails());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No refrigerators found with {numberOfDoors} doors.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number of doors. Please enter a valid option (2, 3, or 4).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void DisplayVacuumsByBatteryVoltage()
        {
            Console.WriteLine("Vacuum Battery Voltage Types");
            Console.WriteLine("1 – 18 V (Low)");
            Console.WriteLine("2 – 24 V (High)");

            Console.Write("Enter battery voltage value: ");
            if (int.TryParse(Console.ReadLine(), out int batteryVoltageOption))
            {
                if (batteryVoltageOption == 18 || batteryVoltageOption == 24)
                {
                    string batteryVoltage = (batteryVoltageOption == 18) ? "Low" : "High";

                    var matchingVacuums = appliances
                        .OfType<Vacuum>()
                        .Where(vacuum => vacuum.BatteryVoltage == batteryVoltageOption)
                        .ToList();

                    if (matchingVacuums.Any())
                    {
                        Console.WriteLine($"Matching vacuums with {batteryVoltage} battery voltage:");
                        foreach (var vacuum in matchingVacuums)
                        {
                            Console.WriteLine(vacuum.DisplayDetails());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No vacuums found with {batteryVoltage} battery voltage.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid battery voltage value. Please enter a valid option (18 or 24).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void DisplayMicrowavesByRoomType()
        {
            Console.WriteLine("Microwave Room Types");
            Console.WriteLine("1 – Kitchen (K)");
            Console.WriteLine("2 – Work Site (W)");

            Console.Write("Enter room type (K for Kitchen, W for Work Site): ");
            string roomType = Console.ReadLine()?.ToUpper(); // Convert to uppercase for case-insensitive comparison

            if (roomType == "K" || roomType == "W")
            {
                var matchingMicrowaves = appliances
                    .OfType<Microwave>()
                    .Where(microwave => microwave.RoomType == roomType)
                    .ToList();

                if (matchingMicrowaves.Any())
                {
                    Console.WriteLine($"Matching microwaves for {roomType} room type:");
                    foreach (var microwave in matchingMicrowaves)
                    {
                        Console.WriteLine(microwave.DisplayDetails());
                    }
                }
                else
                {
                    Console.WriteLine($"No microwaves found for {roomType} room type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'K' for Kitchen or 'W' for Work Site.");
            }
        }

        static void DisplayDishwashersBySoundRating()
        {
            Console.WriteLine("Dishwasher Sound Ratings");
            Console.WriteLine("1 – Quietest (Qt)");
            Console.WriteLine("2 – Quieter (Qr)");
            Console.WriteLine("3 – Quiet (Qu)");
            Console.WriteLine("4 – Moderate (M)");

            Console.Write("Enter sound rating (Qt, Qr, Qu, or M): ");
            string soundRatingInput = Console.ReadLine()?.ToUpper(); // Convert to uppercase for case-insensitive comparison

            var matchingDishwashers = appliances
                .OfType<Dishwasher>()
                .Where(dishwasher => dishwasher.SoundRating == soundRatingInput)
                .ToList();

            if (matchingDishwashers.Any())
            {
                Console.WriteLine($"Matching dishwashers for {soundRatingInput} sound rating:");
                foreach (var dishwasher in matchingDishwashers)
                {
                    Console.WriteLine(dishwasher.DisplayDetails());
                }
            }
            else
            {
                Console.WriteLine($"No dishwashers found for {soundRatingInput} sound rating.");
            }
        }
        static void ProduceRandomApplianceList()
        {
            Console.Write("Enter number of appliances: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfAppliances))
            {
                var random = new Random();
                var randomAppliances = appliances.OrderBy(x => random.Next()).Take(numberOfAppliances).ToList();

                Console.WriteLine("Random appliances:");
                foreach (var appliance in randomAppliances)
                {
                    Console.WriteLine(appliance.DisplayDetails());
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void SaveAndExit()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("appliances.txt"))
                {
                    foreach (var appliance in appliances)
                    {
                        writer.WriteLine(appliance.ToString());
                    }
                }

                Console.WriteLine("Appliances saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving appliances to file: {ex.Message}");
            }

            Console.WriteLine("Exiting program. Thank you for using Modern Appliances!");
            Environment.Exit(0);
        }
    }
}
