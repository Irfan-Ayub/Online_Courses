package com.android.muhammadirfanayub.explicitintents;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class Activity3 extends AppCompatActivity {

    EditText etSurname;
    Button btnSubmit;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_3);

        etSurname = (EditText) findViewById(R.id.etSurname);
        btnSubmit = (Button) findViewById(R.id.btnSubmit);

        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String surname = etSurname.getText().toString().trim();

                Intent intent = new Intent();
                intent.putExtra("surname" , surname);
                setResult(RESULT_OK , intent);

                Activity3.this.finish();

            }
        });
    }
}
