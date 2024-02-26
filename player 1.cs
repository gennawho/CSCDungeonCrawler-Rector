using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;


public class player1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Player thePlayer;
    public TextMeshPro tm;
    public GameObject NorthDoor;
    public GameObject EastDoor;
    public GameObject SouthDoor;
    public GameObject WestDoor;
    private bool amMoving = false;
    private bool atCenter = false;
    float speed = 5.0f;
    public GameObject center;
    private void turnOffExits()
    {
        this.NorthDoor.gameObject.SetActive(false);
        this.SouthDoor.gameObject.SetActive(false);
        this.EastDoor.gameObject.SetActive(false);
        this.WestDoor.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.NorthDoor.gameObject.SetActive(true);
        this.SouthDoor.gameObject.SetActive(true);
        this.EastDoor.gameObject.SetActive(true);
        this.WestDoor.gameObject.SetActive(true);
    }

    void Start()
    {
        this.turnOffExits();

        //disable the middle collider until we know what our initial state will be
        //it should already be disabled by default, but for clarity, lets do it here
        this.middleOfTheRoom.SetActive(false);

        if (!MySingleton.exitDoor.Equals("?"))
        {
            //mark ourselves as moving since we are entering the scene through one of the exits
            this.amMoving = true;

            //we will be positioning the player by one of the exits so we can turn on the middle collider
            this.middleOfTheRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (MySingleton.exitDoor.Equals("north"))
            {
                this.gameObject.transform.position = this.southDoor.transform.position;
                this.gameObject.transform.LookAt(this.northDoor.transform.position);
                //rb.MovePosition(this.southExit.transform.position);
                MySingleton.previousExit = "south";
            }
            else if (MySingleton.exitDoor.Equals("south"))
            {
                this.gameObject.transform.position = this.northDoor.transform.position;
                this.gameObject.transform.LookAt(this.southDoor.transform.position);
                //rb.MovePosition(this.northExit.transform.position);
                MySingleton.previousExit = "north";
            }
            else if (MySingleton.exitDoor.Equals("west"))
            {
                this.gameObject.transform.position = this.eastDoor.transform.position;
                this.gameObject.transform.LookAt(this.westDoor.transform.position);
                MySingleton.previousExit = "east";
                //rb.MovePosition(this.eastExit.transform.position);
            }
            else if (MySingleton.exitDoor.Equals("east"))
            {
                this.gameObject.transform.position = this.westDoor.transform.position;
                this.gameObject.transform.LookAt(this.eastDoor.transform.position);
                MySingleton.previousExit = "west";
                //rb.MovePosition(this.westExit.transform.position);
            }
            //StartCoroutine(turnOnMiddle());
        }
        else
        {
            //We will be positioning the play at the middle
            //so keep the middle collider off for this run of the scene
            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
        

}
   // IEnumerator TurnOnMiddle()
   // {
        //yield return new WaitForSeconds(1);
        //this.center.SetActive(true);
        
    //}
    private void OnCollisionEnter(Collision collision)
    {
        print("onCollisionEnter");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("DungeonRoom");
        }
        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.exitDoor.Equals("?"))
        {
            this.atCenter = true;
            MySingleton.exitDoor = "middle";

        }
    }
    private void OnTriggerExit(Collider other)
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.exitDoor = "north";
            this.gameObject.transform.LookAt(this.NorthDoor.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.exitDoor = "south";
            this.gameObject.transform.LookAt(this.SouthDoor.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.exitDoor = "west";
            this.gameObject.transform.LookAt(this.WestDoor.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.exitDoor = "east";
            this.gameObject.transform.LookAt(this.EastDoor.transform.position);

        }

        //make the player move in the current direction
        if (MySingleton.exitDoor.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.NorthDoor.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.exitDoor.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.SouthDoor.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.exitDoor.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.WestDoor.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.exitDoor.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.EastDoor.transform.position, this.speed * Time.deltaTime);
        }
    }
}
