using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tap : MonoBehaviour {

    // Use this for initialization
    public GameObject popUps;
    private int popUpIndex;


	void Start () {
        
        StartCoroutine(waiter());
    }


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        popUps.SetActive(true);
    }
    // Update is called once per frame


}
