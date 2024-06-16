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

        if (Keyboard.GetState().IsKeyDown(Keys.Right)) characterX++;
        if (Keyboard.GetState().IsKeyDown(Keys.Left)) characterX--;
        // Y axis goes down, 0,0 is top left????
        if (Keyboard.GetState().IsKeyDown(Keys.Up)) characterY--;
        if (Keyboard.GetState().IsKeyDown(Keys.Down)) characterY++;
        
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
        Rectangle sizeRectangle = new Rectangle(characterX, characterY, 32, 32);
        _spriteBatch.Draw(textureMap["ball"], sizeRectangle, Color.White);
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}