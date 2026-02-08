using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace FMScoutFramework.Core
{
	/// <summary>
	/// Holder for the Football Manager process
	/// </summary>
	public class FMProcess
	{
		public Process Process { get; set; }
		public IntPtr Pointer { get; set; }
		public Int64 EndPoint { get; set; }
		public Int64 BaseAddress { get; set; }
		public string VersionDescription { get; set; }
		public Int64 HeapAddress { get; set; }
	}
}
