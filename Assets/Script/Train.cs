using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    [System.Serializable]
    class Gobject
    {
        public GameObject car1;
        public GameObject car2;
        public GameObject car3;
        public GameObject car4;
        public GameObject poprzednik;
    }
    class Train : MonoBehaviour
    {
        public AudioSource audio;
        private int howManyCar;
        public Gobject g;
        public Vector3 przesun;
        private List<GameObject> listaGO;
        public void Start()
        {
            listaGO = new List<GameObject>();
            howManyCar = 2;
            listaGO.Add(g.poprzednik);
            createAllCar();
        }
        public void addCar()
        {
        howManyCar=howManyCar+1;
        }
        public void deleteCar(int N)
        {
            howManyCar = howManyCar - N;
        }
        public void createAllCar()
        {
            przesun = new Vector3(0.2f, 0f, 0f);
            for(int i=0;i<=howManyCar;i++)
            {
                int wagon = Random.Range(1,4);
                switch(wagon)
                {
                    case 1:
                        {
                            createCar(g.car1);
                            break;
                        }
                    case 2:
                        {
                            createCar(g.car2);
                            break;
                        }
                    case 3:
                        {
                            createCar(g.car3);
                            break;
                        }
                    case 4:
                        {
                            createCar(g.car4);
                            break;
                        }
                }
                
            }
        }
        private void createCar(GameObject c1)
        {
            GameObject tmp = Instantiate(c1, g.poprzednik.transform.position - przesun, g.poprzednik.transform.rotation) as GameObject;
            g.poprzednik = tmp;
            listaGO.Add(tmp);
            tmp.transform.parent = g.poprzednik.transform;
        }
        void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Destroy(collision.gameObject);
                audio.Play();
            }

        }
        void Update()
        {
            for(int i=1;i<howManyCar;i++)
            {
                listaGO[i].transform.position = listaGO[i - 1].transform.position;
            }
        }
    }
}
