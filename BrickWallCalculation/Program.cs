using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitsNet;                                           // https://github.com/angularsen/UnitsNet
using UnitsNet.Units;                                     // It is used to represent data with units of measurement and make conversions between them
using ConstructionMaterials;                              // Class that contains the Brick.cs program for the numerical representation of bricks.

namespace BrickWallCalculation
{
    internal class Program
    {
        enum BrickBondingMetric
        {
            Soga,                 
            Tizon,             
            Ingles,                
            Panderete,
        }
        enum BrickBondingImperial
        {
            Stretcher,
            Header,
            English,
            EnglishGarden,
        }
        enum Dosage
        {
            OneTwo,
            OneThree,
            OneFour,
            OneFive,
        }

        static void Main(string[] args)
        {
            //FIRST PART, INPUT DATA .
            //Welcome
            Console.WriteLine("Welcome to the brick wall materials calculator.");
            Console.WriteLine();

            //Select the units of measurement for subsequent calculations 
            Console.WriteLine("What system of units do you want to manage ?");
            Console.WriteLine("         1.- Metric System");
            Console.WriteLine("         2.- Imperial System");

            int system;                                                //which indicates which of the two systems I chose
            while (true)
            {
                Console.Write("Number 1 or 2, select one of the two options: ");
                string selectSystem = Console.ReadLine();
                try
                {
                    if (selectSystem == "1" || selectSystem == "2")
                    {
                        system = Convert.ToInt32(selectSystem);
                        break;
                    }
                    else if (selectSystem == "3" || selectSystem == "4" || selectSystem == "5" || selectSystem == "6" || selectSystem == "7"
                             || selectSystem == "8" || selectSystem == "9" || selectSystem == "0")
                    {
                        Console.WriteLine("Enter only the number 1 or only the number 2");
                        Console.WriteLine();
                    }
                    else
                    {
                        system = Convert.ToInt32(selectSystem);
                    }
                }
                catch
                {
                    MessageCatch();                                     //public static void messageCatch()
                    return;                                             //Stop the program from further executing.
                }
            }
            Console.WriteLine();


            //Notice to the user about what to handle
            if (system == 1)
            {
                Console.WriteLine("ATTENTION, THE FOLLOWING DATA YOU WILL ENTER WILL BE TAKEN IN METERS");
            }
            else
            {
                Console.WriteLine("ATTENTION, THE FOLLOWING DATA YOU ENTER WILL BE TAKEN IN FEETS");
            }
            Console.WriteLine();


            //Input lenght and height wall
            Console.Write("Enter the length of the wall: ");
            string lenghtInput = Console.ReadLine();
            Console.Write("Enter the heigth of the wall: ");
            string heightInput = Console.ReadLine();

            double lenght;                                              //Variable that stores the lenght of the wall 
            double height;                                              //Variable that stores the height of the wall
            try
            {
                lenght = Convert.ToDouble(lenghtInput);
                height = Convert.ToDouble(heightInput);
            }
            catch
            {
                MessageCatch();                                         //public static void messageCatch()
                return;                                                 //Stop the program from further executing.
            }
            Console.WriteLine();


            // Verification of windows.
            Console.WriteLine("Do you have windows in your wall? ");

            int confirmWindows = 0;                                     //Variable that saves the confirmation if it has windows or not.
            while (true)
            {
                Console.Write("Press number 1 if you have windows and 2 if you don't: ");
                string confirmInput = Console.ReadLine();
                try
                {
                    if (confirmInput == "1" || confirmInput == "2")
                    {
                        confirmWindows = Convert.ToInt32(confirmInput);
                        break;
                    }
                    else if (confirmInput == "3" || confirmInput == "4" || confirmInput == "5" || confirmInput == "6" || confirmInput == "7"
                        || confirmInput == "8" || confirmInput == "9" || confirmInput == "0")
                    {
                        Console.WriteLine("Enter only the number 1 or only the number 2");
                        Console.WriteLine();
                    }
                    else
                    {
                        confirmWindows = Convert.ToInt32(confirmInput);
                    }
                }
                catch
                {
                    MessageCatch();                                      //public static void MessageCatch()
                    return;                                              //Stop the program from further executing.
                }
            }
            Console.WriteLine();


            //Quatity of windows and entry of window measurements
            int numWindows = 0;                                          //Save the number of windows.
            double lenghtWin = 0;                                        //Save the lenght of the window if it is only one.
            double heightWin = 0;                                        //Save the height of the window if it is only one.
            List<double> lenghtsWindows = new List<double>();            //Save the lenght of each of the windows in case there are more than one.
            List<double> heightsWindows = new List<double>();            //Save the height of each of the windows in case there are more than one.

            if (confirmWindows == 1)
            {
                Console.Write("How many windows does your wall have?: ");
                string numberWindows = Console.ReadLine();
                try
                {
                    numWindows = Convert.ToInt32(numberWindows);
                }
                catch
                {
                    MessageCatch();                                      //public static void MessageCatch()
                    return;                                              //Stop the program from further executing.
                }
                if (numWindows == 1)
                {
                    Console.Write("Enter the length of the window: ");
                    string lenghtWindow = Console.ReadLine();

                    Console.Write("Enter the heigth of thge wall: ");
                    string heightWindow = Console.ReadLine();
                    try
                    {
                        lenghtWin = Convert.ToDouble(lenghtWindow);
                        heightWin = Convert.ToDouble(heightWindow);
                    }
                    catch
                    {
                        MessageCatch();                                   //public static void MessageCatch()
                        return;                                           //Stop the program from further executing.
                    }
                }
                else if (numWindows > 1)
                {
                    for (int i = 0; i < numWindows; i++)
                    {
                        Console.Write($"Enter the length of the window number {i + 1}: ");
                        string lenghtWindow = Console.ReadLine();
                        Console.Write($"Enter the heigth of the window number {i + 1}: ");
                        string heightWindow = Console.ReadLine();
                        try
                        {
                            lenghtsWindows.Add(Convert.ToDouble(lenghtWindow));
                            heightsWindows.Add(Convert.ToDouble(heightWindow));
                        }

                        catch
                        {
                            MessageCatch();                              //public static void MessageCatch()
                            return;                                      //Stop the preogram from further executing.
                        }
                    }
                }
                Console.WriteLine();
            }


            // Door verification
            Console.WriteLine("Do you have a door or doors in your wall?? ");

            int confirmDoor = 0;                                        //Variable that saves the confirmation if it has door or not.
            while (true)
            {
                Console.Write("Press number 1 if you have doors and 2 if you don't: ");
                string confirmInput = Console.ReadLine();
                try
                {
                    if (confirmInput == "1" || confirmInput == "2")
                    {
                        confirmDoor = Convert.ToInt32(confirmInput);
                        break;
                    }
                    else if (confirmInput == "3" || confirmInput == "4" || confirmInput == "5" || confirmInput == "6" || confirmInput == "7"
                        || confirmInput == "8" || confirmInput == "9" || confirmInput == "0")
                    {
                        Console.WriteLine("Enter only the number 1 or only the number 2");
                        Console.WriteLine();
                    }
                    else
                    {
                        confirmWindows = Convert.ToInt32(confirmInput);
                    }
                }
                catch
                {
                    MessageCatch();                                       //public static void MessageCatch()
                    return;                                               //Stop the program from further executing.
                }
            }
            Console.WriteLine();


            //Quatity of door and entry of door measurements
            int numDoor = 0;                                              //Save the number of doors.
            double lenghtDoor = 0;                                        //Save the lenght of the door if it is only one.
            double heightDoor = 0;                                        //Save the height of the door if it is only one.
            List<double> lenghtsDoors = new List<double>();               //Save the lenght of each of the doors in case there are more than one.
            List<double> heightsDoors = new List<double>();               //Save the height of each of the doors in case there are more than one.

            if (confirmDoor == 1)
            {
                Console.Write("How many doors does your wall have?: ");
                string numberDoors = Console.ReadLine();
                try
                {
                    numDoor = Convert.ToInt32(numberDoors);
                }
                catch
                {
                    MessageCatch();                                       //public static void MessageCatch()
                    return;                                               //Stop the preogram from further executing.
                }
                if (numDoor == 1)
                {
                    Console.Write("Enter the length of the door: ");
                    string lenghtDoorW = Console.ReadLine();

                    Console.Write("Enter the heigth of the door: ");
                    string heightDoorW = Console.ReadLine();
                    try
                    {
                        lenghtDoor = Convert.ToDouble(lenghtDoorW);
                        heightDoor = Convert.ToDouble(heightDoorW);
                    }
                    catch
                    {
                        MessageCatch();                                   //public static void MessageCatch()
                        return;                                           //Stop the preogram from further executing.
                    }
                }
                else if (numDoor > 1)
                {
                    for (int i = 0; i < numDoor; i++)
                    {
                        Console.Write($"Enter the length of the door number {i + 1}: ");
                        string lenghtDoorW = Console.ReadLine();
                        Console.Write($"Enter the heigth of the door number {i + 1}: ");
                        string heightDoorW = Console.ReadLine();
                        try
                        {
                            lenghtsDoors.Add(Convert.ToDouble(lenghtDoorW));
                            heightsDoors.Add(Convert.ToDouble(heightDoorW));
                        }

                        catch
                        {
                            MessageCatch();                              //public static void MessageCatch()
                            return;                                      //Stop the preogram from further executing.
                        }
                    }
                }
            }
            Console.WriteLine();



            //SECOND PART, M2 CALCULATION.
            //Calculate windows area
            Area areaWindow = Area.FromSquareMeters(0);                  //It will save the area of the window(s).
            if (numWindows == 1)
            {
                areaWindow = Area.FromSquareMeters(lenghtWin * heightWin);
            }
            else if (numWindows > 1)
            {
                for (int i = 0; i < numWindows; i++)
                {
                    areaWindow += Area.FromSquareMeters(lenghtsWindows[i] * heightsWindows[i]);
                }
            }

            //Calculate door area
            Area areaDoor = Area.FromSquareMeters(0);                    //It will save the area of the door(s).
            if (numDoor == 1)
            {
                areaDoor = Area.FromSquareMeters(lenghtDoor * heightDoor);
            }
            else if (numDoor > 1)
            {
                for (int i = 0; i < numDoor; i++)
                {
                    areaDoor += Area.FromSquareMeters(lenghtsDoors[i] * heightsDoors[i]);
                }
            }

            //Calculate wall area
            Area areaWall = Area.FromSquareMeters(lenght * height);

            //Calculate total area
            Area areaTotal = areaWall - (areaWindow + areaDoor);

            if (system == 1)
            {
                Console.WriteLine($"THE TOTAL AREA OF THE WALL IS: {areaTotal}");
            }
            else
            {
                areaTotal = Area.FromSquareFeet(areaTotal.Value);
                Console.WriteLine($"THE TOTAL AREA OF THE WALL IS: {areaTotal}");
            }
            Console.WriteLine();



            //THIRD PART, CALCULATION OF BRICKS
            //Input Data: dimensions of brick and joint.
            string name = "";                                             //Save the name of the brick
            string heightMeasurement = "";
            string lenghtMeasurement = "";
            string widthMeasurement = "";
            string joint1 = "";
            string joint2 = "";
            //Save user input to all previous variables (metric system)
            if (system == 1)
            {
                Console.WriteLine("What type of brick will you use ?");
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Height(cm): ");
                heightMeasurement = Console.ReadLine();
                Console.Write("Lenght(cm): ");
                lenghtMeasurement = Console.ReadLine();
                Console.Write("Width(cm): ");
                widthMeasurement = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Horizontal joint(cm): ");
                joint1 = Console.ReadLine();
                Console.Write("Vertical joint(cm): ");
                joint2 = Console.ReadLine();
            }
            //Save user input to all previous variables (Imperial system)
            else if (system == 2)
            {
                Console.WriteLine("What type of brick will you use ?");
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Height(in): ");
                heightMeasurement = Console.ReadLine();
                Console.Write("Lenght(in): ");
                lenghtMeasurement = Console.ReadLine();
                Console.Write("Width(in): ");
                widthMeasurement = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Horizontal joint(in): ");
                joint1 = Console.ReadLine();
                Console.Write("Vertical joint(in): ");
                joint2 = Console.ReadLine();
            }

            double heightBrick = 0;                                    //Save the height of the brick
            double lenghtBrick = 0;                                    //Save the lenght of the brick
            double widthBrick = 0;                                     //Save the width of the brick
            double joinHorizontal = 0;                                 //Saves the dimension of the horizontal joint.
            double joinVertical = 0;                                   //Save the dimension of the vertical joint. 
            try
            {
                heightBrick = Convert.ToDouble(heightMeasurement);
                lenghtBrick = Convert.ToDouble(lenghtMeasurement);
                widthBrick = Convert.ToDouble(widthMeasurement);
                joinHorizontal = Convert.ToDouble(joint1);
                joinVertical = Convert.ToDouble(joint2);
            }
            catch
            {
                MessageCatch();                                         //public static void messageCatch()
                return;                                                 //Stop the program from further executing.
            }
            Console.WriteLine();


            //Calculate the number of brick pieces according to the system.
            Ladrillo brickUsed = new Ladrillo(name, heightBrick, widthBrick, lenghtBrick);              //Variable that will represent the brick with our inputs.
            double bricksU2 = 0;                                                                        //Number of brick pieces per square unity.
            bool keepReadingKey = true;                                                                 //Variable that will control whether or not the 'While' loop is repeated
            BrickBondingMetric indexEnumMetric = 0 ;                                                        //Index number that indicates which member of the enumerator was chosen.
            BrickBondingImperial indexEnumImperial = 0 ;
            Console.WriteLine("BRICK BOUNDING:");

            if (system == 1)                                                                            //which indicates which of the two systems I chose.
            {
                foreach (BrickBondingMetric brickBonding in Enum.GetValues(typeof(BrickBondingMetric))) //Print enumerator members to the console
                {
                    Console.WriteLine($"  {(int)brickBonding}.- {brickBonding}");
                }
                while (keepReadingKey)
                {
                    Console.Write("Select an index number from the options: ");
                    string selectBondInput = Console.ReadLine();
                    try
                    {
                        int selectBond = Convert.ToInt32(selectBondInput);
                        indexEnumMetric = (BrickBondingMetric)selectBond;                                     //Index number that indicates which member of the enumerator was chosen.
                        switch (indexEnumMetric)
                        {
                            case BrickBondingMetric.Soga:
                                bricksU2 = Ladrillo.QuantityInMeter(l => lenghtBrick, brickUsed, joinHorizontal) *
                                    Ladrillo.QuantityInMeter(h => heightBrick, brickUsed, joinVertical);
                                keepReadingKey = false;
                                break;

                            case BrickBondingMetric.Tizon:
                                bricksU2 = Ladrillo.QuantityInMeter(w => widthBrick, brickUsed, joinHorizontal) *
                                    Ladrillo.QuantityInMeter(h => heightBrick, brickUsed, joinVertical);
                                keepReadingKey = false;
                                break;

                            case BrickBondingMetric.Panderete:
                                bricksU2 = Ladrillo.QuantityInMeter(l => lenghtBrick, brickUsed, joinHorizontal) *
                                    Ladrillo.QuantityInMeter(w => widthBrick, brickUsed, joinVertical);
                                keepReadingKey = false;
                                break;

                            case BrickBondingMetric.Ingles:
                                bricksU2 = (Ladrillo.QuantityInMeter(l => lenghtBrick, brickUsed, joinHorizontal) * Ladrillo.QuantityInMeter(h => heightBrick, brickUsed, joinVertical)) +
                                   ((Ladrillo.QuantityInMeter(w => widthBrick, brickUsed, joinHorizontal) * Ladrillo.QuantityInMeter(h => heightBrick, brickUsed, joinVertical)) / 2);
                                keepReadingKey = false;
                                break;

                            default:
                                Console.WriteLine("Please choose only one number from the index:");
                                Console.WriteLine();
                                break;
                        }
                    }
                    catch
                    {
                        MessageCatch();                                     //public static void messageCatch()
                        return;                                             //Stop the program from further executing.
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"{bricksU2} Pcs/m2");
                Console.WriteLine();
            }


            else if (system == 2)                                                                           //which indicates which of the two systems I chose.
            {
                foreach (BrickBondingImperial brickBonding in Enum.GetValues(typeof(BrickBondingImperial))) //Print enumerator members to the console
                {
                    Console.WriteLine($"  {(int)brickBonding}.- {brickBonding}");
                }
                while (keepReadingKey)
                {
                    Console.Write("Select an index number from the options: ");
                    string selectBondInput = Console.ReadLine();
                    try
                    {
                        int selectBond = Convert.ToInt32(selectBondInput);
                        indexEnumImperial = (BrickBondingImperial)selectBond;                               //Index number that indicates which member of the enumerator was chosen.
                        switch (indexEnumImperial)
                        {
                            case BrickBondingImperial.Stretcher:
                                bricksU2 = Ladrillo.QuantityInFeets(l => lenghtBrick, brickUsed, joinHorizontal) *
                                    Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical);
                                keepReadingKey = false;
                                break;

                            case BrickBondingImperial.Header:
                                bricksU2 = Ladrillo.QuantityInFeets(w => widthBrick, brickUsed, joinHorizontal) *
                                    Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical);
                                keepReadingKey = false;
                                break;

                            case BrickBondingImperial.English:
                                bricksU2 = (Ladrillo.QuantityInFeets(l => lenghtBrick, brickUsed, joinHorizontal) * Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical)) +
                                    ((Ladrillo.QuantityInFeets(w => widthBrick, brickUsed, joinHorizontal) * Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical)) / 2);
                                keepReadingKey = false;
                                break;

                            case BrickBondingImperial.EnglishGarden:
                                bricksU2 = ((Ladrillo.QuantityInFeets(l => lenghtBrick, brickUsed, joinHorizontal) * Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical)) * 1.5) +
                                    ((Ladrillo.QuantityInFeets(w => widthBrick, brickUsed, joinHorizontal) * Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical)) / 4);
                                keepReadingKey = false;
                                break;

