using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public GameObject NorthDoor;
    public GameObject EastDoor;
    public GameObject SouthDoor;
    public GameObject WestDoor;
    public GameObject Center;
    float speed = 1.0f;
    void Start()
    {
      /*  if(MySingleton.exitDoor == 'n') {
            this.transform.position = SouthDoor.transform.position;
        }
        else if (MySingleton.exitDoor == 's')
        {
            this.transform.position = NorthDoor.transform.position;
        }
        else if (MySingleton.exitDoor == 'w')
        {
            this.transform.position = EastDoor.transform.position;
        }
        else if (MySingleton.exitDoor == 'e')
        {
            this.transform.position = WestDoor.transform.position;
        }*/

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(Center.transform.position, this.transform.position, speed * Time.deltaTime);
    }
}
