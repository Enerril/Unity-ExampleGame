using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    public GameObject go;
    RandomWalking goWalking;
    Sight goSight;

    private void OnEnable()
    {
        goSight = this.GetComponent<Sight>();
        goSight.SeeEnemy += EnemyDetected;
    }

    void OnDisable()
    {
        goSight.SeeEnemy -= EnemyDetected;
    }
    // Start is called before the first frame update
    void Start()
    {

        goWalking = this.GetComponent<RandomWalking>();
       


       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnemyDetected(string tagName)
    {
        Debug.LogFormat("I SEE {0}",tagName);
    }
}
