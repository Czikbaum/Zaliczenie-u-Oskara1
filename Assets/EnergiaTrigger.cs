using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaTrigger : MonoBehaviour
{
    public EnergiaManager EnergiaTimer;

    public void OnTriggerEnter(Collider other)
    {
        EnergiaTimer.EnergiaTime = 200;
        Debug.Log("cipa");
    }



}
