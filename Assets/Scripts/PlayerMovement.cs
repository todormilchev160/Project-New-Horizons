using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed=5f;
    private float direction =0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }
    public void MoveRight()
    {
        direction=1f;
    }
    public void MoveLeft()
    {
        direction=-1f;
    }
    public void StopMoving()
    {
        direction=0f;
    }
}
