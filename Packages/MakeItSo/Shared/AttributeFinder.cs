using System;
using System.Collections.Generic;
using System.Reflection;

namespace MakeItSo {
	public class AttributeFinder {
		public static MethodInfo[] GetMethodsWithAttribute(Type type, Type targetAttribute) {
			MethodInfo[] methods = type.GetMethods();
			List<MethodInfo> results = new List<MethodInfo>();
			foreach(MethodInfo method in methods) {
				Attribute foundAttribute = method.GetCustomAttribute(targetAttribute, true);
				if(foundAttribute != null) results.Add(method);
			}
			return results.ToArray();
		}
	}
}
