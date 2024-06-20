using System;
using System.Collections.Generic;
using badhrtp2real.Graphics;
using badhrtp2real.Player;
using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Dictionary<string, Texture2D> textureMap = new();

    public static Player.Player player;
    private Camera camera;

    public static int CHARACTER_WIDTH = 32;
    public static int CHARACTER_HEIGHT = 32;

    public static int WINDOW_WIDTH;
    public static int WINDOW_HEIGHT;

    private Dictionary<Direction, bool> directionMovement = new();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player = new RedBall(0, 0);
        camera = new Camera(_graphics.GraphicsDevice);
        
        // initialize direction dict
        directionMovement.Add(Direction.LEFT, false);
        directionMovement.Add(Direction.RIGHT, false);
        directionMovement.Add(Direction.UP, false);
        directionMovement.Add(Direction.DOWN, false);

        WINDOW_WIDTH = Window.ClientBounds.Width;
        WINDOW_HEIGHT = Window.ClientBounds.Height;
        Movement.setBounds(WINDOW_WIDTH, WINDOW_HEIGHT);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        textureMap.Add("ball", Content.Load<Texture2D>("Red-Ball-PNG-Pic"));
        
        // Tile stuff
        TileOperations.fullTexture = Content.Load<Texture2D>("BadhrtpTiles");
        TileOperations.loadTilesIntoDict();
        TileOperations.loadTiledMap();


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        directionMovement[Direction.RIGHT] = false;
        directionMovement[Direction.LEFT] = false;
        directionMovement[Direction.UP] = false;
        directionMovement[Direction.DOWN] = false;
        

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            directionMovement[Direction.RIGHT] = true;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            directionMovement[Direction.LEFT] = true;
        }
        // Y axis goes down, 0,0 is top left????
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            directionMovement[Direction.UP] = true;
        }
        //
        // if (Keyboard.GetState().IsKeyDown(Keys.Down))
        // {
        //     directionMovement[Direction.DOWN] = true;
        // }
        
        // Console.WriteLine(characterX + "," + characterY);
        CalculateMovement();
        Gravity.ApplyGravity(player);
        
        camera.Update(gameTime);
        camera.Position = new Vector2((float)player.COORDINATE_X, (float)player.COORDINATE_Y);
        
        base.Update(gameTime);
    }

    private void CalculateMovement()
    {
        if (directionMovement[Direction.RIGHT])
        {
                Movement.MoveRight();
        }
    
        if (directionMovement[Direction.LEFT])
        {
                Movement.MoveLeft();
        }
    
        if (directionMovement[Direction.UP])
        {
                Movement.Jump();
        }
        
        // if (directionMovement[Direction.DOWN])
        // {
        //     if (!Movement.willCollide(player.COORDINATE_X, player.COORDINATE_Y, Keys.Down))
        //     {
        //         Movement.MoveDown();
        //     }
        // }

        // Update the player's movement based on velocity and acceleration
        Movement.MoveByVector();
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        
        _spriteBatch.Begin(camera);
        
        // draw terrain
        foreach (var tileRectangleAndType in TileOperations.mapTiles)
        {
            _spriteBatch.Draw(TileOperations.tileNumberToTexture[tileRectangleAndType.Item2], tileRectangleAndType.Item1, Color.White);
        }
        
        
        // rectangle to make it small
        Rectangle sizeRectangle = new Rectangle((int) player.COORDINATE_X, (int) player.COORDINATE_Y, CHARACTER_WIDTH, CHARACTER_HEIGHT);
        _spriteBatch.Draw(textureMap["ball"], sizeRectangle, Color.White);
        
        
        // // test to see textures
        // _spriteBatch.Draw(TileOperations.tileNumberToTexture[1], new Rectangle(100, 100, TileOperations.TILE_WIDTH, TileOperations.TILE_HEIGHT), Color.White);
        // _spriteBatch.Draw(TileOperations.tileNumberToTexture[2], new Rectangle(200, 200, TileOperations.TILE_WIDTH, TileOperations.TILE_HEIGHT), Color.White);

        
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}