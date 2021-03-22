package com.example.pocket_table.pocket_table.service;

import org.springframework.stereotype.Component;

@Component
public class PersonService {
    public boolean checkValidString(String number){
        return number.split("0123456789").length==1;
    }
}
