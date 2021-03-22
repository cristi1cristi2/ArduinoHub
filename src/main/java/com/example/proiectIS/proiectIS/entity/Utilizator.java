package com.example.pocket_table.pocket_table.entity;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.*;
import java.util.Date;
import java.util.Set;

@Entity
@Table(name = "utilizator")
public class Utilizator {
    private long id;
    private String username;
    private String pass;
    private String email;
    private int joinDate;
    private String nume;
    private int varsta;
    private int admin;
    private  int inv;


    public Utilizator(String username, String pass, String email, int joinDate, String nume, int varsta, int admin, int inv) {
        this.username = username;
        this.pass = pass;
        this.email = email;
        this.joinDate = joinDate;
        this.nume  = nume;
        this.varsta = varsta;
        this.admin = admin;
        this.inv = inv;
    }
    public Utilizator() {
        this.username = "username";
        this.pass = "pass";
        this.email = "email";
        this.joinDate = 12;
    }


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long getId() {
        return id;
    }


    public void setId(long id) {
        this.id = id;
    }

    private Proiect proiect;

    @JsonIgnoreProperties( {"hibernateLazyInitializer", "utilizatori"})
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "proiect_id")
    public Proiect getProiect() {
        return proiect;
    }

    public void setProiect(Proiect proiect) {
        this.proiect = proiect;
    }

private Set<Grup> grupe;
    @JsonIgnoreProperties(value = { "utilizatori" })
    @ManyToMany(mappedBy = "utilizatori")
    public Set<Grup> getGrupe() {
        return grupe;
    }
    public void setGrupe(Set<Grup> grupe) {
        this.grupe = grupe;
    }

    @Column(name = "username", nullable = false)
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
    @Column(name = "pass", nullable = false)
    public String getPass() {
        return pass;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }
    @Column(name = "email", nullable = false)
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
    @Column(name = "joinDate", nullable = true)
    public int getJoinDate() {
        return joinDate;
    }

    public void setJoinDate(int joinDate) {
        this.joinDate = joinDate;
    }

    @Column(name = "nume", nullable = true)
    public String getnume() {
        return nume;
    }

    public void setNume(String nume) {
        this.nume = nume;
    }

    @Column(name = "varsta", nullable = true)
    public int getVarsta() {
        return varsta;
    }

    public void setVarsta(int varsta) {
        this.varsta = varsta;
    }
    @Column(name = "admin", nullable = true)
    public int getAdmin() {
        return admin;
    }

    public void setAdmin(int admin) {
        this.admin = admin;
    }
    @Column(name = "inv", nullable = true)
    public int getInv() {
        return inv;
    }

    public void setInv(int inv) {
        this.inv = inv;
    }
}
