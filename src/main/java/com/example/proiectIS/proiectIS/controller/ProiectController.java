package com.example.pocket_table.pocket_table.controller;

//import com.example.pocket_table.pocket_table.entity.User;
import com.example.pocket_table.pocket_table.entity.Grup;
import com.example.pocket_table.pocket_table.entity.Proiect;
import com.example.pocket_table.pocket_table.entity.Utilizator;
import com.example.pocket_table.pocket_table.repository.ProiectRepository;
import com.example.pocket_table.pocket_table.repository.UtilizatorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController
public class ProiectController {

    @Autowired
    private ProiectRepository proiectRepository;
    @Autowired
    private  UtilizatorRepository utilizatorRepository;

    @GetMapping("/proiect")
    public List<Proiect> getAllProiect() {
        return proiectRepository.findAll();
    }

    @PostMapping("/addproiect")
    public Proiect addProiect(@Valid @RequestBody Proiect proiect){
        return proiectRepository.save(proiect);
    }

    @DeleteMapping("/delproiect/{id}")
    public void delteProiect( @PathVariable long id){
        Proiect proiect = this.proiectRepository.findById(id).get();
        proiectRepository.delete(proiect);
    }

    @GetMapping("/getProiect/{id}")
    public Proiect getProiect( @PathVariable long id){
        return this.proiectRepository.findById(id).get();
    }

    @PostMapping("/editProiect/{id}/name")
    public Proiect editGrup(@PathVariable long id, String name){

        Proiect pro =  this.proiectRepository.findById(id).get();
        pro.setNume(name);
        return proiectRepository.save(pro);
    }
    @GetMapping("/getProiectBy/{name}")
    public Proiect getByName(@PathVariable String name){
        List<Proiect> proiects = this.proiectRepository.findByNume(name);
        if(proiects.size() != 0){
            return proiects.get(0);
        } else {
            return null;
        }
    }
    @PutMapping("/likProiect/{idp}/{idu}")
    public Proiect linkProiect(@PathVariable long idp, @PathVariable long idu){

        Proiect pro =  this.proiectRepository.findById(idp).get();
        Utilizator utilizator = this.utilizatorRepository.findById(idu).get();
        utilizator.setProiect(pro);
        pro.getUtilizatori().add(utilizator);
        return proiectRepository.save(pro);
    }

}
