// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using MarsRoverBusiness;
using MarsRoverCommon;

bool exit = false;
int xPlateau = 0, yPlateau = 0;
var roverList = new List<MarsRover>();
MarsRover rover = null;

GetCoordinatesOfPlateau();

while (!exit)
{
    ReadInput();
    if (exit)
        break;
    ReadDirectionInput();
}

Console.Clear();
foreach (var item in roverList)
{
    WriteLastCoordinates(item);
}

void ReadDirectionInput()
{
    Console.WriteLine("Enter directions for Rover");
    var directions = Console.ReadLine();
    foreach (var item in directions)
    {
        switch (item.ToString().ToUpper())
        {
            case "M":
                if (!(rover.Move()))
                {
                    rover.CantMove = true;
                    break;
                }
                break;
            default:
                rover.Turn(item.ToString().ToUpper());
                break;
        }
    }
}

void ReadInput()
{
    Console.WriteLine("Enter the Rover's position: (enter the -1 to exit)");
    var coordinateOfRover = Console.ReadLine()?.Split(" ");
    int xRover = 0, yRover = 0;
    var direction = string.Empty;
    EDirect.Direction startDirection = EDirect.Direction.E;

    if (coordinateOfRover?.Length == 1 && Convert.ToInt32(coordinateOfRover[0]) == -1)
    {
        exit = true;
        Console.WriteLine("Exiting from the program...");
        return;
    }

    try
    {
        if (coordinateOfRover?.Length > 0)
        {
            xRover = Convert.ToInt32(coordinateOfRover[0]);
            yRover = Convert.ToInt32(coordinateOfRover[1]);
            direction = coordinateOfRover[2];
            Int32.TryParse(direction, out int result);
            if (result == 0)
                startDirection = (EDirect.Direction)Enum.Parse(typeof(EDirect.Direction), direction.ToUpper());
            else
            {
                Console.WriteLine("Please enter valid value for direction Ex: 1 2 N");
                ReadInput();
            }
        }
        else
        {
            ReadInput();
        }
    }
    catch
    {
        Console.WriteLine("Please enter valid values for coordinates and start direction each seperated by spaces Ex: 1 2 N");
        ReadInput();
    }

    rover = new MarsRover(xRover, yRover, startDirection, xPlateau, yPlateau);
    roverList.Add(rover);
}

void GetCoordinatesOfPlateau()
{
    Console.WriteLine("Enter Upper-right coordinates of the plateau:");
    var coordinateOfPlateau = Console.ReadLine()?.Split(" ");
    try
    {
        if (coordinateOfPlateau?.Length >= 2)
        {
            xPlateau = Convert.ToInt32(coordinateOfPlateau[0]);
            yPlateau = Convert.ToInt32(coordinateOfPlateau[1]);
        }
        else
        {
            Console.WriteLine("Please enter 2 valid values for coordinates each seperated with space Ex: 2 2");
            GetCoordinatesOfPlateau();
        }
    }
    catch
    {
        Console.WriteLine("Please Check entered coordinates. It must be a number");
        GetCoordinatesOfPlateau();
        //throw;
    }
}

void WriteLastCoordinates(MarsRover rover)
{
    if (rover.CantMove)
        Console.WriteLine( String.Format("Cannot Move! Last positon was.. {0} {1} {2}", rover.StartX.ToString(), rover.StartY.ToString(), rover.startDirection.ToString()));
    else
        Console.WriteLine(String.Format("Coordinates: ({0},{1}), direction:{2}", rover.StartX.ToString(), rover.StartY.ToString(), rover.startDirection.ToString()));
}



