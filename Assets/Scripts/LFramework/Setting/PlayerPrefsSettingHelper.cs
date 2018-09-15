using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework
{
    public class PlayerPrefsSettingHelper : ISettingHelper
    {
        public bool GetBool(string settingName)
        {
            return PlayerPrefs.GetInt(settingName) != 0;
        }

        public bool GetBool(string settingName, bool defaultValue)
        {
            return PlayerPrefs.GetInt(settingName, defaultValue ? 1 : 0) != 0;
        }

        public float GetFloat(string settingName)
        {
            return PlayerPrefs.GetFloat(settingName);
        }

        public float GetFloat(string settingName, float defaultValue)
        {
            return PlayerPrefs.GetFloat(settingName, defaultValue);
        }

        public int GetInt(string settingName)
        {
            return PlayerPrefs.GetInt(settingName);
        }

        public int GetInt(string settingName, int defaultValue)
        {
            return PlayerPrefs.GetInt(settingName, defaultValue);
        }

        public object GetObject(Type objectType, string settingName)
        {
            string json = PlayerPrefs.GetString(settingName);
            return JsonUtility.FromJson(json, objectType);
        }

        public object GetObject(Type objectType, string settingName, object defaultObj)
        {
            string json = PlayerPrefs.GetString(settingName, null);
            if(json == null)
            {
                return defaultObj;
            }
            return JsonUtility.FromJson(json,objectType);
        }

        public T GetObject<T>(string settingName)
        {
            string json = PlayerPrefs.GetString(settingName);
            return JsonUtility.FromJson<T>(json);
        }

        public T GetObject<T>(string settingName, T defaultObj)
        {
            string json = PlayerPrefs.GetString(settingName, null);
            if (json == null)
            {
                return defaultObj;
            }
            return JsonUtility.FromJson<T>(json);
        }

        public string GetString(string settingName)
        {
            return PlayerPrefs.GetString(settingName);
        }

        public string GetString(string settingName, string defaultValue)
        {
            return PlayerPrefs.GetString(settingName, defaultValue);
        }

        public bool HasSetting(string settingName)
        {
            return PlayerPrefs.HasKey(settingName);
        }

        public bool Load()
        {
            return true;
        }

        public void RemoveAllSettings()
        {
            PlayerPrefs.DeleteAll();
        }

        public void RemoveSetting(string settingName)
        {
            PlayerPrefs.DeleteKey(settingName);
        }

        public bool Save()
        {
            PlayerPrefs.Save();
            return true;
        }

        public void SetBool(string settingName, bool value)
        {
            PlayerPrefs.SetInt(settingName,value ? 1 : 0);
        }

        public void SetFloat(string settingName, float value)
        {
            PlayerPrefs.SetFloat(settingName, value);
        }

        public void SetInt(string settingName, int value)
        {
            PlayerPrefs.SetInt(settingName,value);
        }

        public void SetObject(string settingName, object value)
        {
            string json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(settingName,json);
        }

        public void SetObject<T>(string settingName, T value)
        {
            string json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(settingName, json);
        }

        public void SetString(string settingName, string value)
        {
            PlayerPrefs.SetString(settingName, value);
        }
    }
}
