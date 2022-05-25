create table roles(
id_rol int not null ,
nombre_rol varchar (20) not null,
primary key(id_rol)
);

 

create table usuarios(
pk_id_usuario int not null,
nombre_usuario varchar (20) not null,
identificacion_usuario char (10) not null,
contraseña_usuario char (8) not null,
fk_id_rol int not null,
primary key(pk_id_usuario)
);

alter table usuarios
add constraint fk_id_rol
foreign key (fk_id_rol)
references roles (id_rol);

create table salas(
pk_id_sala int not null,
nombre_sala varchar (20)not null,
primary key(pk_id_sala)
);

create table elementos(
pk_id_elemento int not null,
nombre_elemento varchar (30)not null,
primary key(pk_id_elemento)
);

create table salas_elementos(
pk_id_salas_elementos int not null,
fk_id_sala int not null,
fk_id_elemento int not null,
primary key(pk_id_salas_elementos)
);

alter table salas_elementos
add constraint fk_id_elemento
foreign key (fk_id_elemento)
references elementos (pk_id_elemento);


create table reservas(
pk_id_reserva int not null,
nombre_evento_reserva varchar(100) not null,
fecha_hora_inicio_reserva timestamp not null,
fecha_hora_fin_reserva timestamp not null,
fk_id_sala int not null,
fk_id_usuario int not null,
primary key(pk_id_reserva)
);

alter table reservas
add constraint fk_id_usuario
foreign key (fk_id_usuario)
references usuarios (pk_id_usuario);

create sequence incremento
start with 1
increment by 1;

create or replace trigger trg_usuarios
before insert on usuarios
for each row
begin 
        select incremento.nextval into :new.pk_id_usuario from dual;
        end;
        
    


