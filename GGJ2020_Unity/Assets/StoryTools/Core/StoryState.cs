
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
public delegate void DoorChangedDelegate(E_DoorState newDoorState);

public enum E_DoorState
{
    Locked,
    Open,
    ShutHard
}

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

    public DoorChangedDelegate OnDoorAChanged;

    private E_DoorState _doorAState = E_DoorState.Locked;

    public E_DoorState DoorAState
    {
        get
        {
            return _doorAState;
        }
        set
        {
            _doorAState = value;

            if (OnDoorAChanged != null)
                OnDoorAChanged(_doorAState);
        }
    }

    //-------- Room 2

    public DoorChangedDelegate OnDoorBChanged;

    private E_DoorState _doorBState = E_DoorState.Locked;

    public E_DoorState DoorBState
    {
        get
        {
            return _doorBState;
        }
        set
        {
            _doorBState = value;

            if (OnDoorBChanged != null)
                OnDoorBChanged(_doorBState);
        }
    }


    //-------- Room 3



    //-------- Global




    //--------- Core
    public void Reset()
    {
        Destroy(gameObject);
    }
}
