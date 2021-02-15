using UnityEngine;
using System.Collections;

public class Spawner1 : MonoBehaviour
{
    public GameObject go;
    bool isCoroutineActive = false;
    int enemyAmount = 10;

    // Start is called before the first frame update
    private void Start()



    {
        if (!isCoroutineActive)
        {
            StartCoroutine(SpawnFighters());
        }
        /*
        for (int i = 0; i < 50; i++)
        {
            Instantiate(go, transform.position, transform.rotation);
        }*/



    }

    // Update is called once per frame
    private void Update()
    {/*
        if (!isCoroutineActive)
        {
            StartCoroutine(SpawnFighters());
        }
        */
    }

    IEnumerator SpawnFighters()


    {
        isCoroutineActive = true;
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject en1 = Pool.singleton.Get("Enemy2");
            if (en1 != null)
            {
                en1.transform.position = this.transform.position;
                en1.SetActive(true);
            }


        }


        /*
        for (int i = 0; i < 15; i++)
        {
            Instantiate(go, transform.position, transform.rotation);
        }
       
        
        
        */




        // isCoroutineActive = false;
    }
}