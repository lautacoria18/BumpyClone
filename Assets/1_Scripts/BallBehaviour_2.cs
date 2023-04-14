using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

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
    public CellBehaviour cellWhenPressed;
    public Transform cellToMove;

    public bool isRight;

    public AudioSource audsrc;
    public AudioClip jump, lose, coin;
    public int grades;
    public float dur;
    public int dir;
    
    private void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.D) || MobileInput.swipeRight)
            {
                if (readyToCurveOnAir && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0 && isGoingUp)
                {
                GetComponent<Animator>().SetTrigger("Fall");
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    StartCoroutine(Curve(gameObject.transform.position, currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform.position, 360));

                }
                else
                {
                //StartCoroutine(Curve(a.position, b.position));
                    cellWhenPressed = currentCell;
                    isRight = true;
               
                    readyToCurve = true;
                }

            }
            if (Input.GetKeyDown(KeyCode.A) || MobileInput.swipeLeft)
            {
            if (readyToCurveOnAir && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0 && isGoingUp)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                StartCoroutine(Curve(gameObject.transform.position, currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform.position, -360));

            }
            else
            {
                cellWhenPressed = currentCell;
                isRight = false;

                readyToCurve = true;

            }
            }
            if (Input.GetKeyUp(KeyCode.W) || MobileInput.swipeUp)
            {
            cellWhenPressed = currentCell;
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
    public IEnumerator Curve(Vector3 start, Vector2 target, int dir) {

        StartCoroutine(AnimateAroundAxis(transform, Vector3.back, dir, dur));
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
    IEnumerator AnimateAroundAxis(Transform trans, Vector3 axis, float changeInAngle, float duration)
    {
        var start = trans.rotation;
        float t = 0f;
        while (t < duration)
        {
            trans.rotation = start * Quaternion.AngleAxis(changeInAngle * t / duration, axis);

            t += Time.deltaTime;
            yield return null;
        }
        Debug.Log("asdfasdfsdafxcvzxcv");
        trans.rotation = start * Quaternion.AngleAxis(changeInAngle, axis);
        //first = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "base" )
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (readyToCurve && cellWhenPressed == currentCell)
                
            {
                if (isRight)
                {
                    if (currentCell.rightCell)
                    {

                        cellToMove = currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform;
                        dir = 360;
                    }
                }
                else {
                    if (currentCell.leftCell)
                    {
                        cellToMove = currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform;
                        dir = -360;
                    }

                }
                
                    StartCoroutine(Curve(gameObject.transform.position, cellToMove.position, dir));
                    Debug.Log("HOWMANY");
                    readyToCurve = false;
                

            }
            else if (readyToJump && cellWhenPressed == currentCell && collision.gameObject.GetComponent<Animator>()) {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Boing");
                GetComponent<Animator>().SetTrigger("Jump");
                audsrc.PlayOneShot(jump);
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

            StartCoroutine(Curve(gameObject.transform.position, currentCell.currentObject.transform.position, 0));

        }
        if (collision.gameObject.tag == "baseskipl")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Boing");
            StartCoroutine(Curve(gameObject.transform.position, currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform.position, -360));
        }
        if (collision.gameObject.tag == "baseskipl2")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Boing");
            if (currentCell.leftCell.GetComponent<CellBehaviour>().leftCell)
            {

                StartCoroutine(Curve(gameObject.transform.position,
                    currentCell.leftCell.GetComponent<CellBehaviour>().leftCell.GetComponent<CellBehaviour>().currentObject.transform.position, -360));
            }
            else {

                StartCoroutine(Curve(gameObject.transform.position, currentCell.leftCell.GetComponent<CellBehaviour>().currentObject.transform.position, -360));
            }
        }
        if (collision.gameObject.tag == "baseskipr")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Boing");
            StartCoroutine(Curve(gameObject.transform.position, currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform.position, 360));
        }
        if (collision.gameObject.tag == "baseskipr2")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Boing");
            if (currentCell.rightCell.GetComponent<CellBehaviour>().rightCell)
            {
                StartCoroutine(Curve(gameObject.transform.position,
                    currentCell.rightCell.GetComponent<CellBehaviour>().rightCell.GetComponent<CellBehaviour>().currentObject.transform.position, 360));
            }
            else
            {

                StartCoroutine(Curve(gameObject.transform.position, currentCell.rightCell.GetComponent<CellBehaviour>().currentObject.transform.position, 360));
            }
        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lose")
        {
            audsrc.PlayOneShot(lose);
            if (UIManager.instance)
            {
                UIManager.instance.LevelLost();
            }
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "cell")
        {
            Debug.Log("trg");
            currentCell = collision.gameObject.GetComponent<CellBehaviour>();
        }
        if (collision.gameObject.tag == "star")
        {
            audsrc.PlayOneShot(coin);
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
            audsrc.PlayOneShot(lose);
            if (UIManager.instance)
            {

                UIManager.instance.LevelLost();


            }
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            //Destroy(gameObject);
          
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
