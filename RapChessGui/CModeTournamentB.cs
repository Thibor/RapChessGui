using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{

	static class CModeTournamentB
	{
		public static bool rotate = true;
		public static int games = 0;
		public static int eloAvg = 3000;
		public static int eloRange = 0;
		public static int records = 10000;
		public static int repetition = 0;
		public static string first = String.Empty;
		public static string opponent = String.Empty;
		public static string engine = String.Empty;
		public static CTourList tourList = new CTourList("Tour-books");
		public static CModeValue modeValue = new CModeValue();
		public static CBookList bookList = new CBookList();
		public static CBook bookWin = null;
		public static CBook bookLoose = null;

		public static void SaveToIni()
		{
			FormChess.ini.Write("mode>tournamentB>book", first);
			FormChess.ini.Write("mode>tournamentB>engine", engine);
			FormChess.ini.Write("mode>tournamentB>mode", modeValue.GetLevel());
			FormChess.ini.Write("mode>tournamentB>value", modeValue.value);
			FormChess.ini.Write("mode>tournamentB>records", records);
			FormChess.ini.Write("mode>tournamentB>eloAvg", eloAvg);
			FormChess.ini.Write("mode>tournamentB>eloRange", eloRange);
		}

		public static void LoadFromIni()
		{
			first = FormChess.ini.Read("mode>tournamentB>book", first);
			engine = FormChess.ini.Read("mode>tournamentB>engine", engine);
			modeValue.SetLevel(FormChess.ini.Read("mode>tournamentB>mode", modeValue.GetLevel()));
			modeValue.value = FormChess.ini.ReadInt("mode>tournamentB>value", modeValue.value);
			records = FormChess.ini.ReadInt("mode>tournamentB>records", records);
			eloAvg = FormChess.ini.ReadInt("mode>tournamentB>eloAvg", eloAvg);
			eloRange = FormChess.ini.ReadInt("mode>tournamentB>eloRange", eloRange);
			tourList.SetLimit(records);
		}

		public static CBook ChooseOpponent(CBook book, CBook book1, CBook book2)
		{
			tourList.CountGames(book.name, book1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(book.name, book2.name, out int rw2, out int rl2, out int rd2);
			if ((book.Elo > book1.Elo) != (rw1 > rl1))
				return book1;
			if ((book.Elo > book2.Elo) != (rw2 > rl2))
				return book2;
			int count1 = (rw1 + rl1 + rd1);
			int count2 = (rw2 + rl2 + rd2);
			if (count1 * 1.1 <= count2 << 1)
				return book1;
			if (count2 * 1.1 <= count1 >> 1)
				return book2;
			return null;
		}

		public static void ListFill()
		{
			int avg = eloAvg;
			CBook book = FormChess.bookList.GetBookByName(FormOptions.tourBSelected);
			if (book != null)
				avg = book.Elo;
			int eloMin = avg - eloRange;
			int eloMax = avg + eloRange;
			if ((eloRange == 0) || (eloAvg == 0))
				if (eloAvg > 0)
				{
					eloMin = avg - eloAvg;
					eloMax = avg + eloAvg;
				}
				else
				{
					eloMin = 0;
					eloMax = 3000;
				}
			bookList.Clear();
			foreach (CBook b in FormChess.bookList)
				if (b.IsPlayable() && (b.tournament > 0))
					if ((b.Elo >= eloMin) && (b.Elo <= eloMax))
						bookList.AddBook(b);
		}

		public static void NewGame()
		{
			rotate = true;
			games = 0;
			repetition = 0;
			opponent = String.Empty;
		}

		public static CBook SelectFirst()
		{
			ListFill();
			CBook b = bookList.GetBookByName(FormOptions.tourBSelected);
			if ((b != null) && (eloRange == 0))
				return b;
			b = bookList.GetBookByName(first);
			if ((b == null) || ((games >= repetition) && (games > 0)))
			{
				b = SelectLast();
				games = 0;
			}
			return b;
		}

		public static CBook SelectSecond(CBook book)
		{
			bookList.SortPosition(book);
			List<CBook> bl = new List<CBook>();
			foreach (CBook b in bookList)
				if (b != book)
					bl.Add(b);
			if (bl.Count == 0)
				return book;
			double bstScore = 0.0;
			CBook bstBook = book;
			for (int n = 0; n < bl.Count - 1; n++)
			{
				CBook b = bl[n];
				double curScore = book.EvaluateOpponent(b,bookList.Count,tourList);
				if (bstScore < curScore)
				{
					bstScore = curScore;
					bstBook = b;
				}

			}
			return bstBook;
		}

		public static CBook SelectLast()
		{
			int count = 0;
			CBook result = null;
			foreach (CBook b in bookList)
			{
				int c = tourList.LastGame(b.name);
				if (count <= c)
				{
					count = c;
					result = b;
				}
			}
			return result;
		}

		public static void SetRepeition(CBook b, CBook o)
		{
			if ((first != b.name) || (opponent != o.name))
			{
				first = b.name;
				opponent = o.name;
				SaveToIni();
				int cg = tourList.CountGames(b.name, o.name, out int rw, out int rl, out _);
				if (games == 0)
				{
					repetition = b.tournament;
					if (cg == 0)
						repetition++;
					if ((b.Elo > o.Elo) != (rw > rl))
						repetition++;
					if (b.hisElo.Count < o.hisElo.Count)
						repetition += 2;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}

	}
}
