public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        //Convert laps to miles when each lap is 50 meters
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}
