using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace badhrtp2real;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Dictionary<String, Texture2D> textureMap = new Dictionary<string, Texture2D>();

    private int characterX = 0;
    private int characterY = 0;

    public static int CHARACTER_WIDTH = 32;
    public static int CHARACTER_HEIGHT = 32;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        textureMap.Add("ball", Content.Load<Texture2D>("Red-Ball-PNG-Pic"));
        Movement.setBounds(Window.ClientBounds.Width, Window.ClientBounds.Height);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            int newPos = Movement.MoveRight(characterX);
            if (!Movement.willCollide(newPos, characterY, Keys.Right))
            {
                characterX = newPos;
            }
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            int newPos = Movement.MoveLeft(characterX);
            if (!Movement.willCollide(newPos, characterY, Keys.Left))
            {
                characterX = newPos;
            }
        }
        // Y axis goes down, 0,0 is top left????
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            int newPos = Movement.MoveUp(characterY);
            if (!Movement.willCollide(newPos, characterY, Keys.Up))
            {
                characterY = newPos;
            }
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            int newPos = Movement.MoveDown(characterY);
            if (!Movement.willCollide(newPos, characterY, Keys.Down))
            {
                characterY = newPos;
            }
        }
        
        Console.WriteLine(characterX + "," + characterY);
        

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        
        _spriteBatch.Begin();
        
        // rectangle to make it small
        Rectangle sizeRectangle = new Rectangle(characterX, characterY, CHARACTER_WIDTH, CHARACTER_HEIGHT);
        _spriteBatch.Draw(textureMap["ball"], sizeRectangle, Color.White);
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}