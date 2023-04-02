using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    public static FuelScript instance;
    [SerializeField] private Image fuelBar;
    [SerializeField] private float fuel = 100f;
    [SerializeField] private float fuelConsumption = 1f;
    [SerializeField] private bool isMoving;
    
    private float currentFuel;

    private void Start()
    {
        instance = this;
        currentFuel = fuel;
        UpdateUI();
    }
    private void Update()
    {
        currentFuel -= fuelConsumption * Time.deltaTime;
        UpdateUI();
        if(currentFuel <= 0)
        {
            GameManagerScript.instance.GameOver();
        }
    }
    private void UpdateUI()
    {
        fuelBar.fillAmount = currentFuel / fuel;
    }
    public void Refuel()
    {
        currentFuel = fuel;
        UpdateUI();
    }
    
}
