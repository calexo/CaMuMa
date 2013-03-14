package com.calexo.xocellar;

import java.util.ArrayList;

public class XoCellarClientLocal {
	
	public static ArrayList<XoWine> getWines()
	{
		ArrayList<XoWine> wines = new ArrayList<XoWine>();
		//XoWine wine = new XoWine();
		
		
		wines.add( new XoWine("Miss Vicky Wine in Provence",
				XoWine.COLOR_ROSE,
				"France",
				"Provence",
				"",
				2010) );
		
		wines.add(new XoWine("Miss Vicky Wine Fleurie",
				XoWine.COLOR_ROUGE,
				"France",
				"Provence",
				"",
				2007));
		
		wines.add(new XoWine("Roussette de Savoie",
				XoWine.COLOR_BLANC,
				"France",
				"Savoie",
				"Saint Germain",
				2007));
		
		return wines;
		
	}

}
