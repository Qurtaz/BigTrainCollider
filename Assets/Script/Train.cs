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
        public GameObject locomotiva;
        public GameObject poprzednik;
        public GameObject particle;
    }
    class Train : MonoBehaviour
    {
        private int howManyCar;
        public Gobject g;
        public Vector3 przesun;
        private List<GameObject> listaGO;
        private Vector3 rotacja;
        private Vector3 skala;
        public void Start()
        {
            listaGO = new List<GameObject>();
            rotacja = new Vector3(90f, 0, 0);
            howManyCar = 0;
            listaGO.Add(g.poprzednik);
            createLocomotive();
            createAllCar();
            listaGO[1].transform.Rotate(rotacja);
            skala = new Vector3(0.1535039f, 0.2225809f, 0.1535039f);
            listaGO[1].transform.localScale = new Vector3(1f, 1f, 1f);
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
            for(int i=0;i<howManyCar;i++)
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
        private void createLocomotive()
        {
            GameObject tmp = Instantiate(g.locomotiva, g.poprzednik.transform.position , g.poprzednik.transform.rotation) as GameObject;
            addPartice(tmp);
            tmp.transform.parent = g.poprzednik.transform;
            g.poprzednik = tmp;
            listaGO.Add(tmp);
        }
        private void createCar(GameObject c1)
        {
            Debug.Log(przesun);
            GameObject tmp = Instantiate(c1, g.poprzednik.transform.position, g.poprzednik.transform.rotation) as GameObject;
            tmp.transform.parent = g.poprzednik.transform;
            if(listaGO[1]==g.poprzednik)
            {
                tmp.transform.localPosition = new Vector3(0,-0.78f,0);
            }
            else
            {
                tmp.transform.localPosition = przesun;
            }
            
            g.poprzednik = tmp;
            listaGO.Add(tmp);
        }
        void addPartice(GameObject temp)
        {
            GameObject tmp = Instantiate(g.particle, temp.transform.position - new Vector3(0.1f, -0.1f,0), temp.transform.rotation) as GameObject;
            tmp.transform.parent = temp.transform;
        }
        void Update()
        {
        }
    }
}
