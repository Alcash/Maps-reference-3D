using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : BaseUIController
{

    public Button m_ClearListCountryButton;
    public Button m_ShowListCountyButton;


    public override void Init(SceneManager sceneManager)
    {
        base.Init(sceneManager);

        m_ClearListCountryButton.onClick.AddListener(ClearListCountryButtonClicked);
        m_ShowListCountyButton.onClick.AddListener(ShowListCountyButtonClicked);
    }


    public void SetActiveClearButton(bool value)
    {

        m_ClearListCountryButton.gameObject.SetActive(value);
    }

    void ClearListCountryButtonClicked()
    {
        _SceneManager.ClearListContry();
    }

    void ShowListCountyButtonClicked()
    {
        _SceneManager.ShowListCountry();
    }

}
