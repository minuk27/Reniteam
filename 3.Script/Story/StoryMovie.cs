using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMovie : MonoBehaviour
{
    AudioSource audioSource;

    bool movieStart;
    GameObject playerObj;
    [SerializeField] List<GameObject> soldierObj;
    [SerializeField] GameObject motherObj;
    [SerializeField] GameObject sisterObj;
    [SerializeField] List<AudioClip> effectSound; //0: 총소리, 1: 문열리는 소리, 2: 총소리2, 3: 몽둥이소리
    [SerializeField] Image blackScreen;
    [SerializeField] GameObject nextTimeScreen;
    [SerializeField] GameObject nextPos;
    private void Awake()
    {
        movieStart = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = effectSound[0];
        blackScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!movieStart)
            return;
        StartCoroutine(firstScene());
    }

    IEnumerator firstScene()
    {
        motherObj.GetComponent<Animator>().enabled = false;
        movieStart = false;
        audioSource.Play();
        yield return new WaitForSeconds(1f); //총소리 시간 보고 결정
        audioSource.Stop();
        audioSource.clip = effectSound[1];
        StartCoroutine(secondScene());
    }

    IEnumerator secondScene()
    {
        yield return null;
        audioSource.Play();
        yield return new WaitForSeconds(1.5f); //문열리는 소리 재생
        audioSource.Pause();
        soldierObj[0].SetActive(true);
        yield return null;
        soldierObj[0].GetComponent<StoryMove>().moveStart(-5f);
        yield return new WaitForSeconds(0.5f);

        motherObj.SetActive(true);
        yield return null;
        motherObj.GetComponent<StoryMove>().moveStart(-3f);
        yield return new WaitForSeconds(0.5f);

        sisterObj.SetActive(true);
        yield return null;
        sisterObj.GetComponent<StoryMove>().moveStart(-2f);
        yield return new WaitForSeconds(0.5f);

        soldierObj[1].SetActive(true);
        yield return null;
        soldierObj[1].GetComponent<StoryMove>().moveStart(-1f);

        yield return new WaitForSeconds(0.5f); //이동대기
        audioSource.UnPause();
        yield return new WaitForSeconds(1.5f); //문닫히는 소리
        StartCoroutine(thirdScene());
    }

    IEnumerator thirdScene()
    {
        yield return null;
        audioSource.Stop();
        audioSource.clip = effectSound[3];

        playerObj.GetComponent<StoryMove>().moveStart(-10f);
        playerObj.GetComponent<PlayerMove>().animationPlayer();

        soldierObj[0].GetComponent<StoryMove>().moveStart(-4f);
        motherObj.GetComponent<StoryMove>().moveStart(-3f);
        sisterObj.GetComponent<StoryMove>().moveStart(-2f);
        soldierObj[1].GetComponent<StoryMove>().moveStart(-1f);

        yield return new WaitForSeconds(1f);
        playerObj.GetComponent<PlayerMove>().animationStop();
        playerObj.GetComponent<StoryMove>().moveStop();
        soldierObj[0].GetComponent<StoryMove>().moveStop();
        motherObj.GetComponent<StoryMove>().moveStop();
        sisterObj.GetComponent<StoryMove>().moveStop();
        soldierObj[1].GetComponent<StoryMove>().moveStop();
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        soldierObj[1].GetComponent<SpriteRenderer>().flipX = true;
        motherObj.GetComponent<SpriteRenderer>().flipX = false;
        yield return new WaitForSeconds(0.7f);
        blackScreen.GetComponentInChildren<Text>().text = "";
        blackScreen.gameObject.SetActive(true);
        audioSource.clip = effectSound[2];
        yield return null;
        audioSource.Play();
        yield return null;
        motherObj.GetComponent<StoryMove>().speedUp();
        motherObj.GetComponent<StoryMove>().moveStart(5.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(fourthScreen());
    }

    IEnumerator fourthScreen()
    {
        yield return null;
        blackScreen.gameObject.SetActive(false);
        motherObj.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3f);
        blackScreen.gameObject.SetActive(true);
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        GameManager.Manager.getScreenTransition.timeChange(PlaceTime.ThreeDay, nextPos, nextTimeScreen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !movieStart)
        {
            playerObj = collision.gameObject;
            playerObj.GetComponent<PlayerMove>().moveStop();
            movieStart = true;
        }
    }
}
