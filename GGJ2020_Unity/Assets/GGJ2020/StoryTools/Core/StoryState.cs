//-------- Room 1

using UnityEngine;

public enum E_AlinnaState
{
	IntroductionsNotCompleted,
	GivenTaskList,
	PsychoAIRevealed,
	Done,
}

public enum E_FridgeState
{
	FirstInteract,
	AccessUnlocked,
}

public enum E_TrashcanState
{
	FirstInteract,
	AccessUnlocked,
}

public enum E_ThrowawayState
{
	OnFloor,
	PickedUp,
	ThrownInHomeStation,
}

public enum E_ThrowawayType
{
	None,
	Capsules_A,
	Headset,
	Phone_A_Scott,
	Capsules_B,
	Shoes,
	Phone_B_Jen,
	Vape,
}


//-------- Room 2



//-------- Room 3




//-------- Global




//--------- Core
public delegate void DoorChangedDelegate(E_DoorState newDoorState);
public delegate void IntroStateDelegate(E_AlinnaState newIntroState);
public delegate void ThrowawayChangedDelegate(E_ThrowawayState newThrowawayState);

public enum E_DoorState
{
	Locked,
	Unlocked,
	Open,
	ShutHard
}

public enum E_CleanupState
{
	LivingRoomDirty,
	BedroomDirty,
	BathroomDirty,
	EverythingClean
}

public class StoryState : Singleton<StoryState>
{
	public E_CleanupState CleanupState
	{
		get
		{
			if (State_Capsules_A == E_ThrowawayState.ThrownInHomeStation &&
				State_Headset == E_ThrowawayState.ThrownInHomeStation &&
				State_Phone_A_Scott == E_ThrowawayState.ThrownInHomeStation &&
				State_Capsules_B == E_ThrowawayState.PickedUp &&
				State_Shoes == E_ThrowawayState.PickedUp &&
				State_Phone_B_Jen == E_ThrowawayState.PickedUp &&
				State_Vape == E_ThrowawayState.PickedUp)
			{
				return E_CleanupState.EverythingClean;
			}
			else if (Door_B_State == E_DoorState.Open || Door_B_State == E_DoorState.Unlocked)
			{
				return E_CleanupState.BathroomDirty;
			}
			else if (Door_A_State == E_DoorState.Open || Door_A_State == E_DoorState.Unlocked)
			{
				return E_CleanupState.BedroomDirty;
			}
			else
			{
				return E_CleanupState.LivingRoomDirty;
			}

		}
	}

	private StoryManager Story;

	// Get's run on game start by Unity
	public void Start()
	{
		Story = StoryManager.Instance;

		// Start the game loop
		Invoke("OnStoryStateChanged", 1.8f);
	}

