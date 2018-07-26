package com.android.muhammadirfanayub.firstapplication;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

public class MainActivity extends AppCompatActivity {

    EditText etID;
    TextView tvMessage;
    TextView tvMessage2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        etID = (EditText) findViewById(R.id.etID);
        tvMessage = (TextView) findViewById(R.id.tvMessage);
        tvMessage2 = (TextView) findViewById(R.id.tvMessage2);

        if(getIntent().getData() != null){
            tvMessage2.setText(getIntent().getData().toString());
        }
        else
        {
            tvMessage2.setText("Nothing Recireved!");
        }
    }

    /**
     * Called on the Click of the Submit Button
     * @param vbtn the View Object for the Button
     */
    public void btnSubmit_OnClick(View vbtn)
    {
        String data = etID.getText().toString();

        if(data.isEmpty())
            return;

        // Extracting the DOB from the ID
        String DOB = data.substring(0,6);

        // Extracting the Gender from the ID
        int gender  = Integer.parseInt(data.charAt(6)+"");
        String sGender = "";
        if(gender >=5 )
            sGender = "Male";
        else
            sGender = "Female";

        // Extracting the Nationality from the ID
        int nationality = Integer.parseInt(data.charAt(10)+"");
        String sNationality = "";
        if(nationality == 0)
            sNationality = "South African";
        else
            sNationality = "Permanent Resident";

        tvMessage.setText("Your Information form your ID Number : \n"+
                            "Date Of Birth: " + DOB + "\n"+
                            "Gender: " + sGender + "\n" +
                            "Nationality: " +sNationality);



    }


}
