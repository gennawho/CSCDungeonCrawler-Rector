using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room
{

    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private player currentPlayer;
    private Pellet northPellet = null;
    private Pellet southPellet = null;
    private Pellet eastPellet = null;
    private Pellet westPellet = null;
    private string name;
    public room(string name)
    {
        this.name = name;
    }
    public void addPlayer(player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);
    }

    public void addExit(string direction, room destination)
    {
        if(howManyExits < theExits.Length)
        {
            Exit e = new Exit(direction, destination);
            this.theExits[howManyExits] = e;
            howManyExits++;
            if (direction.Equals("north"))
            {
                this.northPellet = new ArmorPellet();
            }
            else if (direction.Equals("south"))
            {
                this.southPellet = new ArmorPellet();
            }
            else if (direction.Equals("east"))
            {
                this.eastPellet = new ArmorPellet();
            }
            else if (direction.Equals("west"))
            {
                this.westPellet = new ArmorPellet();
            }
        }
      

    }
    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void removePlayer(string direction)
    {
        Exit theExit = this.GetExitGivenDirection(direction);
        room destinationRoom = theExit.GetDestinationRoom();
        destinationRoom.addPlayer(this.currentPlayer);  
        currentPlayer = null;
    }
    private Exit GetExitGivenDirection(string direction)
    {
        for (int i = 0; i< this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return this.theExits[i];
            }
            else
            {
                return null;
            }
        }
        return null;
    }
    public void addPellet(Pellet p, string direction)
    {
        if(direction.Equals("north"))
        {
            this.northPellet=p;
        }
        if (direction.Equals("south"))
        {
            this.southPellet = p;
        }
        if (direction.Equals("east"))
        {
            this.eastPellet = p;
        }
        if (direction.Equals("west"))
        {
            this.westPellet = p;
        }
    }
    public void removePellet(string direction)
    {
        if (direction.Equals("north"))
        {
            this.northPellet = null;
        }
        if (direction.Equals("south"))
        {
            this.southPellet = null;
        }
        if (direction.Equals("east"))
        {
            this.eastPellet = null;
        }
        if (direction.Equals("west"))
        {
            this.westPellet = null;
        }
    }
    public bool hasPellet(string direction)
    {
        if (direction.Equals("north"))
        {
           return this.northPellet != null;
        }
        else if (direction.Equals("south"))
        {
            return this.southPellet != null;
        }
        else if (direction.Equals("east"))
        {
            return this.eastPellet != null;
        }
        else if (direction.Equals("west"))
        {
            return this.westPellet != null;
        }
            return false;
    }

}

