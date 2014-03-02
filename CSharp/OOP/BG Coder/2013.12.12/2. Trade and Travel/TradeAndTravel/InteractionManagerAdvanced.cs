using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class InteractionManagerAdvanced : InteractionManager
    {
        public InteractionManagerAdvanced()
            : base()
        { }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {

            switch (itemTypeString)
            {
                case "armor":
                    {
                        return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                        break;
                    }
                case "weapon":
                    {
                        item = new Weapon(itemNameString, itemLocation);
                        break;
                    }
                case "wood":
                    {
                        item = new Wood(itemNameString, itemLocation);
                        break;
                    }
                case "iron":
                    {
                        item = new Iron(itemNameString, itemLocation);
                        break;
                    }
                default:
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    {
                        return base.CreateLocation(locationTypeString, locationName);
                    }
                case "mine":
                    {
                        location = new Mine(locationName);
                        break;
                    }
                case "forest":
                    {
                        location = new Forest(locationName);
                        break;
                    }
                default:
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "drop":
                case "pickup":
                case "sell":
                case "buy":
                case "inventory":
                case "money":
                case "travel":
                    {
                        base.HandlePersonCommand(commandWords, actor);
                        break;
                    }
                case "gather":
                    {
                        HandleGaterInteraction(commandWords, actor);
                        break;
                    }
                case "craft":
                    {
                        HandleCraftCommand(commandWords, actor);
                        break;
                    }
                default:
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "shopkeeper":
                case "traveller":
                    {
                        return base.CreatePerson(personTypeString, personNameString, personLocation);
                        break;
                    }
                case "merchant":
                    {
                        person = new Traveller(personNameString, personLocation);
                        break;
                    }
                default:
                    break;
            }
            return person;

        }

        private void HandleGaterInteraction(string[] commandWords, Person actor)
        {
            var inventory = actor.ListInventory();

            if (actor.Location.LocationType == LocationType.Forest)
            {
                foreach (var item in inventory)
                {
                    if (ownerByItem[item] == actor && item.ItemType == ItemType.Weapon)
                    {
                        var woodenItem = new Wood(commandWords[2]);
                        this.AddToPerson(actor, woodenItem);

                        woodenItem.UpdateWithInteraction("gather");
                    }
                }
            }

            if (actor.Location.LocationType == LocationType.Mine)
            {
                foreach (var item in inventory)
                {
                    if (ownerByItem[item] == actor && item.ItemType == ItemType.Armor)
                    {
                        var ironItem = new Iron(commandWords[2]);
                        this.AddToPerson(actor, ironItem);

                        ironItem.UpdateWithInteraction("gather");
                    }
                }
            }

        }

        private void HandleCraftCommand(string[] commandWords, Person actor)
        {
            var inventory = actor.ListInventory();
            bool hasIron = false;
            bool hasWood = false;

            foreach (var item in inventory)
            {
                if (ownerByItem[item] == actor)
                {
                    if (item.ItemType == ItemType.Iron)
                    {
                        hasIron = true;
                    }

                    if (item.ItemType == ItemType.Wood)
                    {
                        hasWood = true;
                    }
                }
            }

            

            switch (commandWords[2])
            {
                case "armor":
                    {
                        if (commandWords[2] == "armor" && hasIron)
                        {
                            var armorItem = new Armor(commandWords[3]);
                            this.AddToPerson(actor, armorItem);

                            armorItem.UpdateWithInteraction("crafted");
                        }

                        break;
                    }
                case "weapon":
                    {
                        if (hasWood && hasIron)
                        {
                            var weaponItem = new Weapon(commandWords[3]);
                            this.AddToPerson(actor, weaponItem);

                            weaponItem.UpdateWithInteraction("crafted");
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
