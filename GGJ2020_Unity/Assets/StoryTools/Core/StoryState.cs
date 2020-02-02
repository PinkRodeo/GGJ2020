
//-------- Room 1

using UnityEngine;

public enum E_IntroState
{
    NotGiven,

    GivenTaskList,

    Psycho,
    Done,
}

public enum E_FridgeState
{
    FirstInteract,
    AccessUnlocked,
}

public enum E_ThrowawayState
{
    OnFloor,
    PickedUp,
    ThrownInBaseStation,
}


public enum E_ThrowawayType
{
    None,
    Capsules_A,
    Headset,
    Phone_A_Scott,
    Capsules_B,

    Phone_B_Jen,


    Vape,
}


//-------- Room 2



//-------- Room 3




//-------- Global




//--------- Core
public delegate void DoorChangedDelegate(E_DoorState newDoorState);
public delegate void IntroStateDelegate(E_IntroState newIntroState);
public delegate void ThrowawayChangedDelegate(E_ThrowawayState newThrowawayState);

public enum E_DoorState
{
    Locked,
    Unlocked,
    Open,
    ShutHard
}

public class StoryState : Singleton<StoryState>
{
    private StoryManager Story;

    private void OnStoryStateChanged()
    {
        if (IntroState == E_IntroState.NotGiven)
        {
            IntroState = E_IntroState.GivenTaskList;

            Story.AddEvent<Alinna_Introduction_1>();
        }

        if (State_Capsules_A == E_ThrowawayState.ThrownInBaseStation)
        {
            if (DoorAState == E_DoorState.Locked)
            {
                DoorAState = E_DoorState.Unlocked;
                Story.AddEvent<Alinna_Door_A_Unlock_1>();
            }
        }

        if (State_Headset == E_ThrowawayState.ThrownInBaseStation && State_Phone_A_Scott == E_ThrowawayState.ThrownInBaseStation)
        {
            if (DoorBState == E_DoorState.Locked)
            {
                DoorBState = E_DoorState.Unlocked;
                Story.AddEvent<Alinna_Door_B_Unlock_1>();
            }
        }

        if (State_Capsules_A == E_ThrowawayState.ThrownInBaseStation &&
            State_Headset == E_ThrowawayState.ThrownInBaseStation &&
            State_Phone_A_Scott == E_ThrowawayState.ThrownInBaseStation &&
            State_Capsules_B == E_ThrowawayState.PickedUp &&
            State_Phone_B_Jen == E_ThrowawayState.PickedUp &&
            State_Vape == E_ThrowawayState.PickedUp &&
            IntroState != E_IntroState.Psycho && IntroState != E_IntroState.Done)
        {
            IntroState = E_IntroState.Psycho;
            Story.AddEvent<Alinna_Congratulations_1>();
        }

        if (State_Capsules_A == E_ThrowawayState.ThrownInBaseStation &&
            State_Headset == E_ThrowawayState.ThrownInBaseStation &&
            State_Phone_A_Scott == E_ThrowawayState.ThrownInBaseStation &&
            State_Capsules_B == E_ThrowawayState.ThrownInBaseStation &&
            State_Phone_B_Jen == E_ThrowawayState.ThrownInBaseStation &&
            State_Vape == E_ThrowawayState.ThrownInBaseStation &&
            IntroState != E_IntroState.Done)
        {
            IntroState = E_IntroState.Done;
            Story.AddEvent<Alinna_End_1>();
        }

    }

    public void Start()
    {
        Story = StoryManager.Instance;
        Invoke("OnStoryStateChanged", 1.8f);

    }

    //-------- Room 1
    public IntroStateDelegate OnIntroStateChanged;

    private E_IntroState introState = E_IntroState.NotGiven;
    public E_IntroState IntroState
    {
        get
        {
            return introState;
        }
        set
        {
            if (introState != value)
            {
                introState = value;
                OnStoryStateChanged();

                if (OnIntroStateChanged != null)
                {
                    OnIntroStateChanged(value);
                }
            }
        }
    }


