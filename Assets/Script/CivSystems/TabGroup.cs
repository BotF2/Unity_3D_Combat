using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;


namespace BOTF3D_Core
{
    public enum TabButtons
    {
        TabDefense,
        TabResearch,
        TabSpy,
        TabIndustry,
    }
    public class TabGroup : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        public Sprite tabIdel;
        public Sprite tabHover;
        public Sprite tabActive;
        public TabButton selectedTab;
        public List<GameObject> objectsToSwap;
       
        public void Subscribe(TabButton button) 
        {
            if (tabButtons == null)
            {
                tabButtons = new List<TabButton>();
            }
            tabButtons.Add(button);
        }
        public void OnTabEnter(TabButton button)
        {
            ResetTabs();
            if (selectedTab == null || button !=selectedTab)
                button.background.sprite = tabHover;
            
        }
        public void OnTabExit(TabButton button)
        {
            ResetTabs();
        }

        public void onTabSelected(TabButton button) 
        {
            if (selectedTab != null)
            {
                selectedTab.Deselect();
            }
            selectedTab = button;
            selectedTab.Select();
            ResetTabs();
            button.background.sprite = tabActive;
            int index = (int)button.tabForPanel;
            for (int i = 0; i < objectsToSwap.Count; i++)
            {
                if(i == index)
                {
                    objectsToSwap[i].SetActive(true);
                }
                else
                {
                    objectsToSwap[i].SetActive(false);
                }
            }
        }
        public void ResetTabs()
        {
            foreach ( TabButton button in tabButtons)
            {
                if (selectedTab != null && button == selectedTab)
                    { continue; }
                button.background.sprite = tabIdel;
            }
        }

    }
}

