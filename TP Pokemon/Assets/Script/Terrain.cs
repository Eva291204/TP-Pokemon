using UnityEngine;

public class Terrain : MonoBehaviour
{
    //Test Seed

    public int seed;
    public int Pokemon1;
    public int Pokemon2;
    public void Start()
    {
        seed = Random.Range(0,5);
        Random.InitState(seed);
        Debug.Log("terrain :" + seed);
        Debug.Log(Pokemon1 = Random.Range(0, 3)); //random Pokemon
        Debug.Log(Pokemon2 = Random.Range(0, 3));
    }
}
