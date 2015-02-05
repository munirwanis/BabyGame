using UnityEngine;
using System.Collections;

public class MouseEvents : MonoBehaviour {

    public float HandSpeed = 0.1f;
    public float Depth = 15f;
    public bool ObjectOnHand = false;
    public bool Collision = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0) && Collision == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                Depth += HandSpeed * 5;
            else
                Depth += HandSpeed;
        }
        if (Input.GetMouseButton(1) && Collision == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                Depth -= HandSpeed * 5;
            else
                Depth -= HandSpeed;
        }

        if (ObjectOnHand)
            renderer.enabled = false;
        else
            renderer.enabled = true;

        Ray HandRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 HandPosition = HandRay.GetPoint(Depth);

        transform.position = HandPosition;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Cubo" && collision.gameObject.name != "Triangulo" && collision.gameObject.name != "Cilindro")
            Collision = true;
    }

    void OnCollisionExit(Collision collision)
    {
        Collision = false;
    }

}
