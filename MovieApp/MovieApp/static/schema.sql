create table if not exists movies (
id int auto_increment,
title varchar (150) not null,
star varchar (150) not null,
genre varchar (150) not null,
date_released datetime not null,
primary key(id)
);