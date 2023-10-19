using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameObject vitoryPanel= GameObject.Find("VitoryPanel");
            //vitoryPanel.SetActive(true);
        }
    }
}
