using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour {

    public float InitialLocalPosX;
    public float InitialLocalPosZ;
    public float FinalLocalPosY = 0.013f;
    public bool Randomize = true;
    public bool OnTable = false;
    public bool Grab = false;
    public GameObject Mestre;

	// Use this for initialization
	void Start () {

        if (this.gameObject.name != "Mesa")
            renderer.material.color = Color.blue;

        InitialLocalPosX = transform.localPosition.x;
        InitialLocalPosZ = transform.localPosition.z;

        RandomPosition();
	}

	// Update is called once per frame
	void Update () {   

        if (Input.GetKeyUp(KeyCode.Space) && Mestre != null)
        {
            Mestre.GetComponent<MouseEvents>().ObjectOnHand = false;
            Grab = false;
        }     

        if (Grab)
            this.transform.position = Mestre.transform.position;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Colisor " + gameObject.name))
        {
            transform.localPosition = new Vector3(InitialLocalPosX, FinalLocalPosY, InitialLocalPosZ);
            renderer.material.color = Color.green;
            OnTable = true;
            Grab = false;
            Mestre.GetComponent<MouseEvents>().ObjectOnHand = false;
        }

        else if (collision.gameObject.name.Contains("Colisor"))
            renderer.material.color = Color.red;
       
        if (collision.gameObject.name == "babyhand" && OnTable == false)
        {
            if (collision.gameObject.GetComponent<MouseEvents>().ObjectOnHand == false)
            {
                Mestre = collision.gameObject;
                Mestre.GetComponent<MouseEvents>().ObjectOnHand = true;
                Grab = true;
                Randomize = false;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (Randomize)
            RandomPosition();
    }

    void OnCollisionExit(Collision collision)
    {
        if (renderer.material.color == Color.red)
            renderer.material.color = Color.blue;

    }

    void RandomPosition()
    {
        Vector3[] Positions = { new Vector3(-3.644695f, 3.2f, 21.3f), new Vector3(-0.3142252f, 3.2f, 21.1f), new Vector3(3.5f, 3.1f, 21f) };
        int Rnd;
        Rnd = Random.Range(0, 3);

        rigidbody.MovePosition(Positions[Rnd]);
    }
}
