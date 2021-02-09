using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoveSwipe : MonoBehaviour {

    private Vector3 startTouchPosition, endTouchPosition;
    private Vector3 startRocketPosition, endRocketPosition;
    private float flyTime;
    private float flightDuration = 0.1f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            /*
            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
                StartCoroutine(Fly("left"));

            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 1.75f)
                StartCoroutine(Fly("right"));
                */

            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > -0.5f)
            {
                StartCoroutine(Fly("down"));

                Debug.Log("down");

            }

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < 0.5f)
                StartCoroutine(Fly("up"));

   

        }
    }

    private IEnumerator Fly(string whereToFly)
    {
        switch (whereToFly)
        {
            case "down":
                flyTime = 0f;
                startRocketPosition = transform.position;
                endRocketPosition = new Vector3
                    (startRocketPosition.x , transform.position.y -15.0f, transform.position.z);

                while (flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector3.Lerp
                        (startRocketPosition, endRocketPosition, flyTime / flightDuration);
                    yield return null;
                }
                break;

            case "up":
                flyTime = 0f;
                startRocketPosition = transform.position;
                endRocketPosition = new Vector3
                    (startRocketPosition.x , transform.position.y + 15.0f, transform.position.z);

                while (flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector3.Lerp
                        (startRocketPosition, endRocketPosition, flyTime / flightDuration);
                    yield return null;
                }
                break;
        }

    }
}
