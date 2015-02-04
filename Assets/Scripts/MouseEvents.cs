using UnityEngine;
using System.Collections;

public class MouseEvents : MonoBehaviour {

    public float DefaultHandZ = 15.13532f;
    public float Depth = 15f;
    public bool ObjectOnHand = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0))
        {
            Depth++;
        }
        if (Input.GetMouseButton(1))
        {
            Depth--;
        }

        Ray HandRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 HandPosition = HandRay.GetPoint(Depth);

        transform.position = HandPosition;
	}

    void OnCollisionEnter(Collision collision){
  
        ObjectOnHand = true;    
	}

    void OnCollisionExit(Collision collision)
    {
        
    }
}
