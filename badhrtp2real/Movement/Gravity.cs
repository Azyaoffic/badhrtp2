using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public static class Gravity
{
    public static double PULLING_GRAVITY = 2;  // pixels per update tick, for now at least

    public static void ApplyGravity(Player.Player player)
    {
        if (!Movement.willCollide(player.COORDINATE_X, player.COORDINATE_Y, Keys.Down))
        {
            player.COORDINATE_Y += PULLING_GRAVITY;
        }
        
    }
}