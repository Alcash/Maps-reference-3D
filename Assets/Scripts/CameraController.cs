using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float minHeight = 3, maxHeight = 80;

    Touch touch1, touch2;

    Vector2 finger1, finger2;

    float sensetiveMove = 0.3f;

    Vector2 delta2Touch, delta2TouchOld;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount == 1)
        {
            touch1 = Input.GetTouch(0);

            transform.Translate(-touch1.deltaPosition.x* sensetiveMove, 0, -touch1.deltaPosition.y* sensetiveMove, Space.World);
        }

        if (Input.touchCount > 1)
        {
            touch1 = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touchOnePrevPos = touch2.position - touch2.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


            if (transform.position.y  + deltaMagnitudeDiff > minHeight && transform.position.y + deltaMagnitudeDiff < minHeight)   
                transform.Translate(0, deltaMagnitudeDiff, 0, Space.World);
                
           
        }


        
    }

    
}
