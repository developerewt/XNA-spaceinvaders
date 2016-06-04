using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
	public class Enemie: Microsoft.Xna.Framework.DrawableGameComponent
	{
		public Vector2 position = Vector2.Zero;
		Vector2 velocity = Vector2.One;
		private Texture2D enemie;
		Game1 game;
		int originX;
		int originY;
		int directionX;
		SpriteBatch spriteBatch;
		int limitHeight;
		int limitWidth;
		int numberOfTicks = 0;




		public Enemie (Game1 game1) : base (game1)
		{
			this.game = game1;

			//should only ever be one player, all value defaults set in Initialize()
		}

		private void Circular(GameTime gameTime){

			Random rnd = new Random();
			int move = rnd.Next(8, 9);

			float time = (float)gameTime.TotalGameTime.TotalSeconds; 
			float speed = move;
			float radius = 100;
			//Center origin position x,y
			if ((originX == limitWidth) || (originX == 0))
				directionX *=-1;

			originX=originX+directionX;



			Vector2 origin = new Vector2(originX,0);

			position.X = (float)(Math.Cos(time * speed) * radius + origin.X);
			position.Y = (float)(Math.Sin(time*speed) * radius + origin.Y);
			
		}

		private void SpaceInvadersMovement(GameTime gameTime){

			Random rnd = new Random();
			int move = rnd.Next(8, 9); // speed

			float time = (float)gameTime.TotalGameTime.TotalSeconds; 
			float speed = move;
			float radius = 10;

			if ((originX == limitWidth) || (originX == 0)) {
				directionX *= -1;
				originX = originX + directionX;
				originY += 20;
			} else {
				originX=originX+directionX;
			
			}
			//Center origin position x,y
			Vector2 origin = new Vector2(originX,originY);
			position.Y = (float)(Math.Sin (time * speed) * radius + origin.Y);
			position.X=originX;
		}


		public override void Update (GameTime gameTime)
		{
			
			this.Circular2 (gameTime);

		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			enemie = Game.Content.Load<Texture2D> ("enemie"); 
			velocity = new Vector2 (1, 1);
			position.Y =  (enemie.Width + enemie.Width / 2);
			position.X = Game.GraphicsDevice.Viewport.Width/ 2 - enemie.Width;
			originX = 1;
			originY = 0;
			directionX =1;
			limitHeight = game.GraphicsDevice.Viewport.Height - (enemie.Height);
			limitWidth = game.GraphicsDevice.Viewport.Width - (enemie.Width);

		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			spriteBatch.Begin ();

			spriteBatch.Draw (enemie, position, Color.White);

			spriteBatch.End ();
		}
	}
}

