using System;
public class Item : IComparable<Item>
{

    public Item(int weight, int price)
    {
        this.Weight = weight;
        this.Price = price;
    }

    public int Weight { get; set; }
    public int Price { get; set; }


    public int CompareTo(Item other)
    {
        return this.Weight.CompareTo(other.Weight);
    }
}
