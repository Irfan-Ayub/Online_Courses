package com.android.muhammadirfanayub.explicitintents;

import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class ImplicitIntent extends AppCompatActivity {

    Button btnCall , btnCallFriend, btnMap, btnWeb;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_implicit_intent);

        btnCall = (Button) findViewById(R.id.btnCall);
        btnCallFriend = (Button) findViewById(R.id.btnCallFriend);
        btnMap = (Button) findViewById(R.id.btnMap);
        btnWeb = (Button) findViewById(R.id.btnWeb);


        btnCall.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Intent.ACTION_DIAL);
                startActivity(intent);

            }
        });

        btnCallFriend.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(Intent.ACTION_DIAL , Uri.parse("tel:03122645175"));
                startActivity(intent);

            }
        });

        btnMap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Intent.ACTION_VIEW , Uri.parse("geo:0,0?q=Karachi"));
                startActivity(intent);

            }
        });

        btnWeb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(Intent.ACTION_VIEW , Uri.parse("https://www.google.com.pk/"));
                startActivity(intent);

            }
        });
    }
}
