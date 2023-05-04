using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int conceptID;
    public bool selected = false;
    public bool displaying;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && selected && !displaying)
        {
            DisplayProperties();
        }
    }

    private void DisplayProperties()
    {
        Debug.Log("Properties display");
        // display the properties of the concept
    }

    public void SelectConcept()
    {
        selected = true;
    }



}
