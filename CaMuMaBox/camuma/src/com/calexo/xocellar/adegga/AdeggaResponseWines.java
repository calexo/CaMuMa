package com.calexo.xocellar.adegga;

import java.util.List;

import com.google.gson.annotations.SerializedName;

public class AdeggaResponseWines {
	@SerializedName("count")
	public Integer count;
	
	public List<AdeggaResponseWinesWine> wine;
}
