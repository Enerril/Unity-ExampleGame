using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject go;
    bool isCoroutineActive = false;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(go, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isCoroutineActive)
        {
            StartCoroutine(SpawnFighters());
        }
    }

    IEnumerator SpawnFighters()
    {
        isCoroutineActive = true;
        yield return new WaitForSeconds(15f);
        for (int i = 0; i < 15; i++)
        {
            Instantiate(go, transform.position, transform.rotation);
        }
        isCoroutineActive = false;
    }
}