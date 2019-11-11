namespace Steamworks.Data
{
	struct SearchFilter<T>
	{
		public string Key { get; internal set; }
		public T Value { get; internal set; }
		public LobbyComparison Comparer { get; internal set; }

		internal SearchFilter ( string k, T v, LobbyComparison c )
		{
			Key = k;
			Value = v;
			Comparer = c;
		}
	}
}
