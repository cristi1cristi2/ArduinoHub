package com.example.pocket_table.pocket_table.entity;

import javax.persistence.*;
import java.awt.print.Book;
import java.util.Date;
import java.util.Set;

@Entity
@Table(name = "componenta")
public class Componenta {
    private long id;
    private String nume;
    private String descriere;
    private int pret;
    private int cantitate;
    private String tip;

    public Componenta(String nume, String descriere, int pret, int cantitate, String tip) {
        this.nume= nume;
        this.descriere = descriere;
        this.pret = pret;
        this.cantitate = cantitate;
        this.tip = tip;
    }
    public Componenta() {}

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long getId() {
        return id;
    }


    public void setId(long id) {
        this.id = id;
    }

    private Set<Proiect> proiecte;

    @ManyToMany(mappedBy = "componente")
    public Set<Proiect> getProiecte() {
        return proiecte;
    }
    public void setProiecte(Set<Proiect> proiecte) {
        this.proiecte = proiecte;
    }

    @Column(name = "nume", nullable = false)
    public String getNume() {
        return nume;
    }

    public void setNume(String nume) {
        this.nume = nume;
    }
    @Column(name = "descriere", nullable = false)
    public String getDescriere() {
        return descriere;
    }

    public void setDescriere(String descriere) {
        this.descriere = descriere;
    }
    @Column(name = "pret", nullable = false)
    public int getPret() {
        return pret;
    }

    public void setPret(int pret) {
        this.pret = pret;
    }
    @Column(name = "cantitate", nullable = true)
    public int getCantitate() {
        return cantitate;
    }

    public void setCantitate(int cantitate) {
        this.cantitate = cantitate;
    }
    @Column(name = "tip", nullable = true)
    public String getTip() {
        return tip;
    }

    public void setTip(String tip) {
        this.tip = tip;
    }
}
