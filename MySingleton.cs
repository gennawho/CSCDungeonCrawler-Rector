using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton 
{
    public static string exitDoor = "?";
    private static Room[] theRooms = new Room[100];
    private static int numRooms = 0;
    public static Room theCurrentRoom = null;
    public static string previousExit = "?";

    public static void addRoom(Room r)
    {
        //static context
        MySingleton.theRooms[numRooms] = r;
        MySingleton.numRooms++;
    }
}
