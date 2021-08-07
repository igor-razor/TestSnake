using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public GameObject Gomain = null;
    public GameObject GOsnakeHead = null;

    private Color color = Color.gray;

    public Color COLOR
    {
        get { return color; }
        set { color = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GOsnakeHead)
        {
            if (GOsnakeHead.GetComponent<SnakeHead>().COLOR == color)
            {
                //Debug.Log("true");
                Gomain.GetComponent<Counter>().COUNTER++;
                Destroy(gameObject);
            }

            if (GOsnakeHead.GetComponent<SnakeHead>().COLOR != color)
            {
                //Debug.Log("false");
                Gomain.GetComponent<MainGen>().Restart();
            }


        }
    }//private void OnTriggerEnter(Collider other)


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//public class Eat : MonoBehaviour
