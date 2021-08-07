using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerColor : MonoBehaviour
{
    public GameObject GOsnakeHead;

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
            GOsnakeHead.GetComponent<SnakeHead>().COLOR = color;
            
            foreach (GameObject go in GOsnakeHead.GetComponent<SnakeHead>().Lsnake)
                { go.GetComponent<Renderer>().material.color = color; }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//public class ChangerColor : MonoBehaviour
