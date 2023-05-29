using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
//using BOTF3D_GalaxyMap;
using BOTF3D_Combat;
using BOTF3D_Core;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

namespace BOTF3D_GalaxyMap
{
    public class SystemDefControl : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;
        private List<int> intList;

        private void Start()
        {
            for (int i = 0; i < 20; i++)//intList.Count; i++)
            {
                GameObject button = Instantiate(buttonPrefab) as GameObject;
                button.SetActive(true);
                button.GetComponent<SystemDefButton>().SetText("Sol Earth");
                button.transform.SetParent(buttonPrefab.transform.parent, false);
            }
        }
    }
}
