using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour {

    public float InitialPosZ;
    public float InitialPosX;
    public bool OnTable = false;
    public bool Grab = false;
    public GameObject Mestre;

	// Use this for initialization
	void Start () {

        if (this.gameObject.name != "Mesa")
            renderer.material.color = Color.blue;

        InitialPosX = transform.localPosition.x;
        InitialPosZ = transform.localPosition.z;

        Debug.Log(gameObject.name + " - POSX: " + InitialPosX + "    POZ: " + InitialPosZ);
        //transform.position = new Vector3(InitialPosX, 0.011f, InitialPosZ);

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space) && Mestre != null)
        {
            Mestre.GetComponent<MouseEvents>().ObjectOnHand = false;
            Grab = false;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log(gameObject.name + " - POSX: " + transform.position.x + " POSY: " + transform.position.y + "    POZ: " + transform.position.z);
        }

        if (Grab)
        {
            this.transform.position = Mestre.transform.position;
        }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Colisor " + gameObject.name))
        {
            Debug.Log("COLISAO: " + gameObject.name + " NA MESA DO " + collision.gameObject.name);
            transform.position = new Vector3(transform.position.x, 0.011f, transform.position.z);
            OnTable = true;
            Grab = false;
            Mestre.GetComponent<MouseEvents>().ObjectOnHand = false;
        }
       
        if (collision.gameObject.name == "babyhand" && OnTable == false)
        {
            if (collision.gameObject.GetComponent<MouseEvents>().ObjectOnHand == false)
            {
                Mestre = collision.gameObject;
                Mestre.GetComponent<MouseEvents>().ObjectOnHand = true;
                Grab = true;
            }
        }
    }
}
