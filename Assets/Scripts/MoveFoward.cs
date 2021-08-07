using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public GameObject Gomain = null;
    private bool started = false;
    public void START() { started = true; }
    public void STOP() { started = false; }

    private float speed_foward = 0.0f;

    public float SPEED_FOWARD
    {
        get { return speed_foward; }
        set { speed_foward = value; }
    }

    private int border = 0;

    public int BORDER
    {
        get { return border; }
        set { border = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), speed_foward * Time.deltaTime);
        }

        if (transform.position.z >= BORDER)
        {
            STOP();
            if (Gomain != null) { Gomain.GetComponent<MainGen>().Restart(); }
        }
    }
}
