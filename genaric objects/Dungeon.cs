using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{

    private string name;
    private room startRoom;
    private room currentRoom;
    private player thePlayer;

    public Dungeon(string name)
    {
        this.name = name;
    }

    public void setStartRoom(room r)
    {
        this.startRoom = r;
    }

    public void addPlayer(player thePlayer)
    {
        this.thePlayer = thePlayer;
        this.startRoom.addPlayer(this.thePlayer);
    }
}
