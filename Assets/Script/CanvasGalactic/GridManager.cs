using System.Collections.Generic;
using UnityEngine;

namespace BOTF3D_GalaxyMap
{

    public class GridManager : MonoBehaviour
    {
        private int _width = 10;
        private int _height = 15;
        [SerializeField]
        private Tile _tilePrefab;
        [SerializeField]
        Canvas _canvasGalactic;
        List<Tile> _tile;
        
        //private Transform _cam;

        private void Start()
        {
            //Tile notNull = new Tile();
            //_tile = new List<Tile> { notNull };
            //GenerateGrid();
        }
        void GenerateGrid()
        {
            //for (int inputY = 0; inputY < _height; inputY++)
            //{
            //    for (int x = 0; x < _width; x++)
            //    {

            //        Tile spawnedTile = Instantiate(_tilePrefab, new Vector3((x * 1000f) - 5300f, (inputY * 1000f) - 9800, 600f), Quaternion.identity);
            //        spawnedTile.enabled = true;

            //        spawnedTile.name = $"Tile {x} {inputY}";
            //        spawnedTile.transform.SetParent(_canvasGalactic.transform, false);
            //        var isOffset = (x % 2 == 0 && inputY % 2 != 0) || (x % 2 != 0 && inputY % 2 == 0);
            //        spawnedTile.Init(isOffset);
            //        _tile.Add(spawnedTile);
            //        spawnedTile.gameObject.SetActive(true);
            //        spawnedTile.GetComponent<SpriteRenderer>().enabled = false;
            //    }
            //}
            //_cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 -0.5f,);
        }
        public void SeeGrid()
        {
            //if (_tile != null)
            //{
            //    foreach (Tile tile in _tile)
            //    {
            //        if (tile != null)
            //        {
            //            //tile.gameObject.SetActive(true);
            //            tile.GetComponent<SpriteRenderer>().enabled = true;
            //        }
            //    }
            //}
        }
        public void HideGrid()
        {
            //if (_tile != null)
            //{
            //    foreach (Tile tile in _tile)
            //    {
            //        if (tile != null)
            //        {
            //            tile.GetComponent<SpriteRenderer>().enabled = false;
            //            //tile.gameObject.SetActive(false);
            //        }
            //    }
            //}
        }
    }
}
