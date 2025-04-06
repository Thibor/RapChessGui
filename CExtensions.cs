﻿using System.Windows.Forms;

namespace RapChessGui
{
	public static class RichTextBoxExtensions
	{

		public static void AddContextMenu(this RichTextBox rtb)
		{
			if (rtb.ContextMenuStrip == null)
			{
				ContextMenuStrip cms = new ContextMenuStrip()
				{
					ShowImageMargin = false
				};

				ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
				tsmiUndo.Click += (sender, e) => rtb.Undo();
				cms.Items.Add(tsmiUndo);

				ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
				tsmiRedo.Click += (sender, e) => rtb.Redo();
				cms.Items.Add(tsmiRedo);

				cms.Items.Add(new ToolStripSeparator());

				ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
				tsmiCut.Click += (sender, e) => rtb.Cut();
				cms.Items.Add(tsmiCut);

				ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
				tsmiCopy.Click += (sender, e) => rtb.Copy();
				cms.Items.Add(tsmiCopy);

				ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
				tsmiPaste.Click += (sender, e) => rtb.Paste();
				cms.Items.Add(tsmiPaste);

				ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
				tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
				cms.Items.Add(tsmiDelete);

				cms.Items.Add(new ToolStripSeparator());

				ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
				tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();
				cms.Items.Add(tsmiSelectAll);

				cms.Opening += (sender, e) =>
				{
					tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
					tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
					tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
					tsmiCopy.Enabled = rtb.SelectionLength > 0;
					tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
					tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
					tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
				};

				rtb.ContextMenuStrip = cms;
			}
		}
	}
}
