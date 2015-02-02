using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour {

    public bool Colisao = false;
    public GameObject Mestre;

	// Use this for initialization
	void Start () {

        if (this.gameObject.name != "Mesa")
            renderer.material.color = Color.blue;

	}
	
	// Update is called once per frame
	void Update () {

        if (Colisao)
        {
            this.transform.position = Mestre.transform.position;
        }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "babyhand")
        {
            Debug.Log("COLISAO: " + this.gameObject.name + " !");
            Mestre = collision.gameObject;
            Colisao = true;
        }

    }
}
