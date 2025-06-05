using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawn_prefabs;
    [SerializeField] private GameObject _spawn_Monster_prefab;


    List<Vector2> spawn_list = new List<Vector2>();
    public static List<Vector2> move_list = new List<Vector2>();
    List<bool> spawn_list_Array = new List<bool>();
    

    void Start()
    {
        Grid_Start();

        for(int i=0; i< transform.childCount; i++)
        {
            move_list.Add(transform.GetChild(i).position);
        }

        StartCoroutine(Spawn_Monster_Coroutine());
    }

    #region 그리드 만들기
    void Grid_Start()
    {
        SpriteRenderer parentSprite = GetComponent<SpriteRenderer>();
        float parentwidth = parentSprite.bounds.size.x;
        float parentheight = parentSprite.bounds.size.y;

        float xCount = transform.localScale.x / 6;
        float yCount = transform.localScale.y / 3;

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 6; col++)
            {

                float xPos = (-parentwidth / 2) + (col * xCount) + (xCount / 2);
                float yPos = (parentheight / 2) - (row * yCount) + (yCount / 2);

                spawn_list_Array.Add(false);


                spawn_list.Add(new Vector2(xPos, yPos + transform.localPosition.y - yCount));
            }
        }
    }
    #endregion 그리드 만들기

    #region 캐릭터 소환
    public void Summon()
    {
        var go = Instantiate(_spawn_prefabs);
        int position_value = -1;

        for(int i=0; i<spawn_list.Count; i++)
        {
            if (spawn_list_Array[i] == false)
            {
                position_value = i;
                spawn_list_Array[i] = true;
                break;
            }
        }

        go.transform.position = spawn_list[position_value];
    }
    #endregion 캐릭터소환

    #region 몬스터 소환
    IEnumerator Spawn_Monster_Coroutine()
    {
        var go = Instantiate(_spawn_Monster_prefab, move_list[0], Quaternion.identity);        

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(Spawn_Monster_Coroutine());
    }
    #endregion 몬스터 소환
}
