using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drzwi : MonoBehaviour
{

    public GameObject DoorButton;
    public GameObject Door;
    public float smooth;

    private Quaternion DoorOpen;
    private Quaternion DoorClosed;

    void Start()
    {

        Door = GameObject.Find("Object001");
        DoorButton = GameObject.Find("DoorButton");
        DoorButton.SetActive(false);
    }

    void OnTriggerEnter(Collider cube)
    {

        if (cube.tag == "DoorButton")
            DoorButton.SetActive(true);
        Debug.Log("button activated");

        DoorOpen = Door.transform.rotation = Quaternion.Euler(0, -90, 0);
        DoorClosed = Door.transform.rotation;

        Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
        Debug.Log("Door Opened");
    }
}