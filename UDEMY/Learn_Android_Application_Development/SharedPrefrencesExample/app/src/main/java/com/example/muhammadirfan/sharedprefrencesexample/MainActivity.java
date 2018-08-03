package com.example.muhammadirfan.sharedprefrencesexample;

import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class MainActivity extends AppCompatActivity {

    Button btnSubmit;
    TextView tvWelcome;
    EditText etName;

    //Saving Data in File
    EditText etName2, etSurname;
    TextView tvResults;

    ArrayList<Person> persons;
    public static final String MY_PREFS_FILENAME = "com.example.muhammadirfan.sharedprefrencesexample.Names";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        tvWelcome = (TextView) findViewById(R.id.tvWelcome);
        etName = (EditText) findViewById(R.id.etName1);

        btnSubmit = (Button) findViewById(R.id.btnSubmit);

        SharedPreferences prefs = getSharedPreferences(MY_PREFS_FILENAME , MODE_PRIVATE);
        String user = prefs.getString("user" , "");

        tvWelcome.setText("Welcome to my app " + user + "!");


        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String name = etName.getText().toString().trim();

                tvWelcome.setText("Welcome to my app " + name + "!");

                SharedPreferences.Editor editor = getSharedPreferences(MY_PREFS_FILENAME , MODE_PRIVATE).edit();
                editor.putString("user" , name);
                editor.commit();
            }
        });

        // Saving Data in a File

        etName2 = (EditText) findViewById(R.id.etName2);
        etSurname = (EditText) findViewById(R.id.etSurname);
        tvResults = (TextView) findViewById(R.id.tvResult);

        persons = new ArrayList<Person>();

        loadDate();
    }

    public void btnAddDate(View v)
    {
        String name = etName2.getText().toString();
        String surname = etSurname.getText().toString();

        Person person = new Person(name, surname);
        persons.add(person);

        setTextToTextView();
    }

    private void setTextToTextView() {

        String text = "";

        for(int i=0; i<persons.size(); i++)
        {
            text = text + persons.get(i).getName() + " " + persons.get(i).getSurname() + "\n";
        }

        tvResults.setText(text);
    }

    public void loadDate()
    {
        persons.clear();
        File file = getApplicationContext().getFileStreamPath("Data.txt");
        String lineFromFile;
        if(file.exists())
        {
            try
            {
                BufferedReader reader = new BufferedReader(new InputStreamReader(openFileInput("Data.txt")));

                while ((lineFromFile = reader.readLine()) != null)
                {
                    StringTokenizer tokens = new StringTokenizer(lineFromFile , ",");
                    Person person = new Person(tokens.nextToken() , tokens.nextToken());
                    persons.add(person);
                }

                reader.close();
                setTextToTextView();

            }

            catch (IOException e)
            {
                Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
            }
        }

    }

    public void btnSaveData(View v)
    {
        try
        {
            FileOutputStream file = openFileOutput("Data.txt",MODE_PRIVATE);
            OutputStreamWriter outputFile = new OutputStreamWriter(file);

            for(int i=0; i<persons.size(); i++)
            {
                outputFile.write(persons.get(i).getName() + "," + persons.get(i).getSurname() + "\n");
            }

            outputFile.flush();
            outputFile.close();

            Toast.makeText(this, "Successfully saved!", Toast.LENGTH_SHORT).show();
        }
        catch(IOException e)
        {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }
}
