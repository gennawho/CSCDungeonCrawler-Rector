using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room
{

    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private player currentPlayer;
    public room(string name)
    {
        this.name = name;
    }
    public void addPlayer(player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);
    }

    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }
    public void addExit(string direction, room destination)
    {
        if(howManyExits < theExits.Length)
        {
            Exit e = new Exit(direction, destination);
            this.theExits[howManyExits] = e;
            howManyExits++;
        }
      
    }
}

