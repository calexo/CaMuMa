package com.calexo.xocellar;

import android.app.Activity;
import android.content.Context;
import android.widget.Toast;

import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.Extra;

@EActivity
public class BaseActivity extends Activity {

	public static final String EXTRA_PARCEL_WINE="com.calexo.xocellar.wine";
	public static final String EXTRA_SEARCH_STRING="com.calexo.xocellar.searchstring";
	public static final String EXTRA_COME_FROM="com.calexo.xocellar.comefrom";
	

	public static final String ACTION_ADDING_WINE = "action_adding_wine";
	
	private String currentAction;
	
	@Extra
	public String ACTION;

	public void toast(String msg)
	{
        Context context = getApplicationContext();
        int duration = Toast.LENGTH_SHORT;
        Toast toast = Toast.makeText(context, msg, duration);
        toast.show();
	}
	
	public String getCurrentAction() {
		return currentAction;
	}


	public void setCurrentAction(String currentAction) {
		this.currentAction = currentAction;
	}
	
}
