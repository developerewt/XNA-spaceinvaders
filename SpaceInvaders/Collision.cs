using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
	public class Collision: Microsoft.Xna.Framework.GameComponent
	{



		public Collision (Game game): base (game)
		{
			

			//should only ever be one player, all value defaults set in Initialize()
		}

		public Boolean checkCollision(Vector2 position) {

			int countComp = Game.Components.Count;
			Enemie enemie = null;
			//For each enemy
			for(int i = (countComp-1); i >= 0; i--) {
				//Check Enemy type
				if (Game.Components [i].GetType () == typeof(Enemie)) {
					enemie = ((Enemie)Game.Components [i]);
					//Check bullet collition with Enemy
					if (
						((enemie.position.X <= position.X) && (position.X <= (enemie.position.X + enemie.Width))) &&
						((enemie.position.Y <= position.Y) && (position.Y <= (enemie.position.Y + enemie.Width)))) {
						//Delete Enemy
						Game.Components.RemoveAt (i);

						//Delete bullet

						return true;


					}
				}

			}

			return false;

		}
	}
}

