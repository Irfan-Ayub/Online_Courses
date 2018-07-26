package com.android.muhammadirfanayub.fragments;

import android.app.FragmentManager;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

import org.w3c.dom.Text;

public class MainActivity extends AppCompatActivity implements  ListFrag.ListItemListener{

    TextView tvDetails;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        tvDetails = (TextView) findViewById(R.id.tvDetails);

        if(findViewById(R.id.layout_default) != null)
        {
            android.support.v4.app.FragmentManager manager = this.getSupportFragmentManager();
            manager.beginTransaction()
                    .hide(manager.findFragmentById(R.id.detailsFrag))
                    .show(manager.findFragmentById(R.id.listFrag))
                    .commit();
        }

        if(findViewById(R.id.layout_land) != null)
        {
            android.support.v4.app.FragmentManager manager = this.getSupportFragmentManager();
            manager.beginTransaction()
                    .show(manager.findFragmentById(R.id.layout_land))
                    .show(manager.findFragmentById(R.id.layout_default))
                    .commit();
        }
    }

    @Override
    public void OnItemSelected(int index) {

        if(findViewById(R.id.layout_default) != null)
        {
            android.support.v4.app.FragmentManager manager = this.getSupportFragmentManager();
            manager.beginTransaction()
                    .hide(manager.findFragmentById(R.id.listFrag))
                    .show(manager.findFragmentById(R.id.detailsFrag))
                    .addToBackStack(null)
                    .commit();
        }

        String[] descriptions = getResources().getStringArray(R.array.descriptions);
        tvDetails.setText(descriptions[index]);

    }
}
