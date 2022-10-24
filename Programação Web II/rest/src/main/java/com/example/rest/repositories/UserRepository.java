package com.example.rest.repositories;

import com.example.rest.models.User;
import org.springframework.stereotype.Repository;


@Repository
public class UserRepository extends JpaRepository<User,Long> { }
}
