using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public List<Vector3> pos = new List<Vector3>();
    public GameObject prefab;
    public TutorialController tut;
    public bool active;
    int x;
    int y;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        //int rand = Random.Range(2, 4);

        //for (int i = 0; i < Enemies.Count; i++)
        //{
        //    Enemies.Add(prefab);
        //}

        for (int i = 0; i < Enemies.Count; i++)
        {
            x = Random.Range(-3, 3);
            y = Random.Range(1, 3);
            z = Random.Range(-3, 2);
            pos.Add(new Vector3(x, y, z));//adds a random position to the vector list of positions
        }
    }

    public void initializeEnemies()//instantiates enemies based on how many we plan to create
    {
        for (int i = 0; i <= Enemies.Count - 1; i++)
        {
            Enemies[i] = prefab;
            Enemies[i] = Instantiate(Enemies[i], pos[i], Quaternion.identity);
            Enemies[i].transform.localRotation = Quaternion.Euler(90, 180, 0);
            Enemies[i].name = "Enemy" + i;
        }
        active = true;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
