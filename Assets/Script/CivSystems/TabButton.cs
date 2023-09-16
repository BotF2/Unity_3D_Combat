using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;

namespace BOTF3D_Core
{
    public enum Panels
    {
        PanelDefense,
        PanelResearch,
        PanelSpy,
        PanelIndustry,
    }

    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public TabGroup tabGroup;
        public Image background;
        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;
        public Panels tabForPanel;

        public void OnPointerClick(PointerEventData eventData)
        {
            tabGroup.onTabSelected(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.OnTabEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tabGroup.OnTabExit(this);
        }

        void Start()
        {
            background= GetComponent<Image>();
            tabGroup.Subscribe(this);

        }
        public void Select()
        {
            if(onTabSelected!= null)
            {
                onTabSelected.Invoke();
            }
        }
        public void Deselect()
        {
            if(onTabDeselected != null)
            {
                onTabDeselected.Invoke();
            }
        }

    }
}
