using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ID;


namespace XPortalChallenge.Common.Players
{
    /// <summary>
    /// This is modded player for XPortalChallenge.
    /// Player starts with a PortalGun and CompanionCube.
    /// Player can not jump or use grappling hooks.
    /// </summary>
    public class XPortalChallengePlayer : ModPlayer
    {



        private IEnumerable<Item> challengeStartingItems = new List<Item>(){
            new Item(ItemID.PortalGun),
            new Item(ItemID.CompanionCube)
        };

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return challengeStartingItems;
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            // Disable usage of hooks.
            if(triggersSet.Grapple)
            {
                this.Player.controlHook = false;
            }
        }

        public override void OnEnterWorld(Player player)
        {
            foreach (Item item in challengeStartingItems)
            {
                if (!player.HasItem(item.netID))
                {
                    player.QuickSpawnItem(null, item.netID, 1);
                }
            }
        }
    }






}
