using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryInfoRow : MonoBehaviour
{

    [SerializeField]
    Text m_AreaText, m_PopulationText, m_GDPText, m_NameText;

    public void SetInfo(Country_SO country)
    {
        m_NameText.text = country.GetName();
        m_AreaText.text = country.GetArea().ToString() ;
        m_GDPText.text =  country.GetGDP().ToString();
        m_PopulationText.text = country.GetPopulation().ToString();
    }

}
