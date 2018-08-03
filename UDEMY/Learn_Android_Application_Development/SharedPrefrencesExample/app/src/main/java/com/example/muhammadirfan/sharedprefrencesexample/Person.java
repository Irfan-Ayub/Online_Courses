package com.example.muhammadirfan.sharedprefrencesexample;

/**
 * Created by muhammad.irfan on 8/3/2018.
 */

public class Person {

    private String name;
    private String  surname;

    public Person(String name, String surname) {
        this.name = name;
        this.surname = surname;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public String getName() {
        return name;
    }

    public String getSurname() {
        return surname;
    }
}
