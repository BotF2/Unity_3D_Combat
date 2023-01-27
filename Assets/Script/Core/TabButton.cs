using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Script;
using BOTF3D_GalaxyMap;
using BOTF3D_Combat;

namespace BOTF3D_Core
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public TabGroup tabGroup;

        public Image background;

        public void OnPointerClick(PointerEventData eventData)
        {
            tabGroup.onTabSelected(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.onTabSelected(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tabGroup.onTabSelected(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            background= GetComponent<Image>();
            tabGroup.Subscribe(this);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
