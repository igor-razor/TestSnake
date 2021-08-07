using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    GUIStyle style = new GUIStyle();

    private int counter = 0;

    public int COUNTER
    {
        get { return counter; }
        set { counter = value; }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 34), "Omnom: " + counter, style);
    }

    // Start is called before the first frame update
    void Start()
    {
        style.normal.textColor = Color.yellow;
        style.fontSize = 32;
        style.fontStyle = FontStyle.Bold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
