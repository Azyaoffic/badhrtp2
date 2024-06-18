namespace badhrtp2real.Player;

public class RedBall : Player
{
    public double COORDINATE_X;
    public double COORDINATE_Y;
    public double WEIGHT = 1;

    public RedBall(double coordinateX, double coordinateY)
    {
        COORDINATE_X = coordinateX;
        COORDINATE_Y = coordinateY;
    }
}