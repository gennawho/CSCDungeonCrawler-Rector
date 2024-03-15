using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit 
{
    private string direction;
    private room destinationRoom;

    public Exit(string direction, room destinationRoom)
    {
        this.direction = direction;
        this.destinationRoom = destinationRoom;
    }

    public string getDirection()
    {
        return this.direction;
    }
    public room GetDestinationRoom()
    {
        return destinationRoom;
    }
}
