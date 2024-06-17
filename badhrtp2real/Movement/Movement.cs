using System;
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
        
        return direction switch 
        {
            Keys.Right => x + Game1.CHARACTER_WIDTH >= width,
            Keys.Left => x <= 0,
            Keys.Up => y <= 0,
            Keys.Down => y + Game1.CHARACTER_HEIGHT >= height
        };
    }
}