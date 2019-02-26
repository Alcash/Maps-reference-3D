using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{

    public Button m_ClearListCountryButton;
    public Button m_ShowListCountyButton;   


    public void Init()
    {
        m_ClearListCountryButton.onClick.AddListener(ClearListCountryButtonClicked);
        m_ShowListCountyButton.onClick.AddListener(ShowListCountyButtonClicked);
    }

    void ClearListCountryButtonClicked()
    {

    }

    void ShowListCountyButtonClicked()
    {

    }

}
