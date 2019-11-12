using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startPlay()
    {
        ps.Play();
    }

    public void stopPlay()
    {
        ps.Stop();
    }

    public void pause()
    {
        ps.Pause();
    }

    public void setPosition(Vector3 pos)
    {
        ps.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
