using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]
    private float movementSpeed;
    private SpriteRenderer sprite;
    public string myName = null;
    private Vector2 targetPos;
    private bool makeUpdate = false;
    public static Character Instance { get; set; }
    
    //Call this first for NPCs that move and Player
    public void InitializeMovement()
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
    }

    //Moving the character based on movement speed
    public void Move(Vector2 inputVector)
    {
        inputVector = inputVector.normalized * movementSpeed;
        body.velocity = inputVector;
    }

    //Random movement for NPCs
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

    //Teleport characters around, esp for moving between scenes
    public void TeleportTo(Vector2 targetPosition)
    {
        transform.position = targetPosition;
    }
    
}
