using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseUIController : MonoBehaviour
{

    float _AnimationTime = 0.3f;
    protected SceneManager _SceneManager;
    protected Animator _Animator;

    protected UnityAction _OpenMethod;
    protected UnityAction _CloseMethod;

    public virtual void Init(SceneManager sceneManager)
    {
        _SceneManager = sceneManager;
        _OpenMethod = ScaleOpenMethod;
        _CloseMethod = ScaleCloseMethod;
         _Animator = GetComponent<Animator>();
    }

    public virtual void Open(bool instantly = false)
    {
        if(instantly)
            gameObject.SetActive(true);
        else
        {
            gameObject.SetActive(true);
            _OpenMethod();
        }
    }

    protected virtual void ScaleOpenMethod()
    {
        StartCoroutine(Opening());
    }
    protected virtual IEnumerator Opening()
    {

        float time = _AnimationTime;

        while(time > 0)
        {
            transform.localScale = Vector3.one * ( 1 - (time / _AnimationTime));
            time -= Time.deltaTime;
            yield return null;
        }

        yield return null;
       
    }

    public virtual void Close(bool instantly = false)
    {
        if(instantly)
            gameObject.SetActive(false);
        else
        {
            ScaleCloseMethod();
        }
    }

    protected virtual void ScaleCloseMethod()
    {
        StartCoroutine(Closing());
    }

    protected virtual IEnumerator Closing()
    {
        float time = _AnimationTime;

        while (time > 0)
        {
            transform.localScale = Vector3.one * ((time / _AnimationTime));
            time -= Time.deltaTime;
            yield return null;
        }
        yield return null;
        gameObject.SetActive(false);
    }
}
