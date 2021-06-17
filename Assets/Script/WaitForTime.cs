using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class WaitForTime
    {
        //void Start()
        //{
        //    //Start the coroutine we define below named ExampleCoroutine.
        //    StartCoroutine(ExampleCoroutine());
        //}

        IEnumerator ExampleCoroutine(float waitTime)
        {
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(waitTime);
        }
    }
}
