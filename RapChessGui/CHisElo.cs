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

		public int EloAvg(int def = 0)
		{
			int sum = 0;
			foreach (int d in this)
				sum += d;
			return Count == 0 ? def : sum / Count;
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

		public void LoadFromStr(string elo)
		{
			Clear();
			string[] his = elo.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string e in his)
				AddValue(Convert.ToInt32(e));
		}

		public string SaveToStr()
		{
			string elo = String.Empty;
			for (int n = 0; n < Count; n++)
			{
				int d = this[n];
				if (d < CElo.eloMin)
					d = CElo.eloMin;
				if (d > CElo.eloMax)
					d = CElo.eloMax;
				this[n] = d;
				elo += $" {d}";
			}
			return elo.Trim();
		}

		public void AddValue(int value)
		{
			Add(value);
			int c = Count - FormOptions.historyLength;
			if (c > 0)
				RemoveRange(0, c);
		}

		public int Last()
		{
			if (Count < 1)
				return Global.elo;
			return this[Count - 1];
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
