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
    float speed = 1.0f;
    void Start()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("onCollisionEnter");
    }
    private void OnTriggerEnter(Collider other)
    {
       
        EditorSceneManager.LoadScene("Scene2");
    }
    private void OnTriggerExit(Collider other)
    {
       
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.NorthDoor.transform.position, this.transform.position, Time.deltaTime * speed);
        MySingleton.exitDoor = 'n';
    }
}
