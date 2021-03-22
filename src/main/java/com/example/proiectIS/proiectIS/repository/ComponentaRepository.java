package com.example.pocket_table.pocket_table.repository;
import com.example.pocket_table.pocket_table.entity.Componenta;
import com.example.pocket_table.pocket_table.entity.Utilizator;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ComponentaRepository extends JpaRepository<Componenta, Long> {
    List<Componenta> findByNume(String name);

}
