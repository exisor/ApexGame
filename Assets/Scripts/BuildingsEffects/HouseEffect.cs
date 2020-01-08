using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEffect : MonoBehaviour
{
    public GameObject building;
    private Color color;

    public int BuildPrice = 2;
    public int BuildingRiseLimit = 10;

    void Start()
    {
        color = building.GetComponent<SpriteRenderer>().color;
        building.GetComponent<SpriteRenderer>().color = color;
    }

    void Update()
    {
        if (color.a == 1f)
        {
            ResoursesController.DirthumanCounter = ResoursesController.DirthumanCounter - BuildPrice;
            ResoursesController.DirthumansLimit = ResoursesController.DirthumansLimit + BuildingRiseLimit;

            // Перерасчет каунтеров
            ResoursesController.MooshromsDecrease = (Mathf.CeilToInt(ResoursesController.WormsFloatCounter / 10) + ResoursesController.DirthumanCounter) * -1; // Черви и грзнолюды

            color.a = 0.99f;
        }
    }
}