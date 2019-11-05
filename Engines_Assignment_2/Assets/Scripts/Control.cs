using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public class Control : MonoBehaviour
{
    public EnemyControl e;
    RaycastHit hit;
    Ray ray;
    public Text t;
    public int score;
    Subject subject = new Subject();
    EnemyCube testing;
    GameObject enemy;
    public bool reset;
    int x; 
    int y;
    int z;
    public int timer;
    public ParticleManager pm;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
        {
            enemy = e.Enemies[i];
        }

        testing = new EnemyCube(enemy, new returnScore());
        subject.AddObserver(testing);

    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(-3, 3);
        y = Random.Range(1, 3);
        z = Random.Range(-3, 2);

        timer++;

        ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        t.text = "Score: " + score;

        mouse();
    }

    public void mouse()
    {
        //Debug.DrawRay(ray.origin, Camera.main.transform.forward * 10, Color.red);
        if (e.GetComponent<EnemyControl>().active == true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                //Debug.Log(objectHit);
                if (hit.transform.tag == "Enemy")
                {
                    //Debug.Log(hit.transform.name);
                    for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
                    {
                        if (hit.transform.name == "Enemy" + i && Input.GetMouseButtonDown(0))
                        {
                            pm.setPosition(e.GetComponent<EnemyControl>().Enemies[i].transform.position);
                            pm.startPlay();
                            subject.Notify();
                            e.GetComponent<EnemyControl>().Enemies[i].SetActive(false);
                            //score = score + 1;

                        }
                    }
                }
            }

            for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
            {
                if (e.GetComponent<EnemyControl>().Enemies[i].activeInHierarchy == false && timer > 30)
                {
                    e.GetComponent<EnemyControl>().Enemies[i].SetActive(true);
                    e.GetComponent<EnemyControl>().Enemies[i].transform.position = new Vector3(x, y, z);
                    timer = 0;
                }
            }
        }
    }
}
