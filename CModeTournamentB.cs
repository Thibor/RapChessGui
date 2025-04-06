using System.Collections.Generic;

namespace RapChessGui
{

	public class CModeTournamentB:CModeTournament
	{
		public static CTourList tourList = new CTourList("books");
		public static CListBook bookList = new CListBook();
		public static CBook bookWin = null;
		public static CBook bookLoose = null;

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

		public void ListFill()
		{
			CBook book = FormChess.bookList.GetBookByName(FormChess.formOptions.cbTourBSelected.Text);
			int avg = book == null ? (int)FormChess.formOptions.nudTourBAvg.Value : book.Elo;
			int range = (int)FormChess.formOptions.nudTourBRange.Value;
			int eloMin = range == 0 ? 0 : avg - range;
			int eloMax = range == 0 ? CElo.eloTotal : avg + range;
			bookList.Clear();
			foreach (CBook b in FormChess.bookList)
				if (b.IsPlayable() && (b.tournament > 0))
					if ((b.Elo >= eloMin) && (b.Elo <= eloMax))
						bookList.AddBook(b);
		}

		public CBook SelectFirst()
		{
			ListFill();
			CBook book = bookList.GetBookByName(FormChess.formOptions.cbTourBSelected.Text);
			if ((book != null) && (FormChess.formOptions.nudTourBRange.Value == 0))
				return book;
			book = bookList.GetBookByName(first);
			if ((book == null) || ((left < 1) && (reps > 0)))
			{
				book = SelectLast();
				reps = 0;
			}
			return book;
		}

		public CBook SelectSecond(CBook book)
		{
			if (book == null)
				return null;
			first = opponent = book.name;
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
				double curScore = book.EvaluateOpponent(b, bookList.Count, tourList);
				if (bstScore < curScore)
				{
					bstScore = curScore;
					bstBook = b;
				}

			}
			opponent = bstBook.name;
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

		public void SetRepeition(CBook b, CBook o)
		{
			if ((first != b.name) || (opponent != o.name))
			{
				first = b.name;
				opponent = o.name;
				int cg = tourList.CountGames(b.name, o.name, out int rw, out int rl, out _);
				if (reps == 0)
				{
					left = b.tournament;
					if (cg == 0)
						left++;
					if ((b.Elo > o.Elo) != (rw > rl))
						left++;
					if (b.history.Count < o.history.Count)
						left += 2;
					rotate = true;
				}
			}
			reps++;
			if (left > 0)
				left--;
			rotate ^= true;
		}

	}
}
