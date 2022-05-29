using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace XPortalChallenge.Common.GlobalItems
{
    public class BannedItems : GlobalItem
    {

        private static IEnumerable<int> bannedItemsIds = new List<int>()
        {
            ItemID.FlyingCarpet,

            // Soaring insygnia
            ItemID.EmpressFlightBooster,
            // Schield of culululu
            ItemID.EoCShield,
            // Jars, Bootles
            ItemID.TsunamiInABottle,
            ItemID.BlizzardinaBottle,
            ItemID.CloudinaBottle,
            ItemID.FartinaJar,
            ItemID.SandstorminaBottle,
            // Ballons
            ItemID.BundleofBalloons,
            ItemID.CloudinaBalloon,
            ItemID.SandstorminaBalloon,
            ItemID.BlizzardinaBalloon,
            ItemID.BlueHorseshoeBalloon,
            ItemID.WhiteHorseshoeBalloon,
            ItemID.YellowHorseshoeBalloon,
            ItemID.FartInABalloon,
            ItemID.BalloonHorseshoeFart, // Green ballon
            ItemID.BalloonHorseshoeHoney, // Amber ballon
            ItemID.SharkronBalloon,
            ItemID.BalloonHorseshoeSharkron, // Pink ballon
            ItemID.BalloonPufferfish,
            ItemID.HoneyBalloon,
            ItemID.ShinyRedBalloon,
            // Other
            ItemID.AmphibianBoots,
            ItemID.Flipper,
            ItemID.FrogFlipper,
            ItemID.FrogWebbing,
            ItemID.FrogLeg,
            ItemID.FrogGear,
            ItemID.MasterNinjaGear,
            ItemID.ShoeSpikes,
            ItemID.ClimbingClaws,
            ItemID.PogoStick,
            ItemID.CelestialShell,
            ItemID.ArcticDivingGear,
            ItemID.LightningBoots,
            ItemID.JellyfishDivingGear,
            ItemID.TerrasparkBoots,
            ItemID.FrostsparkBoots,
            ItemID.FairyBoots,
            ItemID.RocketBoots,
            ItemID.SpectreBoots,
            ItemID.NeptunesShell,
            ItemID.Tabi,
            // Potions
            ItemID.GravitationPotion,
        };

        private static IEnumerable<int> bannedHooksProjectiles = new List<int>() {
            ProjectileID.Hook,
            ProjectileID.AmberHook,
            ProjectileID.AntiGravityHook,
            ProjectileID.BatHook,
            ProjectileID.CandyCaneHook,
            ProjectileID.ChristmasHook,
            ProjectileID.DualHookBlue,
            ProjectileID.DualHookRed,
            ProjectileID.FishHook,
            ProjectileID.GemHookAmethyst,
            ProjectileID.GemHookDiamond,
            ProjectileID.GemHookEmerald,
            ProjectileID.GemHookRuby,
            ProjectileID.GemHookSapphire,
            ProjectileID.GemHookTopaz,
            ProjectileID.IlluminantHook,
            ProjectileID.LunarHookNebula,
            ProjectileID.LunarHookSolar,
            ProjectileID.LunarHookStardust,
            ProjectileID.LunarHookVortex,
            ProjectileID.QueenSlimeHook,
            ProjectileID.SlimeHook,
            ProjectileID.SquirrelHook,
            ProjectileID.StaticHook,
            ProjectileID.TendonHook,
            ProjectileID.ThornHook,
            ProjectileID.TrackHook,
            ProjectileID.WoodHook,
            ProjectileID.WormHook,
            ProjectileID.IvyWhip,
            ProjectileID.SkeletronHand,
            ProjectileID.Web
        };

        private bool CheckIfIsAWingsAccessory(Item item) => item.wingSlot > 0;

        private bool CheckIfIsInBannedList(Item item) => bannedItemsIds.Contains(item.type);

        private bool CheckIfIsMount(Item item) => item.mountType > 0;

        private bool IsGrapplingHook(Item item) => bannedHooksProjectiles.Contains(item.shoot);



        private bool IsBanned(Item item) => CheckIfIsAWingsAccessory(item) || CheckIfIsInBannedList(item) || CheckIfIsMount(item) || IsGrapplingHook(item);

        private static string GetItemNewName(Item item) => $"[Disabled]: {item.Name}";

        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return IsBanned(item);
        }

        public override void SetDefaults(Item item)
        {
            item.SetNameOverride(GetItemNewName(item));
            item.rare = ItemRarityID.LightRed;
            item.accessory = false;
            item.color = Color.Red;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.RemoveRange(1, tooltips.Count - 1);

            TooltipLine tooltip = new TooltipLine(Mod, "XPortalChallenge", $"This item is disabled by XPortalChallenge mod, you can sell it tho.") { OverrideColor = Color.Red };

            tooltips.Add(tooltip);
        }

        public override bool CanUseItem(Item item, Player player)
        {
            return false;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            Main.NewText($"Removing banned item ({item.Name}) from accessory slot", Color.Red);
            player.DropItem(null, player.position, ref item);
        }

        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            return false;
        }
    }
}
