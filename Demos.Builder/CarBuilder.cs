namespace Demos.Builder;

public class CarBuilder
{
    private Car _car;

    public CarBuilder AddEngine(Engine engine)
    {
        _car = _car with { Engine = engine };
        return this;
    }
    
    public CarBuilder AddFrame(Frame frame)
    {
        _car = _car with { Frame = frame };
        return this;
    }

    public CarBuilder WithColour(Color color)
    {
        _car = _car with { Color = color };
        return this;
    }

    public CarBuilder AddTransmission(Transmission transmission)
    {
        _car = _car with { Transmission = transmission };
        return this;
    }

    public CarBuilder AddDoors(int doors)
    {
        _car = _car with { Doors = doors };
        return this;
    }

    public Car Build()
    {
        return _car;
    }
}