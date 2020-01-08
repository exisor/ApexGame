using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResoursesController : MonoBehaviour
{
 
    public CalendarController Calendar;

    //--------------Грязнолюди--------------

    public Text DirthumanCounterText;
    public Text DirthumanSeasonChangeText;
    public Text DirthumanDelayChangeText;

    public static int DirthumanCounter = 10;
    public static int DirthumansLimit = 10;
    public static int DirthumanSeasonChange; 
    public static int DirthumansGrow;
    public static int DirthumansDecrease;
    public static int DirthumansOvergrow = 0;
    public static int DirthumansDelayChange = 90;

    public static float DirthumanFloatCounter;
    public static float DirthumansFloatLimit;
    public Slider DirthumansLimitView;



    //-----------Съедобные продукты---------

    public static int FoodTypes;
    public static int FoodShortage;

    //----------------Грибы-----------------

    public Text MooshromsCounterText;
    public Text MooshromsDayChangeText;

    public static int MooshromsCounter = 50;
    public static int MooshromsLimit = 50;
    public static int MooshromsDayChange;
    public static int MooshromsGrow = 20;
    public static int MooshromsDecrease;
    public static int MooshromsOvergrow = 0;

    public static float MooshromsFloatCounter;
    public static float MooshromsFloatLimit;
    public Slider MooshromsLimitView;

    //----------------Черви-----------------

    public Text WormsCounterText;
    public Text WormsDayChangeText;

    public static int WormsCounter;
    public static int WormsDayChange;
    public static int WormsGrow;
    public static int WormsDecrease;

    public static float EatByWorms;
    public static float WormsFloatCounter;

    //----------------Каменная соль------------

    public Text RawSaltCounterText;
    public Text RawSaltDayChangeText;

    public static int RawSaltCounter = 0;
    public static int RawSaltDayChange = 0;

    public Text PigfacesCounterText;
    public Text PigfacesMonthChangeText;

    public static int PigfacesCounter = 0;
    public static int PigfacesMonthChange = 0;

    void Start()
    {
        Calendar.EndOfDay += OnEndOfDay;
        Calendar.EndOfWeek += OnEndOfWeek;
        Calendar.EndOfMonth += OnEndOfMonth;
        Calendar.EndOfSeason += OnEndOfSeason;
        Calendar.EndOfYear += OnEndOfYear;

        // Стартовый расчет каунтеров
        WormsFloatCounter = WormsCounter;
        MooshromsFloatCounter = MooshromsCounter;
        MooshromsDecrease = (Mathf.CeilToInt(WormsFloatCounter / 20) + DirthumanCounter) * -1;
        WormsGrow = Mathf.RoundToInt(MooshromsFloatCounter / 50);

    }

    void Update()
    {
        // отображение в текстовых полях и прогресбарах лимитов
        DirthumanFloatCounter = DirthumanCounter;
        DirthumansFloatLimit = DirthumansLimit;
        DirthumansLimitView.value = DirthumanFloatCounter / DirthumansFloatLimit;
        DirthumanCounterText.text = "" + DirthumanCounter;
        DirthumanSeasonChangeText.text = "" + (DirthumansGrow + DirthumansDecrease);
        DirthumanDelayChangeText.text = "" + DirthumansDelayChange;

        MooshromsFloatCounter = MooshromsCounter;
        MooshromsFloatLimit = MooshromsLimit;
        MooshromsLimitView.value = MooshromsFloatCounter / MooshromsFloatLimit;
        MooshromsCounterText.text = "" + MooshromsCounter;
        MooshromsDayChangeText.text = "" + (MooshromsGrow + MooshromsDecrease);

        WormsFloatCounter = WormsCounter;
        WormsCounterText.text = "" + WormsCounter;
        WormsDayChangeText.text = "" + (WormsGrow + WormsDecrease);
    }
    private void OnDestroy()
    {
        Calendar.EndOfDay -= OnEndOfDay;
        Calendar.EndOfDay -= OnEndOfWeek;
        Calendar.EndOfDay -= OnEndOfMonth;
        Calendar.EndOfDay -= OnEndOfSeason;
        Calendar.EndOfDay -= OnEndOfYear;
    }

    //every day changes
    void OnEndOfDay() 
    {

        if ((MooshromsCounter + MooshromsGrow + MooshromsDecrease) < 0)
        {
            DirthumansDecrease = MooshromsCounter + MooshromsGrow + MooshromsDecrease;
            WormsDecrease = Mathf.RoundToInt(WormsFloatCounter / 20) * -1;
            MooshromsCounter = 0;
            MooshromsFloatCounter = MooshromsCounter;
            WormsGrow = 0;
            WormsCounter = WormsCounter + WormsGrow + WormsDecrease;
            DirthumanCounter = DirthumanCounter + DirthumansDecrease;
            if (DirthumanCounter < 0)
            {
                DirthumanCounter = 0;
            }
        }
        if ((MooshromsCounter + MooshromsGrow + MooshromsDecrease) > MooshromsLimit)
        {
            MooshromsCounter = MooshromsLimit;
            MooshromsFloatCounter = MooshromsCounter;

            WormsGrow = Mathf.RoundToInt(MooshromsFloatCounter / 50);
            WormsCounter = WormsCounter + WormsGrow + WormsDecrease;
            WormsFloatCounter = WormsCounter;
        }
        if ((MooshromsCounter + MooshromsGrow + MooshromsDecrease) >= 0 & (MooshromsCounter + MooshromsGrow + MooshromsDecrease) <= MooshromsLimit)
        {
            MooshromsCounter = MooshromsCounter + MooshromsGrow + MooshromsDecrease;
            MooshromsFloatCounter = MooshromsCounter;

            WormsGrow = Mathf.RoundToInt(MooshromsFloatCounter / 50);
            WormsCounter = WormsCounter + WormsGrow + WormsDecrease;
            WormsFloatCounter = WormsCounter;
        }

        //to the next day
        MooshromsDecrease = (Mathf.CeilToInt(WormsFloatCounter / 20) + DirthumanCounter) * -1; // Черви и грязнолюды жрут
        DirthumansDelayChange = --DirthumansDelayChange;

        if (MooshromsCounter > 0)
        {
            FoodTypes = 1;
        }

        if (MooshromsCounter <= 0)
        {
            FoodTypes = 0;
        }
        
        if (DirthumansDelayChange == 0)
        {
            DirthumansDelayChange = 90;
        }
        DirthumansGrow = FoodTypes;

    }
    // Каждую неделю шахтеры приносят каменную соль из забоя
    void OnEndOfWeek()
    {

    }

    // Каждый месяц Свинорожи рожают новых Свинорож
    void OnEndOfMonth()
    {

    }

    void OnEndOfSeason() //Бабы рожают раз в сезон, меняется время года
    {
        DirthumanFloatCounter = DirthumanCounter;
        DirthumansFloatLimit = DirthumansLimit;
        DirthumansLimitView.value = DirthumanFloatCounter / DirthumansFloatLimit;
        DirthumanSeasonChange = DirthumansGrow + DirthumansDecrease;
        
        if (DirthumanCounter < DirthumansLimit)
        {
            DirthumanSeasonChange = DirthumansGrow;
            DirthumanCounter = DirthumanCounter + DirthumanSeasonChange;
        }

        if (DirthumanCounter >= DirthumansLimit)
        {
            DirthumanCounter = DirthumansLimit;
            DirthumanSeasonChange = DirthumansOvergrow;
        }
        
    }
    void OnEndOfYear()
    {

    }
}
