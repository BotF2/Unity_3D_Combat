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
        private int _width = 1000, _height = 1000;
        [SerializeField]
        private Tile _tilePrefab;
        [SerializeField]
        private Transform _cam;

        private void Start()
        {
            GenerateGrid();
        }
        void GenerateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3((x * 100f) - 500f, (y * 100f) - 626, 218f), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";

                    var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                    spawnedTile.Init(isOffset);
                }
            }
            //_cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 -0.5f,);
        }
    }
}
