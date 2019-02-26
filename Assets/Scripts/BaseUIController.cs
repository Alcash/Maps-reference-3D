using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIController : MonoBehaviour
{

    public virtual void Init()
    {

    }

    public virtual void Open(bool instantly = false)
    {
        if(instantly)
            gameObject.SetActive(true);
        else
        {
            StartCoroutine(Opening());
        }
    }

    protected virtual IEnumerator Opening()
    {
        gameObject.SetActive(true);
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
        gameObject.SetActive(false);
        yield return null;

    }
}
