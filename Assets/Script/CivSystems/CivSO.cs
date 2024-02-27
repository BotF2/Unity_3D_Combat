using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Assets.Core;
using UnityEngine.Analytics;


[CreateAssetMenu(fileName = "CivSO", menuName = "Civ")]
public class CivSO : ScriptableObject
{
    public int CivInt;
    public string CivEnum;
    public string CivShortName;
    public string CivLongName;
    public string CivHomeSystem;
    public string TraitOne;
    public string TraitTwo;
    public string CivImage;
    public string Insignia;
    public int Population;
    public int Credits;
    public int TechPoints;
    //public string Description;
}


