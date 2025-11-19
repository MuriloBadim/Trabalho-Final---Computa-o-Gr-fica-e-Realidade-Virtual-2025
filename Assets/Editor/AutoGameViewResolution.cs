using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoGameViewResolution
{
    static AutoGameViewResolution()
    {
        EditorSceneManager.sceneOpened += OnSceneOpened;
    }

    private static void OnSceneOpened(UnityEngine.SceneManagement.Scene scene, OpenSceneMode mode)
    {
        // Coloque o nome exato da sua cena vertical
        if (scene.name == "Jogo") 
        {
            SetGameViewResolution("Vertical"); // 720x1280
        }
        else
        {
            SetGameViewResolution("Horizontal"); // 1920x1080
        }
    }

    private static void SetGameViewResolution(string name)
    {
        int index = GetGameViewSizeIndex(name);
        if (index < 0)
        {
            Debug.LogWarning($"Resolução '{name}' não encontrada na Game View.");
            return;
        }

        EditorApplication.ExecuteMenuItem("Window/General/Game");
        var gvWndType = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
        var gameView = EditorWindow.GetWindow(gvWndType);

        var prop = gvWndType.GetProperty("selectedSizeIndex",
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.NonPublic);

        prop.SetValue(gameView, index);
        gameView.Repaint();
    }

    private static int GetGameViewSizeIndex(string name)
    {
        var sizesType = typeof(Editor).Assembly.GetType("UnityEditor.GameViewSizes");
        var groupType = typeof(Editor).Assembly.GetType("UnityEditor.ScriptableSingleton`1")
            .MakeGenericType(sizesType);

        object instance = groupType.GetProperty("instance").GetValue(null, null);
        var getGroup = sizesType.GetMethod("GetGroup");
        var group = getGroup.Invoke(instance, new object[] { (int)GameViewSizeGroupType.Standalone });

        var getDisplayTexts = group.GetType().GetMethod("GetDisplayTexts");
        string[] texts = getDisplayTexts.Invoke(group, null) as string[];

        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].Contains(name))
                return i;
        }

        return -1;
    }
}
