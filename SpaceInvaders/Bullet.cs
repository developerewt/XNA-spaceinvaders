using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System.Linq;
namespace SpaceInvaders
{
	class Bullet : Microsoft.Xna.Framework.DrawableGameComponent
	{
		public Vector2 position = Vector2.Zero;
		Vector2 navePosition = Vector2.Zero;
		Vector2 velocity = Vector2.One;
		private Texture2D bullet; 
		SpriteBatch spriteBatch;
		public Boolean delete;
		Game game;

	

		public Bullet (ref Game1 game,Vector2 positionNave) : base (game)
		{
			navePosition = positionNave;
			this.game = game;

			//should only ever be one player, all value defaults set in Initialize()
		}
		private void checkCollision() {
	
 
			int countComp = Game.Components.Count;
			Enemie enemie = null;
			//For each enemy
			for(int i = (countComp-1); i >= 0; i--) {
				//Check Enemy type
				if (Game.Components [i].GetType () == typeof(Enemie)) {
					enemie = ((Enemie)Game.Components [i]);
					//Check bullet collition with Enemy
					if (
						((enemie.position.X<=position.X)&&(position.X<=(enemie.position.X+enemie.Width))) &&
						((enemie.position.Y>=position.Y)&&(position.Y<=(enemie.position.Y+enemie.Width)))
					   )

					Game.Components.RemoveAt (i);
				}

			}
		}

		public override void Update (GameTime gameTime)
		{
			this.checkCollision ();

			if ((position.Y >= -this.bullet.Height))
				position.Y -= velocity.Y;
			else {
				this.delete = true;
				Game.Components.Remove (this);
				//this = null;
				//this.SetInitPosition (navePosition);
			}
			base.Update (gameTime);
		}

		private void SetInitPosition (Vector2 positionNave)
		{
			
			position.Y = positionNave.Y;
			position.X = positionNave.X;
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			spriteBatch = new SpriteBatch (this.Game.GraphicsDevice);
		}

		public override void Initialize ()
		{
			base.Initialize ();

			delete = false;
			bullet = Game.Content.Load<Texture2D> ("bullet"); 
			velocity = new Vector2 (10, 10);
			this.SetInitPosition (navePosition);
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);
			spriteBatch.Begin ();
			spriteBatch.Draw (bullet, position, Color.White);
			spriteBatch.End ();
		}
	}
}

