class GameDataManager
{
	// 통합적 데이터 관리

	SongObjectManager _songObjectManager;

	public GameDataManager()
	{
		_songObjectManager = new SongObjectManager();
	}

	public void Init()
	{
		// 알맞은 게임 얻기 및 스코어 초기화 등 게임 데이터 초기화
		_songObjectManager.Init();
		Score.Init();
	}
	
	public void Update(float ticks)
	{
		// 총괄적인 업데이트
		// 게임오브젝트 및 스코어 업데이트
		_songObjectManager.Update(ticks);
		Score.Update();
	}

	public bool IsGameEnd()
	{
		// 게임 끝났는지 확인하는 함수
		return Score.IsPlayerDie() || _songObjectManager.IsSongEnd;
	}
}
