using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarkLookAtCamera : MonoBehaviour
{

    public UnityAction OnMarkClicked;
    // Update is called once per frame
    void Update()
    {
        /*if(Camera.main != null)
            transform.LookAt(Camera.main.transform, Vector3.up);

        Vector3 rot = transform.rotation.eulerAngles;
        //rot.x = 0;
       // rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);*/
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        OnMarkClicked?.Invoke();
    }
}
