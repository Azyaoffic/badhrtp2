namespace badhrtp2real.Player;

public class RedBall : Player
{
    public override double COORDINATE_X { get; set; }
    public override double COORDINATE_Y { get; set; }
    public override double WEIGHT { get; set; } = 1;

    public RedBall(double coordinateX, double coordinateY)
    {
        COORDINATE_X = coordinateX;
        COORDINATE_Y = coordinateY;
    }
}