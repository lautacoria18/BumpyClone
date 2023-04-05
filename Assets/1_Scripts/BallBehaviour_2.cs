using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour_2 : MonoBehaviour
{
    public AnimationCurve curve;

    public Transform a, b;

    public float duration = 1.0f;

    public float heightY = 3.0f;
    public float speed;
    public float heightJump;

    public bool readyToCurve;
    public bool readyToJump;
    public bool isGoingUp;

    public bool readyToCurveOnAir;

    public CellBehaviour currentCell;
    public Transform cellToMove;

    public bool isRight;

    
    private void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.D) || MobileInput.swipeRight)
            {
                if (readyToCurveOnAir && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0 && isGoingUp)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    StartCoroutine(Curve(gameObject.transform.position, currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform.position));

                }
                else
                {
                //StartCoroutine(Curve(a.position, b.position));
                isRight = true;
               
                    readyToCurve = true;
                }

            }
            if (Input.GetKeyDown(KeyCode.A) || MobileInput.swipeLeft)
            {
            if (readyToCurveOnAir && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0 && isGoingUp)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                StartCoroutine(Curve(gameObject.transform.position, currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform.position));

            }
            else
            {
                isRight = false;

                readyToCurve = true;

            }
            }
            if (Input.GetKeyUp(KeyCode.W) || MobileInput.swipeUp)
            {

                //cellToMove = currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform;
                readyToJump = true;

            }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            if (Input.GetKeyUp(KeyCode.S) || MobileInput.swipeDown)
            {

                //cellToMove = currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform;
                isGoingUp = false;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            }
        }
        
    }
    // Start is called before the first frame update
    public IEnumerator Curve(Vector3 start, Vector2 target) {


        float timePassed = 0f;
        Vector2 end = target;

        while (timePassed < duration) {

            timePassed += Time.deltaTime;

            float linearT = timePassed / duration;
            float heightT = curve.Evaluate(linearT);

            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position =  Vector2.Lerp(start, end, linearT) +  new Vector2(0f, height);

            yield return null;
        
        }
       
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "base" )
        {
            if (readyToCurve)
            {
                if (isRight)
                {
                    if (currentCell.rightCell)
                    {
                        cellToMove = currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform;
                    }
                }
                else {
                    if (currentCell.leftCell)
                    {
                        cellToMove = currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform;
                    }

                }
                StartCoroutine(Curve(gameObject.transform.position, cellToMove.position));
                Debug.Log("HOWMANY");
                readyToCurve = false;

            }
            else if (readyToJump) {

                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * heightJump);
                readyToJump = false;
                isGoingUp= true;
            }
            else

            {
            
                isGoingUp = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
                Debug.Log("sdfas");

            }


        }
        if (collision.gameObject.tag == "wall") {

            StartCoroutine(Curve(gameObject.transform.position, currentCell.currentObject.transform.position));

        }
        if (collision.gameObject.tag == "baseskipl")
        {

            StartCoroutine(Curve(gameObject.transform.position, currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform.position));
        }
        if (collision.gameObject.tag == "baseskipl2")
        {
            if (currentCell.leftCell.GetComponent<CellBehaviour>().leftCell)
            {
                StartCoroutine(Curve(gameObject.transform.position,
                    currentCell.leftCell.GetComponent<CellBehaviour>().leftCell.GetComponent<CellBehaviour>().currentObject.transform.position));
            }
            else {

                StartCoroutine(Curve(gameObject.transform.position, currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform.position));
            }
        }
        if (collision.gameObject.tag == "baseskipr")
        {

            StartCoroutine(Curve(gameObject.transform.position, currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform.position));
        }
        if (collision.gameObject.tag == "baseskipr2")
        {
            if (currentCell.rightCell.GetComponent<CellBehaviour>().rightCell)
            {
                StartCoroutine(Curve(gameObject.transform.position,
                    currentCell.rightCell.GetComponent<CellBehaviour>().rightCell.GetComponent<CellBehaviour>().currentObject.transform.position));
            }
            else
            {

                StartCoroutine(Curve(gameObject.transform.position, currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform.position));
            }
        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lose")
        {
            if (UIManager.instance)
            {
                UIManager.instance.LevelLost();
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "cell")
        {
            Debug.Log("trg");
            currentCell = collision.gameObject.GetComponent<CellBehaviour>();
        }
        if (collision.gameObject.tag == "star")
        {
            Debug.Log("Toco");
            if (LevelBehaviour.instance)
            {
                Debug.Log("sumo");
                LevelBehaviour.instance.starsTaken += 1;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "spike")
        {
            if (UIManager.instance)
            {

                UIManager.instance.LevelLost();


            }
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "winportal")
        {
            if (UIManager.instance) {

                UIManager.instance.LevelWin();


            }
            Debug.Log("Ganaste");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cell")
        {
            Debug.Log("trg");
            currentCell = collision.gameObject.GetComponent<CellBehaviour>();
        }
        if (collision.gameObject.tag == "baseArea")
        {
            readyToCurveOnAir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "baseArea")
        {
            readyToCurveOnAir = false;
      
        }
    }

}
