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
        static public void GetKlingTrans(GameObject gameObject)
        {
            gameObject.transform.localScale = new Vector3(500, 500, 500);
            gameObject.transform.rotation *= Quaternion.Euler(0, -90f, 0);
        }
        static public void GetFedTrans(GameObject gameObject)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.transform.rotation *= Quaternion.Euler(0, 90f, 0);
        }
        static public void Scale500(GameObject objectScale)
        {
            objectScale.transform.localScale = new Vector3(500, 500, 500);
        }
        static public void Rotate180(GameObject turnAround)
        {
            turnAround.transform.rotation *= Quaternion.Euler(0, 180f, 0);

        }
        static public void RotatePlues90(GameObject turnLeft)
        {
            turnLeft.transform.rotation *= Quaternion.Euler(0, 90f, 0);

        }
        static public void RotateNegative90(GameObject turnRight)
        {
            turnRight.transform.rotation *= Quaternion.Euler(0, -90f, 0);
        }
    }
}
