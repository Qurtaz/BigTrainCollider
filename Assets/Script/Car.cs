using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    public AudioSource audio;
    public GameObject partice;
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(audio);
            audio.Play();
            Instantiate(partice, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
