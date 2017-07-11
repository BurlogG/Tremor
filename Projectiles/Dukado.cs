﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class Dukado : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 158;
			projectile.height = 42;
			projectile.scale = 0.98f;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 120;
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dukado");

		}


		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
			{
				crit = true;
			}
		}

		public override void AI()
		{
			int num613 = 10;
			int num614 = 15;
			float num615 = 1f;
			int num616 = 150;
			int num617 = 42;
			if (projectile.velocity.X != 0f)
			{
				projectile.direction = (projectile.spriteDirection = -Math.Sign(projectile.velocity.X));
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 6)
			{
				projectile.frame = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				projectile.localAI[0] = 1f;
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.scale = ((float)(num613 + num614) - projectile.ai[1]) * num615 / (float)(num614 + num613);
				projectile.width = (int)((float)num616 * projectile.scale);
				projectile.height = (int)((float)num617 * projectile.scale);
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				projectile.netUpdate = true;
			}
			if (projectile.ai[1] != -1f)
			{
				projectile.scale = ((float)(num613 + num614) - projectile.ai[1]) * num615 / (float)(num614 + num613);
				projectile.width = (int)((float)num616 * projectile.scale);
				projectile.height = (int)((float)num617 * projectile.scale);
			}
			if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
			{
				projectile.alpha -= 30;
				if (projectile.alpha < 60)
				{
					projectile.alpha = 60;
				}
			}
			else
			{
				projectile.alpha += 30;
				if (projectile.alpha > 150)
				{
					projectile.alpha = 150;
				}
			}
			if (projectile.ai[0] > 0f)
			{
				projectile.ai[0] -= 1f;
			}
			if (projectile.ai[0] == 1f && projectile.ai[1] > 0f && projectile.owner == Main.myPlayer)
			{
				projectile.netUpdate = true;
				Vector2 center = projectile.Center;
				center.Y -= (float)num617 * projectile.scale / 2f;
				float num618 = ((float)(num613 + num614) - projectile.ai[1] + 1f) * num615 / (float)(num614 + num613);
				center.Y -= (float)num617 * num618 / 2f;
				center.Y += 2f;
				Projectile.NewProjectile(center.X, center.Y, projectile.velocity.X, projectile.velocity.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 10f, projectile.ai[1] - 1f);
			}
			if (projectile.ai[0] <= 0f)
			{
				float num622 = 0.104719758f;
				float num623 = (float)projectile.width / 5f;
				float num624 = (float)(Math.Cos((double)(num622 * -(double)projectile.ai[0])) - 0.5) * num623;
				projectile.position.X = projectile.position.X - num624 * (float)(-(float)projectile.direction);
				projectile.ai[0] -= 1f;
				num624 = (float)(Math.Cos((double)(num622 * -(double)projectile.ai[0])) - 0.5) * num623;
				projectile.position.X = projectile.position.X + num624 * (float)(-(float)projectile.direction);
				return;
			}
		}
	}
}
