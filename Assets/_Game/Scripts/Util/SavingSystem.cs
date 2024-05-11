using UnityEngine;

namespace AppCore
{
    public static class SavingSystem
    {
        public static void Save<T>(T data, string key) where T : struct
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
        }

        public static T? Load<T>(string key) where T : struct
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            if (json.Equals(string.Empty))
                return null;

            return JsonUtility.FromJson<T>(json);
        }
    }
}