using System.Collections.Generic;

class SongObjectManager
{
	// 노래 오브젝트 관리해주는 클래스
	Songs _songs;

	// 현재 노래관련 변수
	int[] _playSong;	// 현재 플레이할 노래 저장하는 배열
	int _index;			// 배열 참조 인덱스

	// 비트연산 관련 변수
	int _bitCount;				// 얼만큼 비트연산 할지 카운트
	readonly int _conpareBit;	// 비교 비트
	int _getBit;				// 노래와 비트연산 후 값 저장

	float _tickSum; 
	readonly float _setObjectTime;

	// 오브젝트 풀 관련 변수
	List<SongObject> _songObjectList = new List<SongObject>();
	int _ObjectMax; // 오브젝트 풀 최대 값 변수

	// 노래가 끝났는지 변수
	bool _isSongEnd; 

	public SongObjectManager()
	{
		// 시작 시 오브젝트 풀 20개 생성 및 readonly 값 설정
		_ObjectMax = 20;
		
		for (int i = 0; i < _ObjectMax; i++)
		{
			_songObjectList.Add(new SongObject());
		}

		_songs = new Songs();
		_setObjectTime = Tick.GetTargetFPSTicks() * Tick.Target;
		_conpareBit = 0x0000000f;
	}

	public bool IsSongEnd
	{
		get
		{
			return _isSongEnd;
		}
	}

	public void Init()
	{
		// 모든 오브젝트 풀 초기화 하기, 배열 참조 인덱스, 비트연산 카운트 초기화 및 노래 가져오기
		foreach (var item in _songObjectList)
		{
			item.Init();
		}

		_index = 0;
		_bitCount = 24;
		_getBit = 0;
		_isSongEnd = false;

		GetSong();
	}

	private void GetSong()
	{
		// 맞는 노래 가져오기
		_playSong = _songs.GetSong();
	}

	public void Update(float ticks)
	{
		// 게임 속도에따라 오브젝트 활성화 및 활성화 된 오브젝트들 업데이트 함수
		_tickSum += ticks * ((int)Speed.GameSpeed);

		if (_tickSum >= _setObjectTime)
		{
			SetSongObject();
			_tickSum = 0;
		}

		foreach (var item in _songObjectList)
		{
			if (item.IsPlay == true)
			{
				item.Update(ticks);
			}
		}
	}

	private void SetSongObject()
	{
		// 오브젝트풀 이용해서 알맞은 위치에 오브젝트 생성하기
		// 배열이 끝나면 노래가 끝난 것이다.
		if (_index == _playSong.Length)
		{
			SongEnd();
			return;
		}

		SongObject temp = GetIsPlayObject();
		_getBit = (_playSong[_index] >> _bitCount) & _conpareBit;

		_bitCount -= 4;

		if (_bitCount < 0)
		{
			_bitCount = 24;
			_index++;
		}

		// 0 이면 음표가 없기 때문에 바로 리턴
		if (_getBit == 0) 
		{
			return;
		}

		// 0이 아니라면 무조건 음표가 표시되어야 한다.
		temp.IsPlay = true;

		// 음표의 x 위치 값을 구하는 식 
		// ex) 비트가 1,2,3 이어도 음표만 다르고 같은 x 위치에서 나온다 -> x 위치 1
		// ex) 비트가 4,5,6 이어도 음표만 다르고 같은 x 위치에서 나온다 -> x 위치 4
		temp.PosX = ((_getBit - 1) / 3) * 3 + 1;

		// 오브젝트가 어떤 음표인지 구하는 식
		// ex) 비트가 1,2,3 이면 x 위치는 1 이므로 빼주어서 배열 인덱스 값으로 사용한다.
		temp.SetObjectC = SongKey.SongObjectC[_getBit - temp.PosX];
	}

	private SongObject GetIsPlayObject()
	{
		// 오브젝트 풀에서 활성화 되지 않은 오브젝트 반환하는 함수
		foreach (var item in _songObjectList)
		{
			if (item.IsPlay == false)
			{
				return item;
			}
		}

		// 오브젝트 풀이 전부 활성화 되있으면 추가로 할당한다.
		SongObject temp = new SongObject();
		_songObjectList.Add(temp);

		return temp;
	}

	private void SongEnd()
	{
		// 노래가 끝났는지 확인해주기 모든 오브젝트들 활성화 안되있다면 끝난것
		foreach (var item in _songObjectList)
		{
			if (item.IsPlay == true)
			{
				return;
			}
		}

		_isSongEnd = true;

		songObjectDelete();
	}

	private void songObjectDelete()
	{
		// 원래 초기 오브젝트 풀 20개
		// 20개 넘어가면 넘어간 것 삭제 해 주기
		if (_ObjectMax < _songObjectList.Count)
		{
			while (_ObjectMax < _songObjectList.Count)
			{
				_songObjectList.RemoveAt(_songObjectList.Count - 1);
			}
		}
	}
}