    private E_FridgeState fridgeState = E_FridgeState.FirstInteract;

    public E_FridgeState FridgeState 
    { 
        get 
        {
            return fridgeState;
        }
        set 
        {
            if (fridgeState != value)
            {
                fridgeState = value;
                OnStoryStateChanged();
            }
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
            if (_doorAState == value)
                return;

            _doorAState = value;

            if (OnDoorAChanged != null)
                OnDoorAChanged(_doorAState);
            OnStoryStateChanged();
        }
    }


    public ThrowawayChangedDelegate OnChanged_Capsules_A;
    private E_ThrowawayState _stateCapsulesA = E_ThrowawayState.OnFloor;

    public E_ThrowawayState State_Capsules_A
    {
        get
        {
            return _stateCapsulesA;
        }
        set
        {
            if (_stateCapsulesA == value)
                return;

            _stateCapsulesA = value;

            if (OnChanged_Capsules_A != null)
                OnChanged_Capsules_A(_stateCapsulesA);
            OnStoryStateChanged();
        }
    }

    //-------- Room 2

    public ThrowawayChangedDelegate OnChanged_Headset;
    private E_ThrowawayState _stateHeadset = E_ThrowawayState.OnFloor;

    public E_ThrowawayState State_Headset
    {
        get
        {
            return _stateHeadset;
        }
        set
        {
            if (_stateHeadset == value)
                return;

            _stateHeadset = value;

            if (OnChanged_Headset != null)
                OnChanged_Headset(_stateHeadset);
            OnStoryStateChanged();
        }
    }

    public ThrowawayChangedDelegate OnChanged_Phone_A_Scott;
    private E_ThrowawayState _statePhone_A_Scott = E_ThrowawayState.OnFloor;

    public E_ThrowawayState State_Phone_A_Scott
    {
        get
        {
            return _statePhone_A_Scott;
        }
        set
        {
            if (_statePhone_A_Scott == value)
                return;

            _statePhone_A_Scott = value;

            if (OnChanged_Phone_A_Scott != null)
                OnChanged_Phone_A_Scott(_statePhone_A_Scott);

            OnStoryStateChanged();
        }
    }

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
            if (_doorBState == value)
                return;

            _doorBState = value;

            if (OnDoorBChanged != null)
                OnDoorBChanged(_doorBState);
            OnStoryStateChanged();
        }
    }


    //-------- Room 3

    public ThrowawayChangedDelegate OnChanged_Capsules_B;
    private E_ThrowawayState _stateCapsulesB = E_ThrowawayState.OnFloor;

    public E_ThrowawayState State_Capsules_B
    {
        get
        {
            return _stateCapsulesB;
        }
        set
        {
            if (_stateCapsulesB == value)
                return;

            _stateCapsulesB = value;

            if (OnChanged_Capsules_B != null)
                OnChanged_Capsules_B(_stateCapsulesB);
            OnStoryStateChanged();
        }
    }

    public ThrowawayChangedDelegate OnChanged_Vape;
    private E_ThrowawayState _stateVape = E_ThrowawayState.OnFloor;

    public E_ThrowawayState State_Vape
    {
        get
        {
            return _stateVape;
        }
        set
        {
            if (_stateVape == value)
                return;

            _stateVape = value;

            if (OnChanged_Vape != null)
                OnChanged_Vape(_stateVape);
            OnStoryStateChanged();
        }
    }

    public ThrowawayChangedDelegate OnChanged_Phone_B_Jen;
    private E_ThrowawayState _statePhone_B_Jen = E_ThrowawayState.OnFloor;

    public E_ThrowawayState State_Phone_B_Jen
    {
        get
        {
            return _statePhone_B_Jen;
        }
        set
        {
            if (_statePhone_B_Jen == value)
                return;

            _statePhone_B_Jen = value;

            if (OnChanged_Phone_B_Jen != null)
                OnChanged_Phone_B_Jen(_statePhone_B_Jen);
            OnStoryStateChanged();
        }
    }

    //-------- Global




    //--------- Core
    public void Reset()
    {
        Destroy(gameObject);
    }
}
