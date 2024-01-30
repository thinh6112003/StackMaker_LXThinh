using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerChild;
    [SerializeField] GameObject brickPlayerPrefab;
    [SerializeField] GameObject vitoryPanel;
    [SerializeField]private float speed;
    private bool isMouseDown= false;
    private bool isMove = false;
    private Vector3 beginPos;
    private Vector3 target;
    private Vector3 direcGo;
    int layerEndPos = 1<< 3;
    int layerGround = 1<< 6;
    private ColorBrick colorOfPlayer;
    List<GameObject> brickList= new List<GameObject>();

    void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
        if (isMove)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position,target,Time.deltaTime* speed);
            if (Vector3.Distance(player.transform.position, target) < 0.01f) isMove = false;
        }
        else
        {
            if (isMouseDown == false && Input.GetMouseButtonDown(0))
            {
                beginPos = Input.mousePosition;
                isMouseDown = true;
            }
            if (isMouseDown)
            {
                Vector3 endPos = Input.mousePosition;
                if (endPos.x - beginPos.x >= 60) DetermineTarget(new Vector3(0.5f, 0, 0));
                else if (endPos.x - beginPos.x <= -60) DetermineTarget(new Vector3(-0.5f, 0, 0));
                else if (endPos.y - beginPos.y >= 60) DetermineTarget(new Vector3(0, 0, 0.5f));
                else if (endPos.y - beginPos.y <= -60) DetermineTarget(new Vector3(0, 0, -0.5f));
            }
        }
    }

    private void DetermineTarget(Vector3 direc)
    {
        direcGo = direc;
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, direc,out hit,50f, layerEndPos))
        {
            if (Physics.Raycast(player.transform.position+ direc* 2, Vector3.down, layerGround))
            {
                target = hit.collider.transform.position;
                isMove = true;
            }   
        }
    }

    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(conststring.BRICK)&&other.GetComponent<Brick>().isCollect==false)
        {
            other.GetComponent<Brick>().isCollect = true;
            Destroy(other.gameObject);
            Brick mauBrick = other.gameObject.GetComponent<Brick>();
            ColorBrick mauCuaBrick = mauBrick.ColorOfBrick;
            i++;
            if (brickList.Count == 0)
            {
                colorOfPlayer = mauCuaBrick;
            }
            GameObject newBrick = Instantiate(brickPlayerPrefab, player.transform);
            newBrick.transform.position = player.transform.position + new Vector3(0, -0.8f, 0) + (new Vector3(0, 0.25f, 0) * brickList.Count);
            playerChild.transform.localPosition += new Vector3(0, 0.25f, 0);
            brickList.Add(newBrick);

        }
        if (other.CompareTag("UnBrick"))
        {
            bool isUnbick = other.gameObject.GetComponent<Unbrick>().isBricksReceived;
            if (isUnbick == false&& brickList.Count==0)
            {
                target = other.transform.position + Vector3.up*2-Vector3.forward;
            }
            if (isUnbick == false && brickList.Count > 0)
            {
                Destroy(brickList[brickList.Count - 1]);
                brickList.RemoveAt(brickList.Count - 1);
                GameObject brickPrefab = Instantiate(brickPlayerPrefab, other.gameObject.transform);
                brickPrefab.transform.localPosition = new Vector3(0, 0.6f, 0);
                playerChild.transform.localPosition -= new Vector3(0, 0.25f, 0);
                brickPrefab.transform.localScale = new Vector3(0.9f, 0.1f, 0.9f);
                other.gameObject.GetComponent<Unbrick>().isBricksReceived = true;
            }
        }
        if (other.CompareTag("Finish"))
        {
            UIManager.Instance.OnVictory();
        }
    }
    public void OnInit()
    {

    }
    public void AddBrick()
    {

    }
    public void RemoveBrick()
    {

    }
    public void ClearBrick()
    {
        while (brickList.Count > 0)
        {
            Destroy(brickList[brickList.Count - 1]);
            brickList.RemoveAt(brickList.Count - 1);
            playerChild.transform.localPosition -= new Vector3(0, 0.25f, 0);
        }
        player.transform.position = new Vector3(-1.5f, 3f, 1.5f);
    }
}
public static class conststring
{
    public static string MAP_NAME = "Map";
    public static string BRICK = "Brick";
}
