using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformacion : MonoBehaviour
{
    public enum TurtlePstation
    {
        _TurtleA,
        _TurtleP,
        
    }

    private int _childCount;

    // Start is called before the first frame update
    void Start()
    {
        _childCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(TurtlePstation turtlePstation)
    {
        switch (turtlePstation)
        {
            case TurtlePstation._TurtleA:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                break;
            case TurtlePstation._TurtleP:
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(false);
                break;
        }
    }
}
