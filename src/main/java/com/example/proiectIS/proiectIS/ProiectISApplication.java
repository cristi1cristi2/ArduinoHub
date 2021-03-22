package com.example.pocket_table.pocket_table;

import com.example.pocket_table.pocket_table.entity.Grup;
import com.example.pocket_table.pocket_table.entity.Utilizator;
import com.example.pocket_table.pocket_table.repository.UtilizatorRepository;
import com.example.pocket_table.pocket_table.repository.GrupRepository;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import java.util.Date;

@SpringBootApplication
public class PocketTableApplication {

	public static void main(String[] args) {
		SpringApplication.run(PocketTableApplication.class, args);
	}

	@Bean
	public CommandLineRunner demoData(UtilizatorRepository utilizatorRepository, GrupRepository grupRepository) {
		return args -> {
			//utilizatorRepository.save(new Utilizator("Cridty", "123", "cristi.serbu17@gmail.com" ,12, "Cristi Serbu", 21, 1, 0));
			//grupRepository.save(new Grup("grupa5", "cea mai tare grupa", 0));
			//personRepository.save(new Person("Adi"));
			//personRepository.save(new Person("Macheciau"));
		};
	}


}
