package com.example.pocket_table.pocket_table.entity;

import javax.persistence.*;
import java.awt.print.Book;
import java.util.Date;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "grup")
public class Grup {
    private long id;
    private String nume;
    private String descriere;
    private int nrPers;

    public Grup(String nume, String descriere, int nrPers ) {
        this.nume = nume;
        this.descriere = descriere;
        this.nrPers = nrPers;
    }
    public Grup() {}

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long getId() {
        return id;
    }


    public void setId(long id) {
        this.id = id;
    }

    private Proiect proiect;

    @ManyToOne(fetch = FetchType.LAZY,optional = true)
    @JoinColumn(name = "pid", nullable = true,  updatable = true, insertable = true)
    public Proiect getProiect() {
        return proiect;
    }
    public void setProiect(Proiect proiect) {
        this.proiect = proiect;
    }


private Set<Utilizator> utilizatori;
    @ManyToMany(cascade = CascadeType.ALL)
    @JoinTable(name = "enrollment", joinColumns = @JoinColumn(name = "grupId", referencedColumnName = "id" ),
            inverseJoinColumns = @JoinColumn(name ="utizilatorId", referencedColumnName = "id"))
    public Set<Utilizator> getUtilizatori() {
        return utilizatori;
    }

    public void setUtilizatori(Set<Utilizator> utilizatori) {
        this.utilizatori = utilizatori;
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
    @Column(name = "nrPers", nullable = false)
    public int getNrPers() {
        return nrPers;
    }

    public void setNrPers(int nrPers) {
        this.nrPers = nrPers;
    }

}
