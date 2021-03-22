package com.example.pocket_table.pocket_table.entity;

import javax.persistence.*;
import java.awt.print.Book;
import java.util.Date;
import java.util.Set;

@Entity
@Table(name = "proiect")
public class Proiect {
    private long id;
    private String nume;
    private String descriere;
    private int pret;

    public Proiect(String username, String descriere, int pret) {
        this.nume = username;
        this.descriere = descriere;
        this.pret = pret;
    }
    public Proiect() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long getId() {
        return id;
    }


    public void setId(long id) {
        this.id = id;
    }

    private Set<Utilizator> utilizatori;

    @OneToMany(mappedBy = "proiect", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    public Set<Utilizator> getUtilizatori() {
        return utilizatori;
    }
    public void setUtilizatori(Set<Utilizator> utilizatori) {
        this.utilizatori = utilizatori;
    }

    private Set<Grup> grupuri;

    @OneToMany(mappedBy = "proiect", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    public Set<Grup> getGrupuri() {
        return grupuri;
    }
    public void setGrupuri(Set<Grup> grupuri) {
        this.grupuri = grupuri;
    }


    private Set<Componenta> componente;
    @ManyToMany(cascade = CascadeType.ALL)
    @JoinTable(name = "compProiect", joinColumns = @JoinColumn(name = "proiectId", referencedColumnName = "id" ),
            inverseJoinColumns = @JoinColumn(name ="componentaId", referencedColumnName = "id"))
    public Set<Componenta> getComponente() {
        return componente;
    }

    public void setComponente(Set<Componenta> componente) {
        this.componente = componente;
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

    @Column(name = "pret", nullable = true)
    public int getPret() {
        return pret;
    }

    public void setPret(int pret) {
        this.pret = pret;
    }
}
