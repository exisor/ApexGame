using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooshromEffect : MonoBehaviour
{
    public GameObject building;
    private Color color;

    public int BuildPrice = 4;
    public int BuildingRiseLimit = 100;
    public int BuildingRiseGrow = 10;

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
            ResoursesController.MooshromsLimit = ResoursesController.MooshromsLimit + BuildingRiseLimit;
            ResoursesController.MooshromsGrow = ResoursesController.MooshromsGrow + BuildingRiseGrow;

            // Перерасчет каунтеров
            ResoursesController.MooshromsDecrease = (Mathf.CeilToInt(ResoursesController.WormsFloatCounter / 10) + ResoursesController.DirthumanCounter) * -1; // Черви и грзнолюды

            color.a = 0.99f;
        }
    }

}
