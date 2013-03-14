package com.calexo.xocellar;



import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

import com.googlecode.androidannotations.annotations.Click;
import com.googlecode.androidannotations.annotations.EActivity;

@EActivity(R.layout.activity_wine_choose_color)
public class WineChooseColorActivity extends BaseActivity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_wine_choose_color);
        getActionBar().setDisplayHomeAsUpEnabled(true);
    }
    

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //getMenuInflater().inflate(R.menu.activity_wine_choose_color, menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                //NavUtils.navigateUpFromSameTask(this);
            	Intent intent = new Intent(this, MainActivity_.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(intent);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }
    
    @Click
    public void btn_add_rouge() {
    	nextStep(XoWine.COLOR_ROUGE);
    }
    @Click
    public void btn_add_blanc() {
    	nextStep(XoWine.COLOR_BLANC);
    }
    @Click
    public void btn_add_rose() {
    	nextStep(XoWine.COLOR_ROSE);
    }
    @Click
    public void btn_add_effervescent() {
    	nextStep(XoWine.COLOR_EFFERVESCENT);
    }
    @Click
    public void btn_add_autre() {
    	nextStep(XoWine.COLOR_AUTRE);
    }


	private void nextStep(int color) {
		
		XoWine wine = new XoWine();
		wine.setColor(color);
		Intent intent = new Intent(this, WineChooseRegionActivity_.class);

        intent.putExtra(EXTRA_PARCEL_WINE, wine);

        startActivity(intent);

	}
    
    
}
