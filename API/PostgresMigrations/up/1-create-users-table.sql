create schema if not exists "user-hub" AUTHORIZATION admin;

create table "user-hub"."users"
(
   id            uuid               primary key,
   login         varchar(20) unique not null,
   password text                    not null
);