using System.Collections.Generic;

public class StateTracker<T>
{
	Dictionary<string, T> Values = new Dictionary<string, T>();

	public T this[string index]
	{
		get
		{
			T toReturn;
			var res = Values.TryGetValue(index, out toReturn);

			if (!res)
			{
				Values.Add(index, toReturn);
			}

			return toReturn;
		}
		set
		{
			if (Values.ContainsKey(index))
			{
				Values[index] = value;
			}
			else
			{
				Values.Add(index, value);
			}
		}
	}
}
