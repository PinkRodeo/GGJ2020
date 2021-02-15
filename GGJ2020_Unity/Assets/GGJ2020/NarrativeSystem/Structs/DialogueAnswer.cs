using System;

namespace GGJ2020.NarrativeSystem
{
	[Serializable]
	public struct DialogueAnswer
	{
		public string Label;
		public string Consequence;

		public DialogueReply Reply;

		public DialogueAnswer(string label, DialogueReply reply)
		{
			Label       = label;
			Consequence = string.Empty;
			Reply       = reply;
		}

		public DialogueAnswer(string label, string consequence, DialogueReply reply) : this(label, reply)
		{
			Consequence = consequence;
		}
	}

	[Serializable]
	public struct DialogueReply
	{
		public string Filename;
		public string Key;

		public DialogueReply(string filename, string key)
		{
			Filename = filename;
			Key      = key;
		}
	}
}