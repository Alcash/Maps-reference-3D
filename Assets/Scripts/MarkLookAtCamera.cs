using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarkLookAtCamera : MonoBehaviour
{

    SpriteRenderer _SpriteRenderer;

    public UnityAction OnMarkClicked;

    public UnityAction OnMarkMouseDown;
    public UnityAction OnMarkMouseUp;

    private void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Camera.main != null)
            transform.LookAt(Camera.main.transform, Vector3.up);

        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);*/
    }

    public void SetActiveMark(bool value)
    {
        _SpriteRenderer.enabled = value;
    }

    private void OnMouseDown()
    {
        OnMarkMouseDown?.Invoke();
    }

    private void OnMouseUp()
    {
        OnMarkMouseUp?.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        OnMarkClicked?.Invoke();
    }
}
