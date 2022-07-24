using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class SaveGamePanel : MonoBehaviour
    {
        public GameObject Panel;

        public void Start()
        {
            Panel.SetActive(false);
        }
        public void OpenPanel()
        {
            if(Panel != null)
            {
                Panel.SetActive(true);
            }
        }
        public void ClosePanel()
        {
            if (Panel != null)
                Panel.SetActive(false);
        }
    }
}
