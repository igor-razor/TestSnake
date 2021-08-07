using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public List<GameObject> Lsnake = new List<GameObject>();

    [SerializeField]
    private Color color = Color.gray;

    public int H = 0;

    public Color COLOR
    {
        get { return color; }
        set { color = value; }
    }

    [SerializeField]
    private GameObject GOroad = null;

    public GameObject GOROAD
    {
        get { return GOroad; }
        set { GOroad = value; }
    }

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
        if (GOroad != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GOroad.transform.position.x, H, transform.position.z) , speed_side * Time.deltaTime);
        }
    }
}//public class SnakeHead : MonoBehaviour
