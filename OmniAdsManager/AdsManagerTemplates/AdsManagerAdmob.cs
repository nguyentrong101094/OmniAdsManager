﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class AdsManager : MonoBehaviour
{
#if false //MODULE_MAKER
    AdMobManager InitAdmobManager()
    {
        var resGO = Resources.Load<GameObject>(admobManagerResourcesPath);
        if (resGO == null)
        {
            throw new System.NullReferenceException($"{admobManagerResourcesPath} not found in Resources");
        }
        var admobGO = Instantiate(resGO);
        _adMobHelper = admobGO.GetComponent<AdMobManager>();
        return _adMobHelper as AdMobManager;
    }
#else
    AdMobManager InitAdmobManager()
    {
        return null;
    }
#endif
}