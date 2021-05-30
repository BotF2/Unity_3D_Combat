using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{

    public class Ships : MonoBehaviour
    {
        public int _shields = 100;
        public int _hull = 100;
        public int _points = 100; // Score
        public Material _hitMaterial;


        Material _orgMaterial;
        Renderer _renderer;
        private Object _gameObject;

        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _orgMaterial = _renderer.sharedMaterial;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (_shields > 0)
            {
                _shields--;
            }
            else if (_hull > 0)
            {
                _hull--;
            }
            else
            {
                GameManager.Instance.Score += _points;
                Destroy(_gameObject);
            }
            _renderer.sharedMaterial = _hitMaterial;
            Invoke("RestoreMaterial", 0.05f);
        }
        private void RestoreMaterial()
        {
            _renderer.sharedMaterial = _orgMaterial;
        }
    }
}
