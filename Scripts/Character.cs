using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]
    private float movementSpeed;
    private SpriteRenderer sprite;
    public static Character Instance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void move(Vector2 inputVector)
    {
        inputVector = inputVector.normalized * movementSpeed;
        body.velocity = inputVector;
    }

    public IEnumerator MoveTo(Vector2 targetPosition, System.Action callback, float delay = 0f)
    {
        while(targetPosition != new Vector2(transform.position.x, transform.position.y))
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 1f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(delay);
        callback();
    }

    public void TeleportTo(Vector2 targetPosition)
    {
        transform.position = targetPosition;
    }
    
}
