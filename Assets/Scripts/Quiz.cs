using System.Threading;
using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public int i;
    public int answer = -1;
    public int yes;
    public Text quiz;
    public GameObject[] Uis;
    bool answered = false;
    public string[] O_problems = { "독도는 동도와 서도가 있다.", "독도는 경상북도에 속해있다.", "독도는 한반도에서 가장 멀리 떨어져 있는 섬이다.", "독도엔 다산초록이라는 식물이 살고 있다.", "현재 일본은 독도가 자신의 나라의 땅이라고 주장 중이다.", "독도는 대한민국의 영토 중 가장 동쪽에 있다.", "독도엔 다산초록이라는 식물이 살고 있다.", "독도는 대한민국의 영토 중 가장 동쪽에 있다.", "독도는 천연기념물로 지정되었다.", "일본은 독도 영유권을 스스로 부정한 적이 있다.", "독도의 옛 이름은 우산도이다.", "독도의 연평균 기온은 12도이다.", "독도를 관광하기 위해 입도하기 위해서는 신고를 하는 절차를 밟는다." };
    public string[] X_problems = { "현재 독도엔 바다사자가 살고 있다.", "세종실록지리지에는 독도는 멀지 아니하여 날씨가 흐려도 충분히 바라볼 수 있다 라는 내용이 있다.", "독도의 우편번호는 39314이다.", "독도의 연평균 강수량은 800mm이다.", "독도의 올바른 영어 표기는 Dockdo이다.", "현재 독도엔 사람이 거주하고 있지 않다.", "독도는 국제법상 분쟁지역에 해당한다.", "독도는 울릉도와 157.5km 떨어져있다." };
    public void QuizUp()
    {
        for (int i = 0; i < Uis.Length; i++)
        {
            Uis[i].SetActive(true);
        }
        i = UnityEngine.Random.Range(0, 2);
        Time.timeScale = 0;
        answer = -1;
        answered = true;
        if (i == 0)
        {
            quiz.text = O_problems[UnityEngine.Random.Range(0, O_problems.Length)];
        }
        if (i == 1)
        {
            quiz.text = X_problems[UnityEngine.Random.Range(0, X_problems.Length)];
        }
    }

    public void sellect_O()
    {
        answer = 0;
        if (i == answer)
        {
            quiz.text = "정답입니다!";
            GameManager.instance.bs.fishCoin += 50;
        }
        if (i != answer)
        {
            quiz.text = "오답입니다..";
        }
        Time.timeScale = 1;
        Invoke("off", 1f);
    }
    public void sellect_X()
    {
        answer = 1;
        if (i == answer)
        {
            quiz.text = "정답입니다!";
            GameManager.instance.bs.fishCoin += 50;
        }
        if (i != answer)
        {
            quiz.text = "오답입니다..";
        }
        Time.timeScale = 1;
        Invoke("off", 1f);
    }
    void off()
    {
        for (int i = 0; i < Uis.Length; i++)
        {
            Uis[i].SetActive(false);
        }

    }
}
