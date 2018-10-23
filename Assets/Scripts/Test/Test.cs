using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MorningStudio;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System;

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
        //DataModel dataModel = new DataModel();
        //dataModel.id = 1;
        //dataModel.name = "klchan";
        //SettingManager.Instance.SetObject("obj",dataModel);
        //SettingManager.Instance.Save();
        //DataModel obj = SettingManager.Instance.GetObject<DataModel>("obj");
        //Log.Info(obj.name);

        //EventManager.Instance.AddListener(TestEventArgs.EventId,OnTestHandle);
        //TestEventArgs args = new TestEventArgs();
        //args.message = "Hello";
        //EventManager.Instance.DispatchNow(this, args);
        //EventManager.Instance.RemoveListener(TestEventArgs.EventId, OnTestHandle);
        //EventManager.Instance.DispatchNow(this, args);

        //MethodInfo methodInfo = typeof(Test).GetMethod("Test1");
        //try
        //{
        //    methodInfo.Invoke(null, new object[] { 1, 2 });
        //}
        //catch (System.ArgumentException)
        //{
        //    Debug.LogWarning("Args not match");
        //}

        byte[] key = Utility.AES.CreateKey("klchan",32);
        byte[] iV = Utility.AES.CreateKey("25ss",16);

        string text = "1234567890testsets:~!@#$%^&*()_+";

        byte[] encrypted = Utility.AES.EncryptStringToBytes(text, key, iV);
        string decrypted = Utility.AES.DecryptStringFromBytes(encrypted, key, iV);
        Debug.LogWarning(string.Format("Original:{0}", text));
        Debug.LogWarning(string.Format("Encrypted:{0}", Convert.ToBase64String(encrypted)));
        Debug.LogWarning(string.Format("decrypted:{0}", decrypted));
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
