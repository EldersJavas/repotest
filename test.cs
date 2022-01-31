using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
// 给定两个整数 n 和 k，返回 [1, n] 范围之内的
 //k 个数字的所有可能组合。其中 1 <= n <= 30,
 // 1 <= k <= n
// 比如给定 n=3 , k =2 返回 [1, 3] 范围之内
 //所有可能的2个数字组合，
 //也就是返回[1,2],[1,3],[2,3]

public class UnityChallengeAuestion : MonoBehaviour
{
    [Range(0,30)]
    public int n;
    public int k;
    private List<List<int>> resultList = new List<List<int>>();
    private Stack<int> resultStack = new Stack<int>();
    // Start is called before the first frame update
    void Start()
    {
        Answer(1, resultStack, resultList);
        //-----------------------输出结果---------------------------
        StringBuilder resultStr = new StringBuilder();
        for (int i = 0; i < resultList.Count; i++)
        {
            resultStr.Clear();
            List<int> temp = new List<int>();
            for (int j = resultList[i].Count - 1; j >= 0; j--)
            {
                resultStr.Append(resultList[i][j] + " ");

            }
            Debug.LogError("结果：[ " + resultStr+ "]");
        }
    }
    void Answer(int startIndex, Stack<int> tempStack, List<List<int>> tempList)
    {
        if (tempStack.Count == k)
        {
            tempList.Add(new List<int>(tempStack));
            return;
        }

        for (int i = startIndex; i <= n; i++)
        {
            tempStack.Push(i);
            Answer(i + 1, tempStack, tempList);
            tempStack.Pop();
        }
    }
}