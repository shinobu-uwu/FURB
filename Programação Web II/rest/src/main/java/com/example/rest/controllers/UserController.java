package com.example.rest.controllers;

import com.example.rest.models.User;
import com.example.rest.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.persistence.Persistence;
import java.util.Date;

@RestController
@RequestMapping("/")
public class UserController {
    @Autowired
    private UserRepository userRepository = new UserRepository();
    public static User[] users = {
            new User("Matheus", new Date()),
            new User("Sophia", new Date()),
            new User("Ronaldo", new Date()),
            new User("Piriquito", new Date()),
            new User("ABCDE", new Date()),
    };

    @GetMapping("/user/{id}")
    public User getUser(@PathVariable int id) {
        return UserController.users[id];
    }

    @PostMapping
    public User createUser(@RequestBody User user) {
        User userNew = new User("ABC", new Date());

        return user;
    }
}
