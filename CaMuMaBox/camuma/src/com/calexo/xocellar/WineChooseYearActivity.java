package com.calexo.xocellar;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;
import android.widget.Toast;

import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.Extra;
import com.googlecode.androidannotations.annotations.UiThread;
import com.googlecode.androidannotations.annotations.ViewById;

@EActivity(R.layout.activity_wine_choose_year)
public class WineChooseYearActivity extends BaseActivity {
	
	@Extra(EXTRA_PARCEL_WINE)
	public XoWine wine;
	
	@ViewById(R.id.txtWine)
	public TextView txtWine;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        getActionBar().setDisplayHomeAsUpEnabled(true);
        
        Context context = getApplicationContext();
        CharSequence text = wine.getRegion();
        int duration = Toast.LENGTH_SHORT;
        Toast toast = Toast.makeText(context, text, duration);
        toast.show();
        
        updateUi();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //getMenuInflater().inflate(R.menu.activity_wine_choose_year, menu);
        return true;
    }
    
    @UiThread
    void updateUi() {
        txtWine.setText(XoWine.COLORS[ wine.getColor() ] + " / " + wine.getRegion());
    }
    
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
            	Intent intent = new Intent(this, MainActivity_.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(intent);
                return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
