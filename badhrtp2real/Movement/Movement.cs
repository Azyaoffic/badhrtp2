using System;
using badhrtp2real.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public static class Movement
{
    private static int speed = 4;
    private static int width;
    private static int height;

    public static void setBounds(int w, int h)
    {
        width = w;
        height = h;
    }

    public static void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public static int MoveRight(int currentX)
    {
        return currentX + speed;
    }
    
    public static int MoveRight(int currentX, int diffSpeed)
    {
        return currentX + diffSpeed;
    }
    
    public static int MoveLeft(int currentX)
    {
        return currentX - speed;
    }
    
    public static int MoveLeft(int currentX, int diffSpeed)
    {
        return currentX - diffSpeed;
    }
    
    public static int MoveUp(int currentY)
    {
        return currentY - speed;
    }
    
    public static int MoveUp(int currentY, int diffSpeed)
    {
        return currentY - diffSpeed;
    }
    
    public static int MoveDown(int currentY)
    {
        return currentY + speed;
    }
    
    public static int MoveDown(int currentY, int diffSpeed)
    {
        return currentY + diffSpeed;
    }

    public static bool willCollide(int x, int y, Keys direction)
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
                        if (mapColl.Intersects(new Rectangle(x + speed, y, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
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
                        if (mapColl.Intersects(new Rectangle(x - speed, y, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
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
                        if (mapColl.Intersects(new Rectangle(x, y - speed, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
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
                        if (mapColl.Intersects(new Rectangle(x, y + speed, Game1.CHARACTER_WIDTH, Game1.CHARACTER_HEIGHT)))
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