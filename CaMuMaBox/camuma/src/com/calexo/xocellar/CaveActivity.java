package com.calexo.xocellar;

import java.util.ArrayList;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListView;
import android.widget.ProgressBar;

import com.googlecode.androidannotations.annotations.AfterViews;
import com.googlecode.androidannotations.annotations.Background;
import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.ItemClick;
import com.googlecode.androidannotations.annotations.UiThread;
import com.googlecode.androidannotations.annotations.ViewById;


@EActivity(R.layout.activity_cave)
public class CaveActivity extends BaseActivity {
	
	XoWineAdapter arrayAdapter;
	ArrayList<XoWine> xoWines;
	
	@ViewById(R.id.pbCave)
	ProgressBar pbCave;
	
	@ViewById(R.id.lvCave)
	ListView lvCave;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActionBar().setDisplayHomeAsUpEnabled(true);
        
        xoWines = new ArrayList<XoWine>();
        //xoWines=XoCellarClientLocal.getWines();
        load();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_cave, menu);
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

    @AfterViews
    void initList()
    {
    	arrayAdapter = new XoWineAdapter(CaveActivity.this, R.layout.listitems,xoWines);
    	lvCave.setAdapter(arrayAdapter);
    }

    @Background
    void load()
    {
    	//xoWines=XoCellarClientLocal.getWines();
    	xoWines.addAll( XoCellarClientLocal.getWines() );
    	loaded();
    }
    
    
    @UiThread
    public void loaded() {
    	pbCave.setVisibility( View.GONE );
    	arrayAdapter.notifyDataSetChanged();
    }
    
    @ItemClick
    void lvCaveItemClicked(XoWine wine) {
    	Intent intent = new Intent(this, FicheActivity_.class);
    	intent.putExtra(EXTRA_PARCEL_WINE, wine);
    	
    	//toast(wine.getName());
    	
        startActivity(intent);
    }

}
