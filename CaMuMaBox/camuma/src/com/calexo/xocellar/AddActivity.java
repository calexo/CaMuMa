package com.calexo.xocellar;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

import com.googlecode.androidannotations.annotations.Click;
import com.googlecode.androidannotations.annotations.EActivity;

@EActivity(R.layout.activity_add)
public class AddActivity extends Activity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_add);
        getActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //getMenuInflater().inflate(R.menu.activity_add, menu);
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
    void btn_add_known() {
    	Intent intent = new Intent(this, CaveActivity_.class);
        startActivity(intent);
    }
    @Click
    void btn_add_new() {
    	Intent intent = new Intent(this, WineChooseColorActivity_.class);
        startActivity(intent);
    }
    
    @Click
    void btn_add_search() {
    	Intent intent = new Intent(this, SearchDbActivity_.class);
        startActivity(intent);
    }

}
