using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            FuelScript.instance.Refuel();
            Destroy(gameObject);
        }
    }
}
