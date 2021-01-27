using UnityEngine;

public class FightMode : MonoBehaviour
{

    RandomWalking goWalking;
    Sight goSight;
    AIController aiController;

    private void OnEnable()
    {
        aiController = this.GetComponent<AIController>();
        goSight = this.GetComponent<Sight>();
        aiController.startFight += StartFightMode;
        goWalking = this.GetComponent<RandomWalking>();





    }

    private void OnDisable()
    {
        aiController.startFight -= StartFightMode;

    }





    private void Start()
    {
    }

    private void Update()
    {
    }


    void StartFightMode(GameObject attacker,GameObject prey)
    {
        goWalking.isWandering = false;
        goSight.seeAnything = true;
        goSight.circleCollider2.radius = goSight.defaultColliderSize;





    }




}