using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D rigidbody;
    private Transform tr;
    private Vector3 targetPosition;

    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        tr = this.GetComponent<Transform>();
        targetPosition = this.transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(tr.position, targetPosition) > .1f)
        {
            rigidbody.MovePosition(Vector3.Lerp(tr.position, targetPosition, speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetPosition = tr.position - other.transform.up / 2f;
    }
}
