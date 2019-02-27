using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCountryUIController : BaseUIController
{
    [SerializeField]
    GameObject _PrefabCountryInfo;
    [SerializeField]
    Button m_ButtonBack, m_ButtonSortArea, m_ButtonSortGDP, m_ButtonSortPopulation;

    ButtonSort _ButtonSortArea, _ButtonSortGDP, _ButtonSortPopulation;


    bool _SortAreaAsc, _SortGDPAsc, _SortPopulationAsc;
    [SerializeField]
    GameObject _ListRoot;

    Country_SO[] countryList;

    List<CountryInfoRow> _CountrySelectedList;

    delegate int ValueMethod(Country_SO country);
    
    ValueMethod _ValueMethod;

    delegate bool CompareDir(int value1, int value2);

    CompareDir _CompareDir;

    public override void Init(SceneManager sceneManager)
    {
        base.Init(sceneManager);
        
        m_ButtonBack.onClick.AddListener(ButtonBackClicked);

        _CountrySelectedList = new List<CountryInfoRow>();

        Close(true);

        m_ButtonSortArea.onClick.AddListener(SortAreaButtonClicked);
        _ButtonSortArea = m_ButtonSortArea.GetComponent<ButtonSort>();

        m_ButtonSortGDP.onClick.AddListener(SortGDPButtonClicked);
        _ButtonSortGDP = m_ButtonSortGDP.GetComponent<ButtonSort>();

        m_ButtonSortPopulation.onClick.AddListener(SortPopulationButtonClicked);
        _ButtonSortPopulation = m_ButtonSortPopulation.GetComponent<ButtonSort>();
    }

    void ButtonBackClicked()
    {
        Close();
    }

    public override void Open(bool instantly = false)
    {
        base.Open(instantly);
        ClearList();

        countryList = _SceneManager.GetCountries().ToArray();
        GameObject countryInfoGO;
        CountryInfoRow info;
        foreach (var country in countryList)
        {
            countryInfoGO = Instantiate(_PrefabCountryInfo, _ListRoot.transform);

            info = countryInfoGO.GetComponent<CountryInfoRow>();
            info.SetInfo(country);
            _CountrySelectedList.Add(info);
        }
       


    }

    void ClearList()
    {
        foreach (var item in _CountrySelectedList)
        {
            Destroy(item.gameObject);
        }

        _CountrySelectedList.Clear();
    }




    void SortPopulationButtonClicked()
    {
        _ValueMethod = ComparePopulation;
        _SortPopulationAsc = !_SortPopulationAsc;
        //_CompareDir = CompareFirstMore;
        //_CompareDir = _SortPopulationAsc?CompareFirstLess:CompareFirstMore;

        if(_SortPopulationAsc)
        {
            _CompareDir = CompareFirstLess;
        }
        else
        {
            _CompareDir = CompareFirstMore;
        }
        _ButtonSortPopulation.ArrowUp(_SortPopulationAsc);

        Sorting();
    }

    void SortAreaButtonClicked()
    {
        _ValueMethod = CompareArea;
        _SortAreaAsc = !_SortAreaAsc;

        if (_SortAreaAsc)
        {
            _CompareDir = CompareFirstLess;
        }
        else
        {
            _CompareDir = CompareFirstMore;
        }
        _ButtonSortArea.ArrowUp(_SortAreaAsc);
        Sorting();
    }

    void SortGDPButtonClicked()
    {
        _ValueMethod = CompareGDP;
        _SortGDPAsc = !_SortGDPAsc;

        if (_SortGDPAsc)
        {
            _CompareDir = CompareFirstLess;
        }
        else
        {
            _CompareDir = CompareFirstMore;
        }
        _ButtonSortGDP.ArrowUp(_SortGDPAsc);

        Sorting();
    }
        

    int CompareArea(Country_SO country)
    {     
        return country.GetArea();
    }

    int CompareGDP(Country_SO country)
    {
        return country.GetGDP();
    }

    int ComparePopulation(Country_SO country)
    {
        return country.GetPopulation();
    }


    bool CompareFirstLess(int value1, int value2)
    {
        return value1 < value2;
    }

    bool CompareFirstMore(int value1, int value2)
    {
        return value1 > value2;
    }

    void Sorting()
    {
        Debug.Log("Start Sort");
        //var maxValue = _ValueMethod(countryList[0]);
        int maxValue = 0;
        int iMaxIndex = 0;
        for (int iMax = 0; iMax < countryList.Length; iMax++)
        {
            maxValue = _ValueMethod(countryList[iMax]);
            iMaxIndex = iMax;
            Debug.Log("start " + _ValueMethod(countryList[iMax]) + " iMax " + iMax);

            for (int i = iMax; i < countryList.Length; i++)
            {
                if ( _CompareDir(maxValue, _ValueMethod(countryList[i])) )
                {
                    maxValue = _ValueMethod(countryList[i]);
                    iMaxIndex = i;
                }
            }
            Debug.Log("iMax "+ iMax + " iMaxIndex " + iMaxIndex);
            Debug.Log("value cur " + _ValueMethod(countryList[iMaxIndex]));
            var temp = countryList[iMaxIndex];
            countryList[iMaxIndex] = countryList[iMax];
            countryList[iMax] = temp;
            //_CountrySelectedList[iMax].SetInfo(countryList[iMax]);
            //_ListRoot.transform.GetChild(iMaxIndex).SetAsFirstSibling();

        }

        for (int i = 0; i < countryList.Length; i++)
        {
            Debug.Log(countryList[i].GetName() + " : " + _ValueMethod(countryList[i]));
            _CountrySelectedList[i].SetInfo(countryList[i]); 
        }       


    }
}