	/// <summary>
	/// This function is ran after any piece of story state changed
	/// </summary>
	private void OnStoryStateChanged()
	{
		// Ignore story state changes while resetting
		if (_isResetting)
			return;

		// Start of the game
		if (IntroState == E_AlinnaState.IntroductionsNotCompleted)
		{
			IntroState = E_AlinnaState.GivenTaskList;
			Story.AddNextEvent<Alinna_Introduction_1>();
		}

		// Thrown away Capsules_A
		if (State_Capsules_A == E_ThrowawayState.ThrownInHomeStation)
		{
			if (Door_A_State == E_DoorState.Locked)
			{
				Door_A_State = E_DoorState.Unlocked;
				Story.AddNextEvent<Alinna_Door_A_Unlock_1>();
			}
		}

		// Threw away all the garbage in the bedroom
		if (State_Headset == E_ThrowawayState.ThrownInHomeStation && State_Phone_A_Scott == E_ThrowawayState.ThrownInHomeStation && State_Shoes == E_ThrowawayState.ThrownInHomeStation)
		{
			if (Door_B_State == E_DoorState.Locked)
			{
				Door_B_State = E_DoorState.Unlocked;
				Story.AddNextEvent<Alinna_Door_B_Unlock_1>();
			}
		}

		// All the garbage is thrown away
		if (State_Capsules_A == E_ThrowawayState.ThrownInHomeStation &&
			State_Headset == E_ThrowawayState.ThrownInHomeStation &&
			State_Phone_A_Scott == E_ThrowawayState.ThrownInHomeStation &&
			State_Capsules_B == E_ThrowawayState.PickedUp &&
			State_Shoes == E_ThrowawayState.PickedUp &&
			State_Phone_B_Jen == E_ThrowawayState.PickedUp &&
			State_Vape == E_ThrowawayState.PickedUp &&
			IntroState != E_AlinnaState.PsychoAIRevealed && IntroState != E_AlinnaState.Done)
		{
			IntroState = E_AlinnaState.PsychoAIRevealed;
			Story.AddNextEvent<Alinna_Congratulations_1>();
		}

		// Creepy reveal at the end
		if (State_Capsules_A == E_ThrowawayState.ThrownInHomeStation &&
			State_Headset == E_ThrowawayState.ThrownInHomeStation &&
			State_Phone_A_Scott == E_ThrowawayState.ThrownInHomeStation &&
			State_Capsules_B == E_ThrowawayState.ThrownInHomeStation &&
			State_Shoes == E_ThrowawayState.ThrownInHomeStation &&
			State_Phone_B_Jen == E_ThrowawayState.ThrownInHomeStation &&
			State_Vape == E_ThrowawayState.ThrownInHomeStation &&
			IntroState != E_AlinnaState.Done)
		{
			IntroState = E_AlinnaState.Done;
			Story.AddNextEvent<Alinna_End_1>();
		}
	}

	//-------- Room 1
	public IntroStateDelegate OnIntroStateChanged;

	private E_AlinnaState introState = E_AlinnaState.IntroductionsNotCompleted;
	public E_AlinnaState IntroState
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

	private E_TrashcanState trashcanState = E_TrashcanState.FirstInteract;

	public E_TrashcanState TrashcanState
	{
		get
		{
			return trashcanState;
		}
		set
		{
			if (trashcanState != value)
			{
				trashcanState = value;
				OnStoryStateChanged();
			}
		}
	}

	public DoorChangedDelegate OnDoorAChanged;

	private E_DoorState _doorAState = E_DoorState.Locked;

	public E_DoorState Door_A_State
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

	public ThrowawayChangedDelegate OnChanged_Shoes;
	private E_ThrowawayState _stateShoes = E_ThrowawayState.OnFloor;

	public E_ThrowawayState State_Shoes
	{
		get
		{
			return _stateShoes;
		}
		set
		{
			if (_stateShoes == value)
				return;

			_stateShoes = value;

			if (OnChanged_Shoes != null)
				OnChanged_Shoes(_stateShoes);

			OnStoryStateChanged();
		}
	}

	public DoorChangedDelegate OnDoorBChanged;

	private E_DoorState _doorBState = E_DoorState.Locked;

	public E_DoorState Door_B_State
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


	// Unsuccesful attempts at cleaning up all the dirty global state
	// TODO: Clean up all this global state on reset

	private bool _isResetting = false;
	public void Reset()
	{
		_isResetting = true;
		IntroState = E_AlinnaState.IntroductionsNotCompleted;
		FridgeState = E_FridgeState.FirstInteract;
		TrashcanState = E_TrashcanState.FirstInteract;
		Door_A_State = E_DoorState.Locked;
		State_Capsules_A = E_ThrowawayState.OnFloor;
		State_Headset = E_ThrowawayState.OnFloor;
		State_Phone_A_Scott = E_ThrowawayState.OnFloor;
		State_Shoes = E_ThrowawayState.OnFloor;
		Door_B_State = E_DoorState.Locked;
		State_Capsules_B = E_ThrowawayState.OnFloor;
		State_Vape = E_ThrowawayState.OnFloor;
		State_Phone_B_Jen = E_ThrowawayState.OnFloor;
		_isResetting = false;
	}
}
