using System;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum Type
    {
        None,
        Nashi,
        Kani,
        Washi,
    }

    public Type type;
    public Sprite sprite;
    //public long heal;
   // public float hpHealPoints;
    
    
    

    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
        //this.hpHealPoints = hpHealPoints;
     
    }
    
}
