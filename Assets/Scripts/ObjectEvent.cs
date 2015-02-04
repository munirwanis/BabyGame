using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour {

    public bool Grab = false;
    public GameObject Mestre;

	// Use this for initialization
	void Start () {


        if (this.gameObject.name != "Mesa")
            renderer.material.color = Color.blue;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space) && Mestre != null)
        {
            Mestre.GetComponent<MouseEvents>().ObjectOnHand = false;
            Grab = false;
        }

        if (Grab)
        {
            this.transform.position = Mestre.transform.position;
        }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "babyhand")
        {   
            if (collision.gameObject.GetComponent<MouseEvents>().ObjectOnHand == false)
            {
                Debug.Log("COLISAO: " + this.gameObject.name + " !");
                Mestre = collision.gameObject;
                Mestre.GetComponent<MouseEvents>().ObjectOnHand = true;
                Grab = true;
            }
        }

    }
}
