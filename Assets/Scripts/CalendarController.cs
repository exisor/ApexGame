using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    public Text Calendar;

    private int _turnNumber;

    public int _dayNumber;
    public int _dayInMonthNumber;
    private string _dayText;

    public int _weakNumber;
    private string _weakText;

    public int _monthNumber;
    public int _treeMonthNumber;
    private string _monthText;

    public int _seasonNumber;
    private int _seasonText;

    public int _yearNumber;
    private string _yearText;

    public string[] _weakDayArray;
    public string[] _monthArray;
    public string[] _seasonArray;

    public Slider DayProgress;
    public float FillSpead;

    public event Action EndOfDay;
    public event Action EndOfWeek;
    public event Action EndOfMonth;
    public event Action EndOfSeason;
    public event Action EndOfYear;

    // Start is called before the first frame update
    void Start()
    {

        _turnNumber = 1;
        _dayNumber = 1;
        _weakNumber = 1;
        _monthNumber = 1;
        _treeMonthNumber = 2;
        _seasonNumber = 1;
        _yearNumber = 1402;
        _dayInMonthNumber = 1;

        _weakDayArray = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        _monthArray = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        _seasonArray = new string[4] { "Winter", "Spring", "Summer", "Autumn" };

        //Calendar.text = "" + _turnNumber + " Turn. " + _weakDayArray[_dayNumber - 1] + ", " + _dayInMonthNumber + " of " + _monthArray[_monthNumber - 1] + " " + _yearNumber + " year. Is " + _seasonArray[_seasonNumber - 1] + ".";
        Calendar.text = "" + _weakDayArray[_dayNumber - 1] + ", " + _dayInMonthNumber + " of " + _monthArray[_monthNumber - 1] + " " + _yearNumber + " year. Is " + _seasonArray[_seasonNumber - 1] + ".";

        DayProgress.value = 0;

    }

    // Update is called once per frame
    void Update()
    {

        DayProgress.value += FillSpead * Time.deltaTime;

        if (DayProgress.value == 1)
        {
            _turnNumber++;
            _dayNumber++;
            _dayInMonthNumber++;
            DayProgress.value = 0;
            if (EndOfDay != null)
            {
                EndOfDay();
            }
            if (_dayNumber > 7)  //Новая неделя
            {
                _dayNumber = 1;
                _weakNumber++;
                if (EndOfWeek != null)
                {
                    EndOfWeek();
                }
            }
            if (_dayInMonthNumber > 28) //Сброс дней в месяце
            {
                _dayInMonthNumber = 1;
            }
            if (_weakNumber > 4) //Новый месяц
            {
                _weakNumber = 1;
                _monthNumber++;
                _treeMonthNumber++;
                if (EndOfMonth != null)
                {
                    EndOfMonth();
                }
            }
            if (_treeMonthNumber > 3) //Новый сезон года
            {
                _treeMonthNumber = 1;
                _seasonNumber++;
                if (EndOfSeason != null)
                {
                    EndOfSeason();
                    Debug.Log("End of Season");
                }
            }
            if (_monthNumber > 12) //Новый год
            {
                _monthNumber = 1;
                _yearNumber++;
                if (EndOfYear != null)
                {
                    EndOfYear();
                }
            }
            if (_seasonNumber > 4) //Сброс сезона в году
            {
                _seasonNumber = 1;
            }
            Calendar.text = "" + _weakDayArray[_dayNumber - 1] + ", " + _dayInMonthNumber + " of " + _monthArray[_monthNumber - 1] + " " + _yearNumber + " year. Is " + _seasonArray[_seasonNumber - 1] + ".";
        }
    }
}
