using System.Collections.Generic;
using UnityEngine;

public class MissionCards : MonoBehaviour
{
    public List<Card> mission01;
    public List<Card> mission02;
    public List<Card> mission03;
    public List<Card> mission04;
    public List<Card> mission05;
    public List<Card> mission06;
    public List<Card> mission07;
    public List<Card> mission08;

    public List<Card> GetMissions()
    {
        switch (GameSave.Instance.GetMission()){
            case 1:
                return mission01;
            case 2:
                return mission02;
            case 3:
                return mission03;
            case 4:
                return mission04;
            case 5:
                return mission05;
            case 6:
                return mission06;
            case 7:
                return mission07;
            case 8:
                return mission08;
        }

        return mission01;
    }
}
