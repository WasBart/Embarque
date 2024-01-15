using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectObjects : MonoBehaviour
{
    public StoryManager sm;
    public GameObject stopText;
    public GameObject subtitleText;
    public TextMeshProUGUI subtitleTextText;
    bool spacePressed;
    bool aPressed;
    // Start is called before the first frame update
    void Start()
    {
        //subtitleTextText = subtitleText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
        else
        {
            spacePressed = false;
        }

        if(Input.GetKeyDown("joystick button 0"))
        {
            aPressed = true;
        }
        else
        {
            aPressed = false;
        }
    }

    void FixedUpdate()
    {

        int layerMask = 1 << 3;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10.0f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            //Debug.Log(hit.transform);
            stopText.SetActive(true);
            if(spacePressed || aPressed)
            {
                //hit.transform.gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
                //Debug.Log("Hit and space pressed");
                if(hit.transform.gameObject.tag == "Famine")
                {
                    sm.famineStop = !sm.famineStop;
                    if(sm.famineStop)
                    {
                        StartCoroutine(ShowFamineText());
                    }
                    sm.famineStoppedOnce = true;
                }
                else if(hit.transform.gameObject.tag == "War")
                {
                    sm.warStop = !sm.warStop;
                    if(sm.warStop)
                    {
                        StartCoroutine(ShowWarText());
                    }
                    sm.warStoppedOnce = true;
                }
                else if(hit.transform.gameObject.tag == "Conquest")
                {
                    sm.conquestStop = !sm.conquestStop;
                    if(sm.conquestStop)
                    {
                        StartCoroutine(ShowConquestText());
                    }
                    sm.conquestStoppedOnce = true;
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
           //Debug.Log("Did not Hit");
           stopText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Ship Volume")
        {
            Debug.Log("Application quitting");
            Application.Quit();
        }
    }

    IEnumerator ShowFamineText()
    {
        subtitleText.SetActive(true);
        subtitleTextText.text = sm.famineTexts[sm.famineStoryObjectIndex];
        yield return new WaitForSeconds(2);
        subtitleText.SetActive(false);
    }

    IEnumerator ShowWarText()
    {
        subtitleText.SetActive(true);
        subtitleTextText.text = sm.warTexts[sm.warStoryObjectIndex];
        yield return new WaitForSeconds(2);
        subtitleText.SetActive(false);
    }

    IEnumerator ShowConquestText()
    {
        subtitleText.SetActive(true);
        subtitleTextText.text = sm.conquestTexts[sm.conquestStoryObjectIndex];
        yield return new WaitForSeconds(2);
        subtitleText.SetActive(false);
    }
}
