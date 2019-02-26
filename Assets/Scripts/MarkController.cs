using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarkController : MonoBehaviour
{

    public Country_SO m_Country;
    MarkLookAtCamera _Mark;
    GameObject _Model;
    GameObject _ModelGO;

    public UnityAction<Country_SO> OnCountryShow;

    // Start is called before the first frame update
    public void Init()
    {
        m_Country.Init();
        
        _Model = m_Country.LoadModel();
        _ModelGO = Instantiate(_Model, transform);

        _ModelGO.SetActive(false);

        _Mark = GetComponentInChildren<MarkLookAtCamera>();
        _Mark.OnMarkClicked += MarkClicked;

        
    }
   

    void MarkClicked()
    {
        _Mark.gameObject.SetActive(false);
        _ModelGO.SetActive(true);

        OnCountryShow?.Invoke(m_Country);
    }
}
