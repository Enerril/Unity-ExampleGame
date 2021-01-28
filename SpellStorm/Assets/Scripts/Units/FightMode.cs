using UnityEngine;
using System.Collections;

public class FightMode : MonoBehaviour
{

    public GameObject projectile;
    private GameObject attacker;
    private GameObject prey;
    private RandomWalking goWalking;
    private Sight goSight;
    private AIController aiController;
    Fireball fireball;


    private float defaultMinCastDistance = 3f;
    private float defaultMinMeleeDistance = 1f;

    private float closingSpeed = 0.05f;

    private bool closingMode = false;
    private bool fightingMode = false;
    private bool isCoroutineActive = false;

    private void OnEnable()
    {
        aiController = this.GetComponent<AIController>();
        goSight = this.GetComponent<Sight>();

        aiController.startClosing += StartClosingMode;
        goWalking = this.GetComponent<RandomWalking>();
    }

    private void OnDisable()
    {
        aiController.startClosing -= StartClosingMode;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (closingMode)
        {
            //      var attackerPos = this.attacker.transform.position;
            //     var preyPos = this.prey.transform.position;
            MoveTowardsEnemy(ref attacker, ref prey);
        }

        if (fightingMode)
        {
            if (!isCoroutineActive)
            {
                StartCoroutine(StartFighting(attacker, prey));
            }
           
        }
    }

    private float DistanceBetweenObjects(ref GameObject obj1, ref GameObject obj2)
    {
        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }

    private void MoveTowardsEnemy(ref GameObject attacker, ref GameObject prey)
    {
        //  Debug.Log("WORK");
        // Debug.Log(attackerPos + "--- " + preyPos);
        if (defaultMinCastDistance < DistanceBetweenObjects(ref attacker, ref prey))
        {
            this.transform.position = Vector3.MoveTowards(attacker.transform.position, prey.transform.position, closingSpeed); // тоже минут на 20 залип из-за того что забыл инициализировать closingSpeed ppc
        }
        else
        {
            closingMode = false;
            fightingMode = true;
        }
    }

    private void StartClosingMode(ref GameObject attacker, ref GameObject prey)
    {
        goWalking.isWandering = false;
        goSight.seeAnything = true;
        goSight.circleCollider2.radius = goSight.defaultColliderSize;

        this.attacker = attacker;
        this.prey = prey;

     //   Debug.Log(DistanceBetweenObjects(ref attacker, ref prey));
        closingMode = true;
    }





    IEnumerator StartFighting(GameObject attacker, GameObject prey)
    {
        isCoroutineActive = true;
        fireball = projectile.GetComponent<Fireball>();
        
        fireball.SetCoordForFireball(attacker, prey);
        
        
        
        
        /*
        Instantiate(projectile, transform.position,transform.rotation);
        fireball = projectile.gameObject.GetComponent<Fireball>();


        fireball.attacker = attacker;
        fireball.prey = prey;
        fireball.haveCoords = true;
        */
        yield return new WaitForSeconds(3f);
        isCoroutineActive = false;
    }






}