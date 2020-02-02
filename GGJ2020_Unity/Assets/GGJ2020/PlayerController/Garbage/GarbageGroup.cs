using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleaningEvent : UnityEvent<GarbageGroup, float> { }


public enum GroupName
{
    testGroup
}

public class GarbageGroup : MonoBehaviour
{
    [SerializeField]
    GroupName groupName;

    [SerializeField, Range(0f, 1f)]
    float RequiredCleaningPercentage = .8f;

    int TotalItems = 0;
    int TotalCleaned = 0;
    List<GarbageItem> toCleanGarbargeItems = new List<GarbageItem>();
    public CleaningEvent OnCleanedEvent = new CleaningEvent();
    public UnityEvent OnCleaningFinished = new UnityEvent();


    static Dictionary<GroupName, GarbageGroup> groups = new Dictionary<GroupName, GarbageGroup>();

    public static GarbageGroup GetGroup(GroupName name)
    {
        if (groups.ContainsKey(name))
        {
            return groups[name];
        }

        Debug.LogWarning($"Failed to find group with name {name}");
        return null;
    }

    public static void BindToFinish(GroupName group, UnityAction BindEvent)
    {
        GetGroup(group).OnCleaningFinished.AddListener(BindEvent);
    }

    void Awake()
    {
        if (groups.ContainsKey(groupName))
        {
            Debug.LogError($"{this.ToString()} ::A group with name {groupName} already exists", groups[groupName]);
        }

        groups.Add(groupName, this);

        OnCleanedEvent.AddListener((_, value) =>
        {
            print($"OnCleanedEvent {value} : {TotalItems} : {TotalCleaned}");
            if (value >= RequiredCleaningPercentage)
            {
                OnCleaningFinished.Invoke();
            }
        });
    }

    public int GetTotalCleaned()
    {
        return TotalCleaned;
    }

    public float PercentageCleaned()
    {
        return (float)TotalCleaned / (float)TotalItems;
    }

    public void Register(GarbageItem item)
    {
        if (item == null)
        {
            Debug.LogError("attempted to register null");
            return;
        }

        TotalItems++;
        toCleanGarbargeItems.Add(item);
    }

    public void ItemCleaned(GarbageItem item)
    {
        if (item.GetGroup() != this)
        {
            Debug.LogWarning("Item is not part of this group");
            return;
        }

        if (toCleanGarbargeItems.Remove(item))
        {
            TotalCleaned++;
            OnCleanedEvent.Invoke(this, PercentageCleaned());
            Destroy(item.gameObject);
        }
    }
}
