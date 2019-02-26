using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Transform m_Canvas;

    public Transform m_Maps;

    DataManager dataManager;

    MarkController[] _MarkControllers;

    CountryInfoUIController _CountryInfo;

    
    // Start is called before the first frame update

    void Awake()
    {
        dataManager = GetComponent<DataManager>();
        dataManager.Init();

        _MarkControllers = m_Maps.GetComponentsInChildren<MarkController>();

        foreach (var item in _MarkControllers)
        {
            item.Init();
            item.OnCountryShow += ShowCountyInfo;
        }

        _CountryInfo = m_Canvas.GetComponentInChildren<CountryInfoUIController>(true);
    }

    void ShowCountyInfo(Country_SO country)
    {
        _CountryInfo.Open(country);
    }
}
