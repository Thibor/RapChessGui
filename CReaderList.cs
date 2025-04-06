using System;
using System.Collections.Generic;
using System.IO;
using RapIni;

namespace RapChessGui
{
	public class CReader
	{
		public string dir = String.Empty;
		public string bookReader = Global.none;
	}

	public class CReaderList : List<CReader>
	{
		public static CRapIni iniFile = new CRapIni(@"Ini\readers.ini");

		public void LoadFromIni()
		{
			Clear();
			bool reset = true;
			string[] dirs = Directory.GetDirectories("Books");
			foreach (string dir in dirs)
			{
				CReader db = new CReader();
				db.dir = Path.GetFileName(dir);
				db.bookReader = iniFile.Read(db.dir);
				Add(db);
				if (db.bookReader != String.Empty)
					reset = false;
			}
			if (reset)
			{
				reset = false;
				foreach (CReader r in this)
					foreach (string fr in CData.fileBookReader)
					{
						string ld = r.dir.ToLower();
						string lf = fr.ToLower();
						int li = lf.LastIndexOf(ld);
						if (li == lf.Length - ld.Length - 4)
						{
							reset = true;
							r.bookReader = fr;
							break;
						}
					}
				if (reset)
					SaveToIni();
			}
		}

		public void SaveToIni()
		{
			iniFile.Clear();
			foreach (CReader db in this)
				iniFile.Write(db.dir, db.bookReader);
			iniFile.Save();
		}

	}
}
