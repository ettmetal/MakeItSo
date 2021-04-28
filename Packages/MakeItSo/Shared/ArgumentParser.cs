using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MakeItSo {
	public class ArgumentParser {
		private string[] arguments;
		private string[] unityArguments;

		public bool ContainsNonStandardArguments => checkForCustomArguments();

		public ArgumentParser(string[] args, string[] unityArgs) {
			arguments = args;
			unityArguments = unityArgs;
		}

		public bool ContainsCommand(string command) { return true; }

		public T GetOption<T>(string argName, int optionIndex = 0) {
			int argIndex = Array.IndexOf(arguments, argName);
			if(argIndex < 0) {
				Debug.LogError($"[{nameof(MakeItSo)}] CLI Argument {argName} not found when looking for its options");
				return default(T);
			}
			string option = arguments[argIndex + ++optionIndex];
			// Is option valid?
			T typedOption = (T)Convert.ChangeType(option, typeof(T));
			// TODO: Check option / throw
			return typedOption;
		}

		private bool checkForCustomArguments() {
			foreach(string argument in arguments) {
				int argIndex = Array.IndexOf(arguments, argument);
				int unityArgIndex = Array.IndexOf(unityArguments, argument);
				if(unityArgIndex > -1) return true; // TODO: This doesn't consider options
			}
			return false;
		}
	}
}
