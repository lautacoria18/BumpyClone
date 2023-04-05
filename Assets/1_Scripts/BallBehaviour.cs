using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BallBehaviour : MonoBehaviour
{

    public float speed;

    public float speed2;
    public float speedLateral;

    public Grid grid;

    private bool canMove;

    //public float speed;
    public Vector3 target;
    public float arcHeight;

    public Transform _startPosition;
    public Transform vectorFinal;
    float stepScale;
    float progress;
    public float angle;
    float distance;

    private bool isCollision;
    private bool startParabole;

    public CellBehaviour currentCell;
    public Transform cellToMove;

    Transform startFrom;

    public bool canPress;
    public bool isLerping;
    private void Start()
    {
        canPress = true;
        distance = 6.50f;
        stepScale = speed / distance;
        //isCollision = true;
    }
    private void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.D))
            {
            StartCoroutine(WaitFor());
            
            cellToMove = currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform;
            canMove = true;
            startFrom = currentCell.transform;


        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(WaitFor());
            cellToMove = currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform;
            canMove = true;

            startFrom = currentCell.transform;
        }
        

        if (!isCollision && startParabole)
        {
            progress = Mathf.Min(progress + Time.deltaTime * stepScale, 1.0f);

            float parabola = 1.0f - 4.0f * (progress - 0.5f) * (progress - 0.5f);

            Vector3 nextPos = Vector3.Lerp(startFrom.position, cellToMove.position, progress);

            nextPos.y += parabola * angle;

            transform.LookAt(nextPos, transform.forward);
            transform.position = nextPos;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            canMove = false;
            if (progress == 1.0f)
            {
            
                Debug.Log("Termino");
                isLerping = false;
            }
            else {
                isLerping = true;
                
            
            }
            
        }
    }
    IEnumerator WaitFor()
    {

    

        while (isLerping)
        {
            Debug.Log("wait");
            yield return null;

        }

      
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //
        if (collision.gameObject.tag == "base")
        {
            if (canMove)
            {
                isCollision = false;
                startParabole = true;

            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed2);
                Debug.Log("sdfas");
                isCollision = true;
                progress = 0;
            }
            //readyToJump = true;

        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cell")
        {
            Debug.Log("trg");
            //currentCell = collision.gameObject.transform.parent.gameObject.GetComponent<CellBehaviour>();
            currentCell = collision.gameObject.GetComponent<CellBehaviour>();
        }
    }
}
