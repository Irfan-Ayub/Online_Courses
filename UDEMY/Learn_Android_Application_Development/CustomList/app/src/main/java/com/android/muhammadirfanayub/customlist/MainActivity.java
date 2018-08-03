package com.android.muhammadirfanayub.customlist;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ListView lvProducts;
    ArrayList<Product> list;

    Button btnToast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

<<<<<<< HEAD
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
=======
//        setContentView(R.layout.activity_main);
>>>>>>> 20cdc57774bd852cd65f0b76ff1a42639e3c7786
        btnToast = (Button) findViewById(R.id.btnTaost);
        btnToast.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(MainActivity.this , "Toast is Showing!" , Toast.LENGTH_SHORT).show();

                showToast("My Custom Toast");

            }
        });


        setContentView(R.layout.activity_main);
        lvProducts = (ListView) findViewById(R.id.lvProducts);

        list = new ArrayList<Product>();
        list.add(new Product("Title1" , "Description" , "Screen" , 1234 , true));
        list.add(new Product("Title2" , "Description" , "Laptop" , 1234 , false));
        list.add(new Product("Title3" , "Description" , "Hdd" , 1234 , true));
        list.add(new Product("Title4" , "Description" , "Memory" , 1234 , false));

        ProductAdapter adapter = new ProductAdapter(this, list);

        lvProducts.setAdapter(adapter);


    }

    // used to show a custom taost
    public void showToast(String message)
    {
        View toastView = getLayoutInflater().inflate(R.layout.toast , (ViewGroup) findViewById(R.id.linlay));

        TextView tvToast = (TextView) toastView.findViewById(R.id.tvTaost);
        tvToast.setText(message);

        // Custom Toast
        Toast toast = new Toast(MainActivity.this);
        toast.setDuration(Toast.LENGTH_LONG);
        toast.setView(toastView);
        toast.setGravity(Gravity.BOTTOM|Gravity.FILL_HORIZONTAL , 0 , 0);
        toast.show();

    }
}
