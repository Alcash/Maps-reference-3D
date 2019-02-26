using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryInfoUIController : BaseUIController
{

    public Text m_AreaText, m_GRPText, m_PopulationText;

    public override void Init()
    {
        base.Init();

        Close();
    }

    public void Open(Country_SO country)
    {
        m_AreaText.text = "Площадь: " + country.GetArea();
        m_GRPText.text = "ВВП: " + country.GetGDP();
        m_PopulationText.text = "Население: " + country.GetPopulation();

        base.Open(true);
    }

    
}
