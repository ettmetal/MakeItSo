using MakeItSo.Editor;

namespace MakeItSo {
	public class Example {
		[EditorCLICommand("-doTheThing")]
		[CLICommandOption]
		public static void DoTheThing() { }
	}
}
