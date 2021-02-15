using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Structs.Utility;
using UnityEngine;

namespace Utility
{
	/// <summary>
	/// A 'fake' dictionary that can be serialized
	/// </summary>
	[Serializable, DebuggerDisplay("Count = {Count}")]
	public class SerializableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IList, ISerializationCallbackReceiver
	{
		#region Fields

		[SerializeField]
		protected List<SerializableKeyValuePair<TKey, TValue>> SerializedDictionary = new List<SerializableKeyValuePair<TKey, TValue>>();

		protected List<SerializableKeyValuePair<TKey, TValue>> InternalList = new List<SerializableKeyValuePair<TKey, TValue>>();

		#endregion

		#region Operators

		public static explicit operator SerializableDictionary<TKey, TValue>(List<SerializableKeyValuePair<TKey, TValue>> list)
		{
			return new SerializableDictionary<TKey, TValue>(list);
		}

		public static implicit operator SerializableDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
		{
			return new SerializableDictionary<TKey, TValue>(dictionary);
		}

		public static implicit operator Dictionary<TKey, TValue>(SerializableDictionary<TKey, TValue> serializableDictionary)
		{
			return serializableDictionary.InternalList.ToDictionary(pair => pair.Key, keyValuePair => keyValuePair.Value);
		}

		#endregion

		#region Properties

		public TValue this[TKey key]
		{
			get
			{
				TryGetValue(key, out TValue value);
				return value;
			}
			set => Add(key, value);
		}

		public object this[object key]
		{
			get
			{
				TryGetValue(key, out TValue value);
				return value;
			}
			set => ((IDictionary) this).Add(key, value);
		}

		public object this[int index]
		{
			get => InternalList[index];
			set
			{
				if (VerifyValue(value))
				{
					InternalList[index] = (SerializableKeyValuePair<TKey, TValue>) value;
				}
			}
		}

		public int Count => InternalList.Count;

		public object SyncRoot => ((ICollection) InternalList).SyncRoot;

		public bool IsFixedSize => false;
		public bool IsSynchronized => false;
		public bool IsReadOnly => false;

		public ICollection<TKey> Keys => InternalList.Select(pair => pair.Key).ToArray();

		public ICollection<TValue> Values => InternalList.Select(pair => pair.Value).ToArray();

		ICollection IDictionary.Values => (ICollection) Keys;

		ICollection IDictionary.Keys => (ICollection) Values;

		#endregion

		#region Constructors

		public SerializableDictionary()
		{
		}

		public SerializableDictionary(IEnumerable<SerializableKeyValuePair<TKey, TValue>> list)
		{
			InternalList         = list.Distinct().ToList();
			SerializedDictionary = InternalList;
		}

		public SerializableDictionary(params SerializableKeyValuePair<TKey, TValue>[] keyValuePairs) : this(keyValuePairs.Distinct())
		{
		}

		public SerializableDictionary(Dictionary<TKey, TValue> dictionary)
		{
			foreach (KeyValuePair<TKey, TValue> pair in dictionary)
			{
				Add(pair.Key, pair.Value);
			}
		}

		public SerializableDictionary(SerializableDictionary<TKey, TValue> dictionary)
		{
			foreach (KeyValuePair<TKey, TValue> pair in dictionary)
			{
				Add(pair.Key, pair.Value);
			}
		}

		#endregion

		#region IDictionary

		public void Add(TKey key, TValue value)
		{
			int index = IndexOf(key);

			// IndexOf returns -1 if it's not present
			if (index < 0)
			{
				SerializableKeyValuePair<TKey, TValue> newPair = new SerializableKeyValuePair<TKey, TValue>(key, value);
				InternalList.Add(newPair);
				SerializedDictionary.Add(newPair);
				return;
			}

			SerializableKeyValuePair<TKey, TValue> pair = InternalList[index];
			pair.Value = value;

			InternalList[index]         = pair;
			SerializedDictionary[index] = pair;
		}

		public bool Remove(TKey key)
		{
			int index = IndexOf(key);

			if (index < 0)
			{
				return false;
			}

			InternalList.RemoveAt(index);
			SerializedDictionary.RemoveAt(index);
			return true;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int index = IndexOf(key);

			if (index >= 0)
			{
				value = InternalList[index].Value;
				return true;
			}

			value = default;
			return false;
		}

		void IDictionary.Add(object key, object value)
		{
			VerifyKey(key);

			VerifyValue(value);

			Add((TKey) key, (TValue) value);
		}

