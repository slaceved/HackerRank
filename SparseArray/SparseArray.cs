using System;
using System.Collections;

namespace SparseArray
{
	/// <summary>
	/// Summary description for SparseArray class.
	/// </summary>
	public class SparseArray : IList
	{
		protected int Dimensions = 1;
		protected Hashtable Hashtable;
		protected int[] LowerBounds, UpperBounds;

		public SparseArray()
		{
			Hashtable = new Hashtable();
			LowerBounds = new int[Dimensions];
			UpperBounds = new int[Dimensions];
		}
		
		public SparseArray(int dimensions)
		{
			Dimensions = dimensions;
			Hashtable = new Hashtable();
			LowerBounds = new int[dimensions];
			UpperBounds = new int[dimensions];
		}

		protected string IndexToHash(int[] indices)
		{
			if (indices.Length != Dimensions)
				throw new ArgumentException("The number of indices must match the number of dimensions");

			var sb = new System.Text.StringBuilder();
			for (var i = 0; i < indices.Length; i++)
			{
				sb.Append(indices[i].ToString());
				if (i < (indices.Length-1))
					sb.Append(',');
			}
			return sb.ToString();
		}

		protected int[] HashToIndex(string hash)
		{
			var subs = hash.Split(',');
			if (subs.Length != Dimensions)
				throw new ArgumentException("The number of indices must match the number of dimensions");

			var ret = new int[Dimensions];
			for (var i = 0; i < Dimensions; i++)
				ret[i] = int.Parse(subs[i]);

			return ret;
		}

		public bool IsFixedSize => false;
	    public bool IsReadOnly => false;
	    public bool IsSynchronized => false;
	    public int Count => Hashtable.Count;
	    public int Rank => Dimensions;
	    public object SyncRoot => " ";

	    public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public int GetLowerBound(int dimension)
		{
			if (dimension > Dimensions)
				throw new ArgumentOutOfRangeException(nameof(dimension));
			return LowerBounds[dimension];
		}

		public int GetUpperBound(int dimension)
		{
			if (dimension > Dimensions)
				throw new ArgumentOutOfRangeException(nameof(dimension));
			return UpperBounds[dimension];
		}

		public object GetValue(int[] indices)
		{
			var key = IndexToHash(indices);
			return Hashtable.Contains(key) ? Hashtable[key] : null;
		}

		public object GetValue(int index)
		{
			return GetValue(indices: new[] { index });
		}

		public object GetValue(int index1, int index2)
		{
			return GetValue(new[] { index1, index2 });
		}

		public void SetValue(object value, int[] indices)
		{
			Hashtable.Add(IndexToHash(indices), value);
			for (var i = 0; i < Dimensions; i++)
			{
				if (LowerBounds[i] > indices[i])
					LowerBounds[i] = indices[i];
				if (UpperBounds[i] < indices[i])
					UpperBounds[i] = indices[i];
			}
		}

		public void SetValue(object value, int index)
		{
			SetValue(value, new[] { index });
		}

		public void SetValue(object value, int index1, int index2)
		{
			SetValue(value, new[] { index1, index2 });
		}

		private class SparseArrayEnumerator : IEnumerator
		{
			private readonly IDictionaryEnumerator _dict;

		    public SparseArrayEnumerator(SparseArray array) {
		        _dict = array.Hashtable.GetEnumerator(); }
			public void Reset() { _dict.Reset(); }
			public bool MoveNext() { return _dict.MoveNext(); }
			public object Current => _dict.Value;
		}

		public IEnumerator GetEnumerator()
		{
			return new SparseArrayEnumerator(this);
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		public void Remove(object value)
		{
			throw new NotImplementedException();
		}

		public bool Contains(object value)
		{
			return Hashtable.ContainsValue(value);
		}

		public void Clear()
		{
			Hashtable.Clear();
		}

		public int IndexOf(object value)
		{
			if (Dimensions != 1)
				throw new RankException();
			return 0;
		}

		public int Add(object value)
		{
			throw new NotImplementedException();
		}

		public object this[int[] indicies]
		{
			get { return GetValue(indicies); } 
			set { SetValue(value, indicies); }
		}

		public object this[int index]
		{
			get { return GetValue(index); } 
			set { SetValue(value, index); }
		}

		public object this[int index1, int index2]
		{
			get { return GetValue(index1, index2); } 
			set { SetValue(value, index1, index2); }
		}

	}
}
