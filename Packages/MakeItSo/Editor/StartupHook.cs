using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace MakeItSo.Editor {
	public class StartupHook {
		[InitializeOnLoadMethod]
		internal static void InitialiseCommandLineTriggers() {
			Debug.Log($"[{nameof(MakeItSo)}] Initializing {nameof(MakeItSo)} - Editor");

			ArgumentParser parser = new ArgumentParser(Environment.GetCommandLineArgs(), UnityEditorCommands.AllCLIArguments);

			if(!parser.ContainsNonStandardArguments) return; // Early-out, refletion is expensive

			foreach(MethodInfo command in GetCommandLineTargets(AppDomain.CurrentDomain.GetAssemblies())) {
				// Get the option(s)
				// Get the command + arg name - possibly by association type
				// Then if parser calls for it, invoke with any supplied args (don't invoke if missing required args)
				//if(parser.ContainsCommand())
				command.Invoke(null, null);
			}
		}

		private static IEnumerable<MethodInfo> GetCommandLineTargets(Assembly[] targetAssemblies) {
			List<MethodInfo> results = new List<MethodInfo>();
			foreach(Assembly assembly in targetAssemblies) {
				foreach(Type type in assembly.GetExportedTypes()) {
					MethodInfo[] methods = AttributeFinder.GetMethodsWithAttribute(type, typeof(EditorCLICommandAttribute));
					if(methods != null && methods.Length > 0) {
						foreach(MethodInfo hit in methods) {
							results.Add(hit);
						}
					}
				}
			}
			return results;
			// Could I do this by implementing an interface as well??
		}

		// private static dynamic GetArguments(MethodInfo targetCommand) {
		// 	// Get argument attribs for the command

		// 	//parse them?
		// }
	}
}
