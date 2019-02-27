using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Transform m_Canvas;

    public Transform m_Maps;

    DataManager _DataManager;

    MarkController[] _MarkControllers;

    CountryInfoUIController _CountryInfo;
    MainUIController _MainUIController;
    SelectCountryUIController _SelectCountryUIController;

    List<Country_SO>  countrySelectedList;
    
    // Start is called before the first frame update

    void Awake()
    {
        _DataManager = GetComponent<DataManager>();
        _DataManager.Init();

        countrySelectedList = new List<Country_SO>();

        _MarkControllers = m_Maps.GetComponentsInChildren<MarkController>();
        
        foreach (var item in _MarkControllers)
        {
            item.Init(this);
            item.OnCountryShow += ShowCountyInfo;
        }

        _CountryInfo = m_Canvas.GetComponentInChildren<CountryInfoUIController>(true);
        _CountryInfo.Init(this);

        _MainUIController = m_Canvas.GetComponentInChildren<MainUIController>(true);
        _MainUIController.Init(this);

        _SelectCountryUIController = m_Canvas.GetComponentInChildren<SelectCountryUIController>(true);
        _SelectCountryUIController.Init(this);
    }

    void ShowCountyInfo(Country_SO country)
    {
        _CountryInfo.Open(country);
    }

    internal void AddCountry(Country_SO country)
    {
        countrySelectedList.Add(country);

        _MainUIController.SetActiveClearButton(countrySelectedList.Count > 0);
    }

    internal void RemoveCountry(Country_SO country)
    {
        countrySelectedList.Remove(country);

        _MainUIController.SetActiveClearButton(countrySelectedList.Count > 0);
    }

    public List<Country_SO> GetCountries()
    {
        return countrySelectedList;
    }


    public void ClearListContry()
    {
        countrySelectedList.Clear();
        foreach (var item in _MarkControllers)
        {
            item.Selected = false;


        }
    }

    public void ShowListCountry()
    {
        _SelectCountryUIController.Open();
    }
}
