using System;
using System.Collections.Generic;

public class Album
{
    public string Name { get; set; }
    public string Artst { get; set; }
    public DateTime Year { get; set; }
    public string Producer { get; set; }
    public decimal Price { get; set; }
    public ICollection<Song> Songs { get; set; }

    public Album()
    {
        this.Songs = new List<Song>();
    }
}