using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject go;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(go, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}