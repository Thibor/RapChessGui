using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace RapLog
{
	public class CRapLog
	{
		public bool enabled = true;
		public bool addDate = true;
		public int max = 100;
		public string path;

		public CRapLog(bool enabled)
		{
			this.enabled = enabled;
			SetPath();
		}

		public CRapLog(string path = "",int max = 100,bool addDate = true)
		{
			this.max = max;
			this.addDate = addDate;
			SetPath(path);
		}

		void SetPath(string p = "")
		{
			path = p;
			if (String.IsNullOrEmpty(path))
			{
				string name = Assembly.GetExecutingAssembly().GetName().Name + ".log";
				path = new FileInfo(name).FullName.ToString();
			}
		}

		public void Add(string m)
		{
			if (!enabled)
				return;
			List<string> list = List();
			if (addDate)
				list.Insert(0, $"{DateTime.Now} {m}");
			else
				list.Add(m);
			int count = list.Count - max;
			if ((count > 0) && (max > 0))
				list.RemoveRange(max, count);
			File.WriteAllLines(path, list);
		}

		public void Add(bool v)
		{
			Add(v.ToString());
		}

		public void Add(int v)
		{
			Add(v.ToString());
		}

		public void Add(double v)
		{
			Add(v.ToString());
		}

		public List<string> List()
		{
			List<string> list = new List<string>();
			if (File.Exists(path))
				list = File.ReadAllLines(path).ToList();
			return list;
		}

	}
}
