using System;
using badhrtp2real.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public static class Movement
{
    private static double speed = 4;
    private static double width;
    private static double height;
    
    public static void setBounds(double w, double h)
    {
        width = w;
        height = h;
    }

    public static void SetSpeed(double newSpeed)
    {
        speed = newSpeed;
    }

    public static double MoveRight(double currentX)
    {
        return currentX + speed;
    }
    
    public static double MoveRight(double currentX, double diffSpeed)
    {
        return currentX + diffSpeed;
    }
    
    public static double MoveLeft(double currentX)
    {
        return currentX - speed;
    }
    
    public static double MoveLeft(double currentX, double diffSpeed)
    {
        return currentX - diffSpeed;
    }
    
    public static double MoveUp(double currentY)
    {
        return currentY - speed;
    }
    
    public static double MoveUp(double currentY, double diffSpeed)
    {
        return currentY - diffSpeed;
    }
    
    public static double MoveDown(double currentY)
    {
        return currentY + speed;
    }
    
    public static double MoveDown(double currentY, double diffSpeed)
    {
        return currentY + diffSpeed;
    }

    public static bool willCollide(double x, double y, Keys direction)
    {

        switch (direction)
        {
            case Keys.Right: 
                var collBorderR = x + Game1.CHARACTER_WIDTH >= width;
                if (collBorderR)
                {
                    return collBorderR;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) (x + speed),(int) y, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            case Keys.Left:
                var collBorderL = x <= 0;
                if (collBorderL)
                {
                    return collBorderL;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) (x - speed), (int) y, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            case Keys.Up:
                var collBorderU = y <= 0;
                if (collBorderU)
                {
                    return collBorderU;
                }
                else
                {
                    foreach (var mapColl in TileOperations.mapCollisions)
                    {
                        if (mapColl.Intersects(new Rectangle((int) x, (int) (y - speed), Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
                        {
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