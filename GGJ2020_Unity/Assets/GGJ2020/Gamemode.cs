using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum rooms
{
    MainMenu,
    EndGameMenu,
    Game,
}

public class Gamemode : MonoBehaviour
{
    static Gamemode gameMode;
    PlayerTankController controller;

    #region room
    static readonly Dictionary<rooms, string[]> Rooms = new Dictionary<rooms, string[]> {
        {rooms.MainMenu, new string[]{ "MainMenu"} },
        {rooms.EndGameMenu, new string[]{"EndScreen"} },
        { rooms.Game, new string[] { "Environment" }},
    };
    #endregion

    static EventUIScriptableObject uiSettings;

    public static EventUIScriptableObject GetUiSettings()
    {
        if (uiSettings == null)
        {
            uiSettings = Resources.Load("UiSettings") as EventUIScriptableObject;
        }
        return uiSettings;
    }

    public static void RegisterPlayer(PlayerTankController controller)
    {
        if (gameMode == null)
        {
            CreateGameMode();
            if (gameMode == null)
            {
                Debug.LogWarning("Gamemode static ref is not  valid");
                return;
            }
        }

        if (gameMode.controller != null)
        {
            Debug.LogWarning("The GameMode has a player ref, attempted to register a new controller");
            return;
        }

        gameMode.controller = controller;
    }

    static string[] GetRoomForType(rooms room)
    {
        return Rooms[room];
    }

    public static void LoadSceneBlocking(rooms room)
    {
        if (gameMode == null)
        {
            CreateGameMode();
            if (gameMode == null)
            {
                Debug.LogWarning("Gamemode static ref is not  valid");
                return;
            }
        }

        bool isFirst = true;
        foreach (var roomName in GetRoomForType(room))
        {
            if (isFirst)
            {
                isFirst = false;
                SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
            }
        }


    }

    public static void StartLoadingScene(rooms room, bool UseFade = false)
    {
        if (gameMode == null)
        {
            CreateGameMode();
            if (gameMode == null)
            {
                Debug.LogWarning("Gamemode static ref is not  valid");
                return;
            }
        }
        gameMode.StartCoroutine(gameMode.LoadSceneWithFade(room));
    }



    IEnumerator LoadSceneWithFade(rooms room)
    {

        bool isFirst = true;

        foreach (var roomName in GetRoomForType(room))
        {
            if (isFirst)
            {
                isFirst = false;
                yield return SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Single);
            }
            else
            {
                yield return SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
            }
        }
    }

    private static void CreateGameMode()
    {
        GameObject obj = new GameObject("GameMode");
        obj.AddComponent<Gamemode>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (gameMode == null)
        {
            gameMode = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
