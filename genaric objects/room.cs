using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room
{

    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private player currentPlayer;
    private gameObject[] pickups = new gameObject[4];
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
        }
      

    }
    public void removePlayer(string direction)
    {
        Exit theExit this.GetExitGivenDirection(direction);
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
    }
    public void removePickup(string direction)
    {
        if (direction.Equals("north"))
        {
            pickups[0].setActive(false);
        }
        if (direction.Equals("east"))
        {
            pickups[1].setActive(false);
        }
        if (direction.Equals("south"))
        {
            pickups[2].setActive(false);
        }
        if (direction.Equals("west"))
        {
            pickups[3].setActive(false);
        }
    }

}

