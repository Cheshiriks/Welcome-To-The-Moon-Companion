using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave Instance;
    private int _mission = 1;
    
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMission(int miss)
    {
        _mission = miss;
    }
    
    public int GetMission()
    {
        return _mission;
    }

}
