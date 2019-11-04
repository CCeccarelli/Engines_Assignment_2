using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public List<Vector3> pos = new List<Vector3>();
    public GameObject prefab;
    public bool tutorial;
    int x;
    int y;
    int z;
    // Start is called before the first frame update
    public void Start()
    {
        //int rand = Random.Range(2, 4);

        //for (int i = 0; i < Enemies.Count; i++)
        //{
        //    Enemies.Add(prefab);
        //}
        tutorial = true;

        for (int i = 0; i < Enemies.Count; i++)
        {
            x = Random.Range(-3, 3);
            y = Random.Range(1, 3);
            z = Random.Range(-3, 2);
            pos.Add(new Vector3(x, y, z));
        }

        if (tutorial == false)
        {
            for (int i = 0; i <= Enemies.Count - 1; i++)
            {
                Enemies[i] = prefab;
                Enemies[i] = Instantiate(Enemies[i], pos[i], Quaternion.identity);
                Enemies[i].transform.localRotation = Quaternion.Euler(90, 180, 0);
                Enemies[i].name = "Enemy" + i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
