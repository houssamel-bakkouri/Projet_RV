using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public bool isHolding = false;
    public Cube inHandCube;
    public OVRInput.Button button2 = OVRInput.Button.Two;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button2))
        {
            if (isHolding) 
            {
                isHolding = false;
                inHandCube.pickedUp = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Cube>(out var cube))
        {
            cube.pickedUp = true;
            cube.controller = transform;
            inHandCube = cube;
            isHolding = true;
        } 
    }

}
