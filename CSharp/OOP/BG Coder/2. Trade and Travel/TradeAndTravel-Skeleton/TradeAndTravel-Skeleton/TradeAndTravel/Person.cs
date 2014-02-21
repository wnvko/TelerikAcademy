using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Person : WorldObject, IGatheringLocation
    {
        HashSet<Item> inventoryItems;

        public Location Location { get; protected set; }

        public Person(string name, Location location)
            : base(name)
        {
            this.Location = location;
            this.inventoryItems = new HashSet<Item>();
        }

        public void AddToInventory(Item item)
        {
            this.inventoryItems.Add(item);
        }

        public void RemoveFromInventory(Item item)
        {
            this.inventoryItems.Remove(item);
        }

        public List<Item> ListInventory()
        {
            List<Item> items = new List<Item>();
            foreach (var item in this.inventoryItems)
            {
                items.Add(item);
            }

            return items;
        }

        public ItemType GatheredType
        {
            get { throw new NotImplementedException(); }
        }

        public ItemType RequiredItem
        {
            get { throw new NotImplementedException(); }
        }

        public Item ProduceItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
