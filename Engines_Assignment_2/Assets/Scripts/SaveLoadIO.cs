using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SaveLoadIO : MonoBehaviour
{
    const string DLL_NAME = "SaveLoadManager";

    [DllImport(DLL_NAME)]
    private static extern void saveScore(int score);

    [DllImport(DLL_NAME)]
    private static extern int loadScore();

    public Control c;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("l"))
        {
            int s = loadScore();
            c.GetComponent<Control>().score = s;
        }

        if (Input.GetKey("s"))
        {
            saveScore(c.GetComponent<Control>().score);
        }

    }
}
