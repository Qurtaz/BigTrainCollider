using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	private Vector3 offset;
    private Vector3 rotacionOffset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - Player.transform.position;
        rotacionOffset = transform.rotation.ToEuler() - Player.transform.rotation.ToEuler();
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
        transform.position = Player.transform.position + offset;
        Vector3 temp = transform.rotation.eulerAngles;
        temp.z = Player.transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(temp);
    }
}
