using UnityEngine;

public class ButtonBack : MonoBehaviour
{
    public void Back()
    {
        FindFirstObjectByType<GameManager>().BackCards();
    }
}
