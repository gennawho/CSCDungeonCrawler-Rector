using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class DungeonController : MonoBehaviour
    {
    public GameObject northDoor, southDoor, eastDoor, westDoor;

    // Start is called before the first frame update
    private string mapIndexToStringForExit(int index)
        {
            if (index == 0)
            {
                return "north";
            }
            else if (index == 1)
            {
                return "south";
            }
            else if (index == 2)
            {
                return "east";
            }
            else if (index == 3)
            {
                return "west";
            }
            else
            {
                return "?";
            }
        }
        void Start()
        {
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            if (theCurrentRoom.hasExit("north"))
            {
                   this.northDoor.SetActive(false);
            }
            if (theCurrentRoom.hasExit("south"))
            {
                this.southDoor.SetActive(false);
            }
            if (theCurrentRoom.hasExit("east"))
            {
                this.eastDoor.SetActive(false);
            }
            if (theCurrentRoom.hasExit("west"))
            {
                this.westDoor.SetActive(false);
            }

        /*if(MySingleton.theDungeon == null)
        {
            MySingleton.generateDungeon();
        }   


            MySingleton.theCurrentRoom = new Room("a room");
            if (MySingleton.previousExit != MySingleton.exitDoor)
            {
                MySingleton.addRoom(MySingleton.theCurrentRoom); //Not using this yet...

                int openDoorIndex = Random.Range(0, 4);
                this.closedDoors[openDoorIndex].SetActive(false); //visually make an open door
                MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));

                for (int i = 0; i < 4; i++)
                {
             //if I am not looking at the already open door
                    if (openDoorIndex != i)
                    {
                //should this door be open or not?
                        int coinFlip = Random.Range(0, 2);
                        if (coinFlip == 1)
                        {
                     //open the door in that direction
                            this.closedDoors[i].SetActive(false); //visually make an open door
                         MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(i));

                        }
                    }
                }

            }*/

    }


    // Update is called once per frame
    void Update()
        {
        
        }
    }
