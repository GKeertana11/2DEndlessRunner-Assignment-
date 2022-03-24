using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentTile;
    public GameObject PlatformTile;
    Stack<GameObject> platform = new Stack<GameObject>();
    private static TileSpawnManager instance;
    public GameObject Temp;

    public static TileSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileSpawnManager>();
            }
            return instance;
        }
    }
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnTile()
    {
        //Instantiate(PlatformTile, currentTile.transform.GetChild(0).position, Quaternion.identity);
        /* currentTile = Instantiate(PlatformTile, currentTile.transform.GetChild(0).position, Quaternion.identity);*/
         if (platform.Count == 0)
         {
             CreateTile(20);
         }
        GameObject temp = platform.Pop();
        temp.SetActive(true);
        temp.transform.position = currentTile.transform.GetChild(0).position;
        currentTile = temp;
    }
    public void CreateTile(int value)
    {
        for (int i = 0; i < value; i++)
        {
            //SpawnTile();
            //CreateTile();
            platform.Push(Instantiate(PlatformTile));
            PlatformTile.SetActive(false);
        }
    }
    public void BackToPool(GameObject obj)
    {
        //obj.GetComponent<Rigidbody>().isKinematic = true;
        platform.Push(obj);
        platform.Peek().SetActive(false);
        //obj.SetActive(false);
    }
}
