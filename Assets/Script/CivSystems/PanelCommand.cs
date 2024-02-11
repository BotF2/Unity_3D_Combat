using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GalaxyMap;
using TMPro;
using System;

namespace Assets.Core
{
    public class PanelCommand : MonoBehaviour
    {
        //CivilizationData civilizationData;
        [SerializeField] private List<TextMeshProUGUI> controlText;
        private static float defenceBudget = 100f;
        private static float researchBudget = 20f;
        private static float intelBudget = 10f;
        private static float industrialBudget = 20f;
        private float[] budgetArray = new float[]{ defenceBudget, researchBudget, intelBudget, industrialBudget };

        public Panels thisPanel;

        private void Update()
        {
            for (int i = 0; i < controlText.Count; i++)
            {
                controlText[i].text = budgetArray[i].ToString();
            }
        }
        public void DisplayBudget(float[] budget) // only for local civ
        {
            float j;
            for (int i = 0; i < budget.Length; i++)
            {
                j = (float)Math.Round((double)budget[i], 1);
                budgetArray[i] += j;
            }
        }
        public void BalanceTheBudget(float[] budget)
        {
            
        }

    }
}
