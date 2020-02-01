
//-------- Room 1

public enum E_FridgeState
{
    FirstInteract,
    AccessUnlocked,
}


//-------- Room 2




//-------- Room 3




//-------- Global




//--------- Core





public class StoryState : Singleton<StoryState>
{
    //-------- Room 1
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

    //-------- Room 2



    //-------- Room 3



    //-------- Global




    //--------- Core
    public void Reset()
    {
        Destroy(gameObject);
    }
}
