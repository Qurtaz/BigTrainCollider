using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    public AudioSource muzyka;
    public GameObject partice;
    public GameObject koniecGry;
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Grund")
            {
                return;
            }
            else
            {
                if(gameObject.transform.parent == collision.gameObject)
                            {
                                return;
                            }
                            else
                            {

                                Debug.Log(gameObject.name);
                                Debug.Log(collision.gameObject.name);
                                muzyka.Play();
                                GameObject tmp =  Instantiate(partice, collision.gameObject.transform.position, collision.gameObject.transform.rotation) as GameObject;
                                Destroy(collision.gameObject);
                                Destroy(gameObject);
                                Destroy(tmp);
                                Instantiate(koniecGry);
                            }
            }
        }
    }
}
