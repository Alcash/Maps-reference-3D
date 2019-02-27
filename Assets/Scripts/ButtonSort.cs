using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSort : MonoBehaviour
{

    Image _Image;

    private void Start()
    {
        _Image = transform.GetChild(1).GetComponent<Image>();
    }

    public void ArrowUp(bool value)
    {
        float rotZ = value ? 0 : 180;
        _Image.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

}
