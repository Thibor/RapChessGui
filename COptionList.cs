using System;
using System.Collections.Generic;
using NSUci;

namespace RapChessGui
{

    class COption
    {
        readonly CUci uci = new CUci();

        public COption(string msg)
        {
            uci.SetMsg(msg);
        }

        public string Text()
        {
            return CData.TextBeauty(Name);
        }

        public bool Option
        {
            get
            {
                return uci.command == "option";
            }
        }

        public string Name
        {
            get
            {
                return uci.GetValue("name", "type");
            }
        }

        public string Type
        {
            get
            {
                return uci.GetStr("type");
            }
        }

        public string Default
        {
            get
            {
                if (Type == "string")
                    return uci.GetValue("default");
                else
                    return uci.GetStr("default");
            }
        }

        public string Min
        {
            get
            {
                return uci.GetStr("min");
            }
        }

        public string Max
        {
            get
            {
                return uci.GetStr("max");
            }
        }

        public List<string> Combo
        {
            get
            {
                List<string> list = new List<string>();
                for (int n = 7; n < uci.tokens.Length - 1; n++)
                    if (uci.tokens[n] == "var")
                        list.Add(uci.GetValue(n + 1, n + 1));
                return list;
            }
        }
    }

    class COptionList : List<COption>
    {

        public COption GetOption(string name)
        {
            foreach (COption o in this)
                if (o.Name == name)
                    return o;
            return null;
        }

        public void Add(string msg)
        {
            COption op = new COption(msg);
            if (op.Option && GetOption(op.Name) == null)
                Add(op);
        }

        public void SortTypeName()
        {
            Sort(delegate (COption o1, COption o2)
            {
                return String.Compare($"{o1.Type} {o1.Name}", $"{o2.Type} {o2.Name}");
            });
        }

    }
}
