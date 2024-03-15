using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton 
{
    public static string exitDoor = "?";
    private static room[] theRooms = new Room[100];
    private static int numRooms = 0;
    public static room theCurrentRoom = null;
    public static string previousExit = "?";

    public static void addRoom(room r)
    {
        //static context
        MySingleton.theRooms[numRooms] = r;
        MySingleton.numRooms++;
    }
}
