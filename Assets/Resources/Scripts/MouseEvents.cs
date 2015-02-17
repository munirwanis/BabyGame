using UnityEngine;
using System.Collections;

public class MouseEvents : MonoBehaviour {

    public float HandSpeed = 0.1f;
    public float Depth = 15f;
    public bool ObjectOnHand = false;
    public bool Collision = false;
    public GameObject Cubo;
    public GameObject Triangulo;
    public GameObject Cilindro;
    public GameObject Objeto = null;

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

        if (Input.GetKeyUp(KeyCode.Alpha1) && ObjectOnHand == false)
        {
            Objeto = Instantiate(Cubo, transform.position, Quaternion.Euler(new Vector3(330.8729f,3.809764f,358.1435f))) as GameObject;
            Objeto.transform.localScale = Cubo.transform.localScale * 200;
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
        if (collision.gameObject.name == "Cubo" || collision.gameObject.name == "Triangulo" || collision.gameObject.name == "Cilindro")
            if (collision.gameObject.GetComponent<ObjectEvent>().OnTable == true && ObjectOnHand == false)
                Collision = true;

        if (collision.gameObject.name.Contains("Cubo") == false && collision.gameObject.name.Contains("Triangulo") == false && collision.gameObject.name.Contains("Cilindro") == false)
            Collision = true;
    }

    void OnCollisionExit(Collision collision)
    {
        Collision = false;
    }

}