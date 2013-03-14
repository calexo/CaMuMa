package com.calexo.xocellar;

import java.util.ArrayList;

import org.springframework.http.ResponseEntity;
import org.springframework.http.converter.json.GsonHttpMessageConverter;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ProgressBar;

import com.calexo.xocellar.adegga.AdeggaResponse;
import com.calexo.xocellar.adegga.AdeggaResponseWinesWine;
import com.calexo.xocellar.adegga.AdeggaRest;
import com.googlecode.androidannotations.annotations.AfterViews;
import com.googlecode.androidannotations.annotations.Background;
import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.Extra;
import com.googlecode.androidannotations.annotations.ItemClick;
import com.googlecode.androidannotations.annotations.UiThread;
import com.googlecode.androidannotations.annotations.ViewById;
import com.googlecode.androidannotations.annotations.rest.RestService;


@EActivity(R.layout.activity_search_db_res)
public class SearchDbResultActivity extends BaseActivity {
	
	@RestService
    AdeggaRest restClient;
	
	@ViewById(R.id.resRest)
	EditText resRest;
	
	@ViewById(R.id.pbSearchDbRes)
	ProgressBar pbSearchDbRes;
	
	@ViewById(R.id.lvSearchDbRes)
	ListView lvSearchDbRes;

	@Extra(BaseActivity.EXTRA_SEARCH_STRING)
	public String searchString;
	
	XoWineAdapter arrayAdapter;
	ArrayList<XoWine> xoWines;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        /*Bundle extras = getIntent().getExtras();
        searchString = extras.getString(EXTRA_SEARCH_STRING);*/
        
        xoWines = new ArrayList<XoWine>();
		
        getActionBar().setDisplayHomeAsUpEnabled(true);
        
        search();
    }
    
    @AfterViews
    void initList()
    {
    	arrayAdapter = new XoWineAdapter(SearchDbResultActivity.this, R.layout.listitems,xoWines);
    	lvSearchDbRes.setAdapter(arrayAdapter);
    }
	


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //getMenuInflater().inflate(R.menu.activity_search_db_result, menu);
        return true;
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
    
    @Background
    public void search() {

    	
    	updateResRest("Go");
    	restClient.getRestTemplate().getMessageConverters().add(new GsonHttpMessageConverter());
 
    	ResponseEntity<AdeggaResponse> wines = restClient.getWines(searchString);
    	
    	
    	String     	res;

    	if (wines.hasBody())
    	{
    		res= "stat:"+wines.getBody().response.stat;
    		res+=" - Count = " + wines.getBody().response.aml.wines.count;
    		for (AdeggaResponseWinesWine w : wines.getBody().response.aml.wines.wine) {
    			xoWines.add(new XoWine(w));
    		}
    		
    	}
    	else
    	{
    		res="KO";
    	}

    	updateResRest(res,true);
    }
    
    @UiThread
    public void updateResRest(String res, boolean hide) {
    	resRest.setText(res);
    	if (hide) pbSearchDbRes.setVisibility( View.GONE );
    	arrayAdapter.notifyDataSetChanged();
    	
    }
    @UiThread
    public void updateResRest(String res) {
    	updateResRest(res,false);
    	
    }
    
    @ItemClick
    void lvSearchDbResItemClicked(XoWine wine) {
    	Intent intent = new Intent(this, FicheActivity_.class);
    	intent.putExtra(EXTRA_PARCEL_WINE, wine);
    	
    	//toast(wine.getName());
    	
        startActivity(intent);
    }
    

}
