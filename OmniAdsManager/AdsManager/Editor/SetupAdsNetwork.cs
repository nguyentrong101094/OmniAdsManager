﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class SetupAdsNetwork : MonoBehaviour
{
    const string packageName = "com.omnilatent.adsmanager";

    [MenuItem("Tools/Omnilatent/Ads Manager/Add Admob")]
    public static void AddAdmobHelper()
    {
        //string path = Path.GetFullPath($"Packages/{packageName}/OmniAdsManager/AdsManagerTemplates/AdsManagerAdmob.cs");
        string path = Path.GetFullPath($"Assets/OmniAds/OmniAdsManager/AdsManagerTemplates/AdsManagerAdmob.cs");
        int line_to_edit = 0;
        string sourceFile = path;
        string destinationFile = Path.GetFullPath($"Assets/OmniAds/OmniAdsManager/AdsManagerTemplates/AdsManagerAdmob.cs");
        string tempFile = Path.GetFullPath($"Assets/OmniAds/OmniAdsManager/AdsManagerTemplates/AdsManagerAdmob.cs.temp");

        // Read the appropriate line from the file.
        string lineToWrite = "#if true //MODULE_MAKER";
        string line = null;
        bool hasFoundLine = false;
        using (StreamReader reader = new StreamReader(sourceFile))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Equals("#if false //MODULE_MAKER"))
                {
                    break;
                }
                line_to_edit++;
            }
        }

        if (!hasFoundLine)
            throw new InvalidDataException("Line does not exist in " + sourceFile);

        // Read from the target file and write to a new file.
        int line_number = 1;
        using (StreamReader reader = new StreamReader(destinationFile))
        using (StreamWriter writer = new StreamWriter(tempFile))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line_number == line_to_edit)
                {
                    writer.WriteLine(lineToWrite);
                }
                else
                {
                    writer.WriteLine(line);
                }
                line_number++;
            }
        }
    }
}