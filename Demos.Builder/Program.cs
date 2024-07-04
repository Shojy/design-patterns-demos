using Demos.Builder;

var sportsCar = new CarBuilder()
    .AddFrame(Frame.Sports)
    .AddEngine(Engine.Electric)
    .AddDoors(2)
    .AddTransmission(Transmission.Automatic)
    .WithColour(Color.Red)
    .Build();
    
Console.WriteLine($"Sporty: {sportsCar}");

var familyCar = new CarBuilder()
    .AddFrame(Frame.Suv)
    .AddEngine(Engine.Diesel)
    .AddDoors(5)
    .AddTransmission(Transmission.Manual)
    .WithColour(Color.Silver)
    .Build();
    
Console.WriteLine($"Family: {familyCar}");