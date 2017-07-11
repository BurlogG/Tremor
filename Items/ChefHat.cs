using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ChefHat : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chef Hat");
			Tooltip.SetDefault("");
		}


	}
}
