using UnityEngine;
using System.Collections;

public class MouseEvents : MonoBehaviour {

    public float OriginalPosZ = 15.13532f;
    public float Depth = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float posz = this.transform.position.z;

        Vector2 MousePos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            if (posz != OriginalPosZ)
                posz = OriginalPosZ;
            else
                posz = 20.13531f;
        }

        Vector3 HandPosition = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, Depth));

        HandPosition.z = posz;

        transform.position = HandPosition;  
	}

    void OnCollisionEnter(Collision collision){

		if (collision.gameObject.name == "Cubo")
			Debug.Log("HUEHUEHUE:");

	}
}
