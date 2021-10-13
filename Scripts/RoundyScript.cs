using System.Collections;
using UnityEngine;

public class RoundyScript : MonoBehaviour
{
    public Joystick joystick;
    private FixedJoystick fixedJoystick;
    public float speed;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        fixedJoystick = joystick.GetComponent<FixedJoystick>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.MovePosition(transform.position + new Vector3(fixedJoystick.Horizontal * speed * Mathf.Clamp(Time.deltaTime,0f,0.015f), fixedJoystick.Vertical * speed * Mathf.Clamp(Time.deltaTime, 0f, 0.015f), 0f));
    }


    


    
}
