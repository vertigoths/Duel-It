using UnityEngine;

public class TouchMoveTwoPlayer : MonoBehaviour
{
    private Rigidbody2D rigidBody;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if(touchPosition.y > 0f)
            {
                if (gameObject.transform.name.Equals("Opponent"))
                {
                    touchPosition.x = Mathf.Clamp(touchPosition.x, -2f, 2f);
                    touchPosition.y = Mathf.Clamp(touchPosition.y, 0f, 4f);
                    rigidBody.MovePosition(new Vector2(touchPosition.x, touchPosition.y));
                }
            }

            else
            {
                if (gameObject.transform.name.Equals("Player"))
                {
                    touchPosition.x = Mathf.Clamp(touchPosition.x, -2f, 2f);
                    touchPosition.y = Mathf.Clamp(touchPosition.y, -4f, 0f);
                    rigidBody.MovePosition(new Vector2(touchPosition.x, touchPosition.y));
                }
            }
        }
    }
}