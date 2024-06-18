using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledCS;


namespace badhrtp2real.Graphics;

public static class TileOperations
{
    public static int TILE_WIDTH = 16;
    public static int TILE_HEIGHT = 16;

    public static int MAP_WIDTH;
    public static int MAP_HEIGHT;


    public static Dictionary<int, Texture2D> tileNumberToTexture = new();
    public static List<(Rectangle, int)> mapTiles = new();
    public static List<Rectangle> mapCollisions = new();
    public static Texture2D fullTexture;

    public static void loadTilesIntoDict()
    {
        tileNumberToTexture.Add(1, GetPartOfTexture(fullTexture, new Rectangle(0, 0, TILE_WIDTH, TILE_HEIGHT)));
        tileNumberToTexture.Add(2, GetPartOfTexture(fullTexture, new Rectangle(16, 0, TILE_WIDTH, TILE_HEIGHT)));
    }

    // thanks chatgpt
    private static Texture2D GetPartOfTexture(Texture2D sourceTexture, Rectangle sourceRectangle)
    {
        // Create an array to hold the color data of the source rectangle
        Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];

        // Get the color data from the source texture
        sourceTexture.GetData(0, sourceRectangle, data, 0, data.Length);

        // Create a new texture to hold the extracted part
        Texture2D partTexture =
            new Texture2D(sourceTexture.GraphicsDevice, sourceRectangle.Width, sourceRectangle.Height);

        // Set the color data to the new texture
        partTexture.SetData(data);

        return partTexture;
    }

    public static void loadTiledMap()
    {

        string workingDirectory = Environment.CurrentDirectory;
        var map = new TiledMap(Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Content\map.tmx");
        MAP_WIDTH = map.Width * TILE_WIDTH;
        MAP_HEIGHT = map.Height * TILE_HEIGHT;

        foreach (var layer in map.Layers)
        {
            if (layer.chunks != null) // collision layer does not have chunks
            {
                foreach (var chunk in layer.chunks)
                {
                    for (var y = 0; y < chunk.height; y++)
                    {
                        for (var x = 0; x < chunk.width; x++)
                        {
                            int bottomOfWindowOffset = MAP_HEIGHT;

                            var index = (y * chunk.width) + x;

                            int tileType = chunk.data[index];

                            if (tileType == 0) continue;
                    
                            mapTiles.Add((new Rectangle((x + chunk.x) * TILE_WIDTH, (y + chunk.y) * TILE_HEIGHT, TILE_WIDTH, TILE_HEIGHT), tileType));
                    
                        }
                    }
                }
            }
            else  // this time collision
            {
                foreach (var item in layer.objects)
                {
                    mapCollisions.Add(new Rectangle((int) item.x,(int) item.y,(int) item.width,(int) item.height));
                }
            }
        }
    }
}