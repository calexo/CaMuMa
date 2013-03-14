package com.calexo.xocellar;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.WindowManager;
import android.widget.ListView;
import android.widget.TextView;

import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.Extra;
import com.googlecode.androidannotations.annotations.ItemClick;
import com.googlecode.androidannotations.annotations.SystemService;
import com.googlecode.androidannotations.annotations.UiThread;
import com.googlecode.androidannotations.annotations.ViewById;


@EActivity(R.layout.activity_wine_choose_region)
public class WineChooseRegionActivity extends BaseActivity {
	
	@Extra(EXTRA_PARCEL_WINE)
	public XoWine wine;
	
	//public static String WINE="com.calexo.xocellar.wine";
	@ViewById(R.id.txtWine)
	TextView txtWine;

	@ViewById(R.id.lstRegions)
	ListView lstRegions;
	
	//@ViewById(R.id.progressBar);
	//ProgressBar progressBar;
	
	@SystemService
    WindowManager windowManager;
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        /*Bundle extras = getIntent().getExtras();
        wine = extras.getParcelable(EXTRA_PARCEL_WINE);*/
        
        int wColor = wine.getColor();
        
        /*Context context = getApplicationContext();
        CharSequence text = XoWine.COLORS[ wColor ];
        int duration = Toast.LENGTH_SHORT;
        Toast toast = Toast.makeText(context, text, duration);
        toast.show();*/
        toast(XoWine.COLORS[ wColor ]);
        
        getActionBar().setDisplayHomeAsUpEnabled(true);
        
        updateUi();
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
    
    @UiThread
    void updateUi() {
        //setProgressBarIndeterminateVisibility(true);
        //setProgressBarVisibility(true);
        //setProgress(3/10*10000);
    	//progressBar.setIndeterminate(false);
    	
        txtWine.setText(XoWine.COLORS[ wine.getColor() ]);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //getMenuInflater().inflate(R.menu.activity_wine_choose_region, menu);
        return true;
    }
    
    @ItemClick
    void lstRegionsItemClicked(String region) {
    	nextStep(region);
    }
    
	private void nextStep(String region) {
		
		//XoWine wine = new XoWine();
		wine.setRegion(region);
		Intent intent = new Intent(this, WineChooseYearActivity_.class);

        intent.putExtra(EXTRA_PARCEL_WINE, wine);

        startActivity(intent);

	}
}
