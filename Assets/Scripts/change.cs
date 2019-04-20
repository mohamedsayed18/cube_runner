using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//change the color on command


public class change : MonoBehaviour
{
    //define some variables
    Renderer thisRend; //renderer of our cube
    float transitionTime = 5f; // Amount of time it takes to fade between colors

    // Start is called before the first frame update
    void Start()
    {
        thisRend = GetComponent<Renderer>(); // grab the renderer component on our sphere

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("up"))//returns true if the key is pressed
        {
            print("up arrow key is held down");
            thisRend.material.SetColor("_Color", Color.green);
        }
        if (Input.GetKey("down"))//returns true if the key is pressed
        {
            print("down arrow key is held down");
        }
    }
}
