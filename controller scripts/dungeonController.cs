using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    public class DungeonController : MonoBehaviour
    {
        public GameObject northDoor, southDoor, eastDoor, westDoor;
        public GameObject northPellet, southPellet, eastPellet, westPellet;
        public TextMeshPro tm;

    // Start is called before the first frame update
        
        void Start()
        {
            setDoors();
            setPellets();

        }
        // Update is called once per frame
        void Update()
        {
            // update the tmpro with num of pellets
        }
        private void setDoors()
        {
            room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
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
        }
    private void setPellets()
    {
        room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (!theCurrentRoom.hasPellet("north"))
        {
            this.northPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("south"))
        {
            this.southPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("east"))
        {
            this.eastPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("west"))
        {
            this.westPellet.SetActive(false);
        }
    }
}
