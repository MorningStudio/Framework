using System;

namespace LFramework
{
    public interface ISettingHelper
    {
        bool GetBool(string settingName);

        bool GetBool(string settingName, bool defaultValue);

        float GetFloat(string settingName);

        float GetFloat(string settingName, float defaultValue);

        int GetInt(string settingName);

        int GetInt(string settingName, int defaultValue);

        string GetString(string settingName);

        string GetString(string settingName, string defaultValue);

        object GetObject(Type objectType, string settingName);

        object GetObject(Type objectType, string settingName, object defaultObj);

        T GetObject<T>(string settingName);

        T GetObject<T>(string settingName, T defaultObj);

        void SetBool(string settingName, bool value);

        void SetFloat(string settingName, float value);

        void SetInt(string settingName, int value);

        void SetString(string settingName, string value);

        void SetObject(string settingName, object value);

        void SetObject<T>(string settingName, T value);

        bool HasSetting(string settingName);

        bool Save();

        bool Load();

        void RemoveAllSettings();

        void RemoveSetting(string settingName);
    }
}