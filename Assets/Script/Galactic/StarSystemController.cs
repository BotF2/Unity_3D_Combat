using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;

namespace GalaxyMap
{
    public class StarSystemController : MonoBehaviour
    {
        public StarSystemData starSysData;
        public Camera camGalactica;
        [SerializeField, Tooltip("Owner Name.")]
        private Transform cameraGalacticTransform;
        private CivEnum starSysCurrentOwner;

        private void Awake()
        {
            //starSysCurrentOwner = starSysData.currentCivOwnerEnum;
        }
        private void Start()
        {
            cameraGalacticTransform = camGalactica.transform;
        }
        public void Update()
        {
            // star systems do not move
        }

        public void LoadSystemOwner(CivData civData, StarSystemSO sysData) // Now CivData can provide newCivDataOnwer data for system
        { // Do we need this anymore?
            //StarSystemSO theSystemData = StarSystemManager.StarSystemDictionary[sysData];
            //theSystemData._ownerCiv = civData;
            //theSystemData._currentOwnerName = civData._shortNameText.ToString();
            //theSystemData._ownerInsigniaSprite = civData._insignia; // Resources.Load<Sprite>("Insignia/" + sysData._sysName.ToUpper());
            //theSystemData._ownerCivSprite = civData._civImage; //Resources.Load<Sprite>("Civilizations/" + sysData._sysName.ToLower());
            //theSystemData._homeColony = true;
            //civOwnerImage.sprite = theSystemData._ownerCivSprite;
            //civInsignia.sprite = theSystemData._ownerInsigniaSprite;
            //originalCivOwnerName = theSystemData._originalOwnerName;
        }
    }

}
