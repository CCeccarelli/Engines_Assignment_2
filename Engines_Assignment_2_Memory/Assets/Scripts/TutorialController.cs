using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject TutorialObj;
    public EnemyControl e;
    public Text TutorialText;
    public Text TutorialHealth;
    public Text Score;
    public Control c;
    public bool tutorial;
    bool healthTutorial;
    int timer;
    RaycastHit hit;
    Ray ray;
    Vector3 PrevPos;
    public List<Vector3> ListOfPos;
    float count = 0;
    bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        TutorialObj.SetActive(false);
        ListOfPos.Add(new Vector3(0.0f, 2.7f, -6.25f));
        ListOfPos.Add(new Vector3(-4.0f, 1.0f, -6.25f));
        ListOfPos.Add(new Vector3(4.0f, 1.0f, -6.25f));
        ListOfPos.Add(new Vector3(4.0f, 1.0f, -6.25f));
        PrevPos = TutorialObj.transform.position;
        tutorial = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ListOfPos.Count == 0) // If Tutorial Block moved to all 3 positions
        {
            TutorialObj.SetActive(false); // Deactivate Tutorial Object

            if (timer >= 100 && healthTutorial == false) // If Health Tutorial wasn't shown
            {
                c.health = 2;
                TutorialText.text = "If you miss a target you'll lose health. If it reaches 0 you Lose!";
                TutorialHealth.color = new Vector4(1, 0, 0, 1);
                if (timer == 200)
                {
                    timer = 0;
                    TutorialHealth.color = new Vector4(0, 0, 0, 1);
                    healthTutorial = true;
                }
            }
            else if (timer >= 120) // If Health Tutorial has been done
            {
                TutorialText.text = "Hit as many enemies as possible to get a high score!";
                if (timer == 240)
                {
                    tutorial = false;
                    e.GetComponent<EnemyControl>().initializeEnemies();
                    ListOfPos.Add(new Vector3(0f, 0f, 0f));
                    ListOfPos.Add(new Vector3(0f, 0f, 0f));
                    TutorialText.color = new Vector4(0, 0, 0, 0);
                }
            }
            timer++;
        }

        else if (ListOfPos.Count == 1) // If player is on the last object position, wait for click and remove object instead of lerping it.
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (Input.GetMouseButtonDown(0) && hit.transform.tag == "tutorialObj")
                {
                    ListOfPos.RemoveAt(0);
                    c.score += 1; // Tutorialize Score
                    Score.text = "Score: <color=red>1</color>";
                    TutorialText.text = "Destroying an Enemy gives you 1 point";
                    timer = 0;
                }
            }
        }

        else // If block still has more positions to travel to
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (timer == 100) // Wait to change message and activate tutorial enemy
            {
                TutorialText.text = "Aim at the enemy object and use the left mouse button to hit it";
                TutorialObj.SetActive(true);
                timer = 0;
            }

            timer++;

            if (move == true)
            {
                TutorialObj.transform.position = Vector3.Lerp(PrevPos, ListOfPos[0], count);
                count += 0.01f;
            }

            if (TutorialObj.transform.position == ListOfPos[0])
            {
                PrevPos = TutorialObj.transform.position;
                count = 0f;
                move = false;
                ListOfPos.RemoveAt(0);
            }
            tutorialRay();
        }
    }


    public void tutorialRay() // Raycast to identify object Hit
    {
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "tutorialObj") // If Player hits the object
            {
                move = true;
            }
            else if (Input.GetMouseButtonDown(0)) // If Player Misses the object and Hits the "Floor"
            {
                if (healthTutorial == false)
                {
                    c.health = 2;
                    TutorialHealth.color = new Vector4(1, 0, 0, 1);
                    TutorialText.text = "If you miss a target you'll lose health. If it reaches 0 you Lose!";
                    healthTutorial = true;
                    timer = -50;
                }
            }
        }

        else // If Raycast doesn't hit a Game Object
        {
            if (Input.GetMouseButtonDown(0)) // And Mouse Button is pressed aiming at nothing
            {
                if (healthTutorial == false)
                {
                    c.health = 2;
                    TutorialHealth.color = new Vector4(1, 0, 0, 1);
                    TutorialText.text = "If you miss a target you'll lose health. If it reaches 0 you Lose!";
                    healthTutorial = true;
                    timer = -50;
                }
            }
        }
    }
}