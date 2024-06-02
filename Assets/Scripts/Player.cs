using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 2.5f;

    public float rotationSpeed = 100;
    public float maxRotationAngle = 22.5f;
    private Vector3 previousPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetPosition();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        ResetRotation();
        previousPosition = transform.position;
       
    }

    private void ResetPosition()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Vector3 displacement = transform.position - previousPosition;
        float rotationAngle = 0f;
        
        if (displacement.y > 0)
        {
            rotationAngle = 22.5f;
        }
        else if (displacement.y < 0)
        {
            rotationAngle = -10f;
        }
        rotationAngle = Mathf.Clamp(rotationAngle, -maxRotationAngle, maxRotationAngle);
        RotateSprite(rotationAngle);
        previousPosition = transform.position;
       

    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void RotateSprite(float angle)
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
