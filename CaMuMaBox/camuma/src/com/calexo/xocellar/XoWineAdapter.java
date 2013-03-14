package com.calexo.xocellar;

import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

public class XoWineAdapter extends ArrayAdapter<XoWine> {
	
	int resource;
	String response;
	Context context;

	public XoWineAdapter(Context context, int resource, List<XoWine> items) {
		super(context, resource, items);
		this.resource=resource;
	}

	@Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        LinearLayout xoWineView;
        //Get the current alert object
        XoWine w = getItem(position);
         
        //Inflate the view
        if(convertView==null)
        {
        	xoWineView = new LinearLayout(getContext());
            String inflater = Context.LAYOUT_INFLATER_SERVICE;
            LayoutInflater vi;
            vi = (LayoutInflater)getContext().getSystemService(inflater);
            vi.inflate(resource, xoWineView, true);
        }
        else
        {
        	xoWineView = (LinearLayout) convertView;
        }
        //Get the text boxes from the listitem.xml file
        TextView wineText =(TextView)xoWineView.findViewById(R.id.txtWineText);
        TextView wineType =(TextView)xoWineView.findViewById(R.id.txtWineType);
        ImageView reslist_color_img = (ImageView)xoWineView.findViewById(R.id.reslist_color_img);
        
         
        //Assign the appropriate data from our alert object above
        if (w.getYear()!=null)
        	wineText.setText(w.getName() + " - " + w.getYear());
        else
        	wineText.setText(w.getName());
        wineType.setText(XoWine.COLORS[w.getColor()]);
        switch (w.getColor())
        {
	        case XoWine.COLOR_ROUGE:
	        	reslist_color_img.setImageResource(R.drawable.rouge);
	        	break;
	        case XoWine.COLOR_BLANC:
	        	reslist_color_img.setImageResource(R.drawable.blanc);
	        	break;
	        case XoWine.COLOR_ROSE:
	        	reslist_color_img.setImageResource(R.drawable.rose);
	        	break;
	        default:
	        	reslist_color_img.setImageResource(R.drawable.nocolor);
	        	break;
	        		
        }
         
        return xoWineView;
    }
}
