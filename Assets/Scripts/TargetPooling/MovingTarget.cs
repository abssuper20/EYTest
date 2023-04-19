using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private int speed;
    private int direction;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("EndPointTrigger"))
            transform.position = startPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            ScoreManager.instance.IncrementScore();
        }
    }

    public void SetDirection(TargetMoveAxis moveAxis)
    {
        direction = (int)moveAxis;
    }

    public void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
