using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class AdsManager : MonoBehaviour
{
#if true //MODULE_MAKER
    const string FANManagerResourcesPath = "FacebookAudienceNetworkHelper";
    IAdsNetworkHelper InitFANHelper()
    {
        var resGO = Resources.Load<GameObject>(FANManagerResourcesPath);
        if (resGO == null)
        {
            Debug.Log($"{FANManagerResourcesPath} not found in Resources");
            return null;
        }
        var adsHelperGO = Instantiate(resGO);
        return adsHelperGO.GetComponent<IAdsNetworkHelper>();
    }
#else
    IAdsNetworkHelper InitFANHelper()
    {
        return null;
    }
#endif
}
