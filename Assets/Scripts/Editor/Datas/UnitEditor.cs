using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MorningStudio;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Unit))]
public class UnitEditor : BaseExcelEditor<Unit>
{	    
    public override bool Load()
    {
        Unit targetData = target as Unit;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<UnitData>().ToArray();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
