using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour {

    public bool Colisao = false;
    public GameObject Mestre;

	// Use this for initialization
	void Start () {
	
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
            Debug.Log("COLISAO CUBO!");
            Mestre = collision.gameObject;
            Colisao = true;
        }

    }
}
