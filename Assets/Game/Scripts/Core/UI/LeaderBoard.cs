using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.UI
{
    public class LeaderBoard : MonoBehaviour
    {
        private List<RectTransform> positions;
        [SerializeField] private List<ScoreLeaderBoard> lines;
        [SerializeField] private float speed;
        private void Awake()
        {
            positions = new List<RectTransform>();
            for (int i = 0; i < lines.Count; i++)
            {
                positions.Add(new GameObject().AddComponent<RectTransform>());
                positions[i].parent = lines[i].gameObject.transform.parent;
                positions[i].position = lines[i].gameObject.GetComponent<RectTransform>().position;
            }
        }

        private void Update()
        {
            SortLabel();
            MoveLabel();
        }

        private void MoveLabel()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].gameObject.GetComponent<RectTransform>().position = Vector3.MoveTowards(lines[i].gameObject.GetComponent<RectTransform>().position, positions[i].position, speed * Time.deltaTime);
            }
        }

        private void SortLabel()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    if (lines[i].score < lines[j].score)
                    {
                        ScoreLeaderBoard g = lines[i];
                        lines[i] = lines[j];
                        lines[j] = g;
                    }
                }
            }
        }
    }
}
