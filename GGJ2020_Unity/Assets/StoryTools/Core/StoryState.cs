
public enum E_FridgeState
{
    FirstInteract,
    AccessUnlocked,
}


public class StoryState : Singleton<StoryState>
{
    private E_FridgeState fridgeState = E_FridgeState.FirstInteract;

    public E_FridgeState FridgeState 
    { 
        get 
        {
            return fridgeState;
        }
        set 
        {
            fridgeState = value;
        }
    }


    public void Reset()
    {
        Destroy(gameObject);
    }
}
