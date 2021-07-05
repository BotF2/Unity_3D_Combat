using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    [SerializeField] int maxHealth = 20;
    [SerializeField] int currentHealth;
    [SerializeField] float regeneratRate = 2f;
    [SerializeField] int regenerateAmount = 1;
    //int maxHealth = 20;
    //int currentHealth;
    //float regeneratRate = 2f;
    //int regenerateAmount = 1;

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
        currentHealth = maxHealth;
        InvokeRepeating("Regerate", regeneratRate, regeneratRate);

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
    void Regenrate()
    {
        if(currentHealth< maxHealth)
            currentHealth += regenerateAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void shieldsTakeDagame(int damage =1)
    {
        currentHealth -= damage;
        if (currentHealth < 1)
        {
            _shieldsUp = false;
            Destroy(_shields);
            Debug.Log("Shields destroid");
        }
    }
}
