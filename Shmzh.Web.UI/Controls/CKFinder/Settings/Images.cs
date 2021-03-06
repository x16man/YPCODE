/*
 * CKFinder
 * ========
 * http://www.ckfinder.com
 * Copyright (C) 2007-2008 Frederico Caldeira Knabben (FredCK.com)
 *
 * The software, this file and its contents are subject to the CKFinder
 * License. Please read the license.txt file before using, installing, copying,
 * modifying or distribute this file or part of its contents. The contents of
 * this file is part of the Source Code of CKFinder.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Web.UI.Controls.CKFinder.Settings
{
	public class Images
	{
		public int MaxWidth;
		public int MaxHeight;
		public int Quality;

		public Images()
		{
			MaxWidth = 1600;
			MaxHeight = 1200;
			Quality = 80;
		}
	}
}
