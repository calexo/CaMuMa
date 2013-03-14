package com.calexo.xocellar;

import android.content.Intent;
import android.view.Menu;
import android.widget.Button;

import com.googlecode.androidannotations.annotations.Click;
import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.ViewById;

@EActivity(R.layout.activity_main)
public class MainActivity extends BaseActivity {
	
	@ViewById(R.id.btn_home_add)
	Button btnHomeAdd;

    /*@Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }*/

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_main, menu);
        return true;
    }
	
	
	@Click
	void btn_home_add() {
		Intent intent = new Intent(getApplicationContext(), AddActivity_.class);
	    //intent.setFlags (Intent.FLAG_ACTIVITY_CLEAR_TOP);
	    startActivity(intent);
	}
	
	@Click
	void btn_home_search() {
		Intent intent = new Intent(getApplicationContext(), SearchActivity_.class);
	    //intent.setFlags (Intent.FLAG_ACTIVITY_CLEAR_TOP);
	    startActivity(intent);
	}
	
	@Click
	void btn_home_cave() {
		Intent intent = new Intent(getApplicationContext(), CaveActivity_.class);
	    //intent.setFlags (Intent.FLAG_ACTIVITY_CLEAR_TOP);
	    startActivity(intent);
	}
	
	@Click
	void btn_home_drink() {
		Intent intent = new Intent(getApplicationContext(), SearchActivity_.class);
	    //intent.setFlags (Intent.FLAG_ACTIVITY_CLEAR_TOP);
	    startActivity(intent);
	}
}
