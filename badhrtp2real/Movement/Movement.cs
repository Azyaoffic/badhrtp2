using System;
using badhrtp2real.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public static class Movement
{
    private static double width;
    private static double height;

    public static Vector2 velocity = Vector2.Zero;
    public static Vector2 acceleration = Vector2.Zero;
    public static float speed = 0.05f; // Adjust the speed as needed.
    public static float friction = 0.99f; // Adjust for friction effect.
    public static float jumpSpeed = 6.0f; // Initial jump speed
    public static bool isJumping;



    public static void setBounds(double w, double h)
    {
        width = w;
        height = h;
    }

    public static void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public static void MoveByVector()
    {
        // Update velocity based on acceleration
        velocity += acceleration;
        
        // Apply friction to the velocity
        velocity *= friction;

        // Rounding velocity to 0
        if (acceleration.X == 0f && Math.Abs(velocity.X) < 0.1)
        {
            velocity.X = 0;
        }
        
        // Update player position based on velocity
        Game1.player.COORDINATE_X += velocity.X;
        Game1.player.COORDINATE_Y += velocity.Y;
        
        
        Console.WriteLine(velocity);
        Console.WriteLine(acceleration);
        
        // Reset acceleration for the next frame
        acceleration = Vector2.Zero;
        CollisionChecks();

    }

    private static void CollisionChecks()
    {
        if (velocity.X > 0)
        {
            willCollide(Game1.player.COORDINATE_X, Game1.player.COORDINATE_Y - 4, Keys.Right);
        }
        else
        {
            willCollide(Game1.player.COORDINATE_X, Game1.player.COORDINATE_Y - 4, Keys.Left);
        }
    }

    public static void MoveRight()
    {
        if (!willCollide(Game1.player.COORDINATE_X, Game1.player.COORDINATE_Y - 4, Keys.Right))
        {
            acceleration += Vector2.UnitX * speed;
        }
    }

    public static void MoveLeft()
    {
        if (!willCollide(Game1.player.COORDINATE_X, Game1.player.COORDINATE_Y - 4, Keys.Left))
        {
            acceleration -= Vector2.UnitX * speed;
        }    
    }

    public static void Jump()
    {
        if (willCollide(Game1.player.COORDINATE_X, Game1.player.COORDINATE_Y + 1, Keys.Down) && !isJumping)
        {
            velocity.Y = -jumpSpeed; // Initial jump velocity
            isJumping = true;
        }
    }
    //
    // public static void MoveDown()
    // {
    //     acceleration += Vector2.UnitY * speed;
    // }

    public static bool willCollide(double x, double y, Keys direction)
    {

        switch (direction)
        {
            case Keys.Right: 
                var collBorderR = x + Game1.CHARACTER_WIDTH >= width;
                if (collBorderR)
                {
                    velocity.X = 0;
                    acceleration.X = 0;
                    return collBorderR;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) (x + speed),(int) y, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
                            velocity.X = 0;
                            acceleration.X = 0;
                            return true;
                        }
                    }

                    return false;
                }
            case Keys.Left:
                var collBorderL = x <= 0;
                if (collBorderL)
                {
                    velocity.X = 0;
                    acceleration.X = 0;
                    return collBorderL;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) (x - speed), (int) y, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
                            velocity.X = 0;
                            acceleration.X = 0;
                            return true;
                        }
                    }

                    return false;
                }
            case Keys.Up:
                var collBorderU = y <= 0;
                if (collBorderU)
                {
                    velocity.Y = 0;
                    acceleration.Y = 0;
                    return collBorderU;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) x, (int) (y - speed), Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
                            velocity.Y = 0;
                            acceleration.Y = 0;
                            return true;
                        }
                    }

                    return false;
                }
            case Keys.Down:
                var collBorderD = y + Game1.CHARACTER_HEIGHT >= height;
                if (collBorderD)
                {
                    return collBorderD;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) x,(int) (y + speed), Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
                            return true;
                        }
                    }

                    return false;
                }
        }

        return false;
    }
}