using System;
using System.Collections.Generic;
using NSUci;

namespace RapChessGui
{

	class COption
	{
		public string name = "";
		public string type = "";
		public string def = "";
		public string min = "";
		public string max = "";

		public string Text()
		{
			return CData.TextBeauty(name);
		}
	}

	class COptionList : List<COption>
	{
		readonly CUci uci = new CUci();

		public COption GetOption(string name)
		{
			foreach (COption o in this)
				if (o.name == name)
					return o;
			return null;
		}

		public void Add(string msg)
		{
			uci.SetMsg(msg);
			if (uci.command == "option")
			{
				COption op = new COption();
				op.name = uci.GetValue("name", "type");
				if (GetOption(op.name) == null)
				{
					uci.GetValue("type", out op.type);
					uci.GetValue("default", out op.def);
					uci.GetValue("min", out op.min);
					uci.GetValue("max", out op.max);
					Add(op);
				}
			}
		}

		public void SortTypeName()
		{
			Sort(delegate (COption o1, COption o2)
			{
				return String.Compare($"{o1.type} {o1.name}", $"{o2.type} {o2.name}");
			});
		}

	}
}
