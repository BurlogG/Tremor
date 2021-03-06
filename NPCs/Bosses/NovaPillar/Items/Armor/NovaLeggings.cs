using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.NovaPillar.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class NovaLeggings : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 16;
			item.rare = 10;
			item.defense = 16;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Leggings");
			Tooltip.SetDefault("18% increased alchemical damage\n" + 
"12% increased alchemical critical strike chance\n" +
"14% increased movement speed");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.18f;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 12;
			player.moveSpeed += 0.14f;
			player.maxRunSpeed += 0.14f;
			Lighting.AddLight((int)((player.position.X + player.width / 2) / 16f), (int)((player.position.Y + player.height / 2) / 16f), 0.8f, 0.7f, 0.3f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3467, 12);
			recipe.AddIngredient(null, "NovaFragment", 15);
			recipe.AddTile(412);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
