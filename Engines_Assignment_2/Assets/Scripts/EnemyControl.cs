using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>(5);
    public List<Vector3> pos;
    public GameObject prefab;
    int x;
    int y;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(2, 4);

        for (int i = 0; i < rand; i++)
        {
            Enemies.Add(prefab);
        }


        for (int i = 0; i < Enemies.Count; i++)
        {
            x = Random.Range(-3, 3);
            y = Random.Range(1, 3);
            z = Random.Range(-3, 2);

            pos.Add(new Vector3(x, y, z));
        }

        for (int i = 0; i <= Enemies.Count - 1; i++)
        {
            Enemies[i] = Instantiate(Enemies[i], pos[i], Quaternion.identity);
            Enemies[i].transform.localRotation = Quaternion.Euler(90, 180, 0);
            Enemies[i].name = "Enemy" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
