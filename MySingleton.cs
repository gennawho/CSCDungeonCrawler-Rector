using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton 
{
    public static string exitDoor = "?";
    public static player thePlayer;
    public static Dungeon theDungeon = MySingleton.generateDungeon();
    public static int numOfPellets = 0;

    public static Dungeon generateDungeon()
    {
        room r1 = new room("R1");
        room r2 = new room("R2");
        room r3 = new room("R3");
        room r4 = new room("R4");
        room r5 = new room("R5");
        room r6 = new room("R6");
        theDungeon = new Dungeon("the cross");
        theDungeon.setStartRoom(r1);
        r1.addExit("north", r2);
        r2.addExit("south", r1);
        r2.addExit("north", r3);
        r3.addExit("south", r2);
        r3.addExit("west", r4);
        r3.addExit("north", r6);
        r3.addExit("east", r5);
        r4.addExit("east", r3);
        r5.addExit("west", r3);
        r6.addExit("south",r3);
        MySingleton.thePlayer = new Player("Mike");
        theDungeon.addPlayer(MySingleton.thePlayer);
        return theDungeon;
    }
}
