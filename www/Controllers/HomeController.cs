using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace www.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";
			ViewData["Runtime"] += " Framework version: " + Environment.Version + " " + Environment.OSVersion + " 64bit: " + Environment.Is64BitProcess;

			var asms = new List<string> ();

			foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
				asms.Add(DumpAssembly(asm));
			}

			asms.Sort();

			ViewData["Assemblies"] = asms;

			return View ();
		}

		private static string DumpAssembly(System.Reflection.Assembly asm) {
			return asm.FullName;
		}
	}
}

