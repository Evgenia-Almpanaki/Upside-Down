using UnityEngine;

public class WinButton : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
            GameManager.Instance.LoadNextScene();
    }
}
