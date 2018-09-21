using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LFramework;
using System.Reflection;

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
        Log.Info(obj.name);

        EventManager.Instance.AddListener(TestEventArgs.EventId,OnTestHandle);
        TestEventArgs args = new TestEventArgs();
        args.message = "Hello";
        EventManager.Instance.DispatchNow(this, args);
        EventManager.Instance.RemoveListener(TestEventArgs.EventId, OnTestHandle);
        EventManager.Instance.DispatchNow(this, args);

        MethodInfo methodInfo = typeof(Test).GetMethod("Test1");
        try
        {
            methodInfo.Invoke(null, new object[] { 1, 2 });
        }
        catch (System.ArgumentException)
        {
            Debug.LogWarning("Args not match");
        }

    }
	
	private void OnTestHandle(object sender,GameEventArgs e)
    {
        TestEventArgs args = e as TestEventArgs;
        Log.Info(args.message);
    }

    public static void Test1(int i1,int i2)
    {
        Debug.LogWarning(string.Format("Test1:{0},{1}",i1,i2));
    }
}
