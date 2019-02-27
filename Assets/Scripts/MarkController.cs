using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarkController : MonoBehaviour
{
    public string m_SlugName;
    Country_SO _Country;
    MarkLookAtCamera _Mark;
    GameObject _Model;
    GameObject _ModelGO;

    bool _IsSelected;

    [SerializeField]
    GameObject m_SelectedIcon;
    [SerializeField]
    TextMesh m_SelectedNameCountry;
    bool _IsWaitSelect;
    public UnityAction<Country_SO> OnCountryShow;
    float _TimeToSelect = 1f;

    SceneManager _SceneManager;



    // Start is called before the first frame update
    public void Init(SceneManager sceneManager)
    {

        _SceneManager = sceneManager;
        _Country = new Country_SO(m_SlugName);

        _Model = _Country.LoadModel();
        _ModelGO = Instantiate(_Model, transform);

        _ModelGO.SetActive(false);


        _Mark = GetComponentInChildren<MarkLookAtCamera>();
        _Mark.OnMarkClicked += MarkClicked;

        _Mark.OnMarkMouseDown += StartWaitSelect;
        _Mark.OnMarkMouseUp += StopWaitSelect;
        m_SelectedNameCountry.gameObject.SetActive(false);
        m_SelectedNameCountry.text = _Country.GetName();

        Selected = false;
    }


    void MarkClicked()
    {
        _Mark.SetActiveMark(false);
        _ModelGO.SetActive(true);

        OnCountryShow?.Invoke(_Country);

        Selected = _IsSelected;
        m_SelectedNameCountry.gameObject.SetActive(true);
    }

    void StartWaitSelect()
    {
        _IsWaitSelect = true;
        StartCoroutine(WaitingSelect());
    }

    void StopWaitSelect()
    {
        _IsWaitSelect = false;
    }


    IEnumerator WaitingSelect()
    {
        float time = _TimeToSelect;
        while (_IsWaitSelect && time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        if (time <= 0)
        {
            SelectCountry();
        }
    }

    void SelectCountry()
    {
        if (_IsSelected == false)
        {
            Selected = true;
            _SceneManager.AddCountry(_Country);
        }
        else
        {
            Selected = false;
            _SceneManager.RemoveCountry(_Country);
        }

       
    }

    public bool Selected
    {
        get
        {
            return _IsSelected;
        }
        set
        {
            _IsSelected = value;
            m_SelectedIcon.SetActive(_IsSelected);
        }
    }
}
