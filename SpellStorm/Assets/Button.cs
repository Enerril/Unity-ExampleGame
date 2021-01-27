using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    RandomWalking randomWalking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        randomWalking = FindObjectOfType<RandomWalking>();
        randomWalking.ToggleWandering();
        Debug.Log("CLICK");
    }
}
