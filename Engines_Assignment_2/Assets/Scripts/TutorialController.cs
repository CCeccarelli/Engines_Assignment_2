using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject TutorialObj;
    public EnemyControl e;
    public Text TutorialText;
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
        if (ListOfPos.Count == 0)
        {
            TutorialObj.SetActive(false);
            TutorialText.text = "Hit as many enemies as possible to get a high score!";
            if (timer == 250 && healthTutorial == false)
            {
                TutorialText.text = "If you miss a target you'll lose health. If it reaches 0 you Lose!";
                timer = 0;
                healthTutorial = true;
            }
            if (timer == 300)
            {
                tutorial = false;
                e.GetComponent<EnemyControl>().initializeEnemies();
                ListOfPos.Add(new Vector3(0f, 0f, 0f));
                ListOfPos.Add(new Vector3(0f, 0f, 0f));
                TutorialText.color = new Vector4(0f, 0f, 0f, 0f);
            }
            timer++;
        }
        else if (ListOfPos.Count == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (Input.GetMouseButtonDown(0) && hit.transform.tag == "tutorialObj")
                {
                    ListOfPos.RemoveAt(0);
                    timer = 0;
                }
            }
        }
        else
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (timer == 100)
            {
                TutorialText.text = "Aim at the red square <enemy> and use the left mouse button to hit it";
                TutorialObj.SetActive(true);
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


    public void tutorialRay()
    {
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "tutorialObj")
            {
                move = true;
            }
            else if (Input.GetMouseButtonDown(0) && hit.transform.tag == "tutorialObj")
            {
                
                TutorialText.text = "If you miss a target you'll lose health. If it reaches 0 you Lose!";
                healthTutorial = true;
            }
        }
    }
}