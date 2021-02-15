using UnityEngine;

namespace GGJ2020.NarrativeSystem
{
	public interface INarrativeIconGetter
	{
		Sprite GetIcon(string iconString);
	}
}