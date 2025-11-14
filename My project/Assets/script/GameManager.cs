using UnityEngine;

public class GameManager : MonoBehaviour
{
  
     

        public int scorePlayer1, scorePlayer2;
        public ScoreScript scoreTextleft, scoreTextright;
       

        public void OnScoreZoneReached(int id , int poängsystem)
        {
            if (id == 1)
                scorePlayer1++;

            if (poängsystem == 2)
                scorePlayer2++;
            UpdateScores();
        }
        private void UpdateScores()
        {
            scoreTextleft.SetScore(scorePlayer1);
            scoreTextright.SetScore(scorePlayer2);
        }
    }
