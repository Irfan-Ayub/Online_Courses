package com.android.muhammadirfanayub.fragments;


import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.ListFragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.net.InterfaceAddress;


/**
 * A simple {@link Fragment} subclass.
 */
public class ListFrag extends ListFragment {


    ListItemListener listItemListener;
    public ListFrag() {
        // Required empty public constructor
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new ArrayAdapter<String>(this.getActivity() , android.R.layout.simple_list_item_1,
                                                getResources().getStringArray(R.array.items)));


        if(this.getActivity().findViewById(R.id.layout_default) == null)
        {
            listItemListener.OnItemSelected(0);
        }
    }

    public interface ListItemListener
    {
        public void OnItemSelected(int index);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);

        try
        {
            listItemListener = (ListItemListener) context;
        }
        catch(ClassCastException e)
        {
            throw new ClassCastException(context.toString() + " must implement interface called " +
                    "ListItemListener!");
        }
    }

    @Override
    public void onListItemClick(ListView l, View v, int position, long id) {
        listItemListener.OnItemSelected(position);
    }
}
