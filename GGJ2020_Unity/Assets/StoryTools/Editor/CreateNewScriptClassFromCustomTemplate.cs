using UnityEditor;

public class CreateNewScriptClassFromCustomTemplate
{
    private const string pathToYourScriptTemplate = "Assets/StoryTools/Editor/EventTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/Create Event Template", isValidateFunction: false, priority: 51)]
    public static void CreateScriptFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToYourScriptTemplate, "Event_New.cs");
    }
}