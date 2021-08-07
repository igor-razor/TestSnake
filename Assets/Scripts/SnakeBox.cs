using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBox : MonoBehaviour
{
    [SerializeField]
    private GameObject GOfront = null;

    public GameObject GOFRONT
    {
        get { return GOfront; }
        set { GOfront = value; }
    }

    private bool started = false;
    public void START() { started = true; }
    public void STOP() { started = false; }

    [SerializeField]
    private float speed_side = 0.0f;

    public float SPEED_SIDE
    {
        get { return speed_side; }
        set { speed_side = value; }
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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GOFRONT.transform.position.x, transform.position.y,transform.position.z), speed_side * Time.deltaTime);
        }
    }
}
