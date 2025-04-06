using RapIni;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RapChessGui
{

	public class CHisElo : List<int>
	{

		public void Assign(CHisElo he)
		{
			Clear();
			foreach (int d in he)
				Add(d);
		}

		public int EloAvg()
		{
			int sum = 0;
			foreach (int d in this)
				sum += d;
			return Count == 0 ? Global.elo : sum / Count;
		}

		public int Trend()
		{
			return Last() - EloAvg();
		}

		public int Change()
		{
			if (Count < 3)
				return 0;
			return Last() - Penultimate();
		}

		public Color GetColor()
		{
			double elo = Last();
			MinMax(out int min, out int max);
			double q = (max - min) / 10;
			if (elo > max - q)
				return Colors.listB;
			if (elo < min + q)
				return Colors.listW;
			return Color.White;
		}

		public string ToStr()
		{
            return String.Join(" ", this.ToArray());
        }

		public void FromStr(string s)
		{
			Clear();
			string[] his = s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string e in his)
				Add(Convert.ToInt32(e));
		}

		public void SaveToIni(CRapIni ini,string key)
		{
			ini.Write(key,ToStr());
		}

		public void LoadFromIni(CRapIni ini,string key)
		{
			FromStr(ini.Read(key));
		}

		public void AddVal(int val)
		{
            Add(val);
            int c = Count - FormOptions.historyLength;
            if (c > 0)
                RemoveRange(0, c);
        }

		public void AddElo(int elo)
		{
            if (elo < CElo.eloMin)
                elo = CElo.eloMin;
            if (elo > CElo.eloMax)
                elo = CElo.eloMax;
           AddVal(elo);
		}

		public int Last()
		{
			if (Count < 1)
				return Global.elo;
			return this[Count - 1];
		}

		public int LastElo()
		{
			return (Last() / 50) * 50;
        }

		public double LastPro()
		{
			double last = Last();
			return (last - CElo.eloMin) / CElo.eloRange; 
		}

        public void Win()
        {
            AddElo(LastElo() + 50);
        }

        public void Lost()
        {
            AddElo(LastElo() - 50);
        }

		public void Draw()
		{
			AddElo(Last());
		}

        public int Penultimate()
		{
			if (Count < 2)
				return 0;
			return this[Count - 2];
		}

		public void MinMax(out int min, out int max)
		{
			min = Count > 0 ? this[0] : 0;
			max = min;
			foreach (int d in this)
			{
				if (min > d)
					min = d;
				if (max < d)
					max = d;
			}
		}

		public void MinMaxDel(out int min, out int max)
		{
			int totMin = Count > 0 ? this[0] : 0;
			int totMax = totMin;
			min = 0;
			max = 0;
			for (int n = 1; n < Count; n++)
			{
				int d = this[n];
				if (totMin > d)
					totMin = d;
				if (totMax < d)
					totMax = d;
				int curMin = totMax - d;
				int curMax = d - totMin;
				if (min < curMin)
					min = curMin;
				if (max < curMax)
					max = curMax;
			}
		}

	}
}
