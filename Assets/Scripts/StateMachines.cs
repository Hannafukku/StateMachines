using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StateMachines : MonoBehaviour
{



    public enum State
    {
    idle,
    walking,
    swimming,
    climbing

    }
     
    public State Currentstate = State.idle;
    Vector3 lastposition;


    // Start is called before the first frame update
    void Start()
    {
        lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      switch (Currentstate)
        {
            case State.idle: Idle(); break;
            case State.walking: Walking(); break;
            case State.swimming: Swimming(); break;
            case State.climbing: Climbing(); break;
           default: break;

        }
    }

     void OnTriggerEnter(Collider other)
    {
       if(other.name == "WaterTrigger")
       
        {
            Currentstate = State.swimming;
        }

       else if(other.name == "MountainTrigger")
        {
            Currentstate = State.climbing;
        }

    }

     void OnTriggerExit(Collider other)
    {
        Currentstate = State.walking;
    }

    void Swimming()
    {
        Debug.Log("i am swimming");
    }

    void Climbing()
    {
        Debug.Log("I am climbing");  
    }

    void Idle()
    {
        Debug.Log("i am idle");
        if(lastposition != transform.position)
        {
            Currentstate = State.walking;
        }
        lastposition = transform.position;
    }

    void Walking()
    {
        Debug.Log("I am walking");
        if (lastposition == transform.position)
        {
            Currentstate = State.idle;
        }
        lastposition = transform.position;
    }
}
