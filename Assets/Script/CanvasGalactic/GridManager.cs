using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using BOTF3D_Core;
using BOTF3D_Combat;
using Assets.Script;

namespace BOTF3D_GalaxyMap
{

    class GridManager : MonoBehaviour
    {
        [SerializeField]
        private int _width = 10;
        [SerializeField]
        private int _height = 15;// whey is this changed to 10??? Hard coded for loop to 15
        [SerializeField]
        private Tile _tilePrefab;
        [SerializeField]
        Canvas _canvasGalactic;
        //List<Tile> _objects;
        //private Transform _cam;

        private void Start()
        {
            GenerateGrid();
        }
        void GenerateGrid()
        {
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 10; x++)
                {

                    Tile spawnedTile = Instantiate(_tilePrefab, new Vector3((x * 1000f) - 5100f, (y * 1000f) - 9800, 600f), Quaternion.identity);
                    //spawnedTile.enabled = true;
                    //spawnedTile.transform.localScale = spawnedTile.transform.localScale* 1000f;
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.transform.SetParent(_canvasGalactic.transform, false);
                    var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                    spawnedTile.Init(isOffset);
                    spawnedTile.gameObject.SetActive(true);
                }
            }
            //_cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 -0.5f,);
        }
    }
}
