package com.calexo.xocellar;

import android.os.Parcel;
import android.os.Parcelable;

import com.calexo.xocellar.adegga.*;

public class XoWine
implements  Parcelable, Cloneable
{
	
	public static final int COLOR_AUTRE=0;
	public static final int COLOR_ROUGE=1;
	public static final int COLOR_BLANC=2;
	public static final int COLOR_ROSE=3;
	public static final int COLOR_EFFERVESCENT=4;
	public static final int COLOR_FORTIFIE=5;
	public static final int COLOR_DOUX=6;
	
	
	public static String[] COLORS={"Autre", "Rouge", "Blanc", "Rosé", "Effervescent", "Fortifié", "Doux"};

	private String name;
	private String appellation;
	private Integer color;
	private String country;
	private String region;
	private Integer year;
	private String producer;

	
	public static final Parcelable.Creator<XoWine> CREATOR = new Parcelable.Creator<XoWine>() {


		
	/**
	 * It will be required during un-marshaling data stored in a Parcel
	 * @author calexo
	 */
	//public class MyCreator implements Parcelable.Creator<xoWine> {
	      public XoWine createFromParcel(Parcel source) {
	            return new XoWine(source);
	      }
	      public XoWine[] newArray(int size) {
	            return new XoWine[size];
	      }
	};
	
	public XoWine(Parcel source){
		/*
         * Reconstruct from the Parcel
         */
		name = source.readString();
		appellation = source.readString();
        color = source.readInt();
        country = source.readString();
        region = source.readString();
        year = source.readInt();
        producer = source.readString();
	}
	
	public XoWine() {
		
	}
	
	public XoWine(AdeggaResponseWinesWine pWine) {
		this.name = pWine.name;
		this.color = pWine.type_id;
		if (this.color>6) this.color=0;
		this.appellation = pWine.name;
		this.country = pWine.country;
		this.producer = pWine.producer;
		this.region = pWine.region;
		if (pWine.vintage.equals("NV"))
			this.year=null;
		else
			this.year = Integer.valueOf(pWine.vintage);
	}

	public XoWine(String name, Integer color, String country, String region, String producer, Integer year)
	{
		this.name = name;
		this.color = color;
		if (this.color>6) this.color=0;
		this.appellation = name;
		this.country = country;
		this.producer = producer;
		this.region = region;
		this.year = year;
	}
	
	public XoWine clone() {
		XoWine o = null;
		try {
			// On récupère l'instance à renvoyer par l'appel de la 
			// méthode super.clone()
			o = (XoWine) super.clone();
		} catch(CloneNotSupportedException cnse) {
			// Ne devrait jamais arriver car nous implémentons 
			// l'interface Cloneable
			cnse.printStackTrace(System.err);
		}
		// on renvoie le clone
		return o;
	}

	
	
	public Integer getColor() {
		return color;
	}
	public void setColor(Integer wColor) {
		this.color = wColor;
	}
	public String getRegion() {
		return region;
	}
	public void setRegion(String wRegion) {
		this.region = wRegion;
	}
	@Override
	public int describeContents() {
		return 0;
	}
	
	
	@Override
	public void writeToParcel(Parcel out, int flags) {
		out.writeString(name);
		out.writeString(appellation);
		if (color!=null) out.writeInt(color);
		else out.writeInt(0);
		out.writeString(country);
		out.writeString(region);
		if (year!=null) out.writeInt(year);
		else out.writeInt(0);
		out.writeString(producer);
	}

	public Integer getYear() {
		return year;
	}

	public void setYear(Integer year) {
		this.year = year;
	}

	public String getCountry() {
		return country;
	}

	public void setCountry(String country) {
		this.country = country;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getAppellation() {
		return appellation;
	}

	public void setAppellation(String appellation) {
		this.appellation = appellation;
	}

	public String getProducer() {
		return producer;
	}

	public void setProducer(String producer) {
		this.producer = producer;
	}

}
