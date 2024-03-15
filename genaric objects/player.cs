using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player
{
    private string name;
    private room currentRoom;
    public player(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }
    public room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(room r)
    {
        this.currentRoom = r;
    }
}
