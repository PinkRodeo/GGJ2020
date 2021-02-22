using GGJ2020.NarrativeSystem.Interfaces;
using UnityEngine;
using Utility;

namespace GGJ2020.NarrativeSystem
{
    public static class NarrativeManager
    {
        private static readonly SerializableDictionary<string, SerializableDictionary<string, DialogueEntry>> narrative;

        // Commented out because it was causing warnings
        // private static INarrativeAudioPlayer audioPlayer = null;
        // private static INarrativeIconGetter iconGetter = null;

        static NarrativeManager()
        {
            narrative = new SerializableDictionary<string, SerializableDictionary<string, DialogueEntry>>();

            foreach (TextAsset file in Resources.LoadAll<TextAsset>("Dialogue"))
            {
                narrative.Add(file.name, JsonUtility.FromJson<SerializableDictionary<string, DialogueEntry>>(file.text));
            }
        }

        public static DialogueEntry GetEntry(string fileName, string keyname)
        {
            return narrative[fileName][keyname];
        }

        [ContextMenu("Load from file")]
        private static void TestLoad()
        {
            foreach (TextAsset file in Resources.LoadAll<TextAsset>("Language"))
            {
                narrative.Add(file.name, JsonUtility.FromJson<SerializableDictionary<string, DialogueEntry>>(file.text));
            }
        }
    }
}