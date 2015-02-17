using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour {

    public float InitialLocalPosX;
    public float InitialLocalPosZ;
    public float FinalLocalPosY = 0.013f;
    public bool OnTable = false;
    public bool Grab = false;
    public GameObject Mestre;

	// Use this for initialization
	void Start () {

        Vector3 MyPosition = transform.position;

        if (this.gameObject.name != "Mesa")
            renderer.material.color = Color.blue;

        InitialLocalPosX = transform.localPosition.x;
        InitialLocalPosZ = transform.localPosition.z;

        transform.position = transform.position * 4;

        RandomPosition(MyPosition);
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
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (renderer.material.color == Color.red)
            renderer.material.color = Color.blue;
    }

    void RandomPosition(Vector3 MyPosition)
    {
        float[] Positions = {-3.644695f, -0.3142252f, 3.494558f};
        bool Ocupado = true;
        int AntiLoop = 0;
        int Rnd;
        Ray RayCast;
        RaycastHit Hit;

        while (Ocupado && AntiLoop < 20)
        {
            Rnd = Random.Range(0, 3);
            RayCast = new Ray(Vector3.zero, new Vector3(Positions[Rnd], MyPosition.y, MyPosition.z));

            if (Rnd == 0)
                Debug.DrawRay(Vector3.zero, new Vector3(Positions[Rnd], MyPosition.y, MyPosition.z), Color.red, 10f);
            else if (Rnd == 1)
                Debug.DrawRay(Vector3.zero, new Vector3(Positions[Rnd], MyPosition.y, MyPosition.z), Color.green, 10f);
            else
                Debug.DrawRay(Vector3.zero, new Vector3(Positions[Rnd], MyPosition.y, MyPosition.z), Color.blue, 10f);

            if (Physics.Raycast(RayCast, out Hit))
            {
                if (Hit.collider == null)
                {
                    Debug.Log(Hit.collider.gameObject.name);
                    transform.position = new Vector3(Positions[Rnd], MyPosition.y, MyPosition.z);
                    Ocupado = false;
                }
                else
                {
                    AntiLoop++;
                    if (Hit.collider.gameObject.name == "Cubo")
                    {
                        Debug.Log("COLLIDER POS: " + Hit.transform.position);
                        Debug.Log("POSICAO ATUAL: " + transform.position);
                        Debug.Log("POSICAO ANTIGA: " + MyPosition);
                    }
                }
            }
                
        }
    }
}
