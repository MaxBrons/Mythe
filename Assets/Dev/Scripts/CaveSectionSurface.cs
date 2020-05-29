using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSectionSurface : MonoBehaviour
{
    private const string _template = "CaveSections";
    private const string _functionName = "AddSurface";
    private void Start() {
        Invoke(_functionName, 5f);
    }

    private void AddSurface() {
        GameObject.FindGameObjectWithTag(_template).GetComponent<CaveSectionTemplate>().AddCaveSurface(gameObject);
    }
}
