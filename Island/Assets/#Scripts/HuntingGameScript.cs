using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HuntingGameScript : SingleTon<HuntingGameScript>{
    private Camera camera;
    public GameObject timerAni;
    public TextMeshProUGUI scoreTxt;
    private int birdnum = 0;
    public GameObject prefab;
    public GameObject birdPrefab;
    public GameObject missPrefab;
    public static List<GameObject> birdList = new List<GameObject>();
    GameObject bird;
    GameObject birdDead;
    GameObject miss;
    private int timer = 0;
    private bool shot;
    public int score = 0;
    private float start, end;
    private int bullet = 20;
    float step;
    private void Start()
    {

        camera = Camera.main;

        shot = false;//못맞춤
        
        StartCoroutine(Timer());
        StartCoroutine(Move());
        StartCoroutine(MakeBird());
        

    }
    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            shot = false;
            bullet--;
            Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100);
            vector = camera.ScreenToWorldPoint(vector);

            vector = new Vector3(vector.x * 71.99999424000046f, vector.y * 71.99999424000046f, 100);


            for (int i = 0; i < birdList.Count; i++)
            {

                Debug.Log(vector.x + "  " + birdList[i].transform.localPosition.x);

                Debug.Log(vector.y + "  " + birdList[i].transform.localPosition.y);
                if (vector.x >= (birdList[i].transform.localPosition.x - 155f) && vector.x <= (birdList[i].transform.localPosition.x + 5f) && vector.y >= (birdList[i].transform.localPosition.y - 70f) && vector.y <= (birdList[i].transform.localPosition.y + 70f))
                {
                   
                        birdDead = Instantiate(prefab, vector, Quaternion.identity);

                        birdDead.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                        
                        birdList[i].SetActive(false);
                        score++;
                        scoreTxt.text = "X " + score.ToString();
                    shot = true;
                        
                }

            }
            if (shot == false)
            {
                 
                    miss = Instantiate(missPrefab, vector, Quaternion.identity);

                    miss.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    score--;
                    scoreTxt.text = "X " + score.ToString();
                
            }
        }


    }

    IEnumerator Timer()
    {
        while (true)
        {
            timer++;
            yield return new WaitForSeconds(1);
        }
       
    }

    IEnumerator Move()
    {
        while (true)
        {

            step = 700f * Time.deltaTime;
            for (int i = 0; i < birdList.Count; i++)
            {
                birdList[i].transform.localPosition = Vector3.MoveTowards(birdList[i].transform.localPosition, new Vector3(700f, end, 0), step);

                if (birdList[i].transform.localPosition.x >= 700f)
                    birdList.RemoveAt(i);

            }

            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator MakeBird()
    {
        yield return new WaitUntil(() => timer >= 5);
        
        Destroy(timerAni);
        StopCoroutine(Timer());
        while (bullet > 0 && birdnum < 20)
        {

            birdnum++;
            start = Random.Range(-140, 300);
            end = Random.Range(-140, 300);  
            bird = Instantiate(birdPrefab, new Vector3(-700f, start + 0f, 0), Quaternion.identity);
            
            bird.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            birdList.Add(bird);
            //Debug.Log(test.transform.localPosition.x);
            
            yield return new WaitForSeconds(1);
        }
    }
    public void Miss()
    {
        //if (Input.GetMouseButton(0))
        //{

        //    Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100);
        //    vector = camera.ScreenToWorldPoint(vector);

        //    vector = new Vector3(vector.x * 71.99999424000046f, vector.y * 71.99999424000046f, 100);


        //    for (int i = 0; i < birdList.Count; i++)
        //    {

        //        Debug.Log(vector.x + "  " + birdList[i].transform.localPosition.x);

        //        Debug.Log(vector.y + "  " + birdList[i].transform.localPosition.y);
        //        if (vector.x >= (birdList[i].transform.localPosition.x - 105f) && vector.x <= (birdList[i].transform.localPosition.x + 25f))
        //        {
        //            if (vector.y >= birdList[i].transform.localPosition.y - 50f && vector.y <= birdList[i].transform.localPosition.y + 50f)
        //            {
        //                birdList[i].SetActive(false);
        //                score++;
        //                scoreTxt.text = score.ToString();
        //            }
        //        }





        //    }
        //}
        

    }
   

}
