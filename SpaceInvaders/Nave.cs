using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
	public class Nave: Microsoft.Xna.Framework.DrawableGameComponent
	{
		public Vector2 position = Vector2.Zero;
		Vector2 velocity = Vector2.One;
		private Texture2D nave;
		Game1 game;
		SpriteBatch spriteBatch;
		KeyboardState currentKBState;
		KeyboardState previousKBState;
		int limitHeight;
		int limitWidth;


		public Nave (Game1 game1) : base (game1)
		{
			this.game = game1;

			//should only ever be one player, all value defaults set in Initialize()
		}



		public override void Update (GameTime gameTime)
		{
			previousKBState = currentKBState;
			currentKBState = Keyboard.GetState ();


			if (currentKBState.IsKeyDown (Keys.Left)) {
				if (position.X >= 0)
					position.X -= velocity.X;
			} else if (currentKBState.IsKeyDown (Keys.Right)) {
				if (position.X <= limitWidth)
					position.X += velocity.X;
			} else if (currentKBState.IsKeyDown (Keys.Up)) {
				if (position.Y >= 0)
					position.Y -= velocity.Y;
			} else if (currentKBState.IsKeyDown (Keys.Down)) {
				if (position.Y <= limitHeight)
					position.Y += velocity.Y;
			}



			if (currentKBState.IsKeyDown (Keys.LeftControl) && !previousKBState.IsKeyDown (Keys.LeftControl)) {
				this.game.Components.Add (
					new Bullet (
						ref this.game,
						new Vector2(nave.Width/2+position.X, position.Y)

					)
				);

			}


		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			nave = Game.Content.Load<Texture2D> ("nave"); 
			velocity = new Vector2 (5, 5);
			position.Y = Game.GraphicsDevice.Viewport.Height - (nave.Width + nave.Width / 2);
			position.X = Game.GraphicsDevice.Viewport.Width / 2 - nave.Width;
			limitHeight = game.GraphicsDevice.Viewport.Height - (nave.Height);
			limitWidth = game.GraphicsDevice.Viewport.Width - (nave.Width);

		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			spriteBatch.Begin ();

			spriteBatch.Draw (nave, position, Color.White);

			spriteBatch.End ();
		}
	}
}

