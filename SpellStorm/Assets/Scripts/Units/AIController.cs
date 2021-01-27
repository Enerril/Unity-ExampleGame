using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public delegate void Born();
public delegate void StartFight(GameObject attacker,GameObject prey);
public class AIController : MonoBehaviour
{
    public event Born bornWasI;
    public event StartFight startFight;
    public GameObject go;
    RandomWalking goWalking;
    Sight goSight;

    private void OnEnable()
    {
        goSight = this.GetComponent<Sight>();
        goWalking = this.GetComponent<RandomWalking>();
        goSight.SeeEnemy += EnemyDetected;
    }

    void OnDisable()
    {
        goSight.SeeEnemy -= EnemyDetected;
    }
    // Start is called before the first frame update
    void Start()
    {
        bornWasI?.Invoke();
        
       


       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnemyDetected(GameObject go, GameObject goe)
    {
     //   Debug.LogFormat("I SEE {0}",goe.tag);

        
        startFight?.Invoke(go,goe);

    }
}
