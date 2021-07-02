using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    public GameObject _shields;
    private bool _shieldsUp;

    public bool ShieldsUp
    {
        get { return _shieldsUp; }
        set { _shieldsUp = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _shieldsUp = true;
        _shields.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_shieldsUp)
        {
            _shields.SetActive(false); // set it in sceen
        }
        else
        {
            _shields.SetActive(true);
        }

    }
}
