using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadCube : MonoBehaviour, IPointerClickHandler
{
    public GameObject GOsnakeHead;

    public void OnPointerClick(PointerEventData eventData)
    {
       // Debug.Log(gameObject.name);
       GOsnakeHead.GetComponent<SnakeHead>().GOROAD = gameObject;
        //throw new NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//public class RoadCube : MonoBehaviour
