using System;

static class Score
{
	// 모든 스코어 관련 담당

	// 스코어들 변수
	static public int Life;			// 목숨
	static public int GameScore;	// 게임 점수
	static public int Combo;		// 콤보 횟수
	static public string State;		// 정확도 나타내는 문자열

	static public void Init()
	{
		// 초기화하기
		Life = 10;
		GameScore = 0;
		Combo = 0;
		State = string.Empty;
	}

	static public void Update()
	{
		Render();
		IsPlayerDie();
	}

	static public bool IsPlayerDie()
	{
		// 라이프가 0이하인지 체크해서 죽었는지 체크하기
		if(Life <= 0)
		{
			return true;
		}

		return false;
	}

	static private void Render()
	{
		Console.SetCursorPosition(20, 5);
		Console.Write("점수 : " + GameScore);
		Console.SetCursorPosition(20, 6);
		Console.Write("목숨 : " + Life);
		Console.SetCursorPosition(20, 7);
		Console.Write("콤보 : " + Combo);
		Console.SetCursorPosition(20, 8);
		Console.Write(State);
	}
}
