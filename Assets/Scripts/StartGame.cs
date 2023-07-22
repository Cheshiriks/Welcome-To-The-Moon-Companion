using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public int missionId;

    public void StartMission()
    {
        GameSave.Instance.ChangeMission(missionId);
        SceneManager.LoadScene(1);
    }
}
