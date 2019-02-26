using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCountryUIController : BaseUIController
{

    public Button m_ButtonBack, m_ButtonSortArea, m_ButtonSortGDP, m_ButtonSortPopulation;

    public override void Init()
    {
        base.Init();

        m_ButtonBack.onClick.AddListener(ButtonBackClicked);

        Close();
    }

    void ButtonBackClicked()
    {
        Close();
    }
}
