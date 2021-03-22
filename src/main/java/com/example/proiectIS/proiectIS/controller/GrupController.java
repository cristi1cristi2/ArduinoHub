package com.example.pocket_table.pocket_table.controller;

import com.example.pocket_table.pocket_table.Exception.NotFoundException;
import com.example.pocket_table.pocket_table.entity.Grup;
import com.example.pocket_table.pocket_table.entity.Utilizator;
import com.example.pocket_table.pocket_table.repository.GrupRepository;
import com.example.pocket_table.pocket_table.repository.UtilizatorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;
import java.util.Optional;

@RestController
public class GrupController {

    @Autowired
    private GrupRepository grupRepository;

    @GetMapping("/grup")
    public List<Grup> getAllGrup() {
        return grupRepository.findAll();
    }

    @PostMapping("/addgrup")
    public Grup addGrup(@Valid @RequestBody Grup grup){
        return grupRepository.save(grup);
    }

    @DeleteMapping("/delgrup/{id}")
    public void deleteGrup( @PathVariable long id){
            Grup grup = this.grupRepository.findById(id).get();
         grupRepository.delete(grup);
    }

    @GetMapping("/getGrup/{id}")
    public Grup getGrup( @PathVariable long id){
        return this.grupRepository.findById(id).get();
    }

    @PostMapping("/editGrup/{id}/name")
    public Grup editGrup(@PathVariable long id, String name){

       Grup grupE =  this.grupRepository.findById(id).get();
       grupE.setNume(name);
        return grupRepository.save(grupE);
    }

    @GetMapping("/getGrupBy/{name}")
    public Grup getByName( @PathVariable String name){
        List<Grup> grups = this.grupRepository.findByNume(name);
        if(grups.size() != 0){
            return grups.get(0);
        } else {
            return null;
        }
    }
}
