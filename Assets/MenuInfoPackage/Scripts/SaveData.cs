using UnityEngine;

namespace Mugitea.MenuInfoPackage
{
    /// <summary>
    /// セーブ・ロードの中身.
    /// </summary>
    public static class SaveData
    {
        public static void Save<T>(T data, string keyName) where T : class
        {
            PlayerPrefs.SetString(keyName, JsonUtility.ToJson(data));
            PlayerPrefs.Save();
        }

        public static T Load<T>(string keyName) where T : class
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(keyName));
        }
    }
}