using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public delegate void Born();
public delegate void startClosing( GameObject   attacker, GameObject  prey);

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
        if (goSight != null)
        {
            goSight.SeeEnemy += EnemyDetected;
        }
    }

    void OnDisable()
    {
        if (goSight != null)
        {
            goSight.SeeEnemy -= EnemyDetected;
    }
    DiedIHave?.Invoke();
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
     //   Debug.LogFormat("I SEE {0}",goe.tag);


        startClosing?.Invoke( go, goe);
        
    }
}
