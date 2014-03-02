using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    class Wood : Item
    {
        const int GeneralWoodValue = 2;
        public int Value { get; set; }

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
            this.Value = GeneralWoodValue;
        }

        public override void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    {
                        if (this.Value > 0)
                        {
                            this.Value--;
                        }

                        break;
                    }
                default:
                    {
                        base.UpdateWithInteraction(interaction);
                        break;
                    }
            }
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Wood };
        }
    }
}
