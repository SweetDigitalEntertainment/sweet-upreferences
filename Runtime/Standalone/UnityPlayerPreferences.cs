using UnityEngine;

#if UNITY_EDITOR || UNITY_STANDALONE
namespace Sweet.PersistentPreferences.Standalone
{
    public sealed class UnityPlayerPreferences : IPersistentPreferences
    {
        private static readonly string _KeyPrefix = "_dp.";

        
        public string GetValue(string key)
        {
            return PlayerPrefs.GetString(_KeyPrefix + key, string.Empty);
        }

        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(_KeyPrefix + key);
        }

        public void SetValue(string key, string value)
        {
            PlayerPrefs.SetString(_KeyPrefix + key, value);
            PlayerPrefs.Save();
        }

        public bool TryGetValue(string key, out string value)
        {
            if (!HasKey(key))
            {
                value = string.Empty;
                return false;
            }

            value = GetValue(key);
            return true;
        }
    }
}
#endif