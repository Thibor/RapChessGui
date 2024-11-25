using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace RapChessGui
{
	public class CEco
	{
		public string eco;
		public string name;
		public string moves;
		public string fen;
		public string continuations;
	}

	class CEcoList
	{
		public List<CEco> list = new List<CEco>();
		readonly string path = $@"{AppDomain.CurrentDomain.BaseDirectory}Books\Eco.tsv";

		public CEcoList()
		{
			LoadFromFile(path);
		}

		void LoadFromFile(string path)
		{
			list.Clear();
			if (File.Exists(path))
			{
				String[] content = File.ReadAllLines(path);
				for (int n = 1; n < content.Length; n++)
				{
					List<string> r = content[n].Split('\t').ToList();
					CEco eco = new CEco();
					eco.eco = r[0];
					eco.name = r[1];
					eco.moves = r[2];
					eco.fen = r[3];
					eco.continuations = r[4];
					list.Add(eco);
				}
			}
		}

		public CEco EpdToEco(string fen)
		{
			foreach (CEco e in list)
				if (e.fen == fen)
					return e;
			return null;
		}

		public CEco MovesToEco(string moves)
		{
			foreach (CEco e in list)
				if(e.moves.IndexOf(moves) == 0)
					return e;
			return null;
		}

		public void SaveToUci()
		{
			string path = $@"{AppDomain.CurrentDomain.BaseDirectory}Books\eco.uci";
			List<string> moves = new List<string>();
			foreach (CEco eco in list)
				moves.Add(eco.moves);
			File.WriteAllLines(path, moves);
		}

		public void SaveToFile(string path)
		{
			List<string> moves = new List<string>
			{
				$"eco\tname\tmoves\tfen\tcontinuations"
			};
			foreach (CEco eco in list)
				moves.Add($"{eco.eco}\t{eco.name}\t{eco.moves}\t{eco.fen}\t{eco.continuations}");
			File.WriteAllLines(path, moves);
		}

	}
}
