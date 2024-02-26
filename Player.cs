using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room
{
    private string name;
    private int exitNum;

    public room(string name)
    {
        
        this.name = name;

    }
    public string display()
    {
        string text = this.name + "->" + this.hp;
        return text;
    }
    public string getName()
    {
        return this.name;   
    }
    public int getHP()
    {
        return this.hp; 
    }
}

