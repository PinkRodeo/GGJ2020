using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum rooms
{
    MainMenu,
    EndGameMenu,
    A,
    B,
}

public class Gamemode : MonoBehaviour
{
    static Gamemode gameMode;
    PlayerTankController controller;

    #region room
    static readonly Dictionary<rooms, string[]> Rooms = new Dictionary<rooms, string[]> {
        {rooms.MainMenu, new string[]{ "MainMenu"} },
        {rooms.EndGameMenu, new string[]{"EndScreen"} },
        { rooms.A, new string[] { "LevelMain" }},
    };

    [SerializeField]
    rooms activeRoom = rooms.MainMenu;
    #endregion

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
        //TODO implement fade
        var oldSceneName = SceneManager.GetActiveScene().name;

        foreach (var roomName in GetRoomForType(room))
        {
            yield return SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
        }

        yield return SceneManager.UnloadSceneAsync(oldSceneName);
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
