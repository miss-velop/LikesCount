using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikesCount;
//Interfaces for the services
public interface IRobotService
{
    Robot BuildRobotDog(List<Parts> parts);
    Robot BuildRobotCat(List<Parts> parts);
    Robot BuildRobotDrone(List<Parts> parts);
    Robot BuildRobotCar(List<Parts> parts);
}

public interface IPartsService
{
    List<Parts> GetParts(Enum type);
}

public interface ICarService
{
    Car BuildCar(List<Parts> parts);
}

// Refactored Factory class
public class Factory
{
    private readonly IRobotService _robotService;
    private readonly IPartsService _partsService;
    private readonly ICarService _carService;

    //Dependency Injection pass services
    public Factory(IRobotService robotService, IPartsService partsService, ICarService carService)
    {
        _robotService = robotService ?? throw new ArgumentNullException(nameof(robotService));
        _partsService = partsService ?? throw new ArgumentNullException(nameof(partsService));
        _carService = carService ?? throw new ArgumentNullException(nameof(carService));
    }

    // Build robots
    public Robot BuildRobot(RobotType robotType)
    {
        var parts = _partsService.GetParts(robotType);
        return robotType switch
        {
            RobotType.RoboticDog => _robotService.BuildRobotDog(parts),
            RobotType.RoboticCat => _robotService.BuildRobotCat(parts),
            RobotType.RoboticDrone => _robotService.BuildRobotDrone(parts),
            RobotType.RoboticCar => _robotService.BuildRobotCar(parts),
            _ => throw new ArgumentException("Invalid robot type")
        };
    }

    //build cars
    public Car BuildCar(CarType carType)
    {
        var parts = _partsService.GetParts(carType);
        return carType switch
        {
            CarType.Toyota => _carService.BuildCar(parts),
            CarType.Ford => _carService.BuildCar(parts),
            CarType.Opel => _carService.BuildCar(parts),
            CarType.Honda => _carService.BuildCar(parts),
            _ => throw new ArgumentException("Invalid car type")
        };
    }
}

// Enums for robot and car types
public enum RobotType
{
    RoboticDog,
    RoboticCat,
    RoboticDrone,
    RoboticCar
}

public enum CarType
{
    Toyota,
    Ford,
    Opel,
    Honda
}

//parts class
public class Parts
{
    public string Name { get; set; }
    public string Description { get; set; }
}

//robot class
public class Robot
{
    public string Model { get; set; }
    public List<Parts> Parts { get; set; }

    public Robot(string model, List<Parts> parts)
    {
        Model = model;
        Parts = parts;
    }


}

//Car class 
public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public List<Parts> Parts { get; set; }

    public Car(string brand, string model, int year, List<Parts> parts)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Parts = parts;
    }


}

