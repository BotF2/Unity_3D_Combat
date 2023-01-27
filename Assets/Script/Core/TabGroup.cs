using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;


namespace BOTF3D_Core
{
    public class TabGroup : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        public Sprite tabIdel;
        public Sprite tabHover;
        public Sprite tabSelected;
        public TabButton selectedTab;

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
            selectedTab = button;
            ResetTabs();
            button.background.sprite = tabSelected;
        }
        public void ResetTabs()
        {
            foreach ( TabButton button in tabButtons)
            {
                if (selectedTab != null && button == selectedTab)
                    continue;
                button.background.sprite = tabIdel;
            }
        }
    }
}

