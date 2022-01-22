using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    private bool used = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !used)
        {
            used = true;
            GameObject colliderObj = collision.collider.gameObject;
            colliderObj.GetComponent<Rigidbody2D>().gravityScale *= -1;
            colliderObj.transform.localScale *= -1;
            Destroy(this.gameObject);
        }
    }
}
