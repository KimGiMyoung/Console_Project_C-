// 틱관련 클래스
static class Tick
{
	public const float Target = 30;

	static public float GetTargetFPSTicks()
	{
		return 10000 * 1000 / Target; // 10000000 / 30;
	}
}
