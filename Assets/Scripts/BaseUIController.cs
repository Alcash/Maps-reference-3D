using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIController : MonoBehaviour
{

    float _AnimationTime = 0.3f;
    protected SceneManager _SceneManager;
    public virtual void Init(SceneManager sceneManager)
    {
        _SceneManager = sceneManager;
    }

    public virtual void Open(bool instantly = false)
    {
        if(instantly)
            gameObject.SetActive(true);
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(Opening());
        }
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
            StartCoroutine(Closing());
        }
    }

    protected virtual IEnumerator Closing()
    {
        float time = _AnimationTime;

        while (time > 0)
        {
            transform.localScale = Vector3.one * (1 - (time / _AnimationTime));
            time -= Time.deltaTime;
            yield return null;
        }
        yield return null;

    }
}
