using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Country_SO
{
    
    string _SlugName = "default";
    string _Name = "";
    int _Area = 0;    
    int _Population = 0;    
    int _GDP = 0;    
    string _Model = "";

    public Country_SO(string slugName)
    {
        _SlugName = slugName;
        Dictionary<string,string> info = DataManager.instance.GetCountryInfo(_SlugName);
        if (info.Count > 0)
        {
            _Name = info["NameCountry"];
            _Area = int.Parse(info["Area"]);
            _Population = int.Parse(info["Population"]);
            _GDP = int.Parse(info["GDP"]);
            _Model = info["Model"];
        }
    }


    public string GetName()
    {
        return _Name;
    }

    public int GetArea()
    {
        return _Area;
    }

    public int GetPopulation()
    {
        return _Population;
    }

    public int GetGDP()
    {
        return _GDP;
    }

    public GameObject LoadModel()
    {
        GameObject result = Resources.Load<GameObject>("Models/" + _Model);
        if (result == null)
            result = new GameObject();
        return result;
    }
}
