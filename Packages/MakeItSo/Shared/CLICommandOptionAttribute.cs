using System;
using System.Collections.Generic;
using UnityEngine;

namespace MakeItSo {
	public class CLICommandOptionAttribute : Attribute {
		public readonly string ValidationRegex;
		public CLICommandOptionAttribute(string validateWith = ".*") {
			ValidationRegex = validateWith;
		}
	}
}
