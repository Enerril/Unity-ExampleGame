using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void SawEnemy(ref GameObject go,ref  GameObject goe);


public class Sight : MonoBehaviour
{
    public event SawEnemy SeeEnemy;

    public GameObject go;

    [HideInInspector] public bool seeAnything = false;
    // public bool test = true;

    [HideInInspector] public CircleCollider2D circleCollider2;

    [HideInInspector] public float defaultColliderSize;
    private float expandCollider = 2f;
    private float maxSight = 6;
    private string goTag;
 //   private string goCastleTag;
    private List<string> enemyTags = new List<string>();

    // Start is called before the first frame update

    private void Awake()
    {
        GetEnemyTags();

    }
    private void Start()
    {

        circleCollider2 = GetComponentInChildren<CircleCollider2D>();
        //  Debug.Log(circleCollider2.radius);

        defaultColliderSize = circleCollider2.radius;
        

    }



    private void Update()
    {
        if (!seeAnything && circleCollider2.radius < maxSight)
        {
            circleCollider2.radius += expandCollider * Time.deltaTime;
        }
        // Debug.Log(circleCollider2.IsTouching(circleCollider2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject goColl = collision.gameObject;
      //  Debug.Log(enemyTags[0] + " " + enemyTags[1]);
        if (collision.gameObject.tag==enemyTags[0] || collision.gameObject.tag == enemyTags[1])
        {
         //   Debug.LogFormat(collision.gameObject.tag);
            SeeEnemy?.Invoke(ref go,ref goColl); // just making a note. I had problem with the class aicontroller. I could not link method to event. Everything seemed okay but that bloody event did not have method in it. After ~2 hours of butthurt debuggin/googlin' I found out that i forgot to attach aicontroller.cs to gameobject prefab....boy was I furious!
            //   Debug.LogFormat("{0} NOTICED {1}", gameObject.name, collision.gameObject.tag); \\ collision.gameObject.tag == "Castle2"
        }
    }

    private void GetEnemyTags() {

        goTag = go.gameObject.tag;

        if (goTag == "Enemy1")
        {
            enemyTags.Add("EnemyBody2");
            enemyTags.Add("Castle2");
        }
        else if (goTag == "Enemy2")
        {
            enemyTags.Add("EnemyBody1");
            enemyTags.Add("Castle1");
        }
    }
}