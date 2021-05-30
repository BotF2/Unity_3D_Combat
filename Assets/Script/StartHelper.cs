using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class StartHelper : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        static public void Scale1000(GameObject blenderModel)
        {
            blenderModel.transform.localScale = new Vector3(1000, 1000, 1000);
        }
        static public void Rotate180(GameObject turnAround)
        {
            turnAround.transform.rotation *= Quaternion.Euler(0, 180f, 0);

        }
        static public void RotatePlues90(GameObject turnAround)
        {
            turnAround.transform.rotation *= Quaternion.Euler(0, 90f, 0);

        }
        static public void RotateNegative90(GameObject turnAround)
        {
            turnAround.transform.rotation *= Quaternion.Euler(0, -90f, 0);
        }
    }
}
