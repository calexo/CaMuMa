package com.calexo.xocellar;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageView;
import android.widget.TextView;

import com.googlecode.androidannotations.annotations.Click;
import com.googlecode.androidannotations.annotations.EActivity;
import com.googlecode.androidannotations.annotations.Extra;
import com.googlecode.androidannotations.annotations.UiThread;
import com.googlecode.androidannotations.annotations.ViewById;

@EActivity(R.layout.activity_fiche)
public class FicheActivity extends BaseActivity {
	
	@Extra(EXTRA_PARCEL_WINE)
	public XoWine wine;
	
	@ViewById(R.id.tvWine)
	TextView tvWine;
	@ViewById(R.id.imgFicheColor)
	ImageView imgFicheColor;
	@ViewById(R.id.imgFicheEtiquette)
	ImageView imgFicheEtiquette;
	@ViewById(R.id.tvFicheMultiDesc)
	TextView tvFicheMultiDesc;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        getActionBar().setDisplayHomeAsUpEnabled(true);
        
        Bundle extras = getIntent().getExtras();
        wine = extras.getParcelable(EXTRA_PARCEL_WINE);
        
        toast(wine.getName());
        
        updateUI();
        
        
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_fiche, menu);
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
            case R.id.menu_fiche_add:
            	toast("Ajoute le vin à la cave");
        }
        return super.onOptionsItemSelected(item);
    }
    
    @UiThread
    void updateUI()
    {
    	tvWine.setText(wine.getName() + " - " + wine.getYear());
    	switch (wine.getColor())
    	{
	    	case XoWine.COLOR_ROUGE:
	    		imgFicheColor.setImageResource(R.drawable.rouge);
	    		break;
	       	case XoWine.COLOR_ROSE:
	    		imgFicheColor.setImageResource(R.drawable.rose);
	    		break;
	    	case XoWine.COLOR_BLANC:
	    		imgFicheColor.setImageResource(R.drawable.blanc);
	    		break;
	    	default:
	    		imgFicheColor.setImageResource(R.drawable.nocolor);	
    	}
    	tvFicheMultiDesc.setText("Producteur : " + wine.getProducer()+"\n"+
    			"Pays : " + wine.getCountry() +"\n"+
    			"Région : " + wine.getRegion());
    	//tvFicheMultiDesc.setText("Producteur : " + wine.getProducer());
    }

    @Click
    void imgFicheColor()
    {
    	toast( XoWine.COLORS[ wine.getColor() ] );
    }
}