		void IDictionary.Remove(object key)
		{
			VerifyKey(key);

			Remove((TKey) key);
		}

		bool IDictionary.Contains(object key)
		{
			return VerifyKey(key) && ContainsKey((TKey) key);
		}

		#endregion

		#region IList

		public int Add(object value)
		{
			return ((IList) InternalList).Add(value);
		}

		public bool Contains(object value)
		{
			return ((IList) InternalList).Contains(value);
		}

		public int IndexOf(object value)
		{
			return ((IList) InternalList).IndexOf(value);
		}

		public void Insert(int index, object value)
		{
			if (VerifyKeyValuePair(value))
			{
				SerializableKeyValuePair<TKey, TValue> pair = (SerializableKeyValuePair<TKey, TValue>) value;

				if (!ContainsKey(pair.Key))
				{
					((IList) InternalList).Insert(index, value);
				}
				else
				{
					throw new ArgumentException($"The dictionary already has a key with value {pair.Key}", nameof(value));
				}
			}
		}

		public void Remove(object value)
		{
			((IList) InternalList).Remove(value);
		}

		public void RemoveAt(int index)
		{
			InternalList.RemoveAt(index);
		}

		#endregion

		#region ICollection

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			if (!InternalList.Contains(item))
			{
				InternalList.Add(item);
				SerializedDictionary.Add(item);
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			SerializedDictionary.Remove(item);
			return InternalList.Remove(item);
		}

		public void Clear()
		{
			InternalList.Clear();
			SerializedDictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item) => InternalList.Contains(item);

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			ToKeyValuePair().ToList().CopyTo(array, arrayIndex);
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection) InternalList).CopyTo(array, index);
		}

		#endregion

		#region ISerializationCallbackReceiver

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
			InternalList = SerializedDictionary.Distinct().ToList();
		}

		#endregion

		#region IEnumerable

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>
			ToKeyValuePair().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		IDictionaryEnumerator IDictionary.GetEnumerator() => ((Dictionary<TKey, TValue>) this).GetEnumerator();

		#endregion

		#region Public

		public bool TryGetValue(object key, out TValue value)
		{
			VerifyKey(key);

			int index = IndexOf((TKey) key);

			if (index >= 0)
			{
				value = InternalList[index].Value;
				return true;
			}

			value = default;
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOf(key) >= 0;
		}

		public bool ContainsValue(TValue value)
		{
			return InternalList.Any(pair => pair.Value.Equals(value));
		}

		/// <summary>
		/// Returns the index of the dictionaryEntry of a given key
		/// </summary>
		public int IndexOf(TKey key)
		{
			int index = InternalList.FindIndex(pair => pair.Key.Equals(key));
			return index;
		}

		#endregion

		#region Private

		private static bool VerifyKey(object key)
		{
			switch (key)
			{
				case null when typeof(TKey).IsValueType:
					throw new ArgumentNullException(nameof(key), $"null while {typeof(TKey).Name} cannot be null");
				case null:
				case TKey _:
					return true;
				default:
					throw new ArgumentException($"{key} is not of type {typeof(TKey).Name}", nameof(key));
			}
		}

		private static bool VerifyValue(object value)
		{
			switch (value)
			{
				case null when typeof(TValue).IsValueType:
					throw new ArgumentNullException(nameof(value), $"null while {typeof(TValue).Name} cannot be null");
				case null:
				case TValue _:
					return true;
				default:
					throw new ArgumentException($"{value} is not of type {typeof(TValue).Name}", nameof(value));
			}
		}

		private static bool VerifyKeyValuePair(object value)
		{
			// if it's neither a serializableKeyValuePair or a KeyValuePair, throw exception
			if (!(value is SerializableKeyValuePair<TKey, TValue>) && !(value is KeyValuePair<TKey, TValue>))
			{
				throw new ArgumentException(
					$"{value} is not of type {typeof(SerializableKeyValuePair<TKey, TValue>)} or {typeof(KeyValuePair<TKey, TValue>)}");
			}

			return true;
		}

		private IEnumerable<KeyValuePair<TKey, TValue>> ToKeyValuePair()
		{
			return InternalList.Select(pair => (KeyValuePair<TKey, TValue>) pair);
		}

		private SerializableKeyValuePair<TKey, TValue> GetPair(TKey key)
		{
			return InternalList.First(pair => pair.Key.Equals(key));
		}

		#endregion
	}
}