                            default:
                                Console.WriteLine("Please choose only one number from the index:");
                                Console.WriteLine();
                                break;
                        }
                    }
                    catch
                    {
                        MessageCatch();                                     //public static void messageCatch()
                        return;                                             //Stop the program from further executing.
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"{bricksU2} Pcs/In2");
                Console.WriteLine();
            }


            //Calculation of total pieces for the entire wall.
            Console.Write("% brick loss: ");
            string inputLoss = Console.ReadLine();
            double brickLoss = 0;                                                       //It will save the percentage of material loss
            try
            {
                brickLoss = Convert.ToDouble(inputLoss) / 100;
            }
            catch
            {
                MessageCatch();
                return;
            }
            double piecesWall = areaTotal.Value * bricksU2;                            //Number of pieces for the wall without % loss. 
            double totalPcs = (piecesWall * brickLoss) + piecesWall;                   //Number of pieces for the wall with % loss.
            Console.WriteLine();
            Console.WriteLine($"TOTAL NUMBER OF BRICKS = {Math.Round(totalPcs, 2)} Pcs");
            Console.WriteLine();



            //FOURTH PART. VOLUMES
            Volume totalVolume = new Volume();                                                                        //Mortar volume taking into account % loss.
            //Metric system  
            if (system == 1)
            {
                Volume volume1 = Volume.FromCubicCentimeters(heightBrick * widthBrick * lenghtBrick) * piecesWall;    //Volume of bricks throughout the wall.
                Volume volume2 = Volume.FromCubicCentimeters(0);                                                      //Wall volume according to the brick set.
                Area areaSquareCm = areaTotal.ToUnit(AreaUnit.SquareCentimeter);                                      //Wall area expressed in cm2.
                switch (indexEnumMetric)
                {
                    case BrickBondingMetric.Soga:
                        volume2 = Volume.FromCubicCentimeters(widthBrick * areaSquareCm.Value);
                        break;

                    case BrickBondingMetric.Tizon:
                        volume2 = Volume.FromCubicCentimeters(lenghtBrick * areaSquareCm.Value);
                        break;

                    case BrickBondingMetric.Panderete:
                        volume2 = Volume.FromCubicCentimeters(heightBrick * areaSquareCm.Value);
                        break;

                    case BrickBondingMetric.Ingles:
                        volume2 = Volume.FromCubicCentimeters(lenghtBrick * areaSquareCm.Value);
                        break;
                }

                Volume volumeMortar = (volume2 - volume1);                                                               //Mortar volume throughout the wall
                Volume volumeMeters = volumeMortar.ToUnit(VolumeUnit.CubicMeter);                                      //Volume expressed in m3.
                totalVolume = (volumeMeters / 10) + volumeMeters;                                                      //Mortar volume taking into account % loss.
                Console.WriteLine($"THE TOTAL VOLUME OF THE MORTAR IS: {totalVolume}");
                Console.WriteLine();
            }

            //Imperial system
            else if (system == 2)
            {
                Volume volume1 = Volume.FromCubicInches(heightBrick * widthBrick * lenghtBrick) * piecesWall;          //Volume of bricks throughout the wall.
                Volume volume2 = Volume.FromCubicInches(0);                                                            //Wall volume according to the brick set.
                Area areaSquareIn = areaTotal.ToUnit(AreaUnit.SquareInch);                                             //Wall area expressed in cm2.
                switch (indexEnumImperial)
                {
                    case BrickBondingImperial.Stretcher:
                        volume2 = Volume.FromCubicInches(widthBrick * areaSquareIn.Value);
                        break;

                    case BrickBondingImperial.Header:
                        volume2 = Volume.FromCubicInches(lenghtBrick * areaSquareIn.Value);
                        break;

                    case BrickBondingImperial.English:
                        volume2 = Volume.FromCubicInches(lenghtBrick * areaSquareIn.Value);
                        break;

                    case BrickBondingImperial.EnglishGarden:
                        volume2 = Volume.FromCubicInches(lenghtBrick * areaSquareIn.Value);
                        break;
                }

                Volume volumeMortar = volume2 - volume1;                                                              //Mortar volume throughout the wall
                Volume volumeFeets = volumeMortar.ToUnit(VolumeUnit.CubicFoot);                                       //Volume expressed in m3.
                totalVolume = (volumeFeets / 10) + volumeFeets;                                                       //Mortar volume taking into account % loss.
                Console.WriteLine($"THE TOTAL VOLUME OF THE MORTAR IS: {totalVolume}");
                Console.WriteLine();
            }



            //FIFTH PART. MATERIALS INPUT
            bool keepReadingKey2 = true;                                                                //Variable that will control whether or not the 'While' loop is repeated
            Dosage indexEnumDosage = 0;                                                                 //Index number that indicates which member of the enumerator was chosen.
            Mass cement = new Mass();                                                                   //Save the amount of cement to use.
            Volume sand = new Volume();                                                                 //Save the amount of area to use.
            Console.WriteLine("DOSAGE:");
            // Metric system
            if (system == 1)                                                                            //which indicates which of the two systems I chose.
            {
                int quantitéDosages = Enum.GetValues(typeof(Dosage)).Length;
                for (int i = 0; i < quantitéDosages; i++)                                               //Print enumerator members to the console
                {
                    Console.WriteLine($"  {i}.- 1:{2 + i}");
                }
                while (keepReadingKey2)
                {
                    Console.Write("Select an index number from the options: ");
                    string selectDosageInput = Console.ReadLine();
                    try
                    {
                        int selectDosage = Convert.ToInt32(selectDosageInput);
                        indexEnumDosage = (Dosage)selectDosage;                                       //Index number that indicates which member of the enumerator was chosen.
                        switch (indexEnumDosage)
                        {
                            case Dosage.OneTwo:
                                cement = totalVolume.Value * Mass.FromKilograms(676);
                                sand = totalVolume.Value * Volume.FromCubicMeters(0.96);
                                keepReadingKey2 = false;
                                break;

                            case Dosage.OneThree:
                                cement = totalVolume.Value * Mass.FromKilograms(505);
                                sand = totalVolume.Value * Volume.FromCubicMeters(1.08);
                                keepReadingKey2 = false;
                                break;

                            case Dosage.OneFour:
                                cement = totalVolume.Value * Mass.FromKilograms(403);
                                sand = totalVolume.Value * Volume.FromCubicMeters(1.15);
                                keepReadingKey2 = false;
                                break;

                            case Dosage.OneFive:
                                cement = totalVolume.Value * Mass.FromKilograms(336);
                                sand = totalVolume.Value * Volume.FromCubicMeters(1.20);
                                keepReadingKey2 = false;
                                break;

                            default:
                                Console.WriteLine("Please choose only one number from the index:");
                                Console.WriteLine();
                                break;
                        }
                    }
                    catch
                    {
                        MessageCatch();                                     //public static void messageCatch()
                        return;                                             //Stop the program from further executing.
                    }
                }
            }


            // Imperial system
            if (system == 2)                                                                            //which indicates which of the two systems I chose.
            {
                int quantitéDosages = Enum.GetValues(typeof(Dosage)).Length;
                for (int i = 0; i < quantitéDosages; i++)                                               //Print enumerator members to the console
                {
                    Console.WriteLine($"  {i}.- 1:{2 + i}");
                }
                while (keepReadingKey2)
                {
                    Console.Write("Select an index number from the options: ");
                    string selectDosageInput = Console.ReadLine();
                    try
                    {
                        int selectDosage = Convert.ToInt32(selectDosageInput);
                        indexEnumDosage = (Dosage)selectDosage;                                        //Index number that indicates which member of the enumerator was chosen.
                        switch (indexEnumDosage)
                        {
                            case Dosage.OneTwo:
                                cement = totalVolume.Value * Mass.FromPounds(42.20);
                                sand = totalVolume.Value * Volume.FromCubicYards(0.0353);
                                keepReadingKey2 = false;
                                break;

                            case Dosage.OneThree:
                                cement = totalVolume.Value * Mass.FromPounds(31.59);
                                sand = totalVolume.Value * Volume.FromCubicYards(0.0405);
                                keepReadingKey2 = false;
                                break;

                            case Dosage.OneFour:
                                cement = totalVolume.Value * Mass.FromPounds(25.15);
                                sand = totalVolume.Value * Volume.FromCubicYards(0.0431);
                                keepReadingKey2 = false;
                                break;

                            case Dosage.OneFive:
                                cement = totalVolume.Value * Mass.FromPounds(20.97);
                                sand = totalVolume.Value * Volume.FromCubicYards(0.0445);
                                keepReadingKey2 = false;
                                break;

                            default:
                                Console.WriteLine("Please choose only one number from the index:");
                                Console.WriteLine();
                                break;
                        }
                    }
                    catch
                    {
                        MessageCatch();                                     //public static void messageCatch()
                        return;                                             //Stop the program from further executing.
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"CEMENT:{cement}");
            Console.WriteLine($"SAND  :{sand}");
            Console.WriteLine();




            //SIXT PART: ART ASCCI
            double numberRow = 0;                                                                                     //Save the number of rows of bricks.
            double numberColumns = 0;                                                                                 //Save the number of brick columns.
            //Get the number of rows and columns depending on the system of units
            if (system == 1)
            {
                switch (indexEnumMetric)
                {
                    case BrickBondingMetric.Soga:
                        numberRow = Ladrillo.QuantityInMeter(h => heightBrick, brickUsed, joinVertical) * height;
                        numberColumns = Ladrillo.QuantityInMeter(l => lenghtBrick, brickUsed, joinHorizontal) * lenght;
                        break;

                    case BrickBondingMetric.Tizon:
                        numberRow = Ladrillo.QuantityInMeter(h => heightBrick, brickUsed, joinVertical) * height;
                        numberColumns = Ladrillo.QuantityInMeter(w => widthBrick, brickUsed, joinHorizontal) * lenght;
                        break;
                }                
            }
            else if (system == 2)
            {
                switch (indexEnumImperial)
                {
                    case BrickBondingImperial.Stretcher:
                        numberRow = Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical) * height;
                        numberColumns = Ladrillo.QuantityInFeets(l => lenghtBrick, brickUsed, joinHorizontal) * lenght;
                        break;

                    case BrickBondingImperial.Header:
                        numberRow = Ladrillo.QuantityInFeets(h => heightBrick, brickUsed, joinVertical) * height;
                        numberColumns = Ladrillo.QuantityInFeets(w => widthBrick, brickUsed, joinHorizontal) * lenght;
                        break;
                }        
            }

            //Print a brick wall if it does not have openings
            double borderB = 0;                                                                                         //Save the number of empty spaces to place the cut bricks
            if (confirmWindows == 2 && confirmDoor == 2)
            {
                //Metric system
                if (system == 1)
                {
                    if ((BrickBondingMetric.Soga == indexEnumMetric || BrickBondingMetric.Panderete == indexEnumMetric) //The conditions of numbers of columns and rows are equivalent 
                        && numberRow < 38 && numberColumns < 29)                                                        //to these measurements in meters: height < 5 && lenght < 7.3 
                    {
                        for (int i = 0; i < numberRow; i++)
                        {
                            for (int j = 0; j < numberColumns + 1; j++)
                            {
                                if (i % 2 == 0 && j < numberColumns)
                                {
                                    Console.Write("▀▀▀ ");
                                }
                                else if (i % 2 != 0 && j > borderB && j < numberColumns)
                                {
                                    Console.Write("▀▀▀ ");
                                }
                                else if (i % 2 != 0)
                                {
                                    Console.Write("▀ ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (BrickBondingMetric.Tizon == indexEnumMetric && height < 5 && lenght < 7.3)
                    {
                        for (int i = 0; i < numberRow - height; i++)
                        {
                            for (int j = 0; j < numberColumns + 1; j++)
                            {
                                if (i % 2 == 0 && j < numberColumns)
                                {
                                    Console.Write("▀▀ ");
                                }
                                else if (i % 2 != 0 && j > borderB && j < numberColumns)
                                {
                                    Console.Write("▀▀ ");
                                }
                                else if (i % 2 != 0 && j > numberColumns)
                                {
                                    Console.Write("▀");
                                }
                                else if (i % 2 != 0)
                                {
                                    Console.Write(" ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
                //Imperial system
                if (system == 2)
                {
                    if (BrickBondingImperial.Stretcher == indexEnumImperial && numberRow < 38 && numberColumns < 29)  //The limit numbers of rows and columns are so 
                    {                                                                                                  //that the graph fits better on the console screen.
                        for (int i = 0; i < numberRow - 1; i++)
                        {
                            for (int j = 0; j < numberColumns + 1; j++)
                            {
                                if (i % 2 == 0 && j < numberColumns)
                                {
                                    Console.Write("▀▀▀ ");
                                }
                                else if (i % 2 != 0 && j > borderB && j < numberColumns)
                                {
                                    Console.Write("▀▀▀ ");
                                }
                                else if (i % 2 != 0)
                                {
                                    Console.Write("▀ ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (BrickBondingImperial.Header == indexEnumImperial && height < 5 && lenght < 7.3)
                    {
                        for (int i = 0; i < numberRow - height; i++)
                        {
                            for (int j = 0; j < numberColumns + 1; j++)
                            {
                                if (i % 2 == 0 && j < numberColumns)
                                {
                                    Console.Write("▀▀ ");
                                }
                                else if (i % 2 != 0 && j > borderB && j < numberColumns)
                                {
                                    Console.Write("▀▀ ");
                                }
                                else if (i % 2 != 0 && j > numberColumns)
                                {
                                    Console.Write("▀");
                                }
                                else if (i % 2 != 0)
                                {
                                    Console.Write(" ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine($"(Approximate drawing.- vertical bricks: {Math.Round(numberRow, 2)}, horizontal bricks: {Math.Round(numberColumns, 2)})");
            }



            //Unit conversion
            if (system == 2)                                                                                    //If at the beginning we declared everything in feet, now it will be converted into meters
            {                                                                                                   //meters for its graphical representation, this will not affect any calculations.
                lenght = lenght * 0.3048;
                height = height * 0.3048;
                lenghtDoor = lenghtDoor * 0.3048;
                heightDoor = heightDoor * 0.3048;
                lenghtWin = lenghtWin * 0.3048;
                heightWin = heightWin * 0.3048;
                for (int i = 0; i < numDoor; i++)
                {
                    heightsDoors[i] = heightsDoors[i] * 0.3048;
                    lenghtsDoors[i] = lenghtsDoors[i] * 0.3048;
                }
                for (int i = 0; i < numWindows; i++)
                {
                    heightsWindows[i] = heightsWindows[i] * 0.3048;
                    lenghtsWindows[i] = lenghtsWindows[i] * 0.3048;
                }
            }

            //Second option: Wall with openings
            if (confirmWindows == 1 || confirmDoor == 1 && lenght < 12 && height < 6)                                         //12m and 6m can enter the console when printing.
            {
                //Door configuration
                if (numDoor == 1)                                                                                             //If we only have one height and length, 
                {                                                                                                             //will add it to the list of heights and lengths.
                    lenghtsDoors.Add(lenghtDoor);
                    heightsDoors.Add(heightDoor);
                }

                int borderSide = 1;                                                                                           //Save the space between doors.
                double[] locationXDoor = new double[numDoor];                                                                 //List of "X" coordinates of each of the doors.
                double locationYDoor = (height * 5) - 1;                                                                      //"Y" coordinate, universal for all doors.
                double[] pixelXDoor = new double[numDoor];                                                                    //Pixels that belong to door characters (X coordinate).
                double[] pixelYDoor = new double[numDoor];                                                                    //Pixels belonging to door characters (y coordinate).

                double expLenghtsDoors = 0;                                                                                   //Saves the sum of all door lengths.  
                for (int i = 0; i < lenghtsDoors.Count; i++)                                                                  //Loop that will fill the previously declared lists.
                {
                    expLenghtsDoors += lenghtsDoors[i] * 10;
                    locationXDoor[i] = (lenght * 10) - (borderSide * (i + 1)) - expLenghtsDoors + ((lenghtsDoors[i] * 10) / 2);
                    pixelXDoor[i] = (lenghtsDoors[i] * 10) / 2;
                    pixelYDoor[numDoor - 1 - i] = heightsDoors[i] * 5;                                                        //[numDoor - 1 - i], makes me first examine the 1st door to the left.
                }

                //Window configuration    
                if (numWindows == 1)                                                                                          //If we only have one height and length, 
                {                                                                                                             //will add it to the list of heights and lengths.
                    lenghtsWindows.Add(lenghtWin);
                    heightsWindows.Add(heightWin);
                }

                double[] locationXWindow = new double[numWindows];                                                           //List of "X" coordinates of each of the windows.
                double locationYWindow = (height * 5) / 2;                                                                   //"Y" coordinate, universal for all windows.
                double[] pixelXWindow = new double[numWindows];                                                              //Pixels that belong to window characters (X coordinate). 
                double[] pixelYWindow = new double[numWindows];                                                              //Pixels belonging to window characters (y coordinate).

                double limitWindowWall = 0;                                                                                  //Saves the character space limit spanned by windows.
                if (confirmDoor == 1)
                {
                    limitWindowWall = locationXDoor[numDoor - 1] - ((lenghtsDoors[numDoor - 1] * 10) / 2);
                }
                else if (confirmDoor == 2)
                {
                    limitWindowWall = (lenght * 10) - 1;
                }

                double windowModule = (limitWindowWall / numWindows) / 2;                                                   //Half of each of the window spaces
                double exponentialModule = 0;                                                                               //Save spaces (equally) of window characters.
                for (int i = 0; i < numWindows; i++)                                                                        //Loop that will fill everything previously stated.
                {
                    exponentialModule += limitWindowWall / numWindows;        
                    locationXWindow[i] = (0 + exponentialModule) - windowModule;                                            //Find the center of the character space allocated for each window.
                    pixelXWindow[i] = (lenghtsWindows[i] * 10) / 2;
                    pixelYWindow[i] = (heightsWindows[i] * 5) / 2;
                }


                //ASCII art settings
                if (confirmDoor == 1 && confirmWindows == 1 && numWindows >= numDoor)                                        //Only if we declare windows and doors
                {
                    for (int j = 0; j < height * 5; j++)
                    {
                        for (int i = 0; i < lenght * 10; i++)
                        {
                            bool wall = false;
                            for (int h = 0; h < numWindows; h++)           
                            {
                                double dxDoor = 0;
                                double dyDoor = 0;

                                if (h < numDoor)
                                {
                                    dxDoor = i - locationXDoor[h];
                                    dyDoor = j - locationYDoor;
                                }
                                double dxWindow = i - locationXWindow[h];
                                double dyWindow = j - locationYWindow;
                                if (Math.Abs(dxWindow) < pixelXWindow[h] && Math.Abs(dyWindow) < pixelYWindow[h])
                                {
                                    Console.Write(" ");
                                    break;
                                }
                                else if (h < numDoor && (Math.Abs(dxDoor) < pixelXDoor[h] && Math.Abs(dyDoor) < pixelYDoor[h]))
                                {
                                    Console.Write("▓");
                                    break;
                                }
                                else if (h == numWindows - 1 || Math.Abs(dxWindow) < pixelXWindow[h] && Math.Abs(dyWindow) < pixelYWindow[h]
                                        && Math.Abs(dxDoor) < pixelXDoor[h] && Math.Abs(dyDoor) < pixelYDoor[h])
                                {
                                    wall = true;
                                    break;
                                }
                            }
                            if (wall == true)
                            {
                                Console.Write("█");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"(Approximate drawing.- Lenght: {lenght}, height: {height})");
                }

                if (confirmDoor == 1 && confirmWindows == 1 && numWindows < numDoor)                                            //Only if we declare windows and doors
                {
                    for (int j = 0; j < height * 5; j++)
                    {
                        for (int i = 0; i < lenght * 10; i++)
                        {
                            bool wall = false;
                            for (int h = 0; h < numDoor; h++)           
                            {
                                double dxWindow = 0;
                                double dyWindow = 0;
                                if (h < numWindows)
                                {
                                dxWindow = i - locationXWindow[h];
                                dyWindow = j - locationYWindow;
                                }
                                double dxDoor = i - locationXDoor[h];
                                double dyDoor = j - locationYDoor;

                                if (h < numWindows && (Math.Abs(dxWindow) < pixelXWindow[h] && Math.Abs(dyWindow) < pixelYWindow[h]))
                                {
                                    Console.Write(" ");
                                    break;
                                }
                                else if (Math.Abs(dxDoor) < pixelXDoor[h] && Math.Abs(dyDoor) < pixelYDoor[h])
                                {
                                    Console.Write("▓");
                                    break;
                                }
                                else if (h == numDoor - 1 || Math.Abs(dxWindow) > pixelXWindow[h] && Math.Abs(dyWindow) > pixelYWindow[h]
                                        && Math.Abs(dxDoor) > pixelXDoor[h] && Math.Abs(dyDoor) > pixelYDoor[h])
                                {
                                    wall = true;
                                    break;
                                }
                            }
                            if (wall == true)
                            {
                                Console.Write("█");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"(Approximate drawing.- Lenght: {lenght}, height: {height})");
                }

                else if (confirmDoor == 1 && confirmWindows == 2)                                                        //Only if I declare doors and only doors.
                {
                    for (int j = 0; j < height * 5; j++)
                    {
                        for (int i = 0; i < lenght * 10; i++)
                        {
                            bool wall = false;
                            for (int h = 0; h < numDoor; h++)
                            {
                                double dxDoor = i - locationXDoor[h];
                                double dyDoor = j - locationYDoor;
                                if (Math.Abs(dxDoor) < pixelXDoor[h] && Math.Abs(dyDoor) < pixelYDoor[h])
                                {
                                    Console.Write("▓");
                                    break;
                                }
                                else if (h == numDoor - 1 || Math.Abs(dxDoor) > pixelXDoor[h] && Math.Abs(dyDoor) > pixelYDoor[h])
                                {
                                    wall = true;
                                    break;
                                }
                            }
                            if (wall == true)
                            {
                                Console.Write("█");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"(Approximate drawing.- Lenght: {lenght}, height: {height})");
                }

                else if (confirmWindows == 1 && confirmDoor == 2)                                                      //Only if I declare windows and only windows.
                {
                    for (int j = 0; j < height * 5; j++)
                    {
                        for (int i = 0; i < lenght * 10; i++)
                        {
                            bool wall = false;
                            for (int h = 0; h < numWindows; h++)
                            {
                                double dxWindow = i - locationXWindow[h];
                                double dyWindow = j - locationYWindow;
                                if (Math.Abs(dxWindow) < pixelXWindow[h] && Math.Abs(dyWindow) < pixelYWindow[h])
                                {
                                    Console.Write(" ");
                                    break;
                                }
                                else if (h == numWindows - 1 || Math.Abs(dxWindow) > pixelXWindow[h] && Math.Abs(dyWindow) > pixelYWindow[h])
                                {
                                    wall = true;
                                    break;
                                }
                            }
                            if (wall == true)
                            {
                                Console.Write("█");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"(Approximate drawing.- Lenght: {lenght}, height: {height})");
                }
            }





            Console.ReadKey(); 
        }

        //Function that will save me lines of code due to its repetitiveness
        public static void MessageCatch()
        {
            Console.WriteLine("Wrong inputs, please enter only numerical numbers");
            Console.WriteLine();
            Console.WriteLine("Press an key to exit.....");
            Console.ReadKey();                                                     
        }
    }
}
