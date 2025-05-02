using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float minY = 0f;
    public float maxY = 2f;
    public float minScale = 0.7f;
    public float maxScale = 2f;
    public Vector2 xLimits = new Vector2(-5f, 5f);

    private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // Ограничиваем зону клика
            mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);
            mousePos.x = Mathf.Clamp(mousePos.x, xLimits.x, xLimits.y);

            targetPos = mousePos;
        }

        // Движение
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Масштаб в зависимости от глубины (Y)
        float t = Mathf.InverseLerp(minY, maxY, transform.position.y);
        float scale = Mathf.Lerp(maxScale, minScale, t);
        transform.localScale = new Vector3(scale, scale, 1);

        
    }

    

}
