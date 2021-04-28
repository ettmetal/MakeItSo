using System;

namespace MakeItSo.Editor {
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	/// <summary>
	/// Attribute to mark a static method as triggered by a command-line argument to the editor.
	/// </summary>
	public class EditorCLICommandAttribute : Attribute {
		/// <summary>
		/// The argument used to trigger the static method from the Unity editor CLI.
		/// </summary>
		public readonly string CLIArgument;

		/// <summary>
		/// Marks a static method to be triggered by the specified command-line <paramref name="argument" />
		/// </summary>
		/// <param name="argument">
		/// <para>The argument which should trigger the method when passed on the command-line.</para>
		/// <para>Typical arguments in Unity are prefixed with "-", e.g. "-MyCLIArgument".</para>
		/// </param>
		public EditorCLICommandAttribute(string argument) {
			CLIArgument = argument;
		}

		private EditorCLICommandAttribute() { }
	}
}
