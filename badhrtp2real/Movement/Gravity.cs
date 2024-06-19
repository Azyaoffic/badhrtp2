using badhrtp2real.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public static class Gravity
{
    public static Vector2 PULLING_GRAVITY_VECTOR = new Vector2(0, 0.3f);

    public static void ApplyGravity(Player.Player player)
    {
        if (!Movement.willCollide(player.COORDINATE_X, player.COORDINATE_Y, Keys.Down))
        {
            Movement.acceleration += PULLING_GRAVITY_VECTOR;
        }
        else
        {
            Game1.player.COORDINATE_Y -= Game1.player.COORDINATE_Y % TileOperations.TILE_HEIGHT;
            Movement.velocity.Y = 0;
            Movement.isJumping = false;
        }
    }
}
