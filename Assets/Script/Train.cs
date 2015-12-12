using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    class Train : MonoBehaviour
    {
        private int howManyCar;
        public GameObject car1;
        public GameObject car2;
        public GameObject car3;
        public GameObject car4;
        public Transform locomotive;
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
            Vector3 przesun = new Vector3(0.2f, 0f, 0f);
            for(int i=0;i<=howManyCar;i++)
            {
                Instantiate(car1, locomotive.position-(przesun* i), locomotive.rotation);
            }
        }
    }
}
