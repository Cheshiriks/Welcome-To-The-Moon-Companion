using UnityEngine;

public class ButtonNext : MonoBehaviour
{

    public void Next()
    {
        FindFirstObjectByType<GameManager>().NextCards();
    }

}
