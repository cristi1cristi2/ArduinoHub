package com.example.pocket_table.pocket_table.controller;

import com.example.pocket_table.pocket_table.Exception.NotFoundException;
import com.example.pocket_table.pocket_table.entity.Componenta;
import com.example.pocket_table.pocket_table.entity.Grup;
import com.example.pocket_table.pocket_table.entity.Utilizator;
import com.example.pocket_table.pocket_table.repository.ComponentaRepository;
import com.example.pocket_table.pocket_table.repository.UtilizatorRepository;
import com.example.pocket_table.pocket_table.service.PersonService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;
import java.util.Optional;

@RestController
public class ComponentaController {

    @Autowired
    private ComponentaRepository componentaRepository;

    @GetMapping("/")
    public String test() {
        return "Hello Heroku";
    }

    @GetMapping("/comp")
    public List<Componenta> getAllComp() {
        return componentaRepository.findAll();
    }

    @PostMapping("/addcomp")
    public Componenta addComp(@Valid @RequestBody Componenta address){
        return componentaRepository.save(address);
    }

    @DeleteMapping("/delComp/{id}")
    public void deleteComponent( @PathVariable long id){
        Componenta componenta = this.componentaRepository.findById(id).get();
        componentaRepository.delete(componenta);
    }

    @GetMapping("/getComp/{id}")
    public Componenta getComp( @PathVariable long id){
        return this.componentaRepository.findById(id).get();
    }

    @PostMapping("/editComp/{id}/name")
    public Componenta editComp(@PathVariable long id, String name){

        Componenta grupE =  this.componentaRepository.findById(id).get();
        grupE.setNume(name);
        return componentaRepository.save(grupE);
    }
    @GetMapping("/getCompBy/{name}")
    public Componenta getByName( @PathVariable String name){
        List<Componenta> componentas = this.componentaRepository.findByNume(name);
        if(componentas.size() != 0){
            return componentas.get(0);
        } else {
            return null;
        }
    }
}
