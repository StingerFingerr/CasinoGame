using UnityEngine;

namespace Services.Progress
{
    public class PlayerPrefsProgressService: IProgressService
    {
        private const string KEY = "Progress";
        
        public Progress Progress { get; private set; }
        public Progress LoadProgress()
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                string json = PlayerPrefs.GetString(KEY);
                Progress = JsonUtility.FromJson<Progress>(json);
            }
            else
            {
                Progress = new Progress();
            }

            return Progress;
        }

        public void SaveProgress()
        {
            string json = JsonUtility.ToJson(Progress);
            PlayerPrefs.SetString(KEY, json);
        }
    }
}