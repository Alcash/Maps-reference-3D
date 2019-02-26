using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "country", menuName = "CountrySO/Unit", order = 1)]
public class Country_SO : ScriptableObject
{
    [SerializeField]
    string slugName = "default";
    [SerializeField]
    int area = 0;
    [SerializeField]
    int population = 0;
    [SerializeField]
    int gdp = 0;
    [SerializeField]
    string model = "";

    public void Init()
    {
        var info = DataManager.instance.GetCountryInfo(slugName);

        area = int.Parse(info["Area"]);
        population = int.Parse(info["Population"]);
        gdp = int.Parse(info["GDP"]);
        model = info["Model"];
    }

    public string GetName()
    {
        return slugName;
    }

    public int GetArea()
    {
        return area;
    }

    public int GetPopulation()
    {
        return population;
    }

    public int GetGDP()
    {
        return gdp;
    }

    public GameObject LoadModel()
    {
        GameObject result = Resources.Load<GameObject>("Models/" + model);
        if (result == null)
            result = new GameObject();
        return result;
    }
}
