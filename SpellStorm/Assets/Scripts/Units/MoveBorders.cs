using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBorders : MonoBehaviour
{
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float padding = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        var newXPos = Mathf.Clamp(transform.position.x, xMin, xMax);


        var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);





        transform.position = new Vector3(newXPos, newYPos,0.75f);
    }
}
