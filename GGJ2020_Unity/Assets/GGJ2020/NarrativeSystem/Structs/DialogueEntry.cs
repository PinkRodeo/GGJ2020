using System;
using UnityEngine;

namespace GGJ2020.NarrativeSystem
{
	[Serializable]
	public struct DialogueEntry
	{
		public string Name;
		public string Icon;
		public string Audio;
		
		[TextArea]
		public string Text;

		public DialogueAnswer[] Answers;

		public DialogueEntry(string name, string text, params DialogueAnswer[] answers)
		{
			Name    = name;
			Icon    = string.Empty;
			Audio   = string.Empty;
			Text    = text;
			Answers = answers;
		}

		public DialogueEntry(string name, string icon, string audio, string text, params  DialogueAnswer[] answers) : this(name, text, answers)
		{
			Icon  = icon;
			Audio = audio;
		}
	}
}