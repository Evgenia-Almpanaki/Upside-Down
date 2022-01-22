using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDestroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }
            Destroy(this.gameObject);
        }
    }
}
