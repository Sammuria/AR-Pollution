using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlane : MonoBehaviour {


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,40);
        transform.localScale = new Vector3(3, 1, 2);


    }
}
