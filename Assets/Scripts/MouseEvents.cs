using UnityEngine;
using System.Collections;

public class MouseEvents : MonoBehaviour {

    public float Depth = 10f;

	// Use this for initialization
	void Start () {

        Vector2 MousePos = Input.mousePosition;
        Vector3 HandPosition = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, Depth));

        HandPosition.z = Depth;

        transform.position = HandPosition;

        Screen.showCursor = true;

        Debug.Log("POSZ: " + this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

        float posz = this.transform.position.z;

        Vector2 MousePos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            if (posz != Depth)
                posz = Depth;
            else
                posz = 20.13531f;

            Debug.Log("POSZ: " + posz);
        }

        Vector3 HandPosition = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, Depth));

        HandPosition.z = posz;

        transform.position = HandPosition;  
	}

    void OnCollisionEnter(Collision collision){

	}

    void OnCollisionExit(Collision collision)
    {

    }
}
