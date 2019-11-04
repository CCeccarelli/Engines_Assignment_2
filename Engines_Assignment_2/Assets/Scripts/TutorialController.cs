using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject TutorialObj;
    public EnemyControl e;
    public Text TutorialText;
    public int timer;
    RaycastHit hit;
    Ray ray;
    public Vector3 PrevPos;
    public List<Vector3> ListOfPos;
    float count = 0;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        ListOfPos.Add(new Vector3(0.0f, 2.7f, -6.25f));
        ListOfPos.Add(new Vector3(0.0f, 0f, -0f));
        ListOfPos.Add(new Vector3(0.0f, -1.1f, -6.25f));
        PrevPos = TutorialObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ListOfPos.Count == 0)
        {
            e.GetComponent<EnemyControl>().tutorial = false;
            e.GetComponent<EnemyControl>().Start();
        }
        else
        {
            timer++;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (timer == 100)
            {
                TutorialText.text = "aim at the enemy object and use the left mouse button to destroy";
            }
            if (move == true)
            {
                TutorialObj.transform.position = Vector3.Lerp(PrevPos, ListOfPos[0], count);
                count += 0.01f;
            }
            if (TutorialObj.transform.position == ListOfPos[0])
            {
                PrevPos = TutorialObj.transform.position;
                ListOfPos.RemoveAt(0);
                count = 0f;
                move = false;
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
        }
    }
}