using UnityEngine;
using System.Collections.Generic;

public class Character_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawn_prefabs;
    List<Vector2> spawn_list = new List<Vector2>();
    List<bool> spawn_list_Array = new List<bool>();

    void Start()
    {
        Grid_Start();
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
}
