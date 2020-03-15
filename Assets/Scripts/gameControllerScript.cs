using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControllerScript : MonoBehaviour
{
    //経過時間
    [SerializeField]private GameObject time;
    private Text time_text;
    private float ElapseTime;

    //残りターゲット
    [SerializeField]private GameObject remainingTarget;
    private Text target_text;
    private int target_num = 9;

    //リザルト画面
    [SerializeField]private GameObject resultPanel;
    [SerializeField]private Text result_text;
    [SerializeField]private GameObject tipsPanel;

    //シーン再読み込み
    private Scene loadScene;

    // Start is called before the first frame update
    void Start()
    {
        time_text = time.GetComponent<Text>();
        target_text = remainingTarget.GetComponent<Text>();
        loadScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        ElapseTime += Time.deltaTime;
        time_text.text = "Time : " + (ElapseTime).ToString("F1");
    }

    public void changeTargetText()
    {
        if (target_text != null)
        {
            target_num -= 1;
            target_text.text = "target : " + (target_num).ToString();
            if (target_num <= 0)
            {
                GameComplete();
            }
        }
    }

    public void GameComplete()
    {
        float resultTime = ElapseTime;

        time.SetActive(false);
        remainingTarget.SetActive(false);

        resultPanel.SetActive(true);
        result_text.text = "YourTime : " + (resultTime).ToString("F1") + "s";
        tipsPanel.SetActive(false);

        
        Time.timeScale = 0;
        
    }

    public void pushRetryButtom()
    {
        SceneManager.LoadScene(loadScene.name);
        Time.timeScale = 1;
    }
}




