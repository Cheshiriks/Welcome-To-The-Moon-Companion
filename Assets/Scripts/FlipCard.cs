using System.Collections;
using UnityEngine;

public class FlipCard : MonoBehaviour
{

    private SpriteRenderer rend;
    
    public Sprite cover, face;

    public bool facedUp;
    private bool coroutineAllowed;
    
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (facedUp)
        {
            rend.sprite = face;
        }
        else
        {
            rend.sprite = cover;
        }
        coroutineAllowed = true;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        float x = 0f;
        for (float i = 0f; i <= 180f; i += 5f) {
            transform.rotation = Quaternion.Euler(0f, x + i, 0f);
            if (i == 90f)
            {
                if (!facedUp)
                {
                    rend.sprite = face;
                }
                else
                {
                    rend.sprite = cover;
                }

                x = 180;
            }
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
        facedUp = !facedUp;
    }

}
