namespace Demos.Builder;

public readonly record struct Car
{
    public Engine Engine { get; init; }
    public Frame Frame { get; init; }
    public Color Color { get; init; }
    public int Doors { get; init; }
    public Transmission Transmission { get; init; } 
}

public enum Engine { Diesel, Petrol, Hybrid, Electric }

public enum Frame { Sports, Hatchback, Suv, Saloon }

public enum Color { Red, Blue, Purple, White, Black, Silver }

public enum Transmission { Manual, Automatic }