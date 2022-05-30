using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        Start,
        Game,
        Fail
    }



    public GridManager GridManager;
    public SwipeControl SwipeControl;
    public Number Number;

    private List<Number> numList;

    GameManager()
    {
        numList = new List<Number>();
    }

    private void Start()
    {
        createFirst();
    }

    private void Update()
    {



        if (Input.GetKeyDown(KeyCode.A) && numList.Count > 0)
        {
            Spawn();
            numList.ForEach(i => i.transform.position += new Vector3(-1.15f, 0, 0));
            foreach (var item in numList)
            {
                item.level++;
                item.SetNumber();
            }


        }
        if (Input.GetKeyDown(KeyCode.D) && numList.Count > 0)
        {
            Spawn();
            numList.ForEach(i => i.transform.position += new Vector3(1.15f, 0, 0));
            Debug.Log(GridManager.grid.gridList[1].elements[1].GetComponent<Tile>().isNumberOn);
        }
        if (Input.GetKeyDown(KeyCode.W) && numList.Count > 0)
        {
            Spawn();
            numList.ForEach(i => i.transform.position += new Vector3(0, 1.15f, 0));
            Debug.Log(GridManager.grid.gridList[1].elements[1].GetComponent<Tile>().isNumberOn);
        }
        if (Input.GetKeyDown(KeyCode.S) && numList.Count > 0)
        {
            Spawn();
            numList.ForEach(i => i.transform.position += new Vector3(0, -1.15f, 0));
            Debug.Log(GridManager.grid.gridList[1].elements[1].GetComponent<Tile>().isNumberOn);
        }
    }

    public void Swipe()
    {
        switch (SwipeControl.SwipeDirection)
        {
            case SwipeDirection.Up:
                Debug.Log("a");
                break;
            case SwipeDirection.Down:
                Debug.Log("a");
                break;
            case SwipeDirection.Left:
                Debug.Log("a");
                break;
            case SwipeDirection.Right:
                Debug.Log("a");
                break;
        }
    }

    private void Move(SwipeDirection direction)
    {

    }

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        Number tempNumber = Instantiate(Number);

        tempNumber.level = UnityEngine.Random.Range(1, 3);
        tempNumber.SetNumber();

        var availableTile = GridManager.GetRandomAvailableTile();

        availableTile.GetComponent<Tile>().isNumberOn = true;
        availableTile.GetComponent<Tile>().Number = tempNumber.GetComponent<Number>();

        tempNumber.transform.position = availableTile.transform.position;
        tempNumber.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        tempNumber.gameObject.transform.DOScale(Vector3.one, .15f);

        tempNumber.transform.parent = availableTile.transform;

        numList.Add(tempNumber);
    }

    public void createFirst()
    {
        Number tempNumber;
        for (int i = 0; i < 2; i++)
        {
            tempNumber = Instantiate(Number);
            var availableTile = GridManager.GetRandomAvailableTile();

            availableTile.GetComponent<Tile>().isNumberOn = true;
            availableTile.GetComponent<Tile>().Number = tempNumber.GetComponent<Number>();

            tempNumber.transform.position = availableTile.transform.position;
            tempNumber.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            tempNumber.gameObject.transform.DOScale(Vector3.one, .15f);

            tempNumber.transform.parent = availableTile.transform;

            numList.Add(tempNumber);
        }
    }
}
