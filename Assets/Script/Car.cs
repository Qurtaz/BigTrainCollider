using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    public AudioSource audio;
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Destroy(collision.gameObject);
            audio.Play();
        }
    }
}
