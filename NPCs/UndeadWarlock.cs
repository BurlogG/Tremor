using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class UndeadWarlock : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Warlock");
			Main.npcFrameCount[npc.type] = 15;
		}
 

        const int ShootRate = 250; // ����� ����५�
        const int ShootDamage = 20; // �஭ �� �����.
        const float ShootKN = 1.0f; // ����뢠���
        const int ShootType = 96; // ��� �த���⠩�� ����� �㤥� �ந����� ����५.
        const float ShootSpeed = 4; // ��, � ⠪ �������, ����� �� ���쭮��� ����५�

        int TimeToShoot = ShootRate; // �६� �� ����५�.

    public override void SetDefaults()
    {
        npc.width = 28;
        npc.height = 46;
        npc.damage = 20;
        npc.defense = 11;
        npc.lifeMax = 340;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 3, 6, 2);
        npc.knockBackResist = 1f;
        npc.aiStyle = 3;
        aiType = 524;
        animationType = 21;
    }

    public override void AI()
    {
            if (--TimeToShoot <= 0 && npc.target != -1) Shoot(); // � �⮩ ��ப� �� ��६����� TimeToShot �⭨������ 1, � �᫨ TimeToShot < ��� = 0, � ��뢠���� ��⮤ Shoot()

        if(Main.rand.Next(210) == 0)
        {
            NPC.NewNPC((int)npc.position.X + 50, (int)npc.position.Y, 34);
        }

       for (int num74 = npc.oldPos.Length - 1; num74 > 0; num74--)
       {
            npc.oldPos[num74] = npc.oldPos[num74 - 1];
       }
            npc.oldPos[0] = npc.position;
    }

        void Shoot()
        {
            TimeToShoot = ShootRate; // ��⠭�������� �㫤�� ����५�
            Vector2 velocity = VelocityFPTP(npc.Center, Main.player[npc.target].Center, ShootSpeed); // ��� �� ����稬 �㦭�� velocity (���᭥��� ��㬥�⮢ ����)
            // 1 ��㬥�� - ������ �� ���ன �㤥� �뫥��� ����५
            // 2 ��㬥�� - ������ � ������ �� ������ ������� 
            // 3 ��㬥�� - ᪮���� ����५�
            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
        }

        Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
        {
            Vector2 move = pos2 - pos1;
            return move * (speed / (float)System.Math.Sqrt(move.X * move.X + move.Y * move.Y));
        }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UWGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UWGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UWGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UWGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UWGore3"), 1f);
        }
}


    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedBoss3 && !Main.dayTime && y < Main.worldSurface ? 0.008f : 0f;
    }
}}