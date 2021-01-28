using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public delegate void Born();
public delegate void startClosing(ref GameObject   attacker,ref GameObject  prey);

public delegate void Died();


public class AIController : MonoBehaviour
{
    public event Born bornWasI;
    public event Died DiedIHave;
    public event startClosing startClosing;
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


    public void EnemyDetected(ref GameObject go, ref GameObject goe)
    {
        Debug.LogFormat("I SEE {0}",goe.tag);


        startClosing?.Invoke(ref go,ref goe);
        
    }
}
