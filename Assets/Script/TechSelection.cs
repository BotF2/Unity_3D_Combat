using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Script
{

    public class TechSelection : MonoBehaviour, IPointerDownHandler
    {
        Toggle _activeTechToggle;
        public Toggle Early, Developed, Advanced, Supreme;
        ToggleGroup TechLevelGroup;

        private void Awake()
        {
            Early.isOn = true;
            Developed.isOn = false;
            Advanced.isOn = false;
            Supreme.isOn = false;
        }
        private void Start()
        {
            TechLevelGroup = GetComponent<ToggleGroup>();
            TechLevelGroup.enabled = true;
            Early.isOn = true;
            Early.Select();
            Early.OnSelect(null); // turns background selected color on, go figure.
            Developed.isOn = false;
            Advanced.isOn = false;
            Supreme.isOn = false;
        }
        private void Update()
        {
            _activeTechToggle = TechLevelGroup.ActiveToggles().ToArray().FirstOrDefault();
            ActiveToggle();
        }
        //public void OnClickPlayCiv() // ToDo: call this on play button in Main Menu
        //{
        //    Toggle techToggle = _activeTechToggle;
        //    Debug.Log(techToggle.name + " _ ");
        //}
        public void ActiveToggle()
        {
            switch (_activeTechToggle.name.ToUpper())
            {
                case "TOGGLE_SUPREME":
                    Supreme = _activeTechToggle;
                    GameManager._techLevel = TechLevel.Supreme;
                    GameManager.Instance.LoadStartGameObjectNames(Environment.CurrentDirectory + "\\Assets\\" + "Temp_GameObjectData.txt"); //"SupremeGameObjectsData.txt");
                    Debug.Log("Active Fed.");
                    break;
                case "TOGGLE_ADVANCED":
                    Debug.Log("Active Kling.");
                    Advanced = _activeTechToggle;
                    GameManager._techLevel = TechLevel.Advanced;
                    GameManager.Instance.LoadStartGameObjectNames(Environment.CurrentDirectory + "\\Assets\\" + "Temp_GameObjectData.txt");// "AdvancedGameObjectData.txt");
                    break;
                case "TOGGLE_DEVELOPED":
                    Debug.Log("Active Rom.");
                    Developed = _activeTechToggle;
                    GameManager._techLevel = TechLevel.Developed;
                    GameManager.Instance.LoadStartGameObjectNames(Environment.CurrentDirectory + "\\Assets\\" + "Temp_GameObjectData.txt"); //"DevelopedGameObjectsData.txt");
                    break;
                case "TOGGLE_EARLY":
                    Debug.Log("Active Card.");
                    Early = _activeTechToggle;
                    GameManager._techLevel = TechLevel.Early;
                    GameManager.Instance.LoadStartGameObjectNames(Environment.CurrentDirectory + "\\Assets\\" + "Temp_GameObjectData.txt"); //"EarlyGameObjectData.txt");
                    break;
                default:
                    break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}

