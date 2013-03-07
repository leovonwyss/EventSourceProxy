﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventSourceProxy
{
	/// <summary>
	/// Serializes an object to a string when an ETW log needs to serialize a non-native object.
	/// </summary>
	public interface ITraceSerializationProvider
	{
		/// <summary>
		/// Serializes an object to a string when an ETW log needs to serialize a non-native object.
		/// </summary>
		/// <param name="value">The object to serialize.</param>
		/// <param name="methodHandle">A RuntimeMethodHandle to the log method being called.</param>
		/// <param name="parameterIndex">The index of the current parameter being logged.</param>
		/// <returns>The string representation of the object. This value can be null.</returns>
		string SerializeObject(object value, RuntimeMethodHandle methodHandle, int parameterIndex);

		/// <summary>
		/// Returns if the should the given parameter be serialized.
		/// </summary>
		/// <param name="method">The method being called.</param>
		/// <param name="parameterIndex">The index of the parameter to analyze.</param>
		/// <returns>True if the value should be serialized, false otherwise.</returns>
		bool ShouldSerialize(MethodInfo method, int parameterIndex);
	}
}