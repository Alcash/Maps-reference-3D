using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : BaseUIController
{

    public Button m_ClearListCountryButton;
    public Button m_ShowListCountyButton;

    [SerializeField]
    Text _CountCountryText;
    string labelCountCountry = "Выбрано: ";

    public override void Init(SceneManager sceneManager)
    {
        base.Init(sceneManager);

        m_ClearListCountryButton.onClick.AddListener(ClearListCountryButtonClicked);
        m_ShowListCountyButton.onClick.AddListener(ShowListCountyButtonClicked);

        _CountCountryText.gameObject.SetActive(false);
    }

    public void SetCountCountry(int value )
    {

        _CountCountryText.gameObject.SetActive(value > 0);

        _CountCountryText.text = labelCountCountry + value;
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
