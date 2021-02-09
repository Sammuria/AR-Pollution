using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manualTap : MonoBehaviour {

    // Use this for initialization
    public GameObject first;
    public GameObject next;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnMouseDown()
    {
        first.SetActive(false);
        next.SetActive(true);
     
    }
}
