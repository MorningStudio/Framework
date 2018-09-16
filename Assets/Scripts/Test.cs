using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LFramework;

public class DataModel
{
    public int id;
    public string name;
}


public class Test : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        DataModel dataModel = new DataModel();
        dataModel.id = 1;
        dataModel.name = "klchan";
        SettingManager.Instance.SetObject("obj",dataModel);
        SettingManager.Instance.Save();
        DataModel obj = SettingManager.Instance.GetObject<DataModel>("obj");
        Log.Warning(obj.name);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
