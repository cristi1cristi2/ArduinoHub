package com.example.pocket_table.pocket_table.controller;

import com.example.pocket_table.pocket_table.entity.Componenta;
import com.example.pocket_table.pocket_table.entity.Grup;
import com.example.pocket_table.pocket_table.entity.Proiect;
import com.example.pocket_table.pocket_table.entity.Utilizator;
import com.example.pocket_table.pocket_table.repository.GrupRepository;
import com.example.pocket_table.pocket_table.repository.UtilizatorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import javax.validation.Valid;
import java.util.List;

@RestController
public class UtilizatorController {

    @Autowired
    private UtilizatorRepository utilizatorRepository;

    @Autowired
    private GrupRepository grupRepository;

    @GetMapping("/utilizator")
    public List<Utilizator> getAllAddress() {
        return utilizatorRepository.findAll();
    }

    @PostMapping("/addutilizator")
    public Utilizator addAddress(@Valid @RequestBody Utilizator address){
       return utilizatorRepository.save(address);
    }

    @DeleteMapping("/delUtilizator/{id}")
    public void deleteComponent( @PathVariable long id){
        Utilizator utilizator = this.utilizatorRepository.findById(id).get();
        utilizatorRepository.delete(utilizator);
    }
    @GetMapping("/getUtilizator/{id}")
    public Utilizator getComp( @PathVariable long id){
        return this.utilizatorRepository.findById(id).get();
    }

    @PutMapping("/editUtilizator/{id}/")
    public Utilizator editComp( @RequestBody Utilizator nou, @PathVariable long id){

        Utilizator utilizator =  this.utilizatorRepository.findById(id).get();
        utilizator.setUsername(nou.getUsername());
        utilizator.setNume(nou.getnume());
        utilizator.setPass(nou.getPass());
        utilizator.setVarsta(nou.getVarsta());

        return utilizatorRepository.save(utilizator);
    }

    @GetMapping("/getByName/{name}")
    public Utilizator getByName( @PathVariable String name){
        List<Utilizator> utilizatori = this.utilizatorRepository.findByUsername(name);
        if(utilizatori.size() != 0){
            return utilizatori.get(0);
        } else {
            return null;
        }
    }
    @PutMapping("/linkUtilizator/{idu}/{idg}")
    public Utilizator linkUtilizator( @PathVariable long idu,  @PathVariable long idg){

        Utilizator utilizator =  this.utilizatorRepository.findById(idu).get();
        Grup grup = this.grupRepository.findById(idg).get();
        grup.getUtilizatori().add(utilizator);
        utilizator.getGrupe().add(grup);

        return utilizatorRepository.save(utilizator);
    }
    @PutMapping("/doneProiect/{idu}")
    public Utilizator doneProiect(@PathVariable long idu){

        Proiect pro =  null;
        Utilizator utilizator = this.utilizatorRepository.findById(idu).get();
        utilizator.setProiect(pro);
//        pro.getUtilizatori().add(utilizator);
        return utilizatorRepository.save(utilizator);
    }

    @PutMapping("/inv/{idg}/{name}")
    public List<Utilizator> doneProiect(@PathVariable int idg,@PathVariable String name){

        List<Utilizator> utilizatori = this.utilizatorRepository.findByUsername(name);

        for (Utilizator u: utilizatori
             ) {
            u.setInv(idg);
            this.utilizatorRepository.save(u);
        }
        return utilizatori;
    }
    @PutMapping("/doneGrup/{idu}/{idg}")
    public Utilizator doneGrup(@PathVariable long idu, @PathVariable long idg) {


        Utilizator utilizator = this.utilizatorRepository.findById(idu).get();
        Grup grup = this.grupRepository.findById(idg).get();
        utilizator.getGrupe().remove(grup);
        grup.getUtilizatori().remove(utilizator);
//        pro.getUtilizatori().add(utilizator);
        grupRepository.save(grup);
        return utilizatorRepository.save(utilizator);
    }
}
