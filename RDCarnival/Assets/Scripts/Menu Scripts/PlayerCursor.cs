using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{
    public Player player;
    public RectTransform cursor;
    public Image cursorImage;
    public Sprite inactiveCursor;
    public Sprite activeCursor;

    public float cursorMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Button"))
        {
            cursorImage.sprite = activeCursor;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Button"))
        {
            cursorImage.sprite = inactiveCursor;
        }
    }

    public void MoveCursor(Vector2 direction)
    {
        
    }
}